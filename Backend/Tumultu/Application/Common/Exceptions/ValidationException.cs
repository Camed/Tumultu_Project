using FluentValidation.Results;

namespace Tumultu.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public IDictionary<string, IEnumerable<string>> Errors { get; set; }
    public ValidationException() : base("One or more validation errors occured") 
    { 
        Errors = new Dictionary<string, IEnumerable<string>>();
    }
    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(group => group.Key, group => (IEnumerable<string>)group.ToList());
    }
}
