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
    private readonly IFilesReadRepository _readRepository;
    private readonly IFilesWriteRepository _writeRepository;

    public UpdateFileCommandHandler(IFilesReadRepository readRepository, IFilesWriteRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _readRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        _writeRepository.Update(entity);

        await _writeRepository.SaveChangesAsync(cancellationToken);
    }
}