using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogProject.Database.Entities
{
    public class WellMeasurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeasurementID { get; set; }

        [ForeignKey("Well")]
        public int WellID { get; set; }
        public double MeasurementValue { get; set; }
        public DateTime MeasurementDateTime { get; set; }

        public virtual Well Well { get; set; }
    }
}
