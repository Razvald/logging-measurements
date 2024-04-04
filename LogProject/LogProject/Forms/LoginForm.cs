using LogProject.Database;
using LogProject.Forms;
using Microsoft.EntityFrameworkCore;

namespace LogProject
{
    public partial class LoginForm : Form
    {
        private string _selectedConnectionString;
        private int userId;

        public LoginForm()
        {
            InitializeComponent();
            InitializeDatabaseComboBox();
        }

        private void InitializeDatabaseComboBox()
        {
            cmbDatabases.Items.Add("LogProject");
            cmbDatabases.Items.Add("PanchenkoDS_107g2_Logging");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedConnectionString))
            {
                MessageBox.Show("����������, �������� ������ �����������.");
                return;
            }

            using var dbContext = CreateDbContext();
            var user = dbContext.Specialists.FirstOrDefault(u => u.Username == txbLogin.Text && u.Password == txbPassword.Text);

            if (user != null)
            {
                this.Hide();
                MainForm mainForm = new MainForm(user, dbContext);
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("�������� ������� ������. ����������, ���������� �����.");
            }
        }

        private AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_selectedConnectionString);
            return new AppDbContext(optionsBuilder.Options);
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDatabases.SelectedItem?.ToString() == "LogProject")
            {
                _selectedConnectionString = $"Server=(local); Database={cmbDatabases.SelectedItem}; Trusted_Connection=True; Integrated Security=true; MultipleActiveResultSets=true; TrustServerCertificate=true;";
            }
            else if (cmbDatabases.SelectedItem?.ToString() == "PanchenkoDS_107g2_Logging")
            {
                _selectedConnectionString = $"Data Source=DBSRV\\AG2023; Initial Catalog={cmbDatabases.SelectedItem}; Integrated Security=true; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=true;";
            }
            else
            {
                _selectedConnectionString = $"Data Source=DBSRV\\AG2023; Initial Catalog={cmbDatabases.SelectedItem}; Integrated Security=true; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=true;";
            }

            ConnectionManager.SetConnectionString(_selectedConnectionString);
        }
    }
}
