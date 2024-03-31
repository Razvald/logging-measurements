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
            // Чтение строки подключения из файла конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json") // logging-measurements\LogProject\LogProject\bin\Debug\net6.0-windows\
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

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
