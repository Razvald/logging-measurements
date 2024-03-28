using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logging_measurements_test.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }

    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        public int? SpecialistID { get; set; }

        [ForeignKey("WellMeasurement")]
        public int? MeasurementID { get; set; }

        [ForeignKey("Specialization")]
        public int? SpecializationID { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual Specialist Specialist { get; set; }
        public virtual WellMeasurement WellMeasurement { get; set; }
        public virtual Specialization Specialization { get; set; }
    }

    public class Specialist
    {
        [Key]
        public int SpecialistID { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? AccountStatus { get; set; }
        public string? Role { get; set; }

        // Связь многие ко многим: один специалист может иметь множество специализаций
        public virtual ICollection<SpecialistSpecialization> SpecialistSpecializations { get; set; }
    }

    public class Specialization
    {
        [Key]
        public int SpecializationID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        // Связь многие ко многим: одна специализация может быть у множества специалистов
        public virtual ICollection<SpecialistSpecialization> SpecialistSpecializations { get; set; }
    }

    // Промежуточная таблица для связи многие ко многим
    public class SpecialistSpecialization
    {
        [Key]
        public int SpecialistSpecializationID { get; set; }

        public int SpecialistID { get; set; }
        public virtual Specialist Specialist { get; set; }

        public int SpecializationID { get; set; }
        public virtual Specialization Specialization { get; set; }
    }

    public class Well
    {
        [Key]
        [ForeignKey("WellType")]
        public int WellID { get; set; }
        public int WellTypeID { get; set; }
        public string? GeoCoordinates { get; set; }
        public double? Depth { get; set; }

        public virtual WellType WellType { get; set; }
    }

    public class WellMeasurement
    {
        [Key]
        [ForeignKey("Well")]
        public int MeasurementID { get; set; }
        public int WellID { get; set; }
        public double? MeasurementValue { get; set; }
        public DateTime? MeasurementDateTime { get; set; }

        public virtual Well Well { get; set; }
    }

    public class WellType
    {
        [Key]
        public int WellTypeID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
