using FluentValidation;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetFuelDetailsQueryValidator : AbstractValidator<GetFuelDetailsQuery>
    {
        public GetFuelDetailsQueryValidator()
        {
            RuleFor(Fuel => Fuel.Id).NotEqual(Guid.Empty);
        }
    }
}
