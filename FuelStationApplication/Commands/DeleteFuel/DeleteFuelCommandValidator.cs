using FluentValidation;

namespace FuelStation.Application.Commands.DeleteFuel
{
    public class DeleteFuelCommandValidator : AbstractValidator<DeleteFuelCommand>
    {
        public DeleteFuelCommandValidator()
        {
            RuleFor(deleteCommand => deleteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
