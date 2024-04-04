namespace LogProject.Controls
{
    partial class DataAnalizeControl
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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            cmbWellType = new ComboBox();
            label1 = new Label();
            btnReturn = new Button();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(3, 80);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(578, 627);
            formsPlot1.TabIndex = 0;
            // 
            // cmbWellType
            // 
            cmbWellType.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbWellType.FormattingEnabled = true;
            cmbWellType.Location = new Point(3, 41);
            cmbWellType.Name = "cmbWellType";
            cmbWellType.Size = new Size(293, 47);
            cmbWellType.TabIndex = 1;
            cmbWellType.SelectedIndexChanged += cmbWellType_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 11);
            label1.Name = "label1";
            label1.Size = new Size(161, 27);
            label1.TabIndex = 3;
            label1.Text = "Тип скважины";
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(302, 41);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(91, 47);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Назад";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // DataAnalizeControl
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnReturn);
            Controls.Add(label1);
            Controls.Add(cmbWellType);
            Controls.Add(formsPlot1);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "DataAnalizeControl";
            Size = new Size(584, 710);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ScottPlot.WinForms.FormsPlot formsPlot1;
        private ComboBox cmbWellType;
        private Label label1;
        private Button btnReturn;
    }
}
