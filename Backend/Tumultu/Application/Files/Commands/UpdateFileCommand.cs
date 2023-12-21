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
    private readonly IFilesRepository _repository;

    public UpdateFileCommandHandler(IFilesRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        _repository.Update(entity);

        await _repository.SaveChangesAsync(cancellationToken);
    }
}