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
    private readonly IReadRepository<FileVariant, Guid> _readRepository;
    private readonly IWriteRepository<FileVariant, Guid> _writeRepository;

    public UpdateFileVariantCommandHandler(IReadRepository<FileVariant, Guid> readRepository, IWriteRepository<FileVariant, Guid> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(UpdateFileVariantCommand request, CancellationToken cancellationToken)
    {
        FileVariant? entity = await _readRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything

        _writeRepository.Update(entity);

        await _writeRepository.SaveChangesAsync(cancellationToken);
    }
}
