using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;

public record DeleteFileCommand(Guid Id) : IRequest;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
{
    private readonly IFilesRepository _filesRepository;

    public DeleteFileCommandHandler(IFilesRepository filesRepository)
    {
        _filesRepository = filesRepository;
    }

    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _filesRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        _filesRepository.Delete(entity);

        await _filesRepository.SaveChangesAsync(cancellationToken);

        entity.AddDomainEvent(new FileDeletedEvent(entity));
    }
}