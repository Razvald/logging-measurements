using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogProject.Database.Entities
{
    public class Specialization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecializationID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        // Связь многие ко многим: одна специализация может быть у множества специалистов
        public virtual ICollection<SpecialistSpecialization> SpecialistSpecializations { get; set; }
    }
}
