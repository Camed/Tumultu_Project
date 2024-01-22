using FluentValidation;

namespace Tumultu.Application.Users.Commands;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}
