using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Commands;

public record UpdateFileVariantCommand : IRequest
{
    public Guid Id { get; init; }
}

public class UpdateFileVariantCommandHandler : IRequestHandler<UpdateFileVariantCommand>
{
    private readonly IFileVariantRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateFileVariantCommandHandler(IFileVariantRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFileVariantCommand request, CancellationToken cancellationToken)
    {
        FileVariant? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything

        _repository.Update(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
