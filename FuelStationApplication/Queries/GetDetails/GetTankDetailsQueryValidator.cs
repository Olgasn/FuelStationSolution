using FluentValidation;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetTankDetailsQueryValidator : AbstractValidator<GetTankDetailsQuery>
    {
        public GetTankDetailsQueryValidator()
        {
            RuleFor(tank => tank.Id).NotEqual(Guid.Empty);
        }
    }
}
