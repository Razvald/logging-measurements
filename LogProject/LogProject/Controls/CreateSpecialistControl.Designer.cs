namespace LogProject.Controls
{
    partial class CreateSpecialistControl
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
            cmbRole = new ComboBox();
            label1 = new Label();
            txbName = new TextBox();
            btnSave = new Button();
            lblSpecializationName = new Label();
            txbPhone = new TextBox();
            label4 = new Label();
            txbLogin = new TextBox();
            label5 = new Label();
            txbPassword = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // cmbRole
            // 
            cmbRole.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(81, 181);
            cmbRole.Margin = new Padding(4);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(171, 37);
            cmbRole.TabIndex = 44;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 15);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 31);
            label1.TabIndex = 38;
            label1.Text = "Имя";
            // 
            // txbName
            // 
            txbName.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbName.Location = new Point(81, 8);
            txbName.Margin = new Padding(4);
            txbName.Name = "txbName";
            txbName.Size = new Size(227, 38);
            txbName.TabIndex = 36;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(444, 165);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(138, 48);
            btnSave.TabIndex = 35;
            btnSave.Text = "Создать";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblSpecializationName
            // 
            lblSpecializationName.AutoSize = true;
            lblSpecializationName.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblSpecializationName.Location = new Point(8, 187);
            lblSpecializationName.Margin = new Padding(6, 0, 6, 0);
            lblSpecializationName.Name = "lblSpecializationName";
            lblSpecializationName.Size = new Size(67, 31);
            lblSpecializationName.TabIndex = 33;
            lblSpecializationName.Text = "Роль";
            lblSpecializationName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbPhone
            // 
            txbPhone.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbPhone.Location = new Point(130, 51);
            txbPhone.Margin = new Padding(4);
            txbPhone.Name = "txbPhone";
            txbPhone.Size = new Size(190, 38);
            txbPhone.TabIndex = 46;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(8, 58);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(112, 31);
            label4.TabIndex = 45;
            label4.Text = "Телефон";
            // 
            // txbLogin
            // 
            txbLogin.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbLogin.Location = new Point(102, 92);
            txbLogin.Margin = new Padding(4);
            txbLogin.Name = "txbLogin";
            txbLogin.Size = new Size(227, 38);
            txbLogin.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(8, 99);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(84, 31);
            label5.TabIndex = 47;
            label5.Text = "Логин";
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbPassword.Location = new Point(116, 133);
            txbPassword.Margin = new Padding(4);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(227, 38);
            txbPassword.TabIndex = 50;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(8, 140);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(98, 31);
            label6.TabIndex = 49;
            label6.Text = "Пароль";
            // 
            // CreateSpecialistControl
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txbPassword);
            Controls.Add(label6);
            Controls.Add(txbLogin);
            Controls.Add(label5);
            Controls.Add(txbPhone);
            Controls.Add(label4);
            Controls.Add(cmbRole);
            Controls.Add(label1);
            Controls.Add(txbName);
            Controls.Add(btnSave);
            Controls.Add(lblSpecializationName);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "CreateSpecialistControl";
            Size = new Size(586, 217);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbRole;
        private CheckBox chbCreateNewClient;
        private TextBox txbClientEmail;
        private TextBox txbClientPhone;
        private Label label2;
        private Label label1;
        private ComboBox cmbClients;
        private TextBox txbName;
        private Button btnSave;
        private Label lblClientName;
        private Label lblSpecializationName;
        private TextBox txbPhone;
        private Label label4;
        private TextBox txbLogin;
        private Label label5;
        private TextBox txbPassword;
        private Label label6;
    }
}
