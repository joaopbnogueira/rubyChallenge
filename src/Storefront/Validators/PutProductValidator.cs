using Cabify.Storefront.Models.Requests;
using FluentValidation;

namespace Cabify.Storefront.Validators
{
    public class PutProductInCartValidator : AbstractValidator<PutProductInCart>
    {
        public PutProductInCartValidator()
        {
            RuleFor(p => p.Quantity).InclusiveBetween(1, 100);
        }
    }
}
