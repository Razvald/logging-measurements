using LogProject.Database;
using LogProject.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogProject.Controls
{
    public partial class CreateOrderControl : UserControl
    {
        private readonly AppDbContext _dbContext;

        private List<Client> _clients;
        private List<Specialization> _specializations;

        public string ClientName => txbClientName.Text;
        public string ClientPhone => txbClientPhone.Text;
        public string ClientEmail => txbClientEmail.Text;
        public string Specialization => cmbSpecialization.SelectedItem?.ToString();
        public bool CreateNewClient => chbCreateNewClient.Checked;
        public string SelectedClient => cmbClients.SelectedItem?.ToString();

        public CreateOrderControl(List<Client> clients, List<Specialization> specializations, AppDbContext dbContext)
        {
            InitializeComponent();
            _clients = clients;
            _specializations = specializations;
            _dbContext = dbContext;
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cmbClients.Items.Clear();
            foreach (var client in _clients)
            {
                cmbClients.Items.Add(client.Name);
            }

            cmbSpecialization.Items.Clear();
            foreach (var specialization in _specializations)
            {
                cmbSpecialization.Items.Add(specialization.Name);
            }
        }

        private void chbCreateNewClient_CheckedChanged(object sender, EventArgs e)
        {
            bool isNewClient = chbCreateNewClient.Checked;
            txbClientName.Enabled = isNewClient;
            txbClientPhone.Enabled = isNewClient;
            txbClientEmail.Enabled = isNewClient;
            cmbClients.Enabled = !isNewClient;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int clientId = 0;

            if (CreateNewClient)
            {
                Client client = new Client
                {
                    Name = ClientName,
                    Phone = ClientPhone,
                    Email = ClientEmail
                };

                _dbContext.Clients.Add(client);
                _dbContext.SaveChanges();

                clientId = client.ClientID;
            }
            else if (!string.IsNullOrEmpty(SelectedClient))
            {
                clientId = _dbContext.Clients.FirstOrDefault(c => c.Name == SelectedClient)?.ClientID ?? 0;
            }

            int specializationId = _dbContext.Specializations.FirstOrDefault(s => s.Name == Specialization)?.SpecializationID ?? 0;

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
    }
}
