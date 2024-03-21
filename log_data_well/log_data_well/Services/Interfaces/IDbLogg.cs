using log_data_well.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log_data_well.Services.Interfaces
{
    internal interface IDbLogg
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
