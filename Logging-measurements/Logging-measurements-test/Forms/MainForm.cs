using Logging_measurements_test.Controlers;
using Logging_measurements_test.Models;

namespace Logging_measurements_test
{
    public partial class MainForm : Form
    {
        private readonly ListOrdersControl listOrders = new();
        private readonly CompleteOrdersControl completeOrders = new();
        private readonly AnalizationDataControl analizationData = new();
        private readonly ReportsControl reports = new();

        readonly AppDbContext _db;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = _db.Clients;
            //MessageBox.Show(_db.DbPath);
        }

        private List<UserControl> activeControls = new List<UserControl>(); // список активных контроллеров

        private void RemovePreviousControl()
        {
            foreach (UserControl control in activeControls)
            {
                if (this.Controls.Contains(control))
                {
                    this.Controls.Remove(control);
                }
            }
            activeControls.Clear(); // очищаем список активных контроллеров
        }

        private void ShowControl(UserControl userControl)
        {
            RemovePreviousControl(); // Удаление предыдущего контроллера
                                     // Добавление Control на форму
            this.Controls.Add(userControl);
            // Установка позиции и других параметров, если необходимо
            userControl.Location = new Point(0, 41);
            // Добавляем контроллер в список активных
            activeControls.Add(userControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemovePreviousControl(); // Удаление предыдущего контроллера
            ShowControl(listOrders);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemovePreviousControl(); // Удаление предыдущего контроллера
            ShowControl(completeOrders);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemovePreviousControl(); // Удаление предыдущего контроллера
            ShowControl(analizationData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemovePreviousControl(); // Удаление предыдущего контроллера
            ShowControl(reports);
        }
    }
}