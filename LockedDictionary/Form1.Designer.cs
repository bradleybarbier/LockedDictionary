namespace UI
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.Stattus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStopProcessing = new System.Windows.Forms.Button();
            this.btnStartProcessing = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalRequests = new System.Windows.Forms.Label();
            this.lblTotalCalls = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.dgRequests = new System.Windows.Forms.DataGridView();
            this.dgState = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgState)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StatusStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 706);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 22);
            this.panel1.TabIndex = 0;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Stattus,
            this.Status});
            this.StatusStrip.Location = new System.Drawing.Point(0, 0);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(858, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // Stattus
            // 
            this.Stattus.Name = "Stattus";
            this.Stattus.Size = new System.Drawing.Size(0, 17);
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 17);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnStopProcessing);
            this.panel2.Controls.Add(this.btnStartProcessing);
            this.panel2.Controls.Add(this.btnAddItems);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(772, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 706);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(6, 99);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStopProcessing
            // 
            this.btnStopProcessing.Enabled = false;
            this.btnStopProcessing.Location = new System.Drawing.Point(6, 70);
            this.btnStopProcessing.Name = "btnStopProcessing";
            this.btnStopProcessing.Size = new System.Drawing.Size(75, 23);
            this.btnStopProcessing.TabIndex = 2;
            this.btnStopProcessing.Text = "Stop";
            this.btnStopProcessing.UseVisualStyleBackColor = true;
            this.btnStopProcessing.Click += new System.EventHandler(this.btnStopProcessing_Click);
            // 
            // btnStartProcessing
            // 
            this.btnStartProcessing.Enabled = false;
            this.btnStartProcessing.Location = new System.Drawing.Point(6, 41);
            this.btnStartProcessing.Name = "btnStartProcessing";
            this.btnStartProcessing.Size = new System.Drawing.Size(75, 23);
            this.btnStartProcessing.TabIndex = 1;
            this.btnStartProcessing.Text = "Start";
            this.btnStartProcessing.UseVisualStyleBackColor = true;
            this.btnStartProcessing.Click += new System.EventHandler(this.btnStartProcessing_Click);
            // 
            // btnAddItems
            // 
            this.btnAddItems.Location = new System.Drawing.Point(6, 12);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(75, 23);
            this.btnAddItems.TabIndex = 0;
            this.btnAddItems.Text = "Add Items";
            this.btnAddItems.UseVisualStyleBackColor = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTotalRequests);
            this.panel3.Controls.Add(this.lblTotalCalls);
            this.panel3.Controls.Add(this.txtLog);
            this.panel3.Controls.Add(this.dgRequests);
            this.panel3.Controls.Add(this.dgState);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(772, 706);
            this.panel3.TabIndex = 2;
            // 
            // lblTotalRequests
            // 
            this.lblTotalRequests.AutoSize = true;
            this.lblTotalRequests.Location = new System.Drawing.Point(4, 431);
            this.lblTotalRequests.Name = "lblTotalRequests";
            this.lblTotalRequests.Size = new System.Drawing.Size(35, 13);
            this.lblTotalRequests.TabIndex = 5;
            this.lblTotalRequests.Text = "label1";
            this.lblTotalRequests.Visible = false;
            // 
            // lblTotalCalls
            // 
            this.lblTotalCalls.AutoSize = true;
            this.lblTotalCalls.Location = new System.Drawing.Point(4, 229);
            this.lblTotalCalls.Name = "lblTotalCalls";
            this.lblTotalCalls.Size = new System.Drawing.Size(35, 13);
            this.lblTotalCalls.TabIndex = 4;
            this.lblTotalCalls.Text = "label1";
            this.lblTotalCalls.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(3, 457);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(762, 243);
            this.txtLog.TabIndex = 3;
            // 
            // dgRequests
            // 
            this.dgRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequests.Location = new System.Drawing.Point(3, 254);
            this.dgRequests.Name = "dgRequests";
            this.dgRequests.Size = new System.Drawing.Size(763, 168);
            this.dgRequests.TabIndex = 2;
            // 
            // dgState
            // 
            this.dgState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgState.Location = new System.Drawing.Point(3, 3);
            this.dgState.Name = "dgState";
            this.dgState.Size = new System.Drawing.Size(763, 219);
            this.dgState.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 728);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locked Dictionary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripStatusLabel Stattus;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.DataGridView dgState;
        private System.Windows.Forms.DataGridView dgRequests;
        private System.Windows.Forms.Button btnStartProcessing;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnStopProcessing;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalRequests;
        private System.Windows.Forms.Label lblTotalCalls;
    }
}

