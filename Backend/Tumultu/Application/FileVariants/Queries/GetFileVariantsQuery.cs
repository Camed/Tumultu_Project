using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Queries;

public record GetFileVariantsQuery : IRequest<IEnumerable<FileVariant>>;

public class GetFileVariantsQueryHandler : IRequestHandler<GetFileVariantsQuery, IEnumerable<FileVariant>>
{
    private readonly IReadRepository<FileVariant, Guid> _repository;

    public GetFileVariantsQueryHandler(IReadRepository<FileVariant, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FileVariant>> Handle(GetFileVariantsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
