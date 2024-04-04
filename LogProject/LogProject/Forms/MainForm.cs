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

        public MainForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _dbContext = new AppDbContext(CreateOptions());

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

                ReportControl reportsControl = new(myOrders, wellTypes)
                {
                    Anchor = AnchorStyles.None,
                    Margin = new Padding((flowLayoutPanel1.Width - Width) / 4,
                    0, 0, 0)
                };

                reportsControl.OrderClicked += ReportControl_OrderClicked;

                reportsControl.SaveClicked += ReportsControl_SaveClicked;
                reportsControl.CancelClicked += ReportsControl_CancelClicked;

                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(reportsControl);
            }
        }

        private void CreateOrder(object sender, EventArgs e)
        {
            var clients = _dbContext.Clients.ToList();
            var spec = _dbContext.Specializations.ToList();
            CreateOrderControl createOrderControl = new(clients, spec);
            createOrderControl.SaveClicked += CreateOrderControl_SaveClicked;

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

        private void CreateOrderControl_SaveClicked(object sender, EventArgs e)
        {
            CreateOrderControl newOrderControl = (CreateOrderControl)sender;
            string clientName = newOrderControl.ClientName;
            string clientPhone = newOrderControl.ClientPhone;
            string clientEmail = newOrderControl.ClientEmail;
            string specialization = newOrderControl.Specialization;
            bool createNewClient = newOrderControl.CreateNewClient;
            string selectedClient = newOrderControl.SelectedClient;

            int clientId = 0;

            if (createNewClient)
            {
                Client client = new Client
                {
                    Name = clientName,
                    Phone = clientPhone,
                    Email = clientEmail
                };

                _dbContext.Clients.Add(client);
                _dbContext.SaveChanges();

                clientId = client.ClientID;
            }
            else if (!string.IsNullOrEmpty(selectedClient))
            {
                clientId = _dbContext.Clients.FirstOrDefault(c => c.Name == selectedClient)?.ClientID ?? 0;
            }

            int specializationId = _dbContext.Specializations.FirstOrDefault(s => s.Name == specialization)?.SpecializationID ?? 0;

            Order order = new()
            {
                ClientID = clientId,
                SpecializationID = specializationId,
                OrderStatus = OrderStatus.Waiting,
                OrderDate = DateTime.Now
            };

            try
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                MessageBox.Show("Заказ успешно создан.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void ReportsControl_SaveClicked(object sender, EventArgs e)
        {
            ReportControl reportsControl = (ReportControl)sender;
            string selectedWellType = reportsControl.SelectedWellType;
            double wellDepth = reportsControl.WellDepth;
            double measurementValue = reportsControl.MeasurementValue;
            int selectedOrderId = reportsControl.SelectedOrderId;

            try
            {
                Random random = new();
                double latitude = Math.Round(random.NextDouble() * (90 - (-90)) - 90, 3);
                double longitude = Math.Round(random.NextDouble() * (180 - (-180)) - 180, 3);
                string geoCoordinates = $"{latitude:F3}° {(latitude >= 0 ? "N" : "S")}, {longitude:F3}° {(longitude >= 0 ? "E" : "W")}";

                var well = new Well
                {
                    WellTypeID = _dbContext.WellTypes.FirstOrDefault(wt => wt.Name == selectedWellType)?.WellTypeID ?? 1,
                    GeoCoordinates = geoCoordinates,
                    Depth = wellDepth
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
                    MeasurementValue = measurementValue,
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

                var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == selectedOrderId);
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

        private void ReportsControl_CancelClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Отказ от заказа сохранен", "Отказ от заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReportControl reportsControl = (ReportControl)sender;
            int selectedOrderId = reportsControl.SelectedOrderId;

            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == selectedOrderId);

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

        private void ReportControl_OrderClicked(object sender, EventArgs e)
        {
            ReportControl reportsControl = (ReportControl)sender;

            int selectedOrderId = (sender as ReportControl).SelectedOrderId;

            if (selectedOrderId != null)
            {
                var selectedOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderID == selectedOrderId);

                if (selectedOrder != null)
                {
                    var wellMeasurement = _dbContext.WellMeasurements.FirstOrDefault(wm => wm.MeasurementID == selectedOrder.MeasurementID);

                    if (wellMeasurement != null)
                    {
                        var well = _dbContext.Wells.FirstOrDefault(w => w.WellID == selectedOrder.WellMeasurement.WellID);

                        if (well != null)
                        {
                            reportsControl.txbWellDepth.Text = well.Depth.ToString();
                            reportsControl.txbMeasurementValue.Text = wellMeasurement.MeasurementValue.ToString();
                            reportsControl.cmbWellType.Text = well.WellType.Name.ToString();
                        }
                    }
                }
            }
        }

        private void OrderControl_Click(object sender, EventArgs e)
        {
            OrderControl clickedControl = (OrderControl)sender;
            int orderId = int.Parse(clickedControl.OrderId);

            DialogResult result = MessageBox.Show("Хотите взять этот заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                AcceptOrder(orderId);
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

            if (order.OrderStatus != OrderStatus.Waiting && order.OrderStatus != OrderStatus.Cancelled)
            {
                MessageBox.Show("Невозможно взять заказ, так как его статус не 'Waiting' или 'Cancelled'.");
                return;
            }

            order.OrderStatus = OrderStatus.InProgress;
            order.SpecialistID = _userId;

            try
            {
                _dbContext.SaveChanges();
                MessageBox.Show("Заказ успешно взят в работу.");
                DisplayOrders(GetOrdersWithStatus(OrderStatus.InProgress, OrderStatus.Cancelled));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при взятии заказа: {ex.Message}");
            }
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

        private static DbContextOptions<AppDbContext> CreateOptions()
        {
            string connectionString = "Server=(local); Database=LogProject; Trusted_Connection=True; Integrated Security=true; MultipleActiveResultSets=true; TrustServerCertificate=true;";
            //string connectionString = "Data Source=DBSRV\\AG2023; Initial Catalog=PanchenkoDS_107g2; Integrated Security=true; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=true;";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }

        private OrderControl CreateOrderControl(Order order)
        {
            return new OrderControl
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

                orderControl.Click += OrderControl_Click;

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
            CreateSpecializationControl specControl = new();
            specControl.SaveClicked += CreateSControl_SaveClicked;

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(specControl);
        }

        private void CreateSControl_SaveClicked(object sender, EventArgs e)
        {
            CreateSpecializationControl specControl = (CreateSpecializationControl)sender;

            string Title = specControl.Title;
            string Desc = specControl.Description;

            Specialization specialization = new Specialization
            {
                Name = Title,
                Description = Desc
            };

            try
            {
                _dbContext.Specializations.Add(specialization);
                _dbContext.SaveChanges();
                MessageBox.Show("Специализация успешно создана.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void CreateUser(object sender, EventArgs e)
        {
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            CreateSpecialistControl createSpecialistControl = new(roles);
            createSpecialistControl.SaveClicked += CreateUserControl_SaveClicked;

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

        private void CreateUserControl_SaveClicked(object sender, EventArgs e)
        {
            CreateSpecialistControl createSpecialist = (CreateSpecialistControl)sender;

            string Name = createSpecialist.SName;
            string Phone = createSpecialist.Phone;
            string Password = createSpecialist.Password;
            string Login = createSpecialist.Login;

            // Преобразуем строковое значение роли в перечисление Role
            if (!Enum.TryParse(createSpecialist.Role, out Role role))
            {
                MessageBox.Show("Ошибка при определении роли.");
                return;
            }

            Specialist specialist = new Specialist
            {
                FullName = Name,
                Phone = Phone,
                Password = Password,
                Username = Login,
                Role = role
            };

            try
            {
                _dbContext.Specialists.Add(specialist);
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