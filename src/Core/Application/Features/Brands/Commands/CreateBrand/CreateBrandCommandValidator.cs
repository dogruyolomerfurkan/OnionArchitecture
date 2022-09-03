using FluentValidation;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandRequest>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(100).MinimumLength(2);
        }
    }
}