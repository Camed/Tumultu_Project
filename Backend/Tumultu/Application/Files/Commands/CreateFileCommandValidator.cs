using Ardalis.GuardClauses;
using FluentValidation;
using Newtonsoft.Json;
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
            .NotNull()
            .NotEmpty()
            .MaximumLength(settings.Common.MaximumFileNameLength);
    }
}
