using FluentValidation;

namespace FuelStation.Application.Commands.UpdateFuel
{
    public class UpdateFuelCommandValidator : AbstractValidator<UpdateFuelCommand>
    {
        public UpdateFuelCommandValidator()
        {
            RuleFor(updateCommand =>
                updateCommand.FuelType).NotEmpty().MaximumLength(35);
            RuleFor(updateCommand =>
                updateCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
