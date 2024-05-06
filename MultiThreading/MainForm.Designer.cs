namespace MultiThreading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStartAcquisition = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkPause = new System.Windows.Forms.CheckBox();
            this.lblTimingInMs = new System.Windows.Forms.Label();
            this.grpBoxAquisition = new System.Windows.Forms.GroupBox();
            this.txtAcquisitionCycleTime = new System.Windows.Forms.TextBox();
            this.btnStopAcquisition = new System.Windows.Forms.Button();
            this.grpBoxDataStorage = new System.Windows.Forms.GroupBox();
            this.txtAcqTimeAvg = new System.Windows.Forms.TextBox();
            this.txtTotalDurationStartEnd = new System.Windows.Forms.TextBox();
            this.lblTotalDuration = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcessingsCnt = new System.Windows.Forms.TextBox();
            this.txtProcessingTimeAvg = new System.Windows.Forms.TextBox();
            this.txtAcquisitionsCnt = new System.Windows.Forms.TextBox();
            this.txtAcqTimeMax = new System.Windows.Forms.TextBox();
            this.txtProcessingTimeMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpBoxAquisition.SuspendLayout();
            this.grpBoxDataStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartAcquisition
            // 
            this.btnStartAcquisition.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnStartAcquisition.Location = new System.Drawing.Point(21, 25);
            this.btnStartAcquisition.Name = "btnStartAcquisition";
            this.btnStartAcquisition.Size = new System.Drawing.Size(143, 29);
            this.btnStartAcquisition.TabIndex = 0;
            this.btnStartAcquisition.Text = "Start Camera Acquisition";
            this.btnStartAcquisition.UseVisualStyleBackColor = false;
            this.btnStartAcquisition.Click += new System.EventHandler(this.btnStartAcquisition_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 43);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // chkPause
            // 
            this.chkPause.AutoSize = true;
            this.chkPause.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkPause.ForeColor = System.Drawing.Color.Olive;
            this.chkPause.Location = new System.Drawing.Point(296, 65);
            this.chkPause.Name = "chkPause";
            this.chkPause.Size = new System.Drawing.Size(130, 19);
            this.chkPause.TabIndex = 2;
            this.chkPause.Tag = "";
            this.chkPause.Text = "Pause All Activities";
            this.chkPause.UseVisualStyleBackColor = true;
            this.chkPause.CheckedChanged += new System.EventHandler(this.chkPause_CheckedChanged);
            // 
            // lblTimingInMs
            // 
            this.lblTimingInMs.AutoSize = true;
            this.lblTimingInMs.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTimingInMs.Location = new System.Drawing.Point(62, 65);
            this.lblTimingInMs.Name = "lblTimingInMs";
            this.lblTimingInMs.Size = new System.Drawing.Size(185, 13);
            this.lblTimingInMs.TabIndex = 3;
            this.lblTimingInMs.Text = "Acquisition Cycle Time In Milliseconds";
            // 
            // grpBoxAquisition
            // 
            this.grpBoxAquisition.Controls.Add(this.txtAcquisitionCycleTime);
            this.grpBoxAquisition.Controls.Add(this.btnStopAcquisition);
            this.grpBoxAquisition.Controls.Add(this.chkPause);
            this.grpBoxAquisition.Controls.Add(this.lblTimingInMs);
            this.grpBoxAquisition.Controls.Add(this.btnStartAcquisition);
            this.grpBoxAquisition.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpBoxAquisition.Location = new System.Drawing.Point(212, 28);
            this.grpBoxAquisition.Name = "grpBoxAquisition";
            this.grpBoxAquisition.Size = new System.Drawing.Size(441, 105);
            this.grpBoxAquisition.TabIndex = 5;
            this.grpBoxAquisition.TabStop = false;
            this.grpBoxAquisition.Text = "Camera Acquisition & Processing";
            // 
            // txtAcquisitionCycleTime
            // 
            this.txtAcquisitionCycleTime.Location = new System.Drawing.Point(21, 62);
            this.txtAcquisitionCycleTime.Name = "txtAcquisitionCycleTime";
            this.txtAcquisitionCycleTime.Size = new System.Drawing.Size(34, 20);
            this.txtAcquisitionCycleTime.TabIndex = 6;
            this.txtAcquisitionCycleTime.Text = "5";
            // 
            // btnStopAcquisition
            // 
            this.btnStopAcquisition.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnStopAcquisition.Location = new System.Drawing.Point(283, 25);
            this.btnStopAcquisition.Name = "btnStopAcquisition";
            this.btnStopAcquisition.Size = new System.Drawing.Size(143, 29);
            this.btnStopAcquisition.TabIndex = 5;
            this.btnStopAcquisition.Text = "Stop Camera Acquisition";
            this.btnStopAcquisition.UseVisualStyleBackColor = false;
            this.btnStopAcquisition.Click += new System.EventHandler(this.btnStopAcquisition_Click);
            // 
            // grpBoxDataStorage
            // 
            this.grpBoxDataStorage.Controls.Add(this.txtAcqTimeAvg);
            this.grpBoxDataStorage.Controls.Add(this.txtTotalDurationStartEnd);
            this.grpBoxDataStorage.Controls.Add(this.lblTotalDuration);
            this.grpBoxDataStorage.Controls.Add(this.label1);
            this.grpBoxDataStorage.Controls.Add(this.label2);
            this.grpBoxDataStorage.Controls.Add(this.txtProcessingsCnt);
            this.grpBoxDataStorage.Controls.Add(this.txtProcessingTimeAvg);
            this.grpBoxDataStorage.Controls.Add(this.txtAcquisitionsCnt);
            this.grpBoxDataStorage.Controls.Add(this.txtAcqTimeMax);
            this.grpBoxDataStorage.Controls.Add(this.txtProcessingTimeMax);
            this.grpBoxDataStorage.Controls.Add(this.label4);
            this.grpBoxDataStorage.Controls.Add(this.label3);
            this.grpBoxDataStorage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpBoxDataStorage.Location = new System.Drawing.Point(35, 147);
            this.grpBoxDataStorage.Name = "grpBoxDataStorage";
            this.grpBoxDataStorage.Size = new System.Drawing.Size(618, 206);
            this.grpBoxDataStorage.TabIndex = 6;
            this.grpBoxDataStorage.TabStop = false;
            this.grpBoxDataStorage.Text = "General Reporting Data";
            // 
            // txtAcqTimeAvg
            // 
            this.txtAcqTimeAvg.Location = new System.Drawing.Point(426, 99);
            this.txtAcqTimeAvg.Name = "txtAcqTimeAvg";
            this.txtAcqTimeAvg.Size = new System.Drawing.Size(76, 20);
            this.txtAcqTimeAvg.TabIndex = 23;
            // 
            // txtTotalDurationStartEnd
            // 
            this.txtTotalDurationStartEnd.Location = new System.Drawing.Point(335, 162);
            this.txtTotalDurationStartEnd.Name = "txtTotalDurationStartEnd";
            this.txtTotalDurationStartEnd.Size = new System.Drawing.Size(86, 20);
            this.txtTotalDurationStartEnd.TabIndex = 22;
            // 
            // lblTotalDuration
            // 
            this.lblTotalDuration.AutoSize = true;
            this.lblTotalDuration.Location = new System.Drawing.Point(55, 166);
            this.lblTotalDuration.Name = "lblTotalDuration";
            this.lblTotalDuration.Size = new System.Drawing.Size(248, 13);
            this.lblTotalDuration.TabIndex = 19;
            this.lblTotalDuration.Text = "Total Duration since last Start: { hh: mm : sec : ms }";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Camera acquisition time: Max and Average in ms:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Image processing time: Max and Average in ms:";
            // 
            // txtProcessingsCnt
            // 
            this.txtProcessingsCnt.Location = new System.Drawing.Point(336, 61);
            this.txtProcessingsCnt.Name = "txtProcessingsCnt";
            this.txtProcessingsCnt.Size = new System.Drawing.Size(86, 20);
            this.txtProcessingsCnt.TabIndex = 14;
            // 
            // txtProcessingTimeAvg
            // 
            this.txtProcessingTimeAvg.Location = new System.Drawing.Point(426, 125);
            this.txtProcessingTimeAvg.Name = "txtProcessingTimeAvg";
            this.txtProcessingTimeAvg.Size = new System.Drawing.Size(76, 20);
            this.txtProcessingTimeAvg.TabIndex = 17;
            // 
            // txtAcquisitionsCnt
            // 
            this.txtAcquisitionsCnt.Location = new System.Drawing.Point(336, 36);
            this.txtAcquisitionsCnt.Name = "txtAcquisitionsCnt";
            this.txtAcquisitionsCnt.Size = new System.Drawing.Size(86, 20);
            this.txtAcquisitionsCnt.TabIndex = 13;
            // 
            // txtAcqTimeMax
            // 
            this.txtAcqTimeMax.Location = new System.Drawing.Point(335, 99);
            this.txtAcqTimeMax.Name = "txtAcqTimeMax";
            this.txtAcqTimeMax.Size = new System.Drawing.Size(86, 20);
            this.txtAcqTimeMax.TabIndex = 15;
            // 
            // txtProcessingTimeMax
            // 
            this.txtProcessingTimeMax.Location = new System.Drawing.Point(335, 124);
            this.txtProcessingTimeMax.Name = "txtProcessingTimeMax";
            this.txtProcessingTimeMax.Size = new System.Drawing.Size(86, 20);
            this.txtProcessingTimeMax.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Number of processed objects - For Camera processing:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of processed objects - For Camera acquisition:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(709, 401);
            this.Controls.Add(this.grpBoxDataStorage);
            this.Controls.Add(this.grpBoxAquisition);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "InsortMultiThreading:: Dietmar Lienhart";
            this.TransparencyKey = System.Drawing.Color.DeepPink;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpBoxAquisition.ResumeLayout(false);
            this.grpBoxAquisition.PerformLayout();
            this.grpBoxDataStorage.ResumeLayout(false);
            this.grpBoxDataStorage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnStartAcquisition;
        private PictureBox pictureBox1;
        private CheckBox chkPause;
        private Label lblTimingInMs;
        private GroupBox grpBoxAquisition;
        private Button btnStopAcquisition;
        private GroupBox grpBoxDataStorage;
        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox txtProcessingTimeAvg;
        private TextBox txtProcessingTimeMax;
        private TextBox txtAcqTimeMax;
        private TextBox txtProcessingsCnt;
        private TextBox txtAcquisitionsCnt;
        private Label label4;
        private Label lblTotalDuration;
        private TextBox txtTotalDurationStartEnd;
        private TextBox txtAcquisitionCycleTime;
        private TextBox txtAcqTimeAvg;
    }
}
