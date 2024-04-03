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
            // Проверка учетных данных пользователя
            if (IsValidUser(txbLogin.Text, txbPassword.Text))
            {
                // Закрываем текущую форму
                this.Hide();

                // Открываем главную форму
                MainForm mainForm = new(userId);
                mainForm.ShowDialog(); // Показываем главную форму как модальную
            }
            else
            {
                MessageBox.Show("Неверные учетные данные. Пожалуйста, попробуйте снова.");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            string connectionString = "Server=(local); Database=LogProject; Trusted_Connection=True; Integrated Security=true; MultipleActiveResultSets=true; TrustServerCertificate=true;";
            //string connectionString = "Data Source=DBSRV\\AG2023; Initial Catalog=PanchenkoDS_107g2; Integrated Security=true; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=true;";

            // Создание конфигурации для подключения к базе данных
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Проверка наличия пользователя в базе данных
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
