namespace LogProject
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txbLogin = new TextBox();
            txbPassword = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            cmbDatabases = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // txbLogin
            // 
            txbLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txbLogin.Location = new Point(14, 135);
            txbLogin.Margin = new Padding(3, 4, 3, 4);
            txbLogin.Name = "txbLogin";
            txbLogin.Size = new Size(235, 35);
            txbLogin.TabIndex = 0;
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txbPassword.Location = new Point(14, 207);
            txbPassword.Margin = new Padding(3, 4, 3, 4);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(235, 35);
            txbPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(73, 327);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(105, 47);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Вход";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 104);
            label1.Name = "label1";
            label1.Size = new Size(75, 27);
            label1.TabIndex = 3;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(14, 175);
            label2.Name = "label2";
            label2.Size = new Size(87, 27);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // cmbDatabases
            // 
            cmbDatabases.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDatabases.FormattingEnabled = true;
            cmbDatabases.Location = new Point(14, 48);
            cmbDatabases.Name = "cmbDatabases";
            cmbDatabases.Size = new Size(235, 34);
            cmbDatabases.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(14, 18);
            label3.Name = "label3";
            label3.Size = new Size(140, 27);
            label3.TabIndex = 6;
            label3.Text = "База данных";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 399);
            Controls.Add(label3);
            Controls.Add(cmbDatabases);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(txbPassword);
            Controls.Add(txbLogin);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            Text = "Form1";
            FormClosed += LoginForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbLogin;
        private TextBox txbPassword;
        private Button btnLogin;
        private Label label1;
        private Label label2;
        private ComboBox cmbDatabases;
        private Label label3;
    }
}
