using LogProject.Database;
using LogProject.Database.Entities;

namespace LogProject.Controls
{
    public partial class OrderControl : UserControl
    {
        private readonly AppDbContext _dbContext;
        private readonly int _userId;

        public OrderControl(int userId, AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _userId = userId;
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
            get { return lblOrderStatus.Text; }
            set { lblOrderStatus.Text = value; }
        }

        private void OrderControl_Click(object sender, EventArgs e)
        {
            if (!_dbContext.Specialists.Any(s => s.Role == Role.Administrator && s.SpecialistID == _userId))
            {

                int orderId = int.Parse(OrderId);

                DialogResult result = MessageBox.Show("Хотите взять этот заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AcceptOrder(orderId);
                }
            }
        }

        private void AcceptOrder(int orderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                MessageBox.Show("Выбранный заказ не найден.");
                return;
            }

            if (order.OrderStatus != Database.Entities.OrderStatus.Waiting && order.OrderStatus != Database.Entities.OrderStatus.Cancelled)
            {
                MessageBox.Show("Невозможно взять заказ, так как его статус не 'Waiting' или 'Cancelled'.");
                return;
            }

            order.OrderStatus = Database.Entities.OrderStatus.InProgress;
            order.SpecialistID = _userId;

            try
            {
                _dbContext.SaveChanges();
                MessageBox.Show("Заказ успешно взят в работу.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при взятии заказа: {ex.Message}");
            }
        }
    }
}
