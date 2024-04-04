using LogProject.Database;
using LogProject.Database.Entities;

namespace LogProject.Controls
{
    public partial class CreateSpecializationControl : UserControl
    {
        private readonly AppDbContext _dbContext;

        public string Title => txbTitle.Text.ToString();
        public string Description => txbDescription.Text.ToString();

        public CreateSpecializationControl(AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Specialization specialization = new Specialization
            {
                Name = Title,
                Description = Description
            };

            try
            {
                _dbContext.Specializations.Add(specialization);
                _dbContext.SaveChanges();
                MessageBox.Show("Специализация успешно создана.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }
    }
}
