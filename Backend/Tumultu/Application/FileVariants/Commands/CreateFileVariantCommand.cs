using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Application.Users.Queries;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand : IRequest<Guid>
{
    public FileEntity File { get; init; }
    public DateTimeOffset? CreatedDate { get; init; }
    public DateTimeOffset? DateModified { get; init; }
    public string? Name { get; init; }
    public Guid? UploadedBy { get; init; }

}

public class CreateFileVariantCommandHandler : IRequestHandler<CreateFileVariantCommand, Guid>
{
    private readonly IWriteRepository<FileVariant, Guid> _writeRepository;
    private readonly IReadRepository<FileVariant, Guid> _readRepository;
    private readonly IMediator _mediator;
    public CreateFileVariantCommandHandler(IWriteRepository<FileVariant, Guid> writeRepository,
                                           IReadRepository<FileVariant, Guid> readRepository,
                                           IMediator mediator)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(CreateFileVariantCommand request, CancellationToken cancellationToken)
    {
        var userQuery = new GetUserByIdQuery { Id = request.UploadedBy ?? default };
        var user = await _mediator.Send(userQuery);

        var entity = new FileVariant
        {
            Name = request.Name,
            CreationTime = request.CreatedDate ?? default,
            ModifiedTime = request.DateModified ?? default,
            UploadedBy = user,
            File = request.File
        };

        _writeRepository.Insert(entity);

        await _writeRepository.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new FileVariantCreatedEvent(entity));

        return entity.Id;
    }
}