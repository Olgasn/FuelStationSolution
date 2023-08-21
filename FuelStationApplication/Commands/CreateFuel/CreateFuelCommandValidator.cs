using FluentValidation;

namespace FuelStation.Application.Commands.CreateFuel
{
    public class CreateFuelCommandValidator : AbstractValidator<CreateFuelCommand>
    {
        public CreateFuelCommandValidator()
        {
            RuleFor(createCommand =>
                createCommand.FuelType).NotEmpty().MaximumLength(35);

        }
    }
}
