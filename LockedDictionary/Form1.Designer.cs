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
            this.lblDeleteCall = new System.Windows.Forms.Label();
            this.lblAddCall = new System.Windows.Forms.Label();
            this.lblRequest = new System.Windows.Forms.Label();
            this.lblProcessIndicator = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStopProcessing = new System.Windows.Forms.Button();
            this.btnStartProcessing = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimerEvents = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRequests = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalRequests = new System.Windows.Forms.Label();
            this.lblTotalCalls = new System.Windows.Forms.Label();
            this.txtCalls = new System.Windows.Forms.TextBox();
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
            this.panel1.Size = new System.Drawing.Size(1629, 22);
            this.panel1.TabIndex = 0;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Stattus,
            this.Status});
            this.StatusStrip.Location = new System.Drawing.Point(0, 0);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1629, 22);
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
            this.panel2.Controls.Add(this.lblDeleteCall);
            this.panel2.Controls.Add(this.lblAddCall);
            this.panel2.Controls.Add(this.lblRequest);
            this.panel2.Controls.Add(this.lblProcessIndicator);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnStopProcessing);
            this.panel2.Controls.Add(this.btnStartProcessing);
            this.panel2.Controls.Add(this.btnAddItems);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1543, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 706);
            this.panel2.TabIndex = 1;
            // 
            // lblDeleteCall
            // 
            this.lblDeleteCall.AutoSize = true;
            this.lblDeleteCall.Enabled = false;
            this.lblDeleteCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteCall.ForeColor = System.Drawing.Color.Red;
            this.lblDeleteCall.Location = new System.Drawing.Point(25, 318);
            this.lblDeleteCall.Name = "lblDeleteCall";
            this.lblDeleteCall.Size = new System.Drawing.Size(35, 31);
            this.lblDeleteCall.TabIndex = 7;
            this.lblDeleteCall.Text = "D";
            // 
            // lblAddCall
            // 
            this.lblAddCall.AutoSize = true;
            this.lblAddCall.Enabled = false;
            this.lblAddCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddCall.ForeColor = System.Drawing.Color.Blue;
            this.lblAddCall.Location = new System.Drawing.Point(25, 276);
            this.lblAddCall.Name = "lblAddCall";
            this.lblAddCall.Size = new System.Drawing.Size(33, 31);
            this.lblAddCall.TabIndex = 6;
            this.lblAddCall.Text = "A";
            this.lblAddCall.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Enabled = false;
            this.lblRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequest.ForeColor = System.Drawing.Color.Yellow;
            this.lblRequest.Location = new System.Drawing.Point(25, 234);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(35, 31);
            this.lblRequest.TabIndex = 5;
            this.lblRequest.Text = "R";
            // 
            // lblProcessIndicator
            // 
            this.lblProcessIndicator.AutoSize = true;
            this.lblProcessIndicator.Enabled = false;
            this.lblProcessIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessIndicator.ForeColor = System.Drawing.Color.Green;
            this.lblProcessIndicator.Location = new System.Drawing.Point(25, 190);
            this.lblProcessIndicator.Name = "lblProcessIndicator";
            this.lblProcessIndicator.Size = new System.Drawing.Size(33, 31);
            this.lblProcessIndicator.TabIndex = 4;
            this.lblProcessIndicator.Text = "P";
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
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtTimerEvents);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtRequests);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblTotalRequests);
            this.panel3.Controls.Add(this.lblTotalCalls);
            this.panel3.Controls.Add(this.txtCalls);
            this.panel3.Controls.Add(this.dgRequests);
            this.panel3.Controls.Add(this.dgState);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1543, 706);
            this.panel3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Timer Log";
            // 
            // txtTimerEvents
            // 
            this.txtTimerEvents.Location = new System.Drawing.Point(7, 334);
            this.txtTimerEvents.Multiline = true;
            this.txtTimerEvents.Name = "txtTimerEvents";
            this.txtTimerEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTimerEvents.Size = new System.Drawing.Size(395, 366);
            this.txtTimerEvents.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(986, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Request Log";
            // 
            // txtRequests
            // 
            this.txtRequests.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRequests.Location = new System.Drawing.Point(985, 334);
            this.txtRequests.Multiline = true;
            this.txtRequests.Name = "txtRequests";
            this.txtRequests.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRequests.Size = new System.Drawing.Size(551, 366);
            this.txtRequests.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Call Log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(769, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Requests";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Calls";
            // 
            // lblTotalRequests
            // 
            this.lblTotalRequests.AutoSize = true;
            this.lblTotalRequests.Location = new System.Drawing.Point(769, 290);
            this.lblTotalRequests.Name = "lblTotalRequests";
            this.lblTotalRequests.Size = new System.Drawing.Size(31, 13);
            this.lblTotalRequests.TabIndex = 5;
            this.lblTotalRequests.Text = "Total";
            this.lblTotalRequests.Click += new System.EventHandler(this.lblTotalRequests_Click);
            // 
            // lblTotalCalls
            // 
            this.lblTotalCalls.AutoSize = true;
            this.lblTotalCalls.Location = new System.Drawing.Point(4, 290);
            this.lblTotalCalls.Name = "lblTotalCalls";
            this.lblTotalCalls.Size = new System.Drawing.Size(31, 13);
            this.lblTotalCalls.TabIndex = 4;
            this.lblTotalCalls.Text = "Total";
            // 
            // txtCalls
            // 
            this.txtCalls.Location = new System.Drawing.Point(417, 334);
            this.txtCalls.Multiline = true;
            this.txtCalls.Name = "txtCalls";
            this.txtCalls.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCalls.Size = new System.Drawing.Size(551, 366);
            this.txtCalls.TabIndex = 3;
            // 
            // dgRequests
            // 
            this.dgRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequests.Location = new System.Drawing.Point(772, 23);
            this.dgRequests.Name = "dgRequests";
            this.dgRequests.Size = new System.Drawing.Size(763, 264);
            this.dgRequests.TabIndex = 2;
            this.dgRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRequests_CellContentClick);
            // 
            // dgState
            // 
            this.dgState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgState.Location = new System.Drawing.Point(3, 23);
            this.dgState.Name = "dgState";
            this.dgState.Size = new System.Drawing.Size(762, 264);
            this.dgState.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1629, 728);
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
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.TextBox txtCalls;
        private System.Windows.Forms.Button btnStopProcessing;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalRequests;
        private System.Windows.Forms.Label lblTotalCalls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRequests;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimerEvents;
        private System.Windows.Forms.Label lblProcessIndicator;
        private System.Windows.Forms.Label lblAddCall;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblDeleteCall;
    }
}

