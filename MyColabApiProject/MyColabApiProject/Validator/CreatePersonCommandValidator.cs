using FluentValidation;
using MyColabApiProject.Commands;


namespace MyColabApiProject.Validator
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty or whitespace.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address cannot be empty or whitespace.");
        }
     }
}
