using Tumultu.Domain.Extensions;
using MediatR;
using Tumultu.Application.Interfaces.Common;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;
public record CreateFileCommand : IRequest<Guid>
{
    public string? FileName { get; init; }
    public byte[] Payload { get; init; } = Array.Empty<byte>();
};

public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateFileCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        var md5 = request.Payload.GetMD5();
        var sha1 = request.Payload.GetSHA1();
        var sha256 = request.Payload.GetSHA256();

        // this file already exists
        if(_context.Files.Any(x => x.MD5Signature == md5 || x.SHA1Signature == sha1 || x.SHA256Signature == sha256))
        {
            // handle file variant creation
            return Guid.Empty;
        }

        var entity = new FileEntity
        {
            MD5Signature = md5,
            SHA1Signature = sha1,
            SHA256Signature = sha256,
            Size = request.Payload.Length,
        };

        entity.AddDomainEvent(new FileCreatedEvent(entity));

        _context.Files.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}