using LogProject.Database;
using LogProject.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LogProject
{
    public partial class LoginForm : Form
    {
        private int userId;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // �������� ������� ������ ������������
            if (IsValidUser(txbLogin.Text, txbPassword.Text))
            {
                // ��������� ������� �����
                this.Hide();

                // ��������� ������� �����
                MainForm mainForm = new(userId);
                mainForm.ShowDialog(); // ���������� ������� ����� ��� ���������
            }
            else
            {
                MessageBox.Show("�������� ������� ������. ����������, ���������� �����.");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // ������ ������ ����������� �� ����� ������������
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json") // logging-measurements\LogProject\LogProject\bin\Debug\net6.0-windows\
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // �������� ������������ ��� ����������� � ���� ������
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // �������� ������� ������������ � ���� ������
            using var dbContext = new AppDbContext(optionsBuilder.Options);
            var user = dbContext.Specialists.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                userId = user.SpecialistID;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
