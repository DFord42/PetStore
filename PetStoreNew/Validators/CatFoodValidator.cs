using System;
using FluentValidation;
namespace PetStore.Validators
{
	public class CatFoodValidator : AbstractValidator<CatFood>
	{
		public CatFoodValidator()
		{
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Description).MinimumLength(10);
        }
	}
}

