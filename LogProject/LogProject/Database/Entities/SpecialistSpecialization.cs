using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogProject.Database.Entities
{
    public class SpecialistSpecialization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecialistSpecializationID { get; set; }

        public int SpecialistID { get; set; }
        public virtual Specialist Specialist { get; set; }

        public int SpecializationID { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}
