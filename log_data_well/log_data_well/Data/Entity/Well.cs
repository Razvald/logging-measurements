namespace log_data_well.Data.Entity
{
    public class Well
    {
        public int WellID { get; set; }
        public int WellTypeID { get; set; }
        public string GeoCoordinates { get; set; }
        public double Depth { get; set; }

        public virtual WellType WellType { get; set; }
    }
}
