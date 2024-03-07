using log_data_well.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace log_data_well.Data
{
    public class AppDataContext(DbContextOptions<AppDataContext> options) : DbContext(options)
    {
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<WellMeasurement> WellMeasurements { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
        public DbSet<Well> Wells { get; set; }
        public DbSet<WellType> WellTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Указываем строку подключения к SQLite базе данных
            optionsBuilder.UseSqlite("Data Source=D:\\DB\\MSSQL15.AG2023\\MSSQL\\DATA\\PanchenkoDS_107g2_KR.mdf");
        }
    }
}
