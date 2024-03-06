using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand(FileEntity? File, DateTimeOffset? CreatedDate, DateTimeOffset? DateModified, string? Name, User? UploadedBy) : IRequest<Guid>;
public class CreateFileVariantCommandHandler : IRequestHandler<CreateFileVariantCommand, Guid>
{
    private readonly IFileVariantRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateFileVariantCommandHandler(IFileVariantRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFileVariantCommand request, CancellationToken cancellationToken)
    {
        var entity = new FileVariant
        {
            Name = request.Name,
            CreationTime = request.CreatedDate ?? default,
            ModifiedTime = request.DateModified ?? default,
            UploadedBy = request.UploadedBy,
            File = request.File
        };

        var existingVariantsByUser = (await _repository.GetAllFileVariantsByFile(request.File!))
            .Where(x => x.UploadedBy == request.UploadedBy);
        if (existingVariantsByUser.Any())
        {
            return existingVariantsByUser.FirstOrDefault()!.Id;
        }

        _repository.Insert(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new FileVariantCreatedEvent(entity));

        return entity.Id;
    }
}