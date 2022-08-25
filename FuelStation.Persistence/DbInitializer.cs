using FuelStation.Domain;

namespace FuelStation.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(FuelStationDbContext context)
        {
            context.Database.EnsureCreated();

            // Проверка занесены ли виды топлива
            if (context.Tanks.Any())
            {
                return;   // База данных инициализирована
            }

            int tanks_number = 35;
            Guid[] tanksId=new Guid[tanks_number];
            int fuels_number = 35;
            Guid[] fuelsId=new Guid[fuels_number];
            int operations_number = 300;
            string tankType;
            string tankMaterial;
            float tankWeight;
            float tankVolume;
            string fuelType;
            float fuelDensity;

            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            string[] tank_voc = { "Цистерна_", "Ведро_", "Бак_", "Фляга_", "Цистерна_" };//словарь названий емкостей
            string[] material_voc = { "Сталь", "Платина", "Алюминий", "ПЭТ", "Чугун", "Алюминий", "Сталь" };//словарь названий видов топлива
            int count_tank_voc = tank_voc.GetLength(0);
            int count_material_voc = material_voc.GetLength(0);
            for (int tankId = 1; tankId <= tanks_number; tankId++)
            {
                tanksId[tankId-1] = Guid.NewGuid();
                tankType = tank_voc[randObj.Next(count_tank_voc)] + tankId.ToString();
                tankMaterial = material_voc[randObj.Next(count_material_voc)];
                tankWeight = 500 * (float)randObj.NextDouble();
                tankVolume = 200 * (float)randObj.NextDouble();
                context.Tanks.Add(new Tank { Id= tanksId[tankId - 1], TankType = tankType, TankWeight = tankWeight, TankVolume = tankVolume, TankMaterial = tankMaterial });
            }
            //сохранение изменений в базу данных, связанную с объектом контекста
            context.SaveChanges();

            //Заполнение таблицы видов топлива
            string[] fuel_voc = { "Нефть_", "Бензин_", "Керосин_", "Мазут_", "Спирт_" };
            int count_fuel_voc = fuel_voc.GetLength(0);
            for (int fuelId = 1; fuelId <= fuels_number; fuelId++)
            {
                fuelsId[fuelId - 1] = Guid.NewGuid();
                fuelType = fuel_voc[randObj.Next(count_fuel_voc)] + fuelId.ToString();
                fuelDensity = 2 * (float)randObj.NextDouble();
                context.Fuels.Add(new Fuel { Id=fuelsId[fuelId-1], FuelType = fuelType, FuelDensity = fuelDensity });
            }
            //сохранение изменений в базу данных, связанную с объектом контекста
            context.SaveChanges();

            //Заполнение таблицы операций
            for (int operationId = 1; operationId <= operations_number; operationId++)
            {
                Guid tankId = tanksId[randObj.Next(1, tanks_number - 1)-1];
                Guid fuelId = fuelsId[randObj.Next(1, fuels_number - 1)-1];
                int inc_exp = randObj.Next(200) - 100;
                DateTime today = DateTime.Now.Date;
                DateTime operationdate = today.AddDays(-operationId);
                context.Operations.Add(new Operation { Id=Guid.NewGuid(), TankId = tankId, FuelId = fuelId, Inc_Exp = inc_exp, OperationDate = operationdate });
            }
            //сохранение изменений в базу данных, связанную с объектом контекста
            context.SaveChanges();

        }
    }
}
