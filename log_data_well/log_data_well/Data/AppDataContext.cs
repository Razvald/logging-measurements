using Microsoft.EntityFrameworkCore;

namespace log_data_well.Data
{
    class AppDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(local); Database=log_data_well;Trusted_Connection=True");
        }

        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<WellMeasurement> WellMeasurements { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
        public DbSet<Well> Wells { get; set; }
        public DbSet<WellType> WellTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Specialist>().HasKey(s => s.SpecialistID);
            modelBuilder.Entity<Specialization>().HasKey(sn => sn.SpecializationID);
            modelBuilder.Entity<Order>().HasKey(o => o.OrderID);
            modelBuilder.Entity<Client>().HasKey(c => c.ClientID);
            modelBuilder.Entity<WellMeasurement>().HasKey(wm => wm.MeasurementID);
            modelBuilder.Entity<MeasurementType>().HasKey(mt => mt.MeasurementTypeID);
            modelBuilder.Entity<Well>().HasKey(w => w.WellID);
            modelBuilder.Entity<WellType>().HasKey(wt => wt.WellTypeID);

            //SeedData(modelBuilder);
        }

        /*private void SeedData(ModelBuilder modelBuilder)
        {
            // Заполнение таблицы Specialists
            modelBuilder.Entity<Specialist>().HasData(
                new Specialist { SpecialistID = 1, FullName = "Иванов Иван Иванович", Phone = "1234567890", Username = "ivanov", Password = "password", AccountStatus = "Active", SpecializationID = 1 },
                new Specialist { SpecialistID = 2, FullName = "Петров Петр Петрович", Phone = "0987654321", Username = "petrov", Password = "password", AccountStatus = "Active", SpecializationID = 2 }
            );

            // Заполнение таблицы Specializations
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { SpecializationID = 1, Name = "Геолог", Description = "Специализация в области геологии" },
                new Specialization { SpecializationID = 2, Name = "Инженер", Description = "Специализация в области инженерии" }
            );

            // Заполнение таблицы Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderID = 1, ClientID = 1, SpecialistID = 1, MeasurementID = 1, OrderDate = DateTime.Now, OrderStatus = "Completed" },
                new Order { OrderID = 2, ClientID = 2, SpecialistID = 2, MeasurementID = 2, OrderDate = DateTime.Now, OrderStatus = "Pending" }
            );

            // Заполнение таблицы Clients
            modelBuilder.Entity<Client>().HasData(
                new Client { ClientID = 1, Name = "ООО Роснефть", Phone = "1111111111", Email = "info@rosneft.com" },
                new Client { ClientID = 2, Name = "Газпром", Phone = "2222222222", Email = "info@gazprom.com" }
            );

            // Заполнение таблицы WellMeasurements
            modelBuilder.Entity<WellMeasurement>().HasData(
                new WellMeasurement { MeasurementID = 1, WellID = 1, MeasurementTypeID = 1, MeasurementValue = 100.5, MeasurementDateTime = DateTime.Now },
                new WellMeasurement { MeasurementID = 2, WellID = 2, MeasurementTypeID = 2, MeasurementValue = 200.7, MeasurementDateTime = DateTime.Now }
            );

            // Заполнение таблицы MeasurementTypes
            modelBuilder.Entity<MeasurementType>().HasData(
                new MeasurementType { MeasurementTypeID = 1, Name = "Температура", MeasurementUnits = "°C", Description = "Измерение температуры" },
                new MeasurementType { MeasurementTypeID = 2, Name = "Давление", MeasurementUnits = "мм рт.ст.", Description = "Измерение давления" }
            );

            // Заполнение таблицы Wells
            modelBuilder.Entity<Well>().HasData(
                new Well { WellID = 1, WellTypeID = 1, GeoCoordinates = "51.5074° N, 0.1278° W", Depth = 1000 },
                new Well { WellID = 2, WellTypeID = 2, GeoCoordinates = "40.7128° N, 74.0060° W", Depth = 1500 }
            );

            // Заполнение таблицы WellTypes
            modelBuilder.Entity<WellType>().HasData(
                new WellType { WellTypeID = 1, Name = "Нефтяная", Description = "Скважина для добычи нефти" },
                new WellType { WellTypeID = 2, Name = "Газовая", Description = "Скважина для добычи природного газа" }
            );
        }*/
    }
}
