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
            // ������������� ������������
            listOrders = new ListOrdersControl();
            completeOrders = new CompleteOrdersControl();
            analizationData = new AnalizationDataControl();
            reports = new ReportsControl();
        }

        private List<UserControl> activeControls = new List<UserControl>(); // ������ �������� ������������

        private void RemovePreviousControl()
        {
            foreach (UserControl control in activeControls)
            {
                if (this.Controls.Contains(control))
                {
                    this.Controls.Remove(control);
                }
            }
            activeControls.Clear(); // ������� ������ �������� ������������
        }

        private void ShowControl(UserControl userControl)
        {
            RemovePreviousControl(); // �������� ����������� �����������
                                     // ���������� Control �� �����
            this.Controls.Add(userControl);
            // ��������� ������� � ������ ����������, ���� ����������
            userControl.Location = new Point(0, 41);
            // ��������� ���������� � ������ ��������
            activeControls.Add(userControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemovePreviousControl(); // �������� ����������� �����������
            ShowControl(listOrders);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemovePreviousControl(); // �������� ����������� �����������
            ShowControl(completeOrders);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemovePreviousControl(); // �������� ����������� �����������
            ShowControl(analizationData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemovePreviousControl(); // �������� ����������� �����������
            ShowControl(reports);
        }
    }
}