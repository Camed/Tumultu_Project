using FluentValidation;
using Newtonsoft.Json;
using Tumultu.Application.Common.Models;

namespace Tumultu.Application.FileVariants.Commands;

public class CreateFileVariantCommandValidator : AbstractValidator<CreateFileVariantCommand>
{
    public CreateFileVariantCommandValidator()
    {
        // to be singletoned probably sooner or later
        var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("./appsettings.json"));

        if(settings is null) throw new ArgumentNullException(nameof(settings));

        RuleFor(x => x.DateModified)
            .GreaterThanOrEqualTo(x => x.CreatedDate)
            .NotNull();

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(settings.Common.MaximumFileNameLength);
    }
}
