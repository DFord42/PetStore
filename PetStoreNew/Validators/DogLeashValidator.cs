using System;
using FluentValidation;
using PetStore;
namespace PetStore.Validators
{
	public class DogLeashValidator : AbstractValidator<DogLeash>
	{
		public DogLeashValidator()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Price).GreaterThan(0);
			RuleFor(x => x.Quantity).GreaterThan(0);
			RuleFor(x => x.Description).MinimumLength(10);
		}
	}
}

