using Logging_measurements_test.Models;
using Logging_measurements_test.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logging_measurements_test.Services.Implementations
{
    internal class DbWorker : IDbWorker
    {
        private readonly AppDbContext _context;

        public DbWorker(AppDbContext dbContext)
        {
            _context = dbContext;

            _context.Clients.Load();
            _context.Orders.Load();
            _context.Specialists.Load();
            _context.Specializations.Load();
            _context.SpecialistSpecializations.Load();
            _context.Wells.Load();
            _context.WellMeasurements.Load();
            _context.WellTypes.Load();
        }
        
        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                MessageBox.Show("Сохранение выполнено успешно");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.InnerException.Message}");
                }
                else
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                }
            }
        }

        public IEnumerable<Client> Clients => _context.Clients.ToList();
        public IEnumerable<Order> Orders => _context.Orders.ToList();
        public IEnumerable<Specialist> Specialists => _context.Specialists.ToList();
        public IEnumerable<Specialization> Specializations => _context.Specializations.ToList();
        public IEnumerable<SpecialistSpecialization> SpecialistSpecializations => _context.SpecialistSpecializations.ToList();
        public IEnumerable<Well> Wells => _context.Wells.ToList();
        public IEnumerable<WellMeasurement> WellMeasurements => _context.WellMeasurements.ToList();
        public IEnumerable<WellType> WellTypes => _context.WellTypes.ToList();
    }
}
