using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tumultu.Application.Interfaces.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files.Queries;

public record GetFileByIdQuery : IRequest<FileEntity>
{
    public Guid Id { get; init; }
}

public class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQuery, FileEntity>
{
    private readonly IApplicationDbContext _context;
    public GetFileByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FileEntity> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Files
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.Null(entity);

        return entity;
    }
}
