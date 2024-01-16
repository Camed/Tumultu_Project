using FluentValidation;

namespace Tumultu.Application.AnalysisResults.Commands;

public class UpdateAnalysisResultCommandValidator : AbstractValidator<UpdateAnalysisResultCommand>
{
    public UpdateAnalysisResultCommandValidator()
    {
        RuleFor(request => request.Id)
            .NotNull();
    }
}