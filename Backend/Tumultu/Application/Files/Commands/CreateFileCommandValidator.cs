using FluentValidation;

namespace Tumultu.Application.Files.Commands;

public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
{
    public CreateFileCommandValidator()
    {
        RuleFor(x => x.Payload)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Payload.Length)
            .LessThanOrEqualTo(26_214_400) // 25mb max
            .GreaterThanOrEqualTo(1); // 1 byte min 


        RuleFor(x => x.FileName)
            .MaximumLength(100) // maximum file name length is 100 characters
            .NotNull()
            .NotEmpty();
    }
}
