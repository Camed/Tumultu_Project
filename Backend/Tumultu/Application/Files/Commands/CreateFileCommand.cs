using Tumultu.Domain.Extensions;
using MediatR;
using Tumultu.Application.Common.Interfaces;
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
    private readonly IRepository<FileEntity, Guid> _repository;

    public CreateFileCommandHandler(IRepository<FileEntity, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        string md5 = request.Payload.GetMD5();
        string sha1 = request.Payload.GetSHA1();
        string sha256 = request.Payload.GetSHA256();

        IEnumerable<FileEntity> filesWithSameSignature = await _repository.GetAllAsync(
            file => file.MD5Signature == md5
                    || file.SHA1Signature == sha1
                    || file.SHA256Signature == sha256);

        // this file already exists
        if (filesWithSameSignature.Any())
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

        _repository.Insert(entity);

        await _repository.SaveChangesAsync(cancellationToken);

        entity.AddDomainEvent(new FileCreatedEvent(entity));

        return entity.Id;
    }
}