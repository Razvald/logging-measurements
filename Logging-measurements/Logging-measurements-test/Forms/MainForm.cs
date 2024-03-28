using Logging_measurements_test.Controlers;
using Logging_measurements_test.Models;
using Logging_measurements_test.Services.Interfaces;

namespace Logging_measurements_test
{
    internal partial class MainForm : Form
    {
        private readonly IDbWorker _context;

        private readonly ListOrdersControl listOrders = new();
        private readonly CompleteOrdersControl completeOrders = new();
        private readonly AnalizationDataControl analizationData = new();
        private readonly ReportsControl reports = new();
        public Specialist _CurrentUser { get; set; }

        public MainForm(IDbWorker db)
        {
            InitializeComponent();

            _context = db;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_CurrentUser.Role == "Admin")
            {
                MessageBox.Show("���������� ��������������");
                btnAnalizationData.Visible = true;
            }
            else
            {
                btnAnalizationData.Visible = false;
            }
        }

        private List<UserControl> activeControls = new();

        private void RemovePreviousControl()
        {
            foreach (UserControl control in activeControls)
            {
                if (this.Controls.Contains(control))
                {
                    this.Controls.Remove(control);
                }
            }
            activeControls.Clear();
        }

        private void ShowControl(UserControl userControl)
        {
            RemovePreviousControl();
            this.Controls.Add(userControl);
            userControl.Location = new Point(12, 47);
            activeControls.Add(userControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListOrdersControl orderControl = new ListOrdersControl();
            // ���������� ���������� � ������
            orderControl.SetOrderInfo("2024-03-28", "�������������", "In Progress");

            // ��������� ������� �������� �� �����
            orderControl.Location = new Point(10, 10);

            // ���������� �������� �� ������� �����
            this.Controls.Add(orderControl);
            /*
            RemovePreviousControl();
            ShowControl(listOrders);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemovePreviousControl();
            ShowControl(completeOrders);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemovePreviousControl();
            ShowControl(analizationData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemovePreviousControl();
            ShowControl(reports);
        }
    }
}