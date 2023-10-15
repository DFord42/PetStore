using System;
using FluentValidation;
namespace PetStore.Validator
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Price).GreaterThan(0);
			RuleFor(x => x.Quantity).GreaterThan(0);
			RuleFor(x => x.Description).MinimumLength(10);
		}
	}
}

