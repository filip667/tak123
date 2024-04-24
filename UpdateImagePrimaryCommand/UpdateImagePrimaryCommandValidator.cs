using FluentValidation;
using PersonalStudio.Application.Services.Commands.UpdateImagePrimaryCommand;

public class UpdateImagePrimaryCommandValidator : AbstractValidator<UpdateImagePrimaryCommand>
{
    public UpdateImagePrimaryCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Image Id is required.");
    }
}
