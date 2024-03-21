namespace log_data_well
{
    partial class MainForm
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
            btnListOrders = new Button();
            btnCompleteOrders = new Button();
            btnAnalizationData = new Button();
            btnReports = new Button();
            SuspendLayout();
            // 
            // btnListOrders
            // 
            btnListOrders.Location = new Point(12, 12);
            btnListOrders.Name = "btnListOrders";
            btnListOrders.Size = new Size(94, 29);
            btnListOrders.TabIndex = 0;
            btnListOrders.Text = "List Orders";
            btnListOrders.UseVisualStyleBackColor = true;
            btnListOrders.Click += button1_Click;
            // 
            // btnCompleteOrders
            // 
            btnCompleteOrders.Location = new Point(112, 12);
            btnCompleteOrders.Name = "btnCompleteOrders";
            btnCompleteOrders.Size = new Size(142, 29);
            btnCompleteOrders.TabIndex = 1;
            btnCompleteOrders.Text = "Complete Orders";
            btnCompleteOrders.UseVisualStyleBackColor = true;
            btnCompleteOrders.Click += button2_Click;
            // 
            // btnAnalizationData
            // 
            btnAnalizationData.Location = new Point(260, 12);
            btnAnalizationData.Name = "btnAnalizationData";
            btnAnalizationData.Size = new Size(132, 29);
            btnAnalizationData.TabIndex = 2;
            btnAnalizationData.Text = "Analization Data";
            btnAnalizationData.UseVisualStyleBackColor = true;
            btnAnalizationData.Click += button3_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(398, 12);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(94, 29);
            btnReports.TabIndex = 3;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += button4_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReports);
            Controls.Add(btnAnalizationData);
            Controls.Add(btnCompleteOrders);
            Controls.Add(btnListOrders);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnListOrders;
        private Button btnCompleteOrders;
        private Button btnAnalizationData;
        private Button btnReports;
    }
}