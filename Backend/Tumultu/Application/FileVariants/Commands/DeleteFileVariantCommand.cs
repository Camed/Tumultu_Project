using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.Commands;

public record DeleteFileVariantCommand(Guid Id) : IRequest;


public class DeleteFileVariantCommandHandler : IRequestHandler<DeleteFileVariantCommand>
{
    private readonly IReadRepository<FileVariant, Guid> _readRepository;
    private readonly IWriteRepository<FileVariant, Guid> _writeRepository;

    public DeleteFileVariantCommandHandler(IReadRepository<FileVariant, Guid> readRepository, IWriteRepository<FileVariant, Guid> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(DeleteFileVariantCommand request, CancellationToken cancellationToken)
    {
        FileVariant? entity = await _readRepository.GetByIdAsync(request.Id);
        
        Guard.Against.NotFound(request.Id, entity);
        _writeRepository.Delete(entity);

        await _writeRepository.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new FileVariantDeletedEvent(entity));

    }
}