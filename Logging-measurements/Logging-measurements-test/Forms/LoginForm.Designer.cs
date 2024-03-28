namespace Logging_measurements_test.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txbLogin = new TextBox();
            txbPassword = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txbLogin
            // 
            txbLogin.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txbLogin.Location = new Point(163, 157);
            txbLogin.Name = "txbLogin";
            txbLogin.Size = new Size(173, 34);
            txbLogin.TabIndex = 0;
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txbPassword.Location = new Point(163, 257);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(173, 34);
            txbPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(186, 318);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(118, 38);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(163, 128);
            label1.Name = "label1";
            label1.Size = new Size(72, 26);
            label1.TabIndex = 3;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(163, 228);
            label2.Name = "label2";
            label2.Size = new Size(82, 26);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 393);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(txbPassword);
            Controls.Add(txbLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbLogin;
        private TextBox txbPassword;
        private Button btnLogin;
        private Label label1;
        private Label label2;
    }
}