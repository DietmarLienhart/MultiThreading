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
            btnStartAcquisition = new Button();
            pictureBox1 = new PictureBox();
            chkPause = new CheckBox();
            lblTimingInMs = new Label();
            grpBoxAquisition = new GroupBox();
            txtAcquisitionCycleTime = new TextBox();
            btnStopAcquisition = new Button();
            txtCurrentSeqNr = new TextBox();
            grpBoxDataStorage = new GroupBox();
            txtAcqTimeAvg = new TextBox();
            txtTotalDurationStartEnd = new TextBox();
            txtGarbageCollectionDelta = new TextBox();
            txtNotContinuedSeqNrsTotal = new TextBox();
            lblTotalDuration = new Label();
            label6 = new Label();
            txtProcessingTimeAvg = new TextBox();
            txtProcessingTimeMax = new TextBox();
            txtAcqTimeMax = new TextBox();
            txtNrOfProcessedObjects = new TextBox();
            txtNrOfAcqObjects = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblLatestSequence = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpBoxAquisition.SuspendLayout();
            grpBoxDataStorage.SuspendLayout();
            SuspendLayout();
            // 
            // btnStartAcquisition
            // 
            btnStartAcquisition.BackColor = SystemColors.AppWorkspace;
            btnStartAcquisition.Location = new Point(24, 29);
            btnStartAcquisition.Name = "btnStartAcquisition";
            btnStartAcquisition.Size = new Size(167, 33);
            btnStartAcquisition.TabIndex = 0;
            btnStartAcquisition.Text = "Start Camera Acquisition";
            btnStartAcquisition.UseVisualStyleBackColor = false;
            btnStartAcquisition.Click += btnStartAcquisition_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(28, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(184, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // chkPause
            // 
            chkPause.AutoSize = true;
            chkPause.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            chkPause.ForeColor = Color.Olive;
            chkPause.Location = new Point(367, 75);
            chkPause.Name = "chkPause";
            chkPause.Size = new Size(130, 19);
            chkPause.TabIndex = 2;
            chkPause.Tag = "";
            chkPause.Text = "Pause All Activities";
            chkPause.UseVisualStyleBackColor = true;
            // 
            // lblTimingInMs
            // 
            lblTimingInMs.AutoSize = true;
            lblTimingInMs.BackColor = SystemColors.ActiveCaptionText;
            lblTimingInMs.Location = new Point(72, 75);
            lblTimingInMs.Name = "lblTimingInMs";
            lblTimingInMs.Size = new Size(210, 15);
            lblTimingInMs.TabIndex = 3;
            lblTimingInMs.Text = "Acquisition Cycle Time In Milliseconds";
            // 
            // grpBoxAquisition
            // 
            grpBoxAquisition.Controls.Add(txtAcquisitionCycleTime);
            grpBoxAquisition.Controls.Add(btnStopAcquisition);
            grpBoxAquisition.Controls.Add(chkPause);
            grpBoxAquisition.Controls.Add(lblTimingInMs);
            grpBoxAquisition.Controls.Add(btnStartAcquisition);
            grpBoxAquisition.ForeColor = SystemColors.ButtonHighlight;
            grpBoxAquisition.Location = new Point(234, 27);
            grpBoxAquisition.Name = "grpBoxAquisition";
            grpBoxAquisition.Size = new Size(515, 121);
            grpBoxAquisition.TabIndex = 5;
            grpBoxAquisition.TabStop = false;
            grpBoxAquisition.Text = "Camera Acquisition & Processing";
            // 
            // txtAcquisitionCycleTime
            // 
            txtAcquisitionCycleTime.Location = new Point(24, 72);
            txtAcquisitionCycleTime.Name = "txtAcquisitionCycleTime";
            txtAcquisitionCycleTime.Size = new Size(39, 23);
            txtAcquisitionCycleTime.TabIndex = 6;
            txtAcquisitionCycleTime.Text = "5";
            // 
            // btnStopAcquisition
            // 
            btnStopAcquisition.BackColor = SystemColors.AppWorkspace;
            btnStopAcquisition.Location = new Point(330, 29);
            btnStopAcquisition.Name = "btnStopAcquisition";
            btnStopAcquisition.Size = new Size(167, 33);
            btnStopAcquisition.TabIndex = 5;
            btnStopAcquisition.Text = "Stop Camera Acquisition";
            btnStopAcquisition.UseVisualStyleBackColor = false;
            btnStopAcquisition.Click += btnStopAcquisition_Click;
            // 
            // txtCurrentSeqNr
            // 
            txtCurrentSeqNr.Location = new Point(388, 40);
            txtCurrentSeqNr.Name = "txtCurrentSeqNr";
            txtCurrentSeqNr.Size = new Size(101, 23);
            txtCurrentSeqNr.TabIndex = 6;
            // 
            // grpBoxDataStorage
            // 
            grpBoxDataStorage.Controls.Add(txtAcqTimeAvg);
            grpBoxDataStorage.Controls.Add(txtTotalDurationStartEnd);
            grpBoxDataStorage.Controls.Add(txtGarbageCollectionDelta);
            grpBoxDataStorage.Controls.Add(txtNotContinuedSeqNrsTotal);
            grpBoxDataStorage.Controls.Add(lblTotalDuration);
            grpBoxDataStorage.Controls.Add(label6);
            grpBoxDataStorage.Controls.Add(txtProcessingTimeAvg);
            grpBoxDataStorage.Controls.Add(txtProcessingTimeMax);
            grpBoxDataStorage.Controls.Add(txtAcqTimeMax);
            grpBoxDataStorage.Controls.Add(txtNrOfProcessedObjects);
            grpBoxDataStorage.Controls.Add(txtNrOfAcqObjects);
            grpBoxDataStorage.Controls.Add(label5);
            grpBoxDataStorage.Controls.Add(label4);
            grpBoxDataStorage.Controls.Add(label3);
            grpBoxDataStorage.Controls.Add(label2);
            grpBoxDataStorage.Controls.Add(label1);
            grpBoxDataStorage.Controls.Add(lblLatestSequence);
            grpBoxDataStorage.Controls.Add(txtCurrentSeqNr);
            grpBoxDataStorage.ForeColor = SystemColors.ButtonHighlight;
            grpBoxDataStorage.Location = new Point(28, 164);
            grpBoxDataStorage.Name = "grpBoxDataStorage";
            grpBoxDataStorage.Size = new Size(721, 299);
            grpBoxDataStorage.TabIndex = 6;
            grpBoxDataStorage.TabStop = false;
            grpBoxDataStorage.Text = "Simple Data Storage";
            // 
            // txtAcqTimeAvg
            // 
            txtAcqTimeAvg.Location = new Point(494, 71);
            txtAcqTimeAvg.Name = "txtAcqTimeAvg";
            txtAcqTimeAvg.Size = new Size(88, 23);
            txtAcqTimeAvg.TabIndex = 23;
            // 
            // txtTotalDurationStartEnd
            // 
            txtTotalDurationStartEnd.Location = new Point(389, 248);
            txtTotalDurationStartEnd.Name = "txtTotalDurationStartEnd";
            txtTotalDurationStartEnd.Size = new Size(100, 23);
            txtTotalDurationStartEnd.TabIndex = 22;
            // 
            // txtGarbageCollectionDelta
            // 
            txtGarbageCollectionDelta.Location = new Point(389, 219);
            txtGarbageCollectionDelta.Name = "txtGarbageCollectionDelta";
            txtGarbageCollectionDelta.Size = new Size(100, 23);
            txtGarbageCollectionDelta.TabIndex = 21;
            // 
            // txtNotContinuedSeqNrsTotal
            // 
            txtNotContinuedSeqNrsTotal.Location = new Point(389, 190);
            txtNotContinuedSeqNrsTotal.Name = "txtNotContinuedSeqNrsTotal";
            txtNotContinuedSeqNrsTotal.Size = new Size(100, 23);
            txtNotContinuedSeqNrsTotal.TabIndex = 20;
            // 
            // lblTotalDuration
            // 
            lblTotalDuration.AutoSize = true;
            lblTotalDuration.Location = new Point(68, 251);
            lblTotalDuration.Name = "lblTotalDuration";
            lblTotalDuration.Size = new Size(272, 15);
            lblTotalDuration.TabIndex = 19;
            lblTotalDuration.Text = "Total Duration since last Start: { hh: mm : sec : ms }";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(68, 223);
            label6.Name = "label6";
            label6.Size = new Size(240, 15);
            label6.TabIndex = 18;
            label6.Text = "Garbage Collection Generation Count 0 to 2:";
            // 
            // txtProcessingTimeAvg
            // 
            txtProcessingTimeAvg.Location = new Point(494, 101);
            txtProcessingTimeAvg.Name = "txtProcessingTimeAvg";
            txtProcessingTimeAvg.Size = new Size(88, 23);
            txtProcessingTimeAvg.TabIndex = 17;
            // 
            // txtProcessingTimeMax
            // 
            txtProcessingTimeMax.Location = new Point(388, 101);
            txtProcessingTimeMax.Name = "txtProcessingTimeMax";
            txtProcessingTimeMax.Size = new Size(100, 23);
            txtProcessingTimeMax.TabIndex = 16;
            // 
            // txtAcqTimeMax
            // 
            txtAcqTimeMax.Location = new Point(388, 71);
            txtAcqTimeMax.Name = "txtAcqTimeMax";
            txtAcqTimeMax.Size = new Size(100, 23);
            txtAcqTimeMax.TabIndex = 15;
            // 
            // txtNrOfProcessedObjects
            // 
            txtNrOfProcessedObjects.Location = new Point(389, 161);
            txtNrOfProcessedObjects.Name = "txtNrOfProcessedObjects";
            txtNrOfProcessedObjects.Size = new Size(100, 23);
            txtNrOfProcessedObjects.TabIndex = 14;
            // 
            // txtNrOfAcqObjects
            // 
            txtNrOfAcqObjects.Location = new Point(389, 132);
            txtNrOfAcqObjects.Name = "txtNrOfAcqObjects";
            txtNrOfAcqObjects.Size = new Size(100, 23);
            txtNrOfAcqObjects.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 193);
            label5.Name = "label5";
            label5.Size = new Size(270, 15);
            label5.TabIndex = 12;
            label5.Text = "The number of not continuous sequence number:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 165);
            label4.Name = "label4";
            label4.Size = new Size(297, 15);
            label4.TabIndex = 11;
            label4.Text = "Number of processed objects - For Camera processing:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 137);
            label3.Name = "label3";
            label3.Size = new Size(298, 15);
            label3.TabIndex = 10;
            label3.Text = "Number of processed objects - For Camera acquisition:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 105);
            label2.Name = "label2";
            label2.Size = new Size(228, 15);
            label2.TabIndex = 9;
            label2.Text = "Image processing time: Max and Average:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 75);
            label1.Name = "label1";
            label1.Size = new Size(237, 15);
            label1.TabIndex = 8;
            label1.Text = "Camera acquisition time: Max and Average:";
            // 
            // lblLatestSequence
            // 
            lblLatestSequence.AutoSize = true;
            lblLatestSequence.Location = new Point(69, 44);
            lblLatestSequence.Name = "lblLatestSequence";
            lblLatestSequence.Size = new Size(151, 15);
            lblLatestSequence.TabIndex = 7;
            lblLatestSequence.Text = "Current Sequence Number:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(795, 510);
            Controls.Add(grpBoxDataStorage);
            Controls.Add(grpBoxAquisition);
            Controls.Add(pictureBox1);
            Name = "MainForm";
            Text = "InsortMultiThreading:: Dietmar Lienhart";
            TransparencyKey = Color.DeepPink;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpBoxAquisition.ResumeLayout(false);
            grpBoxAquisition.PerformLayout();
            grpBoxDataStorage.ResumeLayout(false);
            grpBoxDataStorage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartAcquisition;
        private PictureBox pictureBox1;
        private CheckBox chkPause;
        private Label lblTimingInMs;
        private GroupBox grpBoxAquisition;
        private Button btnStopAcquisition;
        private TextBox txtCurrentSeqNr;
        private GroupBox grpBoxDataStorage;
        private Label label1;
        private Label lblLatestSequence;
        private Label label3;
        private Label label2;
        private TextBox txtProcessingTimeAvg;
        private TextBox txtProcessingTimeMax;
        private TextBox txtAcqTimeMax;
        private TextBox txtNrOfProcessedObjects;
        private TextBox txtNrOfAcqObjects;
        private Label label5;
        private Label label4;
        private Label lblTotalDuration;
        private Label label6;
        private TextBox txtTotalDurationStartEnd;
        private TextBox txtGarbageCollectionDelta;
        private TextBox txtNotContinuedSeqNrsTotal;
        private TextBox txtAcquisitionCycleTime;
        private TextBox txtAcqTimeAvg;
    }
}
