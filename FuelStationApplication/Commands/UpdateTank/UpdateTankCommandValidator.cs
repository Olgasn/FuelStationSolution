using FluentValidation;

namespace FuelStation.Application.Commands.UpdateTank
{
    public class UpdateTankCommandValidator : AbstractValidator<UpdateTankCommand>
    {
        public UpdateTankCommandValidator()
        {
            RuleFor(updateCommand =>
                updateCommand.TankType).NotEmpty().MaximumLength(35);
            RuleFor(updateCommand=>
                updateCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
