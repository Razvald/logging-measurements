namespace log_data_well.Data
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int SpecialistID { get; set; }
        public int MeasurementID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public Client Client { get; set; }
        public Specialist Specialist { get; set; }
        public WellMeasurement WellMeasurement { get; set; }
    }

    public class Specialist
    {
        public int SpecialistID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountStatus { get; set; }

        // Связь многие ко многим: один специалист может иметь множество специализаций
        public ICollection<SpecialistSpecialization> SpecialistSpecializations { get; set; }
    }

    public class Specialization
    {
        public int SpecializationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Связь многие ко многим: одна специализация может быть у множества специалистов
        public ICollection<SpecialistSpecialization> SpecialistSpecializations { get; set; }
    }

    // Промежуточная таблица для связи многие ко многим
    public class SpecialistSpecialization
    {
        public int SpecialistSpecializationID { get; set; }
        public int SpecialistID { get; set; }
        public Specialist Specialist { get; set; }

        public int SpecializationID { get; set; }
        public Specialization Specialization { get; set; }
    }

    public class Well
    {
        public int WellID { get; set; }
        public int WellTypeID { get; set; }
        public string GeoCoordinates { get; set; }
        public double Depth { get; set; }

        public WellType WellType { get; set; }
    }

    public class WellMeasurement
    {
        public int MeasurementID { get; set; }
        public int WellID { get; set; }
        public double MeasurementValue { get; set; }
        public DateTime MeasurementDateTime { get; set; }

        public Well Well { get; set; }
    }

    public class WellType
    {
        public int WellTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
