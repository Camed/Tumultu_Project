using MediatR;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand : IRequest<Guid>
{
    public FileEntity? File { get; init; }
    public DateTimeOffset? CreatedDate { get; init; }
    public DateTimeOffset? DateModified { get; init; }
    public string? Name { get; init; }
    public User? UploadedBy { get; init; }

}

public class CreateFileVariantCommandHandler : IRequestHandler<CreateFileVariantCommand, Guid>
{
    private readonly IFileVariantRepository _repository;
    public CreateFileVariantCommandHandler(IFileVariantRepository fileVariantRepository)
    {
        _repository = fileVariantRepository;
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

        _repository.Insert(entity);

        await _repository.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new FileVariantCreatedEvent(entity));

        return entity.Id;
    }
}