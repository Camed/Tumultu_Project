using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tumultu.Application.Common.Models;

namespace Tumultu.Application.Files.Commands;

public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
{
    public CreateFileCommandValidator()
    {
        var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("./appsettings.json"));

        if(settings is null) throw new ArgumentNullException(nameof(settings));

        RuleFor(x => x.Payload)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Payload.Length)
            .LessThanOrEqualTo(settings.Common.MaximumFileSize)
            .GreaterThanOrEqualTo(settings.Common.MinimumFileSize);


        RuleFor(x => x.FileName)
            .MaximumLength(settings.Common.MaximumFileNameLength)
            .NotNull()
            .NotEmpty();
    }
}
