using FluentValidation;

namespace Tumultu.Application.FileVariants.Commands;

public class UpdateFileVariantCommandValidator : AbstractValidator<UpdateFileVariantCommand>
{
    public UpdateFileVariantCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}
