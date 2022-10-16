using FluentValidation;

namespace FuelStation.Application.Commands.CreateOperation
{
    public class CreateOperationCommandValidator : AbstractValidator<CreateOperationCommand>
    {
        public CreateOperationCommandValidator()
        {
            RuleFor(createCommand =>
                createCommand.Inc_Exp).NotEmpty();

        }
    }
}
