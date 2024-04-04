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
            btnOrderList.Location = new Point(12, 13);
            btnOrderList.Margin = new Padding(3, 4, 3, 4);
            btnOrderList.Name = "btnOrderList";
            btnOrderList.Size = new Size(169, 52);
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
            flowLayoutPanel1.Location = new Point(14, 73);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(756, 971);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnMyOrders
            // 
            btnMyOrders.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMyOrders.Location = new Point(187, 13);
            btnMyOrders.Margin = new Padding(3, 4, 3, 4);
            btnMyOrders.Name = "btnMyOrders";
            btnMyOrders.Size = new Size(173, 52);
            btnMyOrders.TabIndex = 2;
            btnMyOrders.Text = "Принятые заказы";
            btnMyOrders.UseVisualStyleBackColor = true;
            btnMyOrders.Click += btnMyOrders_Click;
            // 
            // btnReport
            // 
            btnReport.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnReport.Location = new Point(366, 13);
            btnReport.Margin = new Padding(3, 4, 3, 4);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(156, 52);
            btnReport.TabIndex = 3;
            btnReport.Text = "Составить отчет";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnGraph
            // 
            btnGraph.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnGraph.Location = new Point(528, 13);
            btnGraph.Margin = new Padding(3, 4, 3, 4);
            btnGraph.Name = "btnGraph";
            btnGraph.Size = new Size(77, 52);
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
            cmbAdd.Location = new Point(611, 27);
            cmbAdd.Margin = new Padding(3, 4, 3, 4);
            cmbAdd.Name = "cmbAdd";
            cmbAdd.Size = new Size(159, 29);
            cmbAdd.TabIndex = 6;
            cmbAdd.Visible = false;
            cmbAdd.SelectedIndexChanged += cmbAdd_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 1051);
            Controls.Add(cmbAdd);
            Controls.Add(btnGraph);
            Controls.Add(btnReport);
            Controls.Add(btnMyOrders);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnOrderList);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(800, 1200);
            MinimumSize = new Size(759, 784);
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