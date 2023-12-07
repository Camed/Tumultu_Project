using System.ComponentModel;
using Tumultu.Domain.Enums;

namespace Tumutlu.Domain.Exceptions;

public class UnsupportedFileTypeException : Exception
{
    public UnsupportedFileTypeException(string extension)
        : base($"Provided file type: *.{extension} is not supported")
    {
    }
}
