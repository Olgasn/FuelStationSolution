using FuelStation.Persistence;

namespace FuelStation.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly FuelStationDbContext Context;

        public TestCommandBase()
        {
            Context = FuelStationContextFactory.Create();
        }

        public void Dispose()
        {
            FuelStationContextFactory.Destroy(Context);
        }
    }
}
