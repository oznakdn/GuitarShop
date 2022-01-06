using FluentValidation;
using GuitarShop.WebApi.Models.ViewModels.GuitarViewModels;

namespace GuitarShop.WebApi.Business.ValidationRules.FluentValidation.GuitarValidators
{
    public class UpdateGuitarValidator:AbstractValidator<UpdateGuitarModel>
    {
        public UpdateGuitarValidator()
        {
            RuleFor(x=>x.BrandId).NotNull().GreaterThan(0);
            RuleFor(x=>x.Code).NotEmpty().NotNull();
            RuleFor(x=>x.Features).MinimumLength(10).MaximumLength(200);
            RuleFor(x=>x.GuitarType).NotNull().GreaterThan(0);
            RuleFor(x=>x.Model).NotNull().MinimumLength(2).MaximumLength(20);
            RuleFor(x=>x.Price).NotNull().GreaterThan(0);
            RuleFor(x=>x.IsActive).NotNull();
            RuleFor(x=>x.IsStock).NotNull();
        }
    }
}