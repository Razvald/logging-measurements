namespace log_data_well.Data
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class MeasurementType
    {
        public int MeasurementTypeID { get; set; }
        public string Name { get; set; }
        public string MeasurementUnits { get; set; }
        public string Description { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int SpecialistID { get; set; }
        public int MeasurementID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual Specialist Specialist { get; set; }
        public virtual WellMeasurement WellMeasurement { get; set; }
    }

    public class Specialist
    {
        public int SpecialistID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountStatus { get; set; }
        public int SpecializationID { get; set; }

        public virtual Specialization Specialization { get; set; }
    }

    public class Specialization
    {
        public int SpecializationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Well
    {
        public int WellID { get; set; }
        public int WellTypeID { get; set; }
        public string GeoCoordinates { get; set; }
        public double Depth { get; set; }

        public virtual WellType WellType { get; set; }
    }

    public class WellMeasurement
    {
        public int MeasurementID { get; set; }
        public int WellID { get; set; }
        public int MeasurementTypeID { get; set; }
        public double MeasurementValue { get; set; }
        public DateTime MeasurementDateTime { get; set; }

        public virtual Well Well { get; set; }
        public virtual MeasurementType MeasurementType { get; set; }
    }

    public class WellType
    {
        public int WellTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
