namespace log_data_well.Data.Entity
{
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
}
