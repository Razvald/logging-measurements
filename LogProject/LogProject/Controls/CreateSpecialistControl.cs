using LogProject.Database;
using LogProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;

namespace LogProject.Controls
{
    public partial class CreateSpecialistControl : UserControl
    {
        private readonly AppDbContext _dbContext;

        private List<Role> _role;

        public new string SName => txbName.Text;
        public string Phone => txbPhone.Text;
        public string Password => txbPassword.Text;
        public string Login => txbLogin.Text;
        public string Role => cmbRole.SelectedItem?.ToString();

        public CreateSpecialistControl(List<Role> role, AppDbContext dbContext)
        {
            InitializeComponent();
            _role = role;
            _dbContext = dbContext;
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
            if (!Enum.TryParse(Role, out Role role))
            {
                MessageBox.Show("Ошибка при определении роли.");
                return;
            }

            Specialist specialist = new()
            {
                FullName = SName,
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
