using Logging_measurements_test.Models;

namespace Logging_measurements_test.Services.Interfaces
{
    internal interface IDbWorker
    {
        public IEnumerable<Client> Clients { get; }
        public IEnumerable<Order> Orders { get; }
        public IEnumerable<Specialist> Specialists { get; }
        public IEnumerable<Specialization> Specializations { get; }
        public IEnumerable<SpecialistSpecialization> SpecialistSpecializations { get; }
        public IEnumerable<Well> Wells { get; }
        public IEnumerable<WellMeasurement> WellMeasurements { get; }
        public IEnumerable<WellType> WellTypes { get; }

        public void SaveChanges();
    }
}
