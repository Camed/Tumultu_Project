using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;

public record DeleteFileCommand(Guid Id) : IRequest;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
{
    private readonly IFileRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFileCommandHandler(IFileRepository fileRepository, IUnitOfWork unitOfWork)
    {
        _repository = fileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _repository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        _repository.Delete(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        entity.AddDomainEvent(new FileDeletedEvent(entity));
    }
}