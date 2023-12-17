using Tumultu.Domain.Common;

namespace Tumultu.Domain.ValueObjects;

public class FileString : ValueObject
{
    public FileString() { }
    public FileString(int? offset, int? stringType, string? stringValue)
    {
        OffsetInFile = offset;
        StringType = stringType;
        StringValue = stringValue;
    }
    public int? OffsetInFile { get; set; }
    public int? StringType { get; set; }
    public string? StringValue { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return OffsetInFile!;
        yield return StringType!;
        yield return StringValue!;
    }
}
