namespace LogProject.Controls
{
    public partial class CreateSpecializationControl : UserControl
    {
        public event EventHandler SaveClicked;

        public string Title => txbTitle.Text.ToString();
        public string Description => txbDescription.Text.ToString();

        public CreateSpecializationControl()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
