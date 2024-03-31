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
            SuspendLayout();
            // 
            // txbLogin
            // 
            txbLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txbLogin.Location = new Point(12, 45);
            txbLogin.Name = "txbLogin";
            txbLogin.Size = new Size(206, 29);
            txbLogin.TabIndex = 0;
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txbPassword.Location = new Point(12, 155);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(206, 29);
            txbPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(64, 245);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(92, 35);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Вход";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(61, 21);
            label1.TabIndex = 3;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 131);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 299);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(txbPassword);
            Controls.Add(txbLogin);
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
    }
}
