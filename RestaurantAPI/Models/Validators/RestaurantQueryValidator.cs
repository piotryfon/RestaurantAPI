using FluentValidation;
using System.Linq;

namespace RestaurantAPI.Models.Validators
{
    //atrubut [ApiController] w kontrolerze wywoła odpowiedni walidator
    public class RestaurantQueryValidator : AbstractValidator<RestaurantQuery>
    {
        private int[] allowedPageSizes = new[]{ 5, 10, 15 };
        public RestaurantQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"Page size must be in [{string.Join(", ", allowedPageSizes)}]");
                }
            });
        }
    }
}
