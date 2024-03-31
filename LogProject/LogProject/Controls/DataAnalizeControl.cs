using LogProject.Database.Entities;
using ScottPlot;

namespace LogProject.Controls
{
    public partial class DataAnalizeControl : UserControl
    {
        private readonly Well[] _wells;
        private readonly WellMeasurement[] _wellMeasurements;
        private readonly WellType[] _wellTypes;
        public DataAnalizeControl(Well[] wells, WellMeasurement[] wellMeasurements, WellType[] wellTypes)
        {
            InitializeComponent();
            _wells = wells;
            _wellMeasurements = wellMeasurements;
            _wellTypes = wellTypes;
            FillWellTypeComboBox();
            UpdatePlot();
        }

        private void FillWellTypeComboBox()
        {
            cmbWellType.Items.Clear();
            foreach (var wellType in _wellTypes)
            {
                cmbWellType.Items.Add(wellType.Name);
            }
        }

        private void UpdatePlot()
        {
            formsPlot1.Plot.Clear();

            // Получаем уникальные типы скважин
            var uniqueWellTypes = _wells.Select(w => w.WellType.Name).Distinct().ToList();

            // Создаем список сегментов для диаграммы
            List<PieSlice> slices = new();

            // Для каждого уникального типа скважины добавляем сегмент в диаграмму
            foreach (var wellType in uniqueWellTypes)
            {
                // Получаем количество скважин с данным типом
                int count = _wells.Count(w => w.WellType.Name == wellType);

                // Создаем сегмент с соответствующими значениями
                PieSlice slice = new()
                {
                    Value = count, // Значение сегмента равно количеству скважин с данным типом
                    FillColor = GetColorForWellType(wellType), // Цвет сегмента зависит от типа скважины
                    Label = wellType // Метка сегмента - название типа скважины
                };

                // Добавляем сегмент в список
                slices.Add(slice);
            }

            // Добавляем круговую диаграмму на график
            var pie = formsPlot1.Plot.Add.Pie(slices);
            pie.ExplodeFraction = .1;
            pie.ShowSliceLabels = true;
            pie.SliceLabelDistance = 1.3;

            // Установить название осей
            formsPlot1.Plot.XLabel("");
            formsPlot1.Plot.YLabel("");

            // Обновляем график
            formsPlot1.Refresh();
        }

        // Метод для определения цвета сегмента в зависимости от типа скважины
        private static ScottPlot.Color GetColorForWellType(string wellType)
        {
            return wellType switch
            {
                "Глубокая скважина" => Colors.Red,
                "Подземный газовый резервуар" => Colors.Blue,
                "Нефтяная скважина" => Colors.Green,
                _ => Colors.Gray, // Если тип скважины неизвестен, возвращаем серый цвет
            };
        }

        private void cmbWellType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlot1();
        }

        private void UpdatePlot1()
        {
            formsPlot1.Plot.Clear();

            // Получаем выбранный тип скважины из комбо бокса
            string selectedWellType = cmbWellType.SelectedItem?.ToString();

            // Отфильтровать данные скважин для выбранного типа
            var filteredWells = _wells.Where(w => w.WellType.Name == selectedWellType).ToArray();

            // Получить измерения для отфильтрованных скважин
            var filteredWellMeasurements = _wellMeasurements
                .Where(wm => filteredWells.Any(w => w.WellID == wm.WellID))
                .ToArray();

            // Создать массив значений для столбчатой диаграммы
            double[] values = filteredWellMeasurements.Select(wm => wm.MeasurementValue / 10).ToArray();
            double[] val = filteredWells.Select(m => m.Depth / 100 * -1).ToArray();

            // Добавить столбчатую диаграмму
            var barPlot = formsPlot1.Plot.Add.Bars(values);
            var barPlot1 = formsPlot1.Plot.Add.Bars(val);

            foreach (var bar in barPlot.Bars)
            {
                bar.Label = (bar.Value * 10).ToString();
            }

            foreach (var bar in barPlot1.Bars)
            {
                bar.Label = (bar.Value * 100).ToString();
            }

            // Установить название осей
            formsPlot1.Plot.XLabel("Скважина");
            formsPlot1.Plot.YLabel("Значение измерения \n Глубина скважины");

            // Обновляем график
            formsPlot1.Refresh();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UpdatePlot();
        }
    }
}
