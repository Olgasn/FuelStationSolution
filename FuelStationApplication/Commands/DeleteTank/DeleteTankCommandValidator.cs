using FluentValidation;

namespace FuelStation.Application.Commands.DeleteTank
{
    public class DeleteTankCommandValidator : AbstractValidator<DeleteTankCommand>
    {
        public DeleteTankCommandValidator()
        {
            RuleFor(deleteCommand => deleteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
