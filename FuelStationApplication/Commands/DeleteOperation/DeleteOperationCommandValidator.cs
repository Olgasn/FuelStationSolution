using FluentValidation;

namespace FuelStation.Application.Commands.DeleteOperation
{
    public class DeleteOperationCommandValidator : AbstractValidator<DeleteOperationCommand>
    {
        public DeleteOperationCommandValidator()
        {
            RuleFor(deleteCommand => deleteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
