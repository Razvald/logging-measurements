using LogProject.Database;
using LogProject.Database.Entities;

namespace LogProject.Controls
{
    public partial class ReportControl : UserControl
    {
        private readonly AppDbContext _dbContext;

        private readonly List<Order> _orders;
        private readonly List<WellType> _wellTypes;
        public string SelectedWellType => cmbWellType.SelectedItem?.ToString();
        public double WellDepth => double.Parse(txbWellDepth.Text);
        public double MeasurementValue => double.Parse(txbMeasurementValue.Text);
        public int SelectedOrderId => int.Parse(cmbOrder.SelectedItem?.ToString());

        public ReportControl(List<Order> orders, List<WellType> wellTypes, AppDbContext dbContext)
        {
            InitializeComponent();
            _orders = orders;
            _wellTypes = wellTypes;
            _dbContext = dbContext;
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cmbOrder.Items.Clear();
            foreach (var order in _orders)
            {
                cmbOrder.Items.Add(order.OrderID);
            }

            cmbWellType.Items.Clear();
            foreach (var wellType in _wellTypes)
            {
                cmbWellType.Items.Add(wellType.Name);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new();
                double latitude = Math.Round(random.NextDouble() * (90 - (-90)) - 90, 3);
                double longitude = Math.Round(random.NextDouble() * (180 - (-180)) - 180, 3);
                string geoCoordinates = $"{latitude:F3}° {(latitude >= 0 ? "N" : "S")}, {longitude:F3}° {(longitude >= 0 ? "E" : "W")}";

                var well = new Well
                {
                    WellTypeID = _dbContext.WellTypes.FirstOrDefault(wt => wt.Name == SelectedWellType)?.WellTypeID ?? 1,
                    GeoCoordinates = geoCoordinates,
                    Depth = WellDepth
                };

                try
                {
                    _dbContext.Wells.Add(well);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
                }

                var wellMeasurement = new WellMeasurement
                {
                    WellID = well.WellID,
                    MeasurementValue = MeasurementValue,
                    MeasurementDateTime = DateTime.Now
                };

                try
                {
                    _dbContext.WellMeasurements.Add(wellMeasurement);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
                }

                var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == SelectedOrderId);
                if (order != null)
                {
                    order.OrderStatus = OrderStatus.Completed;
                    order.OrderDate = DateTime.Now;
                    order.MeasurementID = wellMeasurement.MeasurementID;
                }
                _dbContext.SaveChanges();

                MessageBox.Show("Данные успешно сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Отказ от заказа сохранен", "Отказ от заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == SelectedOrderId);

            order.OrderStatus = OrderStatus.Cancelled;
            order.SpecialistID = null;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }

        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedOrderId != null)
            {
                var selectedOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderID == SelectedOrderId);

                if (selectedOrder != null)
                {
                    var wellMeasurement = _dbContext.WellMeasurements.FirstOrDefault(wm => wm.MeasurementID == selectedOrder.MeasurementID);

                    if (wellMeasurement != null)
                    {
                        var well = _dbContext.Wells.FirstOrDefault(w => w.WellID == selectedOrder.WellMeasurement.WellID);

                        if (well != null)
                        {
                            txbWellDepth.Text = well.Depth.ToString();
                            txbMeasurementValue.Text = wellMeasurement.MeasurementValue.ToString();
                            cmbWellType.Text = well.WellType.Name.ToString();
                        }
                    }
                }
            }
        }
    }
}
