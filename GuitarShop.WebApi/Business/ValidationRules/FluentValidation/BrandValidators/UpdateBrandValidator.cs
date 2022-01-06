using FluentValidation;
using GuitarShop.WebApi.Models.ViewModels.BrandViewModels;

namespace GuitarShop.WebApi.Business.ValidationRules.FluentValidation.BrandValidators
{
    public class UpdateBrandValidator:AbstractValidator<UpdateBrandModel>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x=>x.BrandName).NotNull().MinimumLength(2).MaximumLength(20);
            RuleFor(x=>x.Description).MinimumLength(10).MaximumLength(200);
        }
    }
}