namespace LogProject.Controls
{
    partial class CreateOrderControl
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
            lblClientName = new Label();
            lblSpecializationName = new Label();
            btnSave = new Button();
            txbClientName = new TextBox();
            cmbClients = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txbClientPhone = new TextBox();
            label3 = new Label();
            txbClientEmail = new TextBox();
            chbCreateNewClient = new CheckBox();
            cmbSpecialization = new ComboBox();
            SuspendLayout();
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblClientName.Location = new Point(4, 20);
            lblClientName.Margin = new Padding(4, 0, 4, 0);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(79, 23);
            lblClientName.TabIndex = 20;
            lblClientName.Text = "Клиент ";
            // 
            // lblSpecializationName
            // 
            lblSpecializationName.AutoSize = true;
            lblSpecializationName.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblSpecializationName.Location = new Point(4, 172);
            lblSpecializationName.Margin = new Padding(4, 0, 4, 0);
            lblSpecializationName.Name = "lblSpecializationName";
            lblSpecializationName.Size = new Size(145, 23);
            lblSpecializationName.TabIndex = 17;
            lblSpecializationName.Text = "Специализация";
            lblSpecializationName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(476, 161);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 46);
            btnSave.TabIndex = 21;
            btnSave.Text = "Создать";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txbClientName
            // 
            txbClientName.Enabled = false;
            txbClientName.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbClientName.Location = new Point(423, 12);
            txbClientName.Name = "txbClientName";
            txbClientName.Size = new Size(160, 32);
            txbClientName.TabIndex = 23;
            // 
            // cmbClients
            // 
            cmbClients.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(90, 12);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(121, 31);
            cmbClients.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(294, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 23);
            label1.TabIndex = 25;
            label1.Text = "Имя клиента";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(294, 62);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(85, 23);
            label2.TabIndex = 26;
            label2.Text = "Телефон";
            // 
            // txbClientPhone
            // 
            txbClientPhone.Enabled = false;
            txbClientPhone.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbClientPhone.Location = new Point(386, 53);
            txbClientPhone.Name = "txbClientPhone";
            txbClientPhone.Size = new Size(160, 32);
            txbClientPhone.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(294, 104);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 23);
            label3.TabIndex = 28;
            label3.Text = "Почта";
            // 
            // txbClientEmail
            // 
            txbClientEmail.Enabled = false;
            txbClientEmail.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbClientEmail.Location = new Point(365, 95);
            txbClientEmail.Name = "txbClientEmail";
            txbClientEmail.Size = new Size(160, 32);
            txbClientEmail.TabIndex = 29;
            // 
            // chbCreateNewClient
            // 
            chbCreateNewClient.AutoSize = true;
            chbCreateNewClient.Location = new Point(4, 57);
            chbCreateNewClient.Name = "chbCreateNewClient";
            chbCreateNewClient.Size = new Size(224, 25);
            chbCreateNewClient.TabIndex = 31;
            chbCreateNewClient.Text = "Создать нового клиента";
            chbCreateNewClient.UseVisualStyleBackColor = true;
            chbCreateNewClient.CheckedChanged += chbCreateNewClient_CheckedChanged;
            // 
            // cmbSpecialization
            // 
            cmbSpecialization.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbSpecialization.FormattingEnabled = true;
            cmbSpecialization.Location = new Point(156, 164);
            cmbSpecialization.Name = "cmbSpecialization";
            cmbSpecialization.Size = new Size(121, 31);
            cmbSpecialization.TabIndex = 32;
            // 
            // CreateOrderControl
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbSpecialization);
            Controls.Add(chbCreateNewClient);
            Controls.Add(txbClientEmail);
            Controls.Add(label3);
            Controls.Add(txbClientPhone);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbClients);
            Controls.Add(txbClientName);
            Controls.Add(btnSave);
            Controls.Add(lblClientName);
            Controls.Add(lblSpecializationName);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "CreateOrderControl";
            Size = new Size(586, 210);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClientName;
        private Label lblSpecializationName;
        private Button btnSave;
        private TextBox txbClientName;
        private ComboBox cmbClients;
        private Label label1;
        private Label label2;
        private TextBox txbClientPhone;
        private Label label3;
        private TextBox txbClientEmail;
        private CheckBox chbCreateNewClient;
        private ComboBox cmbSpecialization;
    }
}
