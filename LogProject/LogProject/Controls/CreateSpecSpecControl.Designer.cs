namespace LogProject.Controls
{
    partial class CreateSpecSpecControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            cmbSpecialisation = new ComboBox();
            label1 = new Label();
            btnSave = new Button();
            lblSpecializationName = new Label();
            cmbSpecialist = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // cmbSpecialisation
            // 
            cmbSpecialisation.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbSpecialisation.FormattingEnabled = true;
            cmbSpecialisation.Location = new Point(204, 113);
            cmbSpecialisation.Margin = new Padding(4);
            cmbSpecialisation.Name = "cmbSpecialisation";
            cmbSpecialisation.Size = new Size(171, 37);
            cmbSpecialisation.TabIndex = 55;
            cmbSpecialisation.SelectedIndexChanged += cmbSpecialisation_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 15);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 31);
            label1.TabIndex = 54;
            label1.Text = "Специалист";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(442, 162);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(138, 48);
            btnSave.TabIndex = 52;
            btnSave.Text = "Создать";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblSpecializationName
            // 
            lblSpecializationName.AutoSize = true;
            lblSpecializationName.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblSpecializationName.Location = new Point(6, 118);
            lblSpecializationName.Margin = new Padding(6, 0, 6, 0);
            lblSpecializationName.Name = "lblSpecializationName";
            lblSpecializationName.Size = new Size(188, 31);
            lblSpecializationName.TabIndex = 51;
            lblSpecializationName.Text = "Специализация";
            lblSpecializationName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbSpecialist
            // 
            cmbSpecialist.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbSpecialist.FormattingEnabled = true;
            cmbSpecialist.Location = new Point(165, 9);
            cmbSpecialist.Margin = new Padding(4);
            cmbSpecialist.Name = "cmbSpecialist";
            cmbSpecialist.Size = new Size(171, 37);
            cmbSpecialist.TabIndex = 56;
            cmbSpecialist.SelectedIndexChanged += cmbSpecialist_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 46);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(21, 31);
            label2.TabIndex = 57;
            label2.Text = " ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 162);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(21, 31);
            label3.TabIndex = 58;
            label3.Text = " ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 77);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(21, 31);
            label4.TabIndex = 59;
            label4.Text = " ";
            // 
            // CreateSpecSpecControl
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbSpecialist);
            Controls.Add(cmbSpecialisation);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(lblSpecializationName);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "CreateSpecSpecControl";
            Size = new Size(586, 217);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbSpecialisation;
        private Label label1;
        private Button btnSave;
        private Label lblSpecializationName;
        private ComboBox cmbSpecialist;
        public Label label2;
        public Label label3;
        public Label label4;
    }
}
