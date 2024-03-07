namespace log_data_well.Data.Entity
{
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
}
