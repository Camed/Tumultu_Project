using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Queries;

public record GetFileVariantsQuery : IRequest<IEnumerable<FileVariant>>;

public class GetFileVariantsQueryHandler : IRequestHandler<GetFileVariantsQuery, IEnumerable<FileVariant>>
{
    private readonly IFileVariantReadOnlyRepository _repository;

    public GetFileVariantsQueryHandler(IFileVariantReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FileVariant>> Handle(GetFileVariantsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
