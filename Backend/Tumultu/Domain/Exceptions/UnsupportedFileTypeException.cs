namespace Tumultu.Domain.Exceptions;

public class UnsupportedFileTypeException : Exception
{
    public UnsupportedFileTypeException(string extension)
        : base($"Provided file type: *.{extension} is not supported")
    {
    }
}
