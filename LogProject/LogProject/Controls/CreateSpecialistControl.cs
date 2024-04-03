using LogProject.Database.Entities;

namespace LogProject.Controls
{
    public partial class CreateSpecialistControl : UserControl
    {
        public event EventHandler SaveClicked;
        private List<Role> _role;

        public new string SName => txbName.Text;
        public string Phone => txbPhone.Text;
        public string Password => txbPassword.Text;
        public string Login => txbLogin.Text;
        public string Role => cmbRole.SelectedItem?.ToString();

        public CreateSpecialistControl(List<Role> role)
        {
            InitializeComponent();
            _role = role;
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cmbRole.Items.Clear();
            foreach (var role in _role)
            {
                cmbRole.Items.Add(role);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
