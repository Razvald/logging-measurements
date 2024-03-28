namespace Logging_measurements_test.Controlers
{
    partial class ListOrdersControl
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
            lblDate = new Label();
            lblSpecialization = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(0, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(50, 20);
            lblDate.TabIndex = 0;
            lblDate.Text = "label1";
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.Location = new Point(0, 39);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(50, 20);
            lblSpecialization.TabIndex = 1;
            lblSpecialization.Text = "label2";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(0, 80);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "label3";
            // 
            // ListOrdersControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStatus);
            Controls.Add(lblSpecialization);
            Controls.Add(lblDate);
            Name = "ListOrdersControl";
            Size = new Size(171, 167);
            Load += ListOrdersControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDate;
        private Label lblSpecialization;
        private Label lblStatus;
    }
}
