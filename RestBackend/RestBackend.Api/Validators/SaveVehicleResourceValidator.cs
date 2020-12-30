using FluentValidation;
using RestBackend.Api.Resources;

namespace RestBackend.Api.Validators
{
    public class SaveVehicleResourceValidator : AbstractValidator<SaveVehicleResource>
    {
        public SaveVehicleResourceValidator()
        {

            RuleFor(a => a.Model)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(a => a.Year)
                .NotEmpty()
                .MinimumLength(4);

            RuleFor(a => a.CylinderCap)
                .NotEmpty();

            RuleFor(a => a.BrandId)
                .NotNull();

            RuleFor(a => a.TypeId)
              .NotNull();
        }
    }
}
