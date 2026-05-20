using FluentValidation;
using MyColabApiProject.Commands;


namespace MyColabApiProject.Validator
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty or whitespace.");
        }
     }
}
