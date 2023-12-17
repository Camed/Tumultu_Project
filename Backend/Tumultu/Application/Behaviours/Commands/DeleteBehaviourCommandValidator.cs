using FluentValidation;

namespace Tumultu.Application.Behaviours.Commands;

public class DeleteBehaviourCommandValidator : AbstractValidator<DeleteBehaviourCommand>
{
    public DeleteBehaviourCommandValidator()
    {
        RuleFor(request => request.Id)
            .NotNull();
    }
}