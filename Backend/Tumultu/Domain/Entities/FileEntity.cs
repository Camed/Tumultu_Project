using Tumultu.Domain.Common;
using Tumultu.Domain.ValueObjects;

namespace Tumultu.Domain.Entities;

public class FileEntity : BaseEntity<Guid>
{
    private FileEntity(){}
    
    private FileEntity(string md5, string sha1, string sha256, byte[] payload)
    {
        this.MD5Signature = md5;
        this.SHA1Signature = sha1;
        this.SHA256Signature = sha256;
        this.Size = payload.Length;
    }
    public IList<FileVariant> Variants { get; set; } = [];
    public IList<FileString> FileStrings { get; set; } = [];
    public int Size { get; set; } = -1;
    public string? MD5Signature { get; set; }
    public string? SHA1Signature { get; set; }
    public string? SHA256Signature { get; set; }
    public AnalysisResult? AnalysisResult { get; set; }

    public static async Task<FileEntity> CreateAsync(string md5, string sha1, string sha256, byte[] payload/*, User uploadingUser*/, CancellationToken cancellationToken)
    {
        FileEntity entity = new FileEntity(md5, sha1, sha256, payload);
        entity.AddVariant();
        entity.AnalysisResult = await AnalysisResult.CreateAnalysisAsync(payload/*, uploadingUser*/, cancellationToken);

        return entity;
    }

    public static FileEntity Create(string md5, string sha1, string sha256, byte[] payload)
    {
        FileEntity entity = new FileEntity(md5, sha1, sha256, payload);
        entity.AddVariant();
        entity.AnalysisResult = AnalysisResult.CreateAnalysis(payload/*, uploadingUser*/);

        return entity;
    }

    public void AddVariant(/*User uploadingUser*/)
    {
        FileVariant newVariant = FileVariant.CreateFileVariant(this);
        Variants.Add(newVariant);
    }
}
