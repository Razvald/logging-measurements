namespace LogProject.Controls
{
    partial class CreateSpecializationControl
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
            btnSave = new Button();
            lblSpecializationName = new Label();
            txbTitle = new TextBox();
            txbDescription = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 15);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 23);
            label1.TabIndex = 62;
            label1.Text = "Название";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(442, 162);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(138, 48);
            btnSave.TabIndex = 61;
            btnSave.Text = "Создать";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblSpecializationName
            // 
            lblSpecializationName.AutoSize = true;
            lblSpecializationName.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblSpecializationName.Location = new Point(6, 109);
            lblSpecializationName.Margin = new Padding(6, 0, 6, 0);
            lblSpecializationName.Name = "lblSpecializationName";
            lblSpecializationName.Size = new Size(96, 23);
            lblSpecializationName.TabIndex = 60;
            lblSpecializationName.Text = "Описание";
            lblSpecializationName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbTitle
            // 
            txbTitle.Location = new Point(107, 9);
            txbTitle.Name = "txbTitle";
            txbTitle.Size = new Size(270, 29);
            txbTitle.TabIndex = 63;
            // 
            // txbDescription
            // 
            txbDescription.Location = new Point(111, 103);
            txbDescription.Name = "txbDescription";
            txbDescription.Size = new Size(453, 29);
            txbDescription.TabIndex = 64;
            // 
            // CreateSpecializationControl
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txbDescription);
            Controls.Add(txbTitle);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(lblSpecializationName);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "CreateSpecializationControl";
            Size = new Size(586, 217);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSave;
        private Label lblSpecializationName;
        private TextBox txbTitle;
        private TextBox txbDescription;
    }
}
