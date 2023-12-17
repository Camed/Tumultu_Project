using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;

public record DeleteFileCommand(Guid Id) : IRequest;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
{
    private readonly IRepository<FileEntity, Guid> _repository;

    public DeleteFileCommandHandler(IRepository<FileEntity, Guid> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteFileCommand request, CancellationToken token)
    {
        var entity = await _repository.FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        await _repository.DeleteAsync(request.Id);
        entity.AddDomainEvent(new FileDeletedEvent(entity));
    }
}