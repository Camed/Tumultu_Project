using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;

public record DeleteFileCommand(Guid Id) : IRequest;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
{
    private readonly IFilesReadRepository _readRepository;
    private readonly IFilesWriteRepository _writeRepository;

    public DeleteFileCommandHandler(IFilesReadRepository readRepository, IFilesWriteRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _readRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _writeRepository.Delete(entity);

        await _writeRepository.SaveChangesAsync(cancellationToken);

        entity.AddDomainEvent(new FileDeletedEvent(entity));
    }
}