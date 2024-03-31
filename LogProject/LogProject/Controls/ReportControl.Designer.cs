namespace LogProject.Controls
{
    partial class ReportControl
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label6 = new Label();
            label7 = new Label();
            cmbOrder = new ComboBox();
            cmbWellType = new ComboBox();
            txbWellDepth = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            txbMeasurementValue = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(74, 11);
            label1.Name = "label1";
            label1.Size = new Size(83, 31);
            label1.TabIndex = 0;
            label1.Text = "Отчет";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(52, 72);
            label2.Name = "label2";
            label2.Size = new Size(127, 21);
            label2.TabIndex = 1;
            label2.Text = "Текущий заказ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(52, 140);
            label3.Name = "label3";
            label3.Size = new Size(128, 21);
            label3.TabIndex = 2;
            label3.Text = "Тип скважины";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(33, 277);
            label6.Name = "label6";
            label6.Size = new Size(173, 21);
            label6.TabIndex = 5;
            label6.Text = "Значение измерения";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(33, 207);
            label7.Name = "label7";
            label7.Size = new Size(162, 21);
            label7.TabIndex = 6;
            label7.Text = "Глубина скважины";
            // 
            // cmbOrder
            // 
            cmbOrder.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbOrder.FormattingEnabled = true;
            cmbOrder.Location = new Point(52, 96);
            cmbOrder.Name = "cmbOrder";
            cmbOrder.Size = new Size(127, 29);
            cmbOrder.TabIndex = 7;
            cmbOrder.SelectedIndexChanged += cmbOrder_SelectedIndexChanged;
            // 
            // cmbWellType
            // 
            cmbWellType.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbWellType.FormattingEnabled = true;
            cmbWellType.Location = new Point(52, 164);
            cmbWellType.Name = "cmbWellType";
            cmbWellType.Size = new Size(127, 29);
            cmbWellType.TabIndex = 10;
            // 
            // txbWellDepth
            // 
            txbWellDepth.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txbWellDepth.Location = new Point(52, 231);
            txbWellDepth.Name = "txbWellDepth";
            txbWellDepth.Size = new Size(127, 29);
            txbWellDepth.TabIndex = 13;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Window;
            btnCancel.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(3, 404);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(115, 37);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Отказаться";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Window;
            btnSave.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(124, 404);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 37);
            btnSave.TabIndex = 15;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txbMeasurementValue
            // 
            txbMeasurementValue.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txbMeasurementValue.Location = new Point(52, 301);
            txbMeasurementValue.Name = "txbMeasurementValue";
            txbMeasurementValue.Size = new Size(127, 29);
            txbMeasurementValue.TabIndex = 16;
            // 
            // ReportControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(txbMeasurementValue);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txbWellDepth);
            Controls.Add(cmbWellType);
            Controls.Add(cmbOrder);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ReportControl";
            Size = new Size(238, 444);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private Button btnCancel;
        private Button btnSave;
        public ComboBox cmbOrder;
        public ComboBox cmbWellType;
        public TextBox txbWellDepth;
        public TextBox txbMeasurementValue;
    }
}
