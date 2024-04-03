namespace LogProject.Forms
{
    partial class MainForm
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
            btnOrderList = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnMyOrders = new Button();
            btnReport = new Button();
            btnGraph = new Button();
            cmbAdd = new ComboBox();
            SuspendLayout();
            // 
            // btnOrderList
            // 
            btnOrderList.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnOrderList.Location = new Point(12, 12);
            btnOrderList.Name = "btnOrderList";
            btnOrderList.Size = new Size(132, 37);
            btnOrderList.TabIndex = 0;
            btnOrderList.Text = "Доступные заказы";
            btnOrderList.UseVisualStyleBackColor = true;
            btnOrderList.Click += btnOrderList_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanel1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            flowLayoutPanel1.Location = new Point(12, 55);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(626, 729);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnMyOrders
            // 
            btnMyOrders.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMyOrders.Location = new Point(150, 12);
            btnMyOrders.Name = "btnMyOrders";
            btnMyOrders.Size = new Size(127, 37);
            btnMyOrders.TabIndex = 2;
            btnMyOrders.Text = "Принятые заказы";
            btnMyOrders.UseVisualStyleBackColor = true;
            btnMyOrders.Click += btnMyOrders_Click;
            // 
            // btnReport
            // 
            btnReport.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnReport.Location = new Point(283, 12);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(122, 37);
            btnReport.TabIndex = 3;
            btnReport.Text = "Составить отчет";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnGraph
            // 
            btnGraph.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnGraph.Location = new Point(411, 12);
            btnGraph.Name = "btnGraph";
            btnGraph.Size = new Size(67, 37);
            btnGraph.TabIndex = 5;
            btnGraph.Text = "График";
            btnGraph.UseVisualStyleBackColor = true;
            btnGraph.Visible = false;
            btnGraph.Click += btnGraph_Click;
            // 
            // cmbAdd
            // 
            cmbAdd.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbAdd.FormattingEnabled = true;
            cmbAdd.Location = new Point(484, 18);
            cmbAdd.Name = "cmbAdd";
            cmbAdd.Size = new Size(154, 25);
            cmbAdd.TabIndex = 6;
            cmbAdd.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 796);
            Controls.Add(cmbAdd);
            Controls.Add(btnGraph);
            Controls.Add(btnReport);
            Controls.Add(btnMyOrders);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnOrderList);
            MaximumSize = new Size(666, 835);
            MinimumSize = new Size(666, 600);
            Name = "MainForm";
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOrderList;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnMyOrders;
        private Button btnReport;
        private Button btnGraph;
        private ComboBox cmbAdd;
    }
}