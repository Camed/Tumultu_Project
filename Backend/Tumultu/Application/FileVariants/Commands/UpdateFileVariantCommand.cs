using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Commands;

public record UpdateFileVariantCommand : IRequest
{
    public Guid Id { get; init; }
}

public class UpdateFileVariantCommandHandler : IRequestHandler<UpdateFileVariantCommand>
{
    private readonly IFileVariantsRepository _fileVariantsRepository;
    public UpdateFileVariantCommandHandler(IFileVariantsRepository fileVariantsRepository)
    {
        _fileVariantsRepository = fileVariantsRepository;
    }

    public async Task Handle(UpdateFileVariantCommand request, CancellationToken cancellationToken)
    {
        FileVariant? entity = await _fileVariantsRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything

        _fileVariantsRepository.Update(entity);

        await _fileVariantsRepository.SaveChangesAsync(cancellationToken);
    }
}
