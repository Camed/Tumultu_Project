using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Queries;

public record GetFileVariantsByFileQuery : IRequest<IEnumerable<FileVariant>>
{
    public FileEntity File { get; init; }
}

public record GetFileVariantsByFileQueryHandler : IRequestHandler<GetFileVariantsByFileQuery, IEnumerable<FileVariant>>
{
    private readonly IReadRepository<FileVariant, Guid> _repository;
    public GetFileVariantsByFileQueryHandler(IReadRepository<FileVariant, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FileVariant>> Handle(GetFileVariantsByFileQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<FileVariant> entities = (await _repository.GetAllAsync())
                                                .Where(x => x.File?.Id == request.File.Id);

        return entities;    
    }
}
