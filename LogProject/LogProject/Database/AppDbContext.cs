using LogProject.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogProject.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<SpecialistSpecialization> SpecialistSpecializations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<WellMeasurement> WellMeasurements { get; set; }
        public DbSet<Well> Wells { get; set; }
        public DbSet<WellType> WellTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            var specialists = new List<Specialist>
            {
                new() { SpecialistID = 1, FullName = "Сидоров Сидор Сидорович", Phone = "+7(345)678 90 12", Username = "1", Password = "1", Role = Role.Administrator},
                new() { SpecialistID = 2, FullName = "Иванов Иван Иванович", Phone = "+7(123)456 78 90", Username = "2", Password = "2", Role = Role.Worker },
                new() { SpecialistID = 3, FullName = "Петров Петр Петрович", Phone = "+7(234)567 89 01", Username = "3", Password = "3", Role = Role.Worker },
                new() { SpecialistID = 4, FullName =  "Дима", Phone = "+7(983)300 88 23", Username = "4", Password = "4", Role = Role.Worker },
                new() { SpecialistID = 5, FullName = "5", Phone = "5", Username = "5", Password = "5", Role = Role.Worker },
            };

            var specializations = new List<Specialization>
            {
                new() { SpecializationID = 1, Name = "Геофизический анализ", Description = "Анализ геофизических данных скважин" },
                new() { SpecializationID = 2, Name = "Логгирование скважин", Description = "Логгирование данных скважин" },
                new() { SpecializationID = 3, Name = "Техническое обслуживание оборудования", Description = "Обслуживание и ремонт каротажного оборудования" }
            };

            var specialistSpecializations = new List<SpecialistSpecialization>
            {
                new() { SpecialistSpecializationID = 1, SpecialistID = 2, SpecializationID = 1 },
                new() { SpecialistSpecializationID = 2, SpecialistID = 3, SpecializationID = 2 },
                new() { SpecialistSpecializationID = 3, SpecialistID = 3, SpecializationID = 3 },
                new() { SpecialistSpecializationID = 4, SpecialistID = 4, SpecializationID = 1 },
                new() { SpecialistSpecializationID = 5, SpecialistID = 4, SpecializationID = 2 },
                new() { SpecialistSpecializationID = 6, SpecialistID = 5, SpecializationID = 3 }
            };

            var orders = new List<Order>
            {
                new() { OrderID = 1, ClientID = 1, SpecializationID = 1, SpecialistID = 2, MeasurementID = 1, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed },
                new() { OrderID = 2, ClientID = 2, SpecializationID = 2, SpecialistID = 3, MeasurementID = 2, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed },
                new() { OrderID = 3, ClientID = 3, SpecializationID = 3, SpecialistID = 3, MeasurementID = 3, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed },
                new() { OrderID = 4, ClientID = 2, SpecializationID = 1, SpecialistID = 4, MeasurementID = 4, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed },
                new() { OrderID = 5, ClientID = 3, SpecializationID = 2, SpecialistID = 4, MeasurementID = 5, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Completed },
                new() { OrderID = 6, ClientID = 1, SpecializationID = 3, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Waiting },
                new() { OrderID = 7, ClientID = 3, SpecializationID = 2, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Waiting }
            };

            var clients = new List<Client>
            {
                new() { ClientID = 1, Name = "ООО 'Геоинформация'", Phone = "+7(123)456 78 90", Email = "info@geo.com" },
                new() { ClientID = 2, Name = "ЗАО 'Нефтегаз'", Phone = "+7(234)567 89 01", Email = "info@oilgas.com" },
                new() { ClientID = 3, Name = "ИП 'СтройГео'", Phone = "+7(345)678 90 12", Email = "info@stroygeo.com" }
            };

            var wellMeasurements = new List<WellMeasurement>
            {
                new() { MeasurementID = 1, WellID = 1, MeasurementValue = 97.2, MeasurementDateTime = DateTime.Now },
                new() { MeasurementID = 2, WellID = 2, MeasurementValue = 197.5, MeasurementDateTime = DateTime.Now },
                new() { MeasurementID = 3, WellID = 3, MeasurementValue = 156.5, MeasurementDateTime = DateTime.Now },
                new() { MeasurementID = 4, WellID = 4, MeasurementValue = 138.5, MeasurementDateTime = DateTime.Now },
                new() { MeasurementID = 5, WellID = 5, MeasurementValue = 178.8, MeasurementDateTime = DateTime.Now },
                new() { MeasurementID = 6, WellID = 6, MeasurementValue = 41, MeasurementDateTime = DateTime.Now },
                new() { MeasurementID = 7, WellID = 7, MeasurementValue = 176, MeasurementDateTime = DateTime.Now },
                new() { MeasurementID = 8, WellID = 8, MeasurementValue = 98.5, MeasurementDateTime = DateTime.Now }
            };

            var wellTypes = new List<WellType>
            {
                new() { WellTypeID = 1, Name = "Глубокая скважина", Description = "Скважина для добычи из глубоких пластов" },
                new() { WellTypeID = 2, Name = "Подземный газовый резервуар", Description = "Скважина для добычи природного газа" },
                new() { WellTypeID = 3, Name = "Нефтяная скважина", Description = "Скважина для добычи нефти" }
            };

            var wells = new List<Well>
            {
                new() { WellID = 1, WellTypeID = 1, GeoCoordinates = "53.480° N, 2.242° W", Depth = 500.0 },
                new() { WellID = 2, WellTypeID = 2, GeoCoordinates = "31.968° N, 9.901° W", Depth = 800.0 },
                new() { WellID = 3, WellTypeID = 2, GeoCoordinates = "39.968° N, 29.901° W", Depth = 400 },
                new() { WellID = 4, WellTypeID = 3, GeoCoordinates = "51.968° N, 3.901° W", Depth = 600.0 },
                new() { WellID = 5, WellTypeID = 1, GeoCoordinates = "29.760° N, 95.369° W", Depth = 1200.0 },
                new() { WellID = 6, WellTypeID = 3, GeoCoordinates = "51.968° N, 3.901° W", Depth = 142 },
                new() { WellID = 7, WellTypeID = 3, GeoCoordinates = "51.968° N, 3.901° W", Depth = 367.0 },
                new() { WellID = 8, WellTypeID = 1, GeoCoordinates = "29.760° N, 95.369° W", Depth = 997.0 }
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
