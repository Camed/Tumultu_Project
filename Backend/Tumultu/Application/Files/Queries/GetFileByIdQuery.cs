using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files.Queries;

public record GetFileByIdQuery : IRequest<FileEntity>
{
    public Guid Id { get; init; }
}

public class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQuery, FileEntity>
{
    private readonly IFilesReadRepository _repository;

    public GetFileByIdQueryHandler(IFilesReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<FileEntity> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
    {
        FileEntity? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.Null(entity);

        return entity;
    }
}