using Tumultu.Domain.Extensions;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;
using System.Linq;

namespace Tumultu.Application.Files.Commands;

public record CreateFileCommand(string? FileName, User? User, byte[] Payload) : IRequest<Guid>;
public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Guid>
{
    private readonly IFileRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateFileCommandHandler(IFileRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        string md5 = request.Payload.GetMD5();
        string sha1 = request.Payload.GetSHA1();
        string sha256 = request.Payload.GetSHA256();

        IEnumerable<FileEntity> filesWithSameSignature = 
            await _repository.GetAllByAnySignature(md5, sha1, sha256);


        FileEntity workingEntity;

        // this file already exists
        if (filesWithSameSignature.Count() > 0)
        {
            // handle file variant creation
            FileEntity existingEntity = filesWithSameSignature.FirstOrDefault()!;

            existingEntity.AddVariant(request.User!);

            workingEntity = existingEntity;
        }
        else
        {
            var newEntity = FileEntity.Create(md5,
                                sha1,
                                sha256,
                                request.Payload,
                                request.User!);

            _repository.Insert(newEntity);
            workingEntity = newEntity;
        }


        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //entity.AddDomainEvent(new FileCreatedEvent(entity));
        //analysis.AddDomainEvent(new AnalysisCreatedEvent(analysis));
        //analysis.AddDomainEvent(new AnalysisCompletedEvent(analysis));

        return workingEntity.Id;
    }
}