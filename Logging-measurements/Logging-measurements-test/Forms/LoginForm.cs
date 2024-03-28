using Logging_measurements_test.Models;
using Logging_measurements_test.Services.Interfaces;

namespace Logging_measurements_test.Forms
{
    internal partial class LoginForm : Form
    {
        private readonly IDbWorker _context;

        public LoginForm(IDbWorker context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbLogin.Text;
            string password = txbPassword.Text;

            // Проверка введенных данных с данными в базе данных
            var user = _context.Specialists.FirstOrDefault(s => s.Username == username && s.Password == password);

            if (user != null)
            {
                // Успешная аутентификация
                MainForm mainForm = new(/*user*/);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Ошибка аутентификации
                MessageBox.Show("Неправильное имя пользователя или пароль. Попробуйте снова.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
