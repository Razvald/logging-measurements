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

            var uniqueWellTypes = _wells.Select(w => w.WellType.Name).Distinct().ToList();

            List<PieSlice> slices = new();

            foreach (var wellType in uniqueWellTypes)
            {
                int count = _wells.Count(w => w.WellType.Name == wellType);

                PieSlice slice = new()
                {
                    Value = count,
                    FillColor = GetColorForWellType(wellType),
                    Label = wellType
                };

                slices.Add(slice);
            }

            var pie = formsPlot1.Plot.Add.Pie(slices);
            pie.ExplodeFraction = .1;
            pie.ShowSliceLabels = true;
            pie.SliceLabelDistance = 1.8;
            formsPlot1.Plot.Axes.SetLimits(-2.5, 2, -2.2, 2.4);

            formsPlot1.Plot.XLabel("");
            formsPlot1.Plot.YLabel("");

            formsPlot1.Refresh();
        }

        private static ScottPlot.Color GetColorForWellType(string wellType)
        {
            return wellType switch
            {
                "Глубокая скважина" => Colors.Red,
                "Подземный газовый резервуар" => Colors.Blue,
                "Нефтяная скважина" => Colors.Green,
                _ => Colors.Gray
            };
        }

        private void cmbWellType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlot1();
        }

        private void UpdatePlot1()
        {
            formsPlot1.Plot.Clear();

            Plot plot = formsPlot1.Plot;

            string selectedWellType = cmbWellType.SelectedItem?.ToString();

            var filteredWells = _wells.Where(w => w.WellType.Name == selectedWellType).ToArray();

            var filteredWellMeasurements = _wellMeasurements
                .Where(wm => filteredWells.Any(w => w.WellID == wm.WellID))
                .ToArray();

            // Создать массив значений для столбчатой диаграммы
            double[] values = filteredWellMeasurements.Select(wm => wm.MeasurementValue).ToArray();
            double[] depths = filteredWells.Select(m => m.Depth).ToArray();
            
            Array.Sort(depths);

            var s = plot.Add.Scatter(depths, values);
            s.Smooth = true;

            plot.Axes.SetLimits(depths.Min(), depths.Max(), values.Min(), values.Max());

            plot.XLabel("Глубина");
            plot.YLabel("Значение измерения");

            formsPlot1.Refresh();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UpdatePlot();
        }
    }
}
