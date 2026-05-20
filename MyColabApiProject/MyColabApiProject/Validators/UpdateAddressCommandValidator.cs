using FluentValidation;
using MyColabApiProject.Commands;


namespace MyColabApiProject.Validator
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            RuleFor(x => x.StreetName).NotEmpty().WithMessage("StreetName cannot be empty or whitespace.");
            RuleFor(x => x.StreetNumber).NotEmpty().WithMessage("StreetNumber cannot be empty or whitespace.");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("PostalCode cannot be empty or whitespace.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City cannot be empty or whitespace.");
        }
    }
}
