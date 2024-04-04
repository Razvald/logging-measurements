using LogProject.Controls;
using LogProject.Database;
using LogProject.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogProject.Forms
{
    public partial class MainForm : Form
    {
        private readonly int _userId;
        private readonly AppDbContext _dbContext;

        public MainForm(Specialist user, AppDbContext dbContext)
        {
            InitializeComponent();
            _userId = user.SpecialistID;
            _dbContext = dbContext;

            if (IsAdminUser(_userId))
            {
                btnGraph.Visible = true;
                cmbAdd.Visible = true;
            }
        }

        private bool IsAdminUser(int id)
        {
            return _dbContext.Specialists.Any(s => s.Role == Role.Administrator && s.SpecialistID == id);
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            var orders = GetOrdersWithStatus(OrderStatus.Waiting, OrderStatus.Cancelled);
            DisplayOrders(orders);
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            if (IsAdminUser(_userId))
            {
                var orders = GetOrdersWithStatus(OrderStatus.InProgress);
                DisplayOrders(orders);
            }
            else
            {
                var myOrders = GetMyOrders(_userId);
                DisplayOrders(myOrders);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (IsAdminUser(_userId))
            {
                var orders = GetOrdersWithStatus(OrderStatus.Completed);
                DisplayOrders(orders);
            }
            else
            {
                var myOrders = GetMyOrders(_userId);
                var wellTypes = _dbContext.WellTypes.ToList();

                ReportControl reportsControl = new(myOrders, wellTypes, _dbContext)
                {
                    Anchor = AnchorStyles.None,
                    Margin = new Padding((flowLayoutPanel1.Width - Width) / 4,
                    0, 0, 0)
                };

                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(reportsControl);
            }
        }

        private void CreateOrder(object sender, EventArgs e)
        {
            var clients = _dbContext.Clients.ToList();
            var spec = _dbContext.Specializations.ToList();
            CreateOrderControl createOrderControl = new(clients, spec, _dbContext);

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(createOrderControl);
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            var wells = _dbContext.Wells.ToArray();
            var wellMeasurements = _dbContext.WellMeasurements.ToArray();
            var wellTypes = _dbContext.WellTypes.ToArray();

            DataAnalizeControl dataAnalizeControl = new(wells, wellMeasurements, wellTypes);

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(dataAnalizeControl);
        }

        public List<Order> GetOrdersWithStatus(params OrderStatus[] statuses)
        {
            var orders = _dbContext.Orders
                .Include(o => o.Client)
                .Include(o => o.Specialization)
                .Where(o => statuses.Contains(o.OrderStatus))
                .ToList();

            return orders;
        }

        public List<Order> GetMyOrders(int userId)
        {
            var orders = _dbContext.Orders
                .Include(o => o.Client)
                .Include(o => o.Specialization)
                .Where(o => o.SpecialistID == userId)
                .ToList();

            return orders;
        }

        private OrderControl CreateOrderControl(Order order)
        {
            return new OrderControl(_userId, _dbContext)
            {
                OrderId = order.OrderID.ToString(),
                ClientName = order.Client?.Name ?? "Не указано",
                ClientPhone = order.Client?.Phone ?? "Не указано",
                SpecializationName = order.Specialization?.Name ?? "Не указано",
                SpecializationDescription = order.Specialization?.Description ?? "Не указано",
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus.ToString()
            };
        }

        private void DisplayOrders(IEnumerable<Order> orders)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var order in orders)
            {
                OrderControl orderControl = CreateOrderControl(order);

                flowLayoutPanel1.Controls.Add(orderControl);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var orders = GetOrdersWithStatus(OrderStatus.Waiting, OrderStatus.Cancelled);
            DisplayOrders(orders);

            cmbAdd.Items.Add("Создать заказ");
            cmbAdd.Items.Add("Создать специалиста");
            cmbAdd.Items.Add("Создать специализацию");
            cmbAdd.Items.Add("Связать специализацию");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();

            LoginForm loginForm = new();
            loginForm.Show();
        }

        private void cmbAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdd.SelectedItem?.ToString() == "Создать заказ")
            {
                CreateOrder(sender, e);
            }
            if (cmbAdd.SelectedItem?.ToString() == "Создать специалиста")
            {
                CreateUser(sender, e);
            }
            if (cmbAdd.SelectedItem?.ToString() == "Связать специализацию")
            {
                CreateSS(sender, e);
            }
            if (cmbAdd.SelectedItem?.ToString() == "Создать специализацию")
            {
                CreateS(sender, e);
            }
        }

        private void CreateS(object sender, EventArgs e)
        {
            CreateSpecializationControl specControl = new(_dbContext);

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(specControl);
        }

        private void CreateUser(object sender, EventArgs e)
        {
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            CreateSpecialistControl createSpecialistControl = new(roles, _dbContext);

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(createSpecialistControl);
        }

        private void CreateSS(object sender, EventArgs e)
        {
            var specialist = _dbContext.Specialists.ToList();
            var specialisation = _dbContext.Specializations.ToList();
            CreateSpecSpecControl specControl = new(specialist, specialisation);
            specControl.SaveClicked += CreateSSControl_SaveClicked;
            specControl.Spec1Clicked += Spec1Control_SpecClicked;
            specControl.Spec2Clicked += Spec2Control_SpecClicked;

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(specControl);
        }

        private void Spec2Control_SpecClicked(object sender, EventArgs e)
        {
            var specControl = (CreateSpecSpecControl)sender;
            if (specControl.Specialization != null)
            {
                int selectedSpecializationID = int.Parse(specControl.Specialization);

                Specialization selectedSpecialization = _dbContext.Specializations
                    .FirstOrDefault(s => s.SpecializationID == selectedSpecializationID); ;

                if (selectedSpecialization != null)
                {
                    specControl.label3.Text = selectedSpecialization.Name;
                }
            }
            else
            {
                specControl.label3.Text = "";
            }
        }

        private void Spec1Control_SpecClicked(object sender, EventArgs e)
        {
            var specControl = (CreateSpecSpecControl)sender;
            if (specControl.Specialist != null)
            {
                int selectedSpecialistID = int.Parse(specControl.Specialist);

                // Находим специалиста по его идентификатору
                Specialist selectedSpecialist = _dbContext.Specialists
                    .Include(s => s.SpecialistSpecializations)
                    .ThenInclude(ss => ss.Specialization)
                    .FirstOrDefault(s => s.SpecialistID == selectedSpecialistID);

                if (selectedSpecialist != null)
                {
                    specControl.label2.Text = selectedSpecialist.FullName;

                    var specialization = selectedSpecialist.SpecialistSpecializations.FirstOrDefault();
                    if (specialization != null)
                    {
                        specControl.label4.Text = specialization.Specialization.Name;
                    }
                    else
                    {
                        specControl.label4.Text = "Нет специализации";
                    }
                }
            }
            else
            {
                specControl.label2.Text = "";
                specControl.label4.Text = "";
            }
        }

        private void CreateSSControl_SaveClicked(object sender, EventArgs e)
        {
            CreateSpecSpecControl specControl = (CreateSpecSpecControl)sender;

            string Specialist = specControl.Specialist;
            string Specialization = specControl.Specialization;

            int parsedSpecialistID = int.Parse(Specialist);
            int parsedSpecializationID = int.Parse(Specialization);

            SpecialistSpecialization specialistSpecialization = new SpecialistSpecialization
            {
                SpecialistID = parsedSpecialistID,
                SpecializationID = parsedSpecializationID
            };

            try
            {
                _dbContext.SpecialistSpecializations.Add(specialistSpecialization);
                _dbContext.SaveChanges();
                MessageBox.Show("Специалист успешно создан.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }
    }
}
//https://scottplot.net/cookbook/5.0/