using Microsoft.EntityFrameworkCore;

namespace Logging_measurements_test.Models
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<SpecialistSpecialization> SpecialistSpecializations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<WellMeasurement> WellMeasurements { get; set; }
        public DbSet<Well> Wells { get; set; }
        public DbSet<WellType> WellTypes { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var specialists = new List<Specialist>
            {
                new Specialist { SpecialistID = 1, FullName = "Иванов Иван Иванович", Phone = "1234567890", Username = "ivanov", Password = "password1", AccountStatus = "Active" },
                new Specialist { SpecialistID = 2, FullName = "Петров Петр Петрович", Phone = "2345678901", Username = "petrov", Password = "password2", AccountStatus = "Active" },
                new Specialist { SpecialistID = 3, FullName = "Сидоров Сидор Сидорович", Phone = "3456789012", Username = "sidorov", Password = "password3", AccountStatus = "Active" },
                new Specialist { SpecialistID = 4, FullName = "Алексеев Алексей Алексеевич", Phone = "4567890123", Username = "alexeev", Password = "password4", AccountStatus = "Active" },
                new Specialist { SpecialistID = 5, FullName = "Николаев Николай Николаевич", Phone = "5678901234", Username = "nikolaev", Password = "password5", AccountStatus = "Active" },
                new Specialist { SpecialistID = 6, Username = "1", Password = "1", Role = "Admin"}
            };

            var specializations = new List<Specialization>
            {
                new Specialization { SpecializationID = 1, Name = "Геофизический анализ", Description = "Анализ геофизических данных скважин" },
                new Specialization { SpecializationID = 2, Name = "Интерпретация данных", Description = "Интерпретация результатов каротажных измерений" },
                new Specialization { SpecializationID = 3, Name = "Логгирование скважин", Description = "Логгирование данных скважин" },
                new Specialization { SpecializationID = 4, Name = "Техническое обслуживание оборудования", Description = "Обслуживание и ремонт каротажного оборудования" },
                new Specialization { SpecializationID = 5, Name = "Маркшейдерские работы", Description = "Измерение параметров скважин и обследование местности" }
            };

            var specialistSpecializations = new List<SpecialistSpecialization>
            {
                new SpecialistSpecialization { SpecialistSpecializationID = 1, SpecialistID = 1, SpecializationID = 1 },
                new SpecialistSpecialization { SpecialistSpecializationID = 2, SpecialistID = 2, SpecializationID = 2 },
                new SpecialistSpecialization { SpecialistSpecializationID = 3, SpecialistID = 3, SpecializationID = 3 },
                new SpecialistSpecialization { SpecialistSpecializationID = 4, SpecialistID = 4, SpecializationID = 4 },
                new SpecialistSpecialization { SpecialistSpecializationID = 5, SpecialistID = 5, SpecializationID = 5 }
            };

            var orders = new List<Order>
            {
                new Order { OrderID = 1, ClientID = 1, SpecializationID = 1, SpecialistID = 1, MeasurementID = 1, OrderDate = DateTime.Now, OrderStatus = "In Progress" },
                new Order { OrderID = 2, ClientID = 2, SpecializationID = 2, SpecialistID = 2, MeasurementID = 2, OrderDate = DateTime.Now, OrderStatus = "Completed" },
                new Order { OrderID = 3, ClientID = 3, SpecializationID = 3, SpecialistID = 3, MeasurementID = 3, OrderDate = DateTime.Now, OrderStatus = "In Progress" },
                new Order { OrderID = 4, ClientID = 4, SpecializationID = 4, SpecialistID = 4, MeasurementID = 4, OrderDate = DateTime.Now, OrderStatus = "Completed" },
                new Order { OrderID = 5, ClientID = 5, SpecializationID = 5, SpecialistID = 5, MeasurementID = 5, OrderDate = DateTime.Now, OrderStatus = "In Progress" }
                //,
                //new Order { OrderID = 6, ClientID = 1, SpecializationID = 2, /*SpecialistID */ MeasurementID = 6, OrderDate = DateTime.Now, OrderStatus = "Waiting"},
                //new Order { OrderID = 7, ClientID = 3, SpecializationID = 4, /*SpecialistID */ MeasurementID = 7, OrderDate = DateTime.Now, OrderStatus = "Waiting"}
            };

            var clients = new List<Client>
            {
                new Client { ClientID = 1, Name = "ООО 'Геоинформация'", Phone = "1234567890", Email = "info@geo.com" },
                new Client { ClientID = 2, Name = "ЗАО 'Нефтегаз'", Phone = "2345678901", Email = "info@oilgas.com" },
                new Client { ClientID = 3, Name = "ИП 'СтройГео'", Phone = "3456789012", Email = "info@stroygeo.com" },
                new Client { ClientID = 4, Name = "ООО 'ПромГео'", Phone = "4567890123", Email = "info@promgeo.com" },
                new Client { ClientID = 5, Name = "ООО 'ЭнергоГео'", Phone = "5678901234", Email = "info@energygeo.com" }
            };

            var wellMeasurements = new List<WellMeasurement>
            {
                new WellMeasurement { MeasurementID = 1, WellID = 1, MeasurementValue = 15.2, MeasurementDateTime = DateTime.Now },
                new WellMeasurement { MeasurementID = 2, WellID = 2, MeasurementValue = 16.5, MeasurementDateTime = DateTime.Now },
                new WellMeasurement { MeasurementID = 3, WellID = 3, MeasurementValue = 14.8, MeasurementDateTime = DateTime.Now },
                new WellMeasurement { MeasurementID = 4, WellID = 4, MeasurementValue = 15.7, MeasurementDateTime = DateTime.Now },
                new WellMeasurement { MeasurementID = 5, WellID = 5, MeasurementValue = 16.3, MeasurementDateTime = DateTime.Now }
                //,
                //new WellMeasurement { MeasurementID = 6, WellID = 6, MeasurementValue = 0, MeasurementDateTime = DateTime.Now },
                //new WellMeasurement { MeasurementID = 7, WellID = 7, MeasurementValue = 0, MeasurementDateTime = DateTime.Now }
            };

            var wellTypes = new List<WellType>
            {
                new WellType { WellTypeID = 1, Name = "Глубокая скважина", Description = "Скважина для добычи из глубоких пластов" },
                new WellType { WellTypeID = 2, Name = "Подземный газовый резервуар", Description = "Скважина для добычи природного газа" },
                new WellType { WellTypeID = 3, Name = "Нефтяная скважина", Description = "Скважина для добычи нефти" },
                new WellType { WellTypeID = 4, Name = "Артезианская скважина", Description = "Скважина для добычи артезианской воды" },
                new WellType { WellTypeID = 5, Name = "Исследовательская скважина", Description = "Скважина для проведения исследований в геологии или геофизике" }
            };

            var wells = new List<Well>
            {
                new Well { WellID = 1, WellTypeID = 1, GeoCoordinates = "53.4808° N, 2.2426° W", Depth = 500.0 },
                new Well { WellID = 2, WellTypeID = 2, GeoCoordinates = "31.9686° N, 99.9018° W", Depth = 800.0 },
                new Well { WellID = 3, WellTypeID = 3, GeoCoordinates = "29.7604° N, 95.3698° W", Depth = 1200.0 },
                new Well { WellID = 4, WellTypeID = 4, GeoCoordinates = "40.7128° N, 74.0060° W", Depth = 300.0 },
                new Well { WellID = 5, WellTypeID = 5, GeoCoordinates = "51.5074° N, 8.1278° W", Depth = 700.0 }
                //,
                //new Well { WellID = 6, WellTypeID = 3, GeoCoordinates = "24.5074° N, 54.1278° W", Depth = 400.0 },
                //new Well { WellID = 7, WellTypeID = 4, GeoCoordinates = "62.5074° N, 37.1278° W", Depth = 800.0 }
            };

            modelBuilder.Entity<WellType>().HasData(wellTypes);
            modelBuilder.Entity<Well>().HasData(wells);
            modelBuilder.Entity<Specialist>().HasData(specialists);
            modelBuilder.Entity<Specialization>().HasData(specializations);
            modelBuilder.Entity<SpecialistSpecialization>().HasData(specialistSpecializations);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<Client>().HasData(clients);
            modelBuilder.Entity<WellMeasurement>().HasData(wellMeasurements);
        }
    }
}
