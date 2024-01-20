﻿using Tumultu.Domain.Extensions;
using MediatR;
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
    private readonly IFileRepository _repository;
    public CreateFileCommandHandler(IFileRepository fileRepository)
    {
        _repository = fileRepository;
    }

    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        string md5 = request.Payload.GetMD5();
        string sha1 = request.Payload.GetSHA1();
        string sha256 = request.Payload.GetSHA256();

        IEnumerable<FileEntity> filesWithSameSignature = 
            await _repository.GetAllByAnySignature(md5, sha1, sha256);

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