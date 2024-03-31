using LogProject.Controls;
using LogProject.Database;
using LogProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

            // Показать кнопку создания нового заказа только для администратора
            if (IsAdminUser(_userId))
            {
                btnGraph.Visible = true;
                btnCreateOrder.Visible = true;
            }
        }

        private bool IsAdminUser(int id)
        {
            // Проверяем, есть ли администратор среди специалистов
            var admin = _dbContext.Specialists.FirstOrDefault(s => s.Role == Role.Administrator);
            if (admin.SpecialistID == id)
            {
                return true; // Если администратор найден, возвращаем true, иначе false
            }
            else { return false; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var orders = GetOrdersWithStatus(OrderStatus.Waiting, OrderStatus.Cancelled);
            DisplayOrders(orders);
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
                    Anchor = AnchorStyles.None, // Отключаем привязку к краям
                    Margin = new Padding((flowLayoutPanel1.Width - Width) / 4,
                    0, 0, 0)
                };

                // Подписываемся на события кнопок в ReportControl
                reportsControl.SaveClicked += ReportsControl_SaveClicked;
                reportsControl.CancelClicked += ReportsControl_CancelClicked;

                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(reportsControl);
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
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
            // Получаем данные о скважинах и измерениях из вашего контекста базы данных
            var wells = _dbContext.Wells.ToArray();
            var wellMeasurements = _dbContext.WellMeasurements.ToArray();
            var wellTypes = _dbContext.WellTypes.ToArray();

            // Создаем экземпляр UserControl с передачей данных о скважинах и измерениях
            DataAnalizeControl dataAnalizeControl = new(wells, wellMeasurements, wellTypes);

            // Очищаем и добавляем UserControl на панель
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

            int clientId = 0; // Инициализируем ClientID

            if (createNewClient)
            {
                // Создаем нового клиента
                Client client = new Client
                {
                    Name = clientName,
                    Phone = clientPhone,
                    Email = clientEmail
                };

                // Добавляем клиента в базу данных
                _dbContext.Clients.Add(client);
                _dbContext.SaveChanges();

                // Получаем ID нового клиента
                clientId = client.ClientID;
            }
            else if (!string.IsNullOrEmpty(selectedClient))
            {
                // Если выбран существующий клиент из списка, получаем его ID
                clientId = _dbContext.Clients.FirstOrDefault(c => c.Name == selectedClient)?.ClientID ?? 0;
            }

            // Получаем ID специализации
            int specializationId = _dbContext.Specializations.FirstOrDefault(s => s.Name == specialization)?.SpecializationID ?? 0;

            // Создаем новый заказ
            Order order = new()
            {
                ClientID = clientId,
                SpecializationID = specializationId,
                OrderStatus = OrderStatus.Waiting,
                OrderDate = DateTime.Now
            };

            try
            {
                // Добавляем заказ в базу данных
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }

            MessageBox.Show("Заказ успешно создан.");
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
                double latitude = Math.Round(random.NextDouble() * (90 - (-90)) - 90, 3); // Округление широты до 3 знаков после запятой
                double longitude = Math.Round(random.NextDouble() * (180 - (-180)) - 180, 3); // Округление долготы до 3 знаков после запятой
                string geoCoordinates = $"{latitude:F3}° {(latitude >= 0 ? "N" : "S")}, {longitude:F3}° {(longitude >= 0 ? "E" : "W")}";
                // Здесь F3 означает форматирование с фиксированным количеством знаков после запятой (3 в данном случае).

                // Создание новой записи Well
                var well = new Well
                {
                    WellTypeID = _dbContext.WellTypes.FirstOrDefault(wt => wt.Name == selectedWellType)?.WellTypeID ?? 1,
                    GeoCoordinates = geoCoordinates,
                    Depth = wellDepth
                };

                try
                {
                    _dbContext.Wells.Add(well);
                    _dbContext.SaveChanges(); // Сохранение изменений и получение WellID
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
                }

                // Создание новой записи WellMeasurement
                var wellMeasurement = new WellMeasurement
                {
                    WellID = well.WellID, // Установка WellID после сохранения Well
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
                    // Изменение свойств заказа
                    order.OrderStatus = OrderStatus.Completed;
                    order.OrderDate = DateTime.Now;
                    order.MeasurementID = wellMeasurement.MeasurementID;
                    // Добавление других свойств заказа, если необходимо
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
            if (order != null)
            {
                // Изменение свойств заказа
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
        }

        private void OrderControl_Click(object sender, EventArgs e)
        {
            // Получаем экземпляр OrderControl, который был нажат
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

            // Обновляем статус заказа и привязываем его к текущему пользователю (рабочему)
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

        private DbContextOptions<AppDbContext> CreateOptions()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

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

                // Добавляем обработчик события клика
                orderControl.Click += OrderControl_Click;

                flowLayoutPanel1.Controls.Add(orderControl);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Закрываем текущую форму
            this.Close();

            // Открываем форму входа
            LoginForm loginForm = new();
            loginForm.Show();
        }
    }
}
// https://scottplot.net/cookbook/5.0/