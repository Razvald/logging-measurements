using Logging_measurements_test.Models;

namespace Logging_measurements_test.Controlers
{
    public partial class ReportsControl : UserControl
    {
        public ReportsControl()
        {
            InitializeComponent();
        }

        public ReportsControl(Order? selectedOrder)
        {
            SelectedOrder = selectedOrder;
        }

        public Order? SelectedOrder { get; }
    }
}
