using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.Commands;

public record DeleteFileVariantCommand(Guid Id) : IRequest;


public class DeleteFileVariantCommandHandler : IRequestHandler<DeleteFileVariantCommand>
{
    private readonly IFileVariantRepository _repository;
    public DeleteFileVariantCommandHandler(IFileVariantRepository fileVariantRepository)
    {
        _repository = fileVariantRepository;
    }

    public async Task Handle(DeleteFileVariantCommand request, CancellationToken cancellationToken)
    {
        FileVariant? entity = await _repository.GetByIdAsync(request.Id);
        
        Guard.Against.NotFound(request.Id, entity);
        _repository.Delete(entity);

        await _repository.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new FileVariantDeletedEvent(entity));

    }
}