using LogProject.Database.Entities;

namespace LogProject.Controls
{
    public partial class CreateOrderControl : UserControl
    {
        public event EventHandler SaveClicked;
        private List<Client> _clients;
        private List<Specialization> _specializations;

        public string ClientName => txbClientName.Text;
        public string ClientPhone => txbClientPhone.Text;
        public string ClientEmail => txbClientEmail.Text;
        public string Specialization => cmbSpecialization.SelectedItem?.ToString();
        public bool CreateNewClient => chbCreateNewClient.Checked;
        public string SelectedClient => cmbClients.SelectedItem?.ToString();

        public CreateOrderControl(List<Client> clients, List<Specialization> specializations)
        {
            InitializeComponent();
            _clients = clients;
            _specializations = specializations;
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
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
