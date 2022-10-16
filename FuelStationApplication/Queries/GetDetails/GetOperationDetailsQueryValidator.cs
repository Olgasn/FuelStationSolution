using FluentValidation;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetOperationDetailsQueryValidator : AbstractValidator<GetOperationDetailsQuery>
    {
        public GetOperationDetailsQueryValidator()
        {
            RuleFor(operation => operation.Id).NotEqual(Guid.Empty);
        }
    }
}
