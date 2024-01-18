using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files.Queries;

public record GetFilesQuery : IRequest<IEnumerable<FileEntity>>;

public class GetFilesQueryHandler : IRequestHandler<GetFilesQuery, IEnumerable<FileEntity>>
{
    private readonly IFileReadOnlyRepository _repository;

    public GetFilesQueryHandler(IFileReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FileEntity>> Handle(GetFilesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}