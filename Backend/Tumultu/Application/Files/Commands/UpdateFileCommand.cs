using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files.Commands;

public record class UpdateFileCommand : IRequest
{
    public Guid Id { get; init; }
}

public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand>
{
    private readonly IRepository<FileEntity, Guid> _repository;

    public UpdateFileCommandHandler(IRepository<FileEntity, Guid> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository
            .FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);
    }
}