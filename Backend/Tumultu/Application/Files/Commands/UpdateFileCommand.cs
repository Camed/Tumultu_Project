using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files.Commands;

public record UpdateFileCommand : IRequest
{
    public Guid Id { get; init; }
}

public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand>
{
    private readonly IFileRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFileCommandHandler(IFileRepository fileRepository, IUnitOfWork unitOfWork)
    {
        _repository = fileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        _repository.Update(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}