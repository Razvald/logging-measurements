using log_data_well.Data;
using log_data_well.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log_data_well.Services.Implementations
{
    internal class DbLogg : IDbLogg
    {
        private readonly AppDataContext _context;

        public DbLogg(AppDataContext context)
        {
            _context = context;

            _context.Clients.Load();
            _context.Orders.Load();
            _context.Specialists.Load();
            _context.Specializations.Load();
            _context.SpecialistSpecializations.Load();
            _context.Wells.Load();
            _context.WellMeasurements.Load();
            _context.WellTypes.Load();
        }

        public IEnumerable<Client> Clients => _context.Clients.ToList();
        public IEnumerable<Order> Orders => _context.Orders.ToList();
        public IEnumerable<Specialist> Specialists => _context.Specialists.ToList();
        public IEnumerable<Specialization> Specializations => _context.Specializations.ToList();
        public IEnumerable<SpecialistSpecialization> SpecialistSpecializations => _context.SpecialistSpecializations.ToList();
        public IEnumerable<Well> Wells => _context.Wells.ToList();
        public IEnumerable<WellMeasurement> WellMeasurements => _context.WellMeasurements.ToList();
        public IEnumerable<WellType> WellTypes => _context.WellTypes.ToList();


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
    }
}
