using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand : IRequest<FileVariant?>
{
    public FileEntity? File { get; init; }
    public DateTimeOffset? CreatedDate { get; init; }
    public DateTimeOffset? DateModified { get; init; }
    public string? Name { get; init; }
    public User? UploadedBy { get; init; }

}

public class CreateFileVariantCommandHandler : IRequestHandler<CreateFileVariantCommand, FileVariant?>
{
    private readonly IFileVariantRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateFileVariantCommandHandler(IFileVariantRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FileVariant?> Handle(CreateFileVariantCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request.File);

        var entity = new FileVariant
        {
            Name = request.Name,
            CreationTime = request.CreatedDate ?? default,
            ModifiedTime = request.DateModified ?? default,
            UploadedBy = request.UploadedBy,
            File = request.File
        };

        var existingVariantsByUser = (await _repository.GetAllFileVariantsByFile(request.File))
            .Where(x => x.UploadedBy == request.UploadedBy);
        if (existingVariantsByUser.Count() > 0)
        {
            return existingVariantsByUser.FirstOrDefault();
        }

        _repository.Insert(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new FileVariantCreatedEvent(entity));

        return entity;
    }
}