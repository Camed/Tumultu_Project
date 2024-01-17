using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.Commands;

public record DeleteFileVariantCommand(Guid Id) : IRequest;


public class DeleteFileVariantCommandHandler : IRequestHandler<DeleteFileVariantCommand>
{
    private readonly IFileVariantsRepository _fileVariantsRepository;
    public DeleteFileVariantCommandHandler(IFileVariantsRepository fileVariantsRepository)
    {
        _fileVariantsRepository = fileVariantsRepository;
    }

    public async Task Handle(DeleteFileVariantCommand request, CancellationToken cancellationToken)
    {
        FileVariant? entity = await _fileVariantsRepository.GetByIdAsync(request.Id);
        
        Guard.Against.NotFound(request.Id, entity);
        _fileVariantsRepository.Delete(entity);

        await _fileVariantsRepository.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new FileVariantDeletedEvent(entity));

    }
}