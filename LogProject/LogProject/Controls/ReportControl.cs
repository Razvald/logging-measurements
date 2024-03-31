using LogProject.Database.Entities;

namespace LogProject.Controls
{
    public partial class ReportControl : UserControl
    {
        private List<Order> _orders;
        private List<WellType> _wellTypes;
        public event EventHandler SaveClicked;
        public event EventHandler CancelClicked;
        public string SelectedWellType => cmbWellType.SelectedItem?.ToString();
        public double WellDepth => double.Parse(txbWellDepth.Text);
        public double MeasurementValue => double.Parse(txbMeasurementValue.Text);
        public int SelectedOrderId => int.Parse(cmbOrder.SelectedItem?.ToString());

        public ReportControl(List<Order> orders, List<WellType> wellTypes)
        {
            InitializeComponent();
            _orders = orders;
            _wellTypes = wellTypes;
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            // Заполнение комбобокса текущими заказами со статусом InProgress
            cmbOrder.Items.Clear();
            foreach (var order in _orders)
            {
                cmbOrder.Items.Add(order.OrderID);
            }

            // Другие заполнения комбобоксов
            cmbWellType.Items.Clear();
            foreach (var wellType in _wellTypes)
            {
                cmbWellType.Items.Add(wellType.Name);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
