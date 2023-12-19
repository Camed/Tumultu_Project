using FluentValidation;

namespace Tumultu.Application.Behaviours.Commands;

public class UpdateBehaviourCommandValidator : AbstractValidator<UpdateBehaviourCommand>
{
    public UpdateBehaviourCommandValidator()
    {
        RuleFor(request => request.Id)
            .NotNull();
    }
}