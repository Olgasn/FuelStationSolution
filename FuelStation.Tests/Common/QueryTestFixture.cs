using AutoMapper;
using FuelStation.Application.Interfaces;
using FuelStation.Application.Common.Mappings;
using FuelStation.Persistence;

namespace FuelStation.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public FuelStationDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = FuelStationContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IFuelStationDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            FuelStationContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
