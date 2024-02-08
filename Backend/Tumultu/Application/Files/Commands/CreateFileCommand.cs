using Tumultu.Domain.Extensions;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;
using Tumultu.Domain.Constants;

namespace Tumultu.Application.Files.Commands;

public record CreateFileCommand : IRequest<FileEntity?>
{
    public string? FileName { get; init; }
    public User? User { get; init; }
    public byte[] Payload { get; init; } = Array.Empty<byte>();
};

public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, FileEntity?>
{
    private readonly IFileRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateFileCommandHandler(IFileRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FileEntity?> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        string md5 = request.Payload.GetMD5();
        string sha1 = request.Payload.GetSHA1();
        string sha256 = request.Payload.GetSHA256();

        IEnumerable<FileEntity> filesWithSameSignature = 
            await _repository.GetAllByAnySignature(md5, sha1, sha256);

        // this file already exists
        if (filesWithSameSignature.Count() > 0)
        {
            // handle file variant creation
            return filesWithSameSignature.FirstOrDefault();
        }

        var entity = new FileEntity
        {
            MD5Signature = md5,
            SHA1Signature = sha1,
            SHA256Signature = sha256,
            Size = request.Payload.Length,
        };

        var variant = createFileVariant(entity, request.User!);
        var analysis = await performFirstAnalysis(request.Payload, request.User!);

        entity.AnalysisResult = analysis;
        entity.Variants = entity.Variants.Concat(new[] { variant });

        _repository.Insert(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        entity.AddDomainEvent(new FileCreatedEvent(entity));

        analysis.AddDomainEvent(new AnalysisCreatedEvent(analysis));
        analysis.AddDomainEvent(new AnalysisCompletedEvent(analysis));

        return entity;
    }

    private async Task<AnalysisResult> performFirstAnalysis(byte[] payload, User requestingUser)
    {
        var analysisResult = new AnalysisResult();

        analysisResult.AnalysisDate = DateTime.UtcNow;
        analysisResult.LatestAnalysisBy = requestingUser;
        analysisResult.DetectedSignatures = Signatures.MatchSignatures(payload);
        analysisResult.EntropyData = await payload.CalculateEntropyAsync(256);
        analysisResult.OriginalAnalysisBy = requestingUser;

        return analysisResult;
    }

    private FileVariant createFileVariant(FileEntity file, User requestingUser)
    {
        // create logic for file variant creation and gathering data from payload
        var variant = new FileVariant()
        {
            File = file,
            UploadedBy = requestingUser,
        };
        return variant;
    }
}