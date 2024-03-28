using Logging_measurements_test.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Logging_measurements_test.Forms
{
    internal partial class LoginForm : Form
    {
        private readonly IDbWorker _context;
        private static IServiceProvider _serviceProvider = null!;

        public LoginForm(IDbWorker context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbLogin.Text;
            string password = txbPassword.Text;

            var user = _context.Specialists.FirstOrDefault(s => s.Username == username && s.Password == password);

            if (user != null)
            {
                MainForm mainForm = _serviceProvider.GetRequiredService<MainForm>();
                mainForm._CurrentUser = user;
                mainForm.Show();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль. Попробуйте снова.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
