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
    private readonly IFilesRepository _filesRepository;

    public UpdateFileCommandHandler(IFilesRepository filesRepository)
    {
        _filesRepository = filesRepository;
    }

    public async Task Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _filesRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        _filesRepository.Update(entity);

        await _filesRepository.SaveChangesAsync(cancellationToken);
    }
}