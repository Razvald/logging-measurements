using LogProject.Database;
using LogProject.Forms;
using Microsoft.EntityFrameworkCore;

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
            if (IsValidUser(txbLogin.Text, txbPassword.Text))
            {
                this.Hide();

                MainForm mainForm = new(userId);
                mainForm.ShowDialog();
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

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

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
