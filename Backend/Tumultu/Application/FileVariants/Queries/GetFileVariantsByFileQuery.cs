using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Queries;

public record GetFileVariantsByFileQuery : IRequest<IEnumerable<FileVariant>>
{
    public FileEntity? File { get; init; }
}

public record GetFileVariantsByFileQueryHandler : IRequestHandler<GetFileVariantsByFileQuery, IEnumerable<FileVariant>>
{
    private readonly IFileVariantReadOnlyRepository _repository;
    public GetFileVariantsByFileQueryHandler(IFileVariantReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FileVariant>> Handle(GetFileVariantsByFileQuery request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request.File);
        IEnumerable<FileVariant> entities = (await _repository.GetAllFileVariantsByFile(request.File));

        return entities;    
    }
}
