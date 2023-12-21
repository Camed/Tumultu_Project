using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;

public record DeleteFileCommand(Guid Id) : IRequest;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
{
    private readonly IFilesRepository _repository;

    public DeleteFileCommandHandler(IFilesRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _repository.Delete(entity);

        await _repository.SaveChangesAsync(cancellationToken);

        entity.AddDomainEvent(new FileDeletedEvent(entity));
    }
}