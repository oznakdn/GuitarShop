using FluentValidation;
using GuitarShop.WebApi.Models.ViewModels.CustomerViewModels;

namespace GuitarShop.WebApi.Business.ValidationRules.FluentValidation.CustomerValidators
{
    public class UpdateCustomerValidator:AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x=>x.FirstName).NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(x=>x.LastName).NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x=>x.ContactId).GreaterThan(0);
        }
    }
}