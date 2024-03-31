using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogProject.Database.Entities
{
    public class Specialist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecialistID { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }

        // Связь многие ко многим: один специалист может иметь множество специализаций
        public virtual ICollection<SpecialistSpecialization> SpecialistSpecializations { get; set; }
    }

    public enum Role
    {
        Administrator,
        Worker
    }
}
