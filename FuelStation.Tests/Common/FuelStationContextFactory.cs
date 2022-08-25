using Microsoft.EntityFrameworkCore;
using FuelStation.Domain;
using FuelStation.Persistence;

namespace FuelStation.Tests.Common
{
    public class FuelStationContextFactory
    {

        public static Guid IdForDelete = Guid.NewGuid();
        public static Guid IdForUpdate = Guid.NewGuid();
        public static int tanks_number = 35;
        public static int fuels_number = 35;
        public static int operations_number = 300;


        public static FuelStationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FuelStationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new FuelStationDbContext(options);
            context.Database.EnsureCreated();

            Guid[] tanksId = new Guid[tanks_number];
            Guid[] fuelsId = new Guid[fuels_number];
            string tankType;
            string tankMaterial;
            float tankWeight;
            float tankVolume;
            string fuelType;
            float fuelDensity;

            Random randObj = new(1);

            //Заполнение таблицы емкостей
            string[] tank_voc = { "Цистерна_", "Ведро_", "Бак_", "Фляга_", "Цистерна_" };//словарь названий емкостей
            string[] material_voc = { "Сталь", "Платина", "Алюминий", "ПЭТ", "Чугун", "Алюминий", "Сталь" };//словарь названий видов топлива
            int count_tank_voc = tank_voc.GetLength(0);
            int count_material_voc = material_voc.GetLength(0);
            for (int tankId = 1; tankId <= tanks_number-1; tankId++)
            {
                switch (tankId)
                {
                    case 1:
                        tanksId[tankId - 1] = IdForDelete;
                        break;

                    case 2:
                        tanksId[tankId - 1] = IdForUpdate;
                        break;

                    default:
                        tanksId[tankId - 1] = Guid.NewGuid();
                        break;
                }
                tankType = tank_voc[randObj.Next(count_tank_voc)] + tankId.ToString();
                tankMaterial = material_voc[randObj.Next(count_material_voc)];
                tankWeight = 500 * (float)randObj.NextDouble();
                tankVolume = 200 * (float)randObj.NextDouble();
                context.Tanks.Add(new Tank { Id = tanksId[tankId - 1], TankType = tankType, TankWeight = tankWeight, TankVolume = tankVolume, TankMaterial = tankMaterial });
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
            string[] fuel_voc = { "Нефть_", "Бензин_", "Керосин_", "Мазут_", "Спирт_" };
            int count_fuel_voc = fuel_voc.GetLength(0);
            for (int fuelId = 1; fuelId <= fuels_number-1; fuelId++)
            {
                switch (fuelId)
                {
                    case 1:
                        fuelsId[fuelId - 1] = IdForDelete;
                        break;

                    case 2:
                        fuelsId[fuelId - 1] = IdForUpdate;
                        break;

                    default:
                        fuelsId[fuelId - 1] = Guid.NewGuid();
                        break;
                }
                fuelType = fuel_voc[randObj.Next(count_fuel_voc)] + fuelId.ToString();
                fuelDensity = 2 * (float)randObj.NextDouble();
                context.Fuels.Add(new Fuel { Id = fuelsId[fuelId - 1], FuelType = fuelType, FuelDensity = fuelDensity });
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
            for (int operationId = 1; operationId <= operations_number-1; operationId++)
            {
                Guid Id;
                switch (operationId)
                {
                    case 1:
                        Id = IdForDelete;
                        break;

                    case 2:
                        Id = IdForUpdate;
                        break;

                    default:
                        Id = Guid.NewGuid();
                        break;
                }

                Guid tankId = tanksId[randObj.Next(1, tanks_number - 1) - 1];
                Guid fuelId = fuelsId[randObj.Next(1, fuels_number - 1) - 1];
                int inc_exp = randObj.Next(200) - 100;
                DateTime today = DateTime.Now.Date;
                DateTime operationdate = today.AddDays(-operationId);
                context.Operations.Add(new Operation { Id = Id, TankId = tankId, FuelId = fuelId, Inc_Exp = inc_exp, OperationDate = operationdate });
            }
            //Дополнительная запись для тестирование единичной выборки
            context.Operations.Add(new Operation
            {
                TankId = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                FuelId = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                OperationDate = DateTime.Today,
                Inc_Exp=1000
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
