using Microsoft.EntityFrameworkCore;
using FuelStation.Domain;
using FuelStation.Persistence;

namespace FuelStation.Tests.Common
{
    public class FuelStationContextFactory
    {
        internal static Guid IdForDelete = Guid.NewGuid();
        internal static Guid IdForUpdate = Guid.NewGuid();
        internal static int tanksNumber = 30;
        internal static int fuelsNumber = 10;
        internal static int operationsNumber = 200;

        public static FuelStationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FuelStationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new FuelStationDbContext(options);
            context.Database.EnsureCreated();

            Guid[] tanksId = new Guid[tanksNumber];
            Guid[] fuelsId = new Guid[fuelsNumber];
            string tankType;
            string tankMaterial;
            float tankWeight;
            float tankVolume;
            string fuelType;
            float fuelDensity;

            Random randObj = new(1);

            //Заполнение таблицы емкостей
            string[] tankDictionary = { "Цистерна_", "Ведро_", "Бак_", "Фляга_", "Цистерна_" };//словарь названий емкостей
            string[] materialDictionary = { "Сталь", "Платина", "Алюминий", "ПЭТ", "Чугун", "Алюминий", "Сталь" };//словарь названий видов топлива
            int count_tankDictionary = tankDictionary.GetLength(0);
            int count_materialDictionary = materialDictionary.GetLength(0);
            for (int tankId = 1; tankId <= tanksNumber-1; tankId++)
            {
                tanksId[tankId - 1] = tankId switch
                {
                    1 => IdForDelete,
                    2 => IdForUpdate,
                    _ => Guid.NewGuid(),
                };
                tankType = tankDictionary[randObj.Next(count_tankDictionary)] + tankId.ToString();
                tankMaterial = materialDictionary[randObj.Next(count_materialDictionary)];
                tankWeight = 500 * (float)randObj.NextDouble();
                tankVolume = 200 * (float)randObj.NextDouble();
                context.Tanks.Add(new Tank 
                    { 
                        Id = tanksId[tankId - 1], 
                        TankType = tankType, 
                        TankWeight = tankWeight, 
                        TankVolume = tankVolume, 
                        TankMaterial = tankMaterial 
                    });
            }
            //Дополнительная запись для тестирование единичной выборки
            context.Tanks.Add(new Tank
            {
                TankMaterial = "Сталь",
                TankVolume = 123,
                Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                TankType = "Title2"
            });

            //сохранение изменений в базу данных, связанную с объектом контекста
            context.SaveChanges();

            //Заполнение таблицы видов топлива
            string[] fuelDictionary = { "Нефть_", "Бензин_", "Керосин_", "Мазут_", "Спирт_" };
            int count_fuelDictionary = fuelDictionary.GetLength(0);
            for (int fuelId = 1; fuelId <= fuelsNumber - 1; fuelId++)
            {
                fuelsId[fuelId - 1] = fuelId switch
                {
                    1 => IdForDelete,
                    2 => IdForUpdate,
                    _ => Guid.NewGuid(),
                };
                fuelType = fuelDictionary[randObj.Next(count_fuelDictionary)] + fuelId.ToString();
                fuelDensity = 2 * (float)randObj.NextDouble();
                context.Fuels.Add(new Fuel 
                { 
                    Id = fuelsId[fuelId - 1], 
                    FuelType = fuelType, 
                    FuelDensity = fuelDensity 
                });
            }
            //Дополнительная запись для тестирование единичной выборки
            context.Fuels.Add(new Fuel
            {
                FuelDensity = 2,
                Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                FuelType = "Title2"
            });
            //сохранение изменений в базу данных, связанную с объектом контекста
            context.SaveChanges();

            //Заполнение таблицы операций
            for (int operationId = 1; operationId <= operationsNumber - 1; operationId++)
            {
                var Id = operationId switch
                {
                    1 => IdForDelete,
                    2 => IdForUpdate,
                    _ => Guid.NewGuid(),
                };
                Guid tankId = tanksId[randObj.Next(1, tanksNumber - 1) - 1];
                Guid fuelId = fuelsId[randObj.Next(1, fuelsNumber - 1) - 1];
                int inc_exp = randObj.Next(200) - 100;
                DateTime today = DateTime.Now.Date;
                DateTime operationDate = today.AddDays(-operationId);
                context.Operations.Add(new Operation 
                { 
                    Id = Id, 
                    TankId = tankId, 
                    FuelId = fuelId, 
                    Inc_Exp = inc_exp, 
                    OperationDate = operationDate 
                });
            }
            //Дополнительная запись для тестирование единичной выборки
            context.Operations.Add(new Operation
            {
                TankId = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                FuelId = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                OperationDate = DateTime.Today,
                Inc_Exp = 1000
            });
            //сохранение изменений в базу данных, связанную с объектом контекста
            context.SaveChanges();
            return context;

        }

        public static void Destroy(FuelStationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
