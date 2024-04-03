using LogProject.Database.Entities;

namespace LogProject.Controls
{
    public partial class CreateSpecSpecControl : UserControl
    {
        public event EventHandler SaveClicked;
        public event EventHandler Spec1Clicked;
        public event EventHandler Spec2Clicked;
        private List<Specialist> _specialists;
        private List<Specialization> _specializations;

        public string Specialist => cmbSpecialist.SelectedItem?.ToString();
        public string Specialization => cmbSpecialisation.SelectedItem?.ToString();

        public CreateSpecSpecControl(List<Specialist> specialists, List<Specialization> specializations)
        {
            InitializeComponent();
            _specialists = specialists;
            _specializations = specializations;
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cmbSpecialist.Items.Clear();
            foreach (var specialist in _specialists)
            {
                cmbSpecialist.Items.Add(specialist.SpecialistID);
            }

            cmbSpecialisation.Items.Clear();
            foreach (var specialization in _specializations)
            {
                cmbSpecialisation.Items.Add(specialization.SpecializationID);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void cmbSpecialist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Spec1Clicked?.Invoke(this, EventArgs.Empty);
        }

        private void cmbSpecialisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Spec2Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
