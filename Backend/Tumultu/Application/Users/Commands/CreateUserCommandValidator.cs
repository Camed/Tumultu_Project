using FluentValidation;
using Newtonsoft.Json;
using Tumultu.Application.Common.Models;

namespace Tumultu.Application.Users.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("./appsettings.json"));

        if(settings is null) throw new ArgumentNullException(nameof(settings));

        RuleFor(x => x.Username)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty();
    }
}
