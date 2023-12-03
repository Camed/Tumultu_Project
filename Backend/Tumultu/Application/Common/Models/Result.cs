namespace Tumultu.Application.Common.Models;

public class Result
{
    internal Result(bool success, IEnumerable<string> errors)
    {
        this.Succeeded = success;
        Errors = errors;
    }

    public bool Succeeded { get; init; }
    public IEnumerable<string> Errors { get; init; }
    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }
    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }

}
