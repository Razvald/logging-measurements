using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogProject.Database.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        public int? SpecialistID { get; set; }

        [ForeignKey("WellMeasurement")]
        public int? MeasurementID { get; set; }

        [ForeignKey("Specialization")]
        public int? SpecializationID { get; set; }

        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual Specialist Specialist { get; set; }
        public virtual WellMeasurement WellMeasurement { get; set; }
        public virtual Specialization Specialization { get; set; }
    }

    public enum OrderStatus
    {
        InProgress,
        Completed,
        Cancelled,
        Waiting
    }
}
