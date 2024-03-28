using Logging_measurements_test.Models;
using Logging_measurements_test.Services.Interfaces;
using System.Windows.Forms;

namespace Logging_measurements_test.Controlers
{
    internal partial class ListOrdersControl : UserControl
    {
        public ListOrdersControl()
        {
            InitializeComponent();
        }

        private void ListOrdersControl_Load(object sender, EventArgs e)
        {

        }

        public void SetOrderInfo(string date, string specialization, string status)
        {
            lblDate.Text = date;
            lblSpecialization.Text = specialization;
            lblStatus.Text = status;
        }
    }
}
