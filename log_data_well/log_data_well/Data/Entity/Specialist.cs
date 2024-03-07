namespace log_data_well.Data.Entity
{
    public class Specialist
    {
        public int SpecialistID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountStatus { get; set; }
        public int SpecialtyID { get; set; }

        public virtual Specialization Specialization { get; set; }
    }
}
