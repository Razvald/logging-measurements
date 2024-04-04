using LogProject.Database.Entities;

namespace LogProject.Controls
{
    public partial class ReportControl : UserControl
    {
        private readonly List<Order> _orders;
        private readonly List<WellType> _wellTypes;
        public event EventHandler SaveClicked;
        public event EventHandler CancelClicked;
        public event EventHandler OrderClicked;
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
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
