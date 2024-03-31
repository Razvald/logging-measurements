using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogProject.Database.Entities
{
    public class Well
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WellID { get; set; }

        [ForeignKey("WellType")]
        public int WellTypeID { get; set; }
        public string? GeoCoordinates { get; set; }
        public double Depth { get; set; }

        public virtual WellType WellType { get; set; }
    }
}
