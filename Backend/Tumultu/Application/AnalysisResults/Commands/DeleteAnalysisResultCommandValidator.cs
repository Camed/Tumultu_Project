using FluentValidation;

namespace Tumultu.Application.AnalysisResults.Commands;

public class DeleteAnalysisResultCommandValidator : AbstractValidator<DeleteAnalysisResultCommand>
{
    public DeleteAnalysisResultCommandValidator()
    {
        RuleFor(request => request.Id)
            .NotNull();
    }
}