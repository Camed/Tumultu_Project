using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Queries;

public record GetFileVariantByIdQuery : IRequest<FileVariant>
{
    public Guid Id { get; init; }
}

public class GetFileVariantByIdQueryHandler : IRequestHandler<GetFileVariantByIdQuery, FileVariant>
{
    private readonly IFileVariantReadOnlyRepository _repository;
    public GetFileVariantByIdQueryHandler(IFileVariantReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<FileVariant> Handle(GetFileVariantByIdQuery request, CancellationToken cancellationToken)
    {
        FileVariant? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.Null(entity);
        return entity;
    }
}