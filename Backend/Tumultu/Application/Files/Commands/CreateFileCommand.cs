using Tumultu.Domain.Extensions;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;

public record CreateFileCommand(string FileName, byte[] Payload) : IRequest<Guid>;

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

        // this file already exists
        if (filesWithSameSignature.Any())
        {
            // handle file variant creation
            return Guid.Empty;
        }

        var entity = new FileEntity
        {
            MD5Signature = md5,
            SHA1Signature = sha1,
            SHA256Signature = sha256,
            Size = request.Payload.Length,
        };

        _repository.Insert(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        entity.AddDomainEvent(new FileCreatedEvent(entity));

        return entity.Id;
    }
}