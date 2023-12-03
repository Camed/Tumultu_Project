using Tumultu.Domain.Common;

namespace Domain.ValueObjects;

public class FileNote : ValueObject
{
    public FileNote() { }
    public FileNote(string? date, string? text)
    {
        Date = date;
        Text = text;
    }
    public string? Date { get; set; }
    public string? Text { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date!;
        yield return Text!;
    }
}
