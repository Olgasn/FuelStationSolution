using FluentValidation;

namespace FuelStation.Application.Commands.CreateTank
{
    public class CreateTankCommandValidator : AbstractValidator<CreateTankCommand>
    {
        public CreateTankCommandValidator()
        {
            RuleFor(createCommand =>
                createCommand.TankType).NotEmpty().MaximumLength(35);

        }
    }
}
