using log_data_well.Controlers;

namespace log_data_well
{
    public partial class MainForm : Form
    {
        private readonly ListOrdersControl listOrders;
        private readonly CompleteOrdersControl completeOrders;
        private readonly AnalizationDataControl analizationData;
        private readonly ReportsControl reports;

        public MainForm()
        {
            InitializeComponent();
            // Инициализация контроллеров
            listOrders = new ListOrdersControl();
            completeOrders = new CompleteOrdersControl();
            analizationData = new AnalizationDataControl();
            reports = new ReportsControl();
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