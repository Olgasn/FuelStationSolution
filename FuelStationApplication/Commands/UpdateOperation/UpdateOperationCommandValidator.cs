using FluentValidation;

namespace FuelStation.Application.Commands.UpdateOperation
{
    public class UpdateOperationCommandValidator : AbstractValidator<UpdateOperationCommand>
    {
        public UpdateOperationCommandValidator()
        {
            RuleFor(updateCommand =>
                updateCommand.Inc_Exp).NotEmpty();
            RuleFor(updateCommand =>
                updateCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
