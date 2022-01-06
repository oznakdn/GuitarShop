using FluentValidation;
using GuitarShop.WebApi.Models.ViewModels.BrandViewModels;

namespace GuitarShop.WebApi.Business.ValidationRules.FluentValidation.BrandValidators
{
    public class CreateBrandValidator:AbstractValidator<CreateBrandModel>
    {
        public CreateBrandValidator()
        {
            RuleFor(x=>x.BrandName).NotNull().MinimumLength(2).MaximumLength(20);
            RuleFor(x=>x.Description).MinimumLength(10).MaximumLength(200);

        }
    }
}