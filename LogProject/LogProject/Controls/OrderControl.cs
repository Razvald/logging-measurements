namespace LogProject.Controls
{
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            InitializeComponent();
        }

        public string OrderId
        {
            get { return lblOrderId.Text; }
            set { lblOrderId.Text = value; }
        }

        public string ClientName
        {
            set { lblClientName.Text = value; }
        }

        public string ClientPhone
        {
            set { lblClientPhone.Text = value; }
        }

        public string SpecializationName
        {
            set { lblSpecializationName.Text = value; }
        }

        public string SpecializationDescription
        {
            set { lblSpecializationDescription.Text = value; }
        }

        public DateTime OrderDate
        {
            set { lblOrderDate.Text = value.ToString("dd/MM/yyyy"); }
        }

        public string OrderStatus
        {
            set { lblOrderStatus.Text = value; }
        }
    }
}
