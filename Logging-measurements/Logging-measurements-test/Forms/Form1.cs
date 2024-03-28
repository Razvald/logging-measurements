using Logging_measurements_test.Models;
using Logging_measurements_test.Services.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Logging_measurements_test
{
    internal partial class Form1 : Form
    {
        private readonly IDbWorker _db;

        public Form1(IDbWorker db)
        {
            InitializeComponent();
            _db = db;
        }

        private void HideForeignKeyColumns<T>()
        {
            foreach (DataGridViewColumn column in dvgTest.Columns)
            {
                // Получаем свойство по имени столбца
                var property = typeof(T).GetProperty(column.Name, BindingFlags.Public | BindingFlags.Instance);

                if (property != null)
                {
                    // Проверяем, является ли свойство виртуальным
                    bool isVirtual = property.GetGetMethod().IsVirtual;

                    // Скрываем столбец, если он является виртуальным навигационным свойством или коллекцией
                    if (isVirtual)
                    {
                        column.Visible = false;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dvgTest.DataSource = _db.Wells;
            HideForeignKeyColumns<Well>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dvgTest.DataSource = _db.Specialists;
            HideForeignKeyColumns<Specialist>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dvgTest.DataSource = _db.Specializations;
            HideForeignKeyColumns<Specialization>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dvgTest.DataSource = _db.SpecialistSpecializations;
            HideForeignKeyColumns<SpecialistSpecialization>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dvgTest.DataSource = _db.Orders;
            HideForeignKeyColumns<Order>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dvgTest.DataSource = _db.Clients;
            HideForeignKeyColumns<Client>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dvgTest.DataSource = _db.WellMeasurements;
            HideForeignKeyColumns<WellMeasurement>();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dvgTest.DataSource = _db.WellTypes;
            HideForeignKeyColumns<WellType>();
        }
    }
}
