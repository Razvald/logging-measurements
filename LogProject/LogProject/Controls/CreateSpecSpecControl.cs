using LogProject.Database;
using LogProject.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogProject.Controls
{
    public partial class CreateSpecSpecControl : UserControl
    {
        private readonly AppDbContext _dbContext;

        private List<Specialist> _specialists;
        private List<Specialization> _specializations;

        public string Specialist => cmbSpecialist.SelectedItem?.ToString();
        public string Specialization => cmbSpecialisation.SelectedItem?.ToString();

        public CreateSpecSpecControl(List<Specialist> specialists, List<Specialization> specializations, AppDbContext dbContext)
        {
            InitializeComponent();
            _specialists = specialists;
            _specializations = specializations;
            _dbContext = dbContext;
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
            int parsedSpecialistID = int.Parse(Specialist);
            int parsedSpecializationID = int.Parse(Specialization);

            SpecialistSpecialization specialistSpecialization = new SpecialistSpecialization
            {
                SpecialistID = parsedSpecialistID,
                SpecializationID = parsedSpecializationID
            };

            try
            {
                _dbContext.SpecialistSpecializations.Add(specialistSpecialization);
                _dbContext.SaveChanges();
                MessageBox.Show("Специалист успешно создан.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void cmbSpecialist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Specialist != null)
            {
                int selectedSpecialistID = int.Parse(Specialist);

                // Находим специалиста по его идентификатору
                Specialist selectedSpecialist = _dbContext.Specialists
                    .Include(s => s.SpecialistSpecializations)
                    .ThenInclude(ss => ss.Specialization)
                    .FirstOrDefault(s => s.SpecialistID == selectedSpecialistID);

                if (selectedSpecialist != null)
                {
                    label2.Text = selectedSpecialist.FullName;

                    var specialization = selectedSpecialist.SpecialistSpecializations.FirstOrDefault();
                    if (specialization != null)
                    {
                        label4.Text = specialization.Specialization.Name;
                    }
                    else
                    {
                        label4.Text = "Нет специализации";
                    }
                }
            }
            else
            {
                label2.Text = "";
                label4.Text = "";
            }
        }

        private void cmbSpecialisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Specialization != null)
            {
                int selectedSpecializationID = int.Parse(Specialization);

                Specialization selectedSpecialization = _dbContext.Specializations
                    .FirstOrDefault(s => s.SpecializationID == selectedSpecializationID); ;

                if (selectedSpecialization != null)
                {
                    label3.Text = selectedSpecialization.Name;
                }
            }
            else
            {
                label3.Text = "";
            }
        }
    }
}
