using log_data_well.Data;
using log_data_well.Services.Interfaces;

namespace log_data_well.Forms
{
    internal partial class LoginForm : Form
    {
        private readonly IDbLogg _context;

        public LoginForm(IDbLogg dbLogg)
        {
            InitializeComponent();
            _context = dbLogg;
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
