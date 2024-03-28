namespace Logging_measurements_test
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
            btnListOrders.Location = new Point(10, 9);
            btnListOrders.Margin = new Padding(3, 2, 3, 2);
            btnListOrders.Name = "btnListOrders";
            btnListOrders.Size = new Size(82, 22);
            btnListOrders.TabIndex = 0;
            btnListOrders.Text = "List Orders";
            btnListOrders.UseVisualStyleBackColor = true;
            btnListOrders.Click += button1_Click;
            // 
            // btnCompleteOrders
            // 
            btnCompleteOrders.Location = new Point(98, 9);
            btnCompleteOrders.Margin = new Padding(3, 2, 3, 2);
            btnCompleteOrders.Name = "btnCompleteOrders";
            btnCompleteOrders.Size = new Size(124, 22);
            btnCompleteOrders.TabIndex = 1;
            btnCompleteOrders.Text = "Complete Orders";
            btnCompleteOrders.UseVisualStyleBackColor = true;
            btnCompleteOrders.Click += button2_Click;
            // 
            // btnAnalizationData
            // 
            btnAnalizationData.Location = new Point(228, 9);
            btnAnalizationData.Margin = new Padding(3, 2, 3, 2);
            btnAnalizationData.Name = "btnAnalizationData";
            btnAnalizationData.Size = new Size(116, 22);
            btnAnalizationData.TabIndex = 2;
            btnAnalizationData.Text = "Analization Data";
            btnAnalizationData.UseVisualStyleBackColor = true;
            btnAnalizationData.Click += button3_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(348, 9);
            btnReports.Margin = new Padding(3, 2, 3, 2);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(82, 22);
            btnReports.TabIndex = 3;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += button4_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnReports);
            Controls.Add(btnAnalizationData);
            Controls.Add(btnCompleteOrders);
            Controls.Add(btnListOrders);
            Margin = new Padding(3, 2, 3, 2);
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