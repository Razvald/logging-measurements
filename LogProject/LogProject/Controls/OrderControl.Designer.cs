namespace LogProject.Controls
{
    partial class OrderControl
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
            lblClientPhone = new Label();
            lblSpecializationName = new Label();
            lblSpecializationDescription = new Label();
            lblOrderDate = new Label();
            lblClientName = new Label();
            lblOrderStatus = new Label();
            label3 = new Label();
            lblOrderId = new Label();
            SuspendLayout();
            // 
            // lblClientPhone
            // 
            lblClientPhone.AutoSize = true;
            lblClientPhone.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblClientPhone.Location = new Point(4, 39);
            lblClientPhone.Margin = new Padding(4, 0, 4, 0);
            lblClientPhone.Name = "lblClientPhone";
            lblClientPhone.Size = new Size(112, 31);
            lblClientPhone.TabIndex = 3;
            lblClientPhone.Text = "Телефон";
            // 
            // lblSpecializationName
            // 
            lblSpecializationName.AutoSize = true;
            lblSpecializationName.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblSpecializationName.Location = new Point(4, 80);
            lblSpecializationName.Margin = new Padding(4, 0, 4, 0);
            lblSpecializationName.Name = "lblSpecializationName";
            lblSpecializationName.Size = new Size(211, 34);
            lblSpecializationName.TabIndex = 4;
            lblSpecializationName.Text = "Специализация";
            lblSpecializationName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSpecializationDescription
            // 
            lblSpecializationDescription.AutoSize = true;
            lblSpecializationDescription.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblSpecializationDescription.Location = new Point(4, 114);
            lblSpecializationDescription.Margin = new Padding(4, 0, 4, 0);
            lblSpecializationDescription.Name = "lblSpecializationDescription";
            lblSpecializationDescription.Size = new Size(125, 31);
            lblSpecializationDescription.TabIndex = 5;
            lblSpecializationDescription.Text = "Описание";
            lblSpecializationDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrderDate.Location = new Point(494, 190);
            lblOrderDate.Margin = new Padding(4, 0, 4, 0);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(140, 31);
            lblOrderDate.TabIndex = 6;
            lblOrderDate.Text = "01.01.0001";
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblClientName.Location = new Point(4, 5);
            lblClientName.Margin = new Padding(4, 0, 4, 0);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(116, 34);
            lblClientName.TabIndex = 8;
            lblClientName.Text = "Клиент ";
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.AutoSize = true;
            lblOrderStatus.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrderStatus.Location = new Point(4, 186);
            lblOrderStatus.Margin = new Padding(4, 0, 4, 0);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(100, 34);
            lblOrderStatus.TabIndex = 10;
            lblOrderStatus.Text = "Статус";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(305, 154);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(329, 34);
            label3.TabIndex = 14;
            label3.Text = "Дата поступления заказа";
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrderId.Location = new Point(587, 0);
            lblOrderId.Margin = new Padding(4, 0, 4, 0);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(47, 42);
            lblOrderId.TabIndex = 15;
            lblOrderId.Text = "Id";
            // 
            // OrderControl
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(lblOrderId);
            Controls.Add(label3);
            Controls.Add(lblOrderStatus);
            Controls.Add(lblClientName);
            Controls.Add(lblOrderDate);
            Controls.Add(lblSpecializationDescription);
            Controls.Add(lblSpecializationName);
            Controls.Add(lblClientPhone);
            Cursor = Cursors.Hand;
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "OrderControl";
            Size = new Size(638, 221);
            Click += OrderControl_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSpecializationName;
        private Label lblClientName;
        private Label lblClientPhone;
        private Label label6;
        private Label label7;
        private Label lblSpecializationDescription;
        private Label label9;
        private Label lblOrderDate;
        private Label lblOrderStatus;
        private Label label3;
        private Label lblOrderId;
    }
}
