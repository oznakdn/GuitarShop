using FluentValidation;
using GuitarShop.WebApi.Models.ViewModels.CustomerViewModels;

namespace GuitarShop.WebApi.Business.ValidationRules.FluentValidation.CustomerValidators
{
    public class CreateCustomerValidator:AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x=>x.FirstName).NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(x=>x.LastName).NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x=>x.Username).NotNull().MinimumLength(5).MaximumLength(20);
            RuleFor(x=>x.Password).NotNull().MinimumLength(6).MaximumLength(10);
            RuleFor(x=>x.ContactId).GreaterThan(0);
        }
    }
}