namespace CPU_SCHEDULING_SIMULATION
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerateProcess = new System.Windows.Forms.Button();
            this.txtNoOfProcess = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdProcesses = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdPPSchedule = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPPAvgTurnAround = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHRRNAvgTurnAround = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEODRRAvgTurnAround = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ProcessID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ArrivalTime = new System.Windows.Forms.DataGridViewLinkColumn();
            this.BurstTime = new System.Windows.Forms.DataGridViewLinkColumn();
            this.IOBlockTime = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewLinkColumn();
            this.FinishTime = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TurnAroundTime = new System.Windows.Forms.DataGridViewLinkColumn();
            this.grdHRRNSchedule = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.grdEODRRSchedule = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcesses)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPPSchedule)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHRRNSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEODRRSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenerateProcess);
            this.groupBox1.Controls.Add(this.txtNoOfProcess);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate CPU Processes";
            // 
            // btnGenerateProcess
            // 
            this.btnGenerateProcess.Location = new System.Drawing.Point(455, 28);
            this.btnGenerateProcess.Name = "btnGenerateProcess";
            this.btnGenerateProcess.Size = new System.Drawing.Size(302, 37);
            this.btnGenerateProcess.TabIndex = 2;
            this.btnGenerateProcess.Text = "Generate and Schedule Processess";
            this.btnGenerateProcess.UseVisualStyleBackColor = true;
            this.btnGenerateProcess.Click += new System.EventHandler(this.BtnGenerateProcess_Click);
            // 
            // txtNoOfProcess
            // 
            this.txtNoOfProcess.AsciiOnly = true;
            this.txtNoOfProcess.Location = new System.Drawing.Point(320, 37);
            this.txtNoOfProcess.Mask = "000";
            this.txtNoOfProcess.Name = "txtNoOfProcess";
            this.txtNoOfProcess.RejectInputOnFirstFailure = true;
            this.txtNoOfProcess.Size = new System.Drawing.Size(100, 27);
            this.txtNoOfProcess.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter No of Processes to Simulate :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdProcesses);
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 168);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generated CPU Processes Parameters (using exponential distribution function)";
            // 
            // grdProcesses
            // 
            this.grdProcesses.AllowUserToAddRows = false;
            this.grdProcesses.AllowUserToDeleteRows = false;
            this.grdProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessID,
            this.ArrivalTime,
            this.BurstTime,
            this.IOBlockTime});
            this.grdProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProcesses.Location = new System.Drawing.Point(3, 23);
            this.grdProcesses.Name = "grdProcesses";
            this.grdProcesses.ReadOnly = true;
            this.grdProcesses.Size = new System.Drawing.Size(770, 142);
            this.grdProcesses.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdPPSchedule);
            this.groupBox3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 343);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 168);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Schedule Result of Preemptive Priority Algorithm";
            // 
            // grdPPSchedule
            // 
            this.grdPPSchedule.AllowUserToAddRows = false;
            this.grdPPSchedule.AllowUserToDeleteRows = false;
            this.grdPPSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPPSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn1,
            this.StartTime,
            this.FinishTime,
            this.TurnAroundTime});
            this.grdPPSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPPSchedule.Location = new System.Drawing.Point(3, 23);
            this.grdPPSchedule.Name = "grdPPSchedule";
            this.grdPPSchedule.ReadOnly = true;
            this.grdPPSchedule.Size = new System.Drawing.Size(770, 142);
            this.grdPPSchedule.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grdHRRNSchedule);
            this.groupBox4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(15, 564);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(776, 168);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Schedule Result of Highest-Response-ratio-Next Algorithm";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.grdEODRRSchedule);
            this.groupBox5.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(15, 791);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(776, 168);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Schedule Result of Even-Odd Dynamic Round Robin Algorithm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Average Turn Around Time (ms) : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPPAvgTurnAround);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(481, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 29);
            this.panel1.TabIndex = 7;
            // 
            // lblPPAvgTurnAround
            // 
            this.lblPPAvgTurnAround.AutoSize = true;
            this.lblPPAvgTurnAround.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPAvgTurnAround.Location = new System.Drawing.Point(242, 8);
            this.lblPPAvgTurnAround.Name = "lblPPAvgTurnAround";
            this.lblPPAvgTurnAround.Size = new System.Drawing.Size(0, 16);
            this.lblPPAvgTurnAround.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblHRRNAvgTurnAround);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(481, 540);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 29);
            this.panel2.TabIndex = 8;
            // 
            // lblHRRNAvgTurnAround
            // 
            this.lblHRRNAvgTurnAround.AutoSize = true;
            this.lblHRRNAvgTurnAround.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRRNAvgTurnAround.Location = new System.Drawing.Point(242, 7);
            this.lblHRRNAvgTurnAround.Name = "lblHRRNAvgTurnAround";
            this.lblHRRNAvgTurnAround.Size = new System.Drawing.Size(0, 16);
            this.lblHRRNAvgTurnAround.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Average Turn Around Time (ms) : ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblEODRRAvgTurnAround);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(481, 769);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(304, 29);
            this.panel3.TabIndex = 9;
            // 
            // lblEODRRAvgTurnAround
            // 
            this.lblEODRRAvgTurnAround.AutoSize = true;
            this.lblEODRRAvgTurnAround.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEODRRAvgTurnAround.Location = new System.Drawing.Point(242, 7);
            this.lblEODRRAvgTurnAround.Name = "lblEODRRAvgTurnAround";
            this.lblEODRRAvgTurnAround.Size = new System.Drawing.Size(0, 16);
            this.lblEODRRAvgTurnAround.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Average Turn Around Time (ms) : ";
            // 
            // ProcessID
            // 
            this.ProcessID.DataPropertyName = "ProcessID";
            this.ProcessID.HeaderText = "ProcessID";
            this.ProcessID.Name = "ProcessID";
            this.ProcessID.ReadOnly = true;
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ArrivalTime.DataPropertyName = "ArrivalTime";
            this.ArrivalTime.HeaderText = "Arrival Time (ms)";
            this.ArrivalTime.Name = "ArrivalTime";
            this.ArrivalTime.ReadOnly = true;
            // 
            // BurstTime
            // 
            this.BurstTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BurstTime.DataPropertyName = "BurstTime";
            this.BurstTime.HeaderText = "CPU Burst Time (ms)";
            this.BurstTime.Name = "BurstTime";
            this.BurstTime.ReadOnly = true;
            // 
            // IOBlockTime
            // 
            this.IOBlockTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IOBlockTime.DataPropertyName = "IOBlockTime";
            this.IOBlockTime.HeaderText = "IO Block Time (ms)";
            this.IOBlockTime.Name = "IOBlockTime";
            this.IOBlockTime.ReadOnly = true;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "ProcessID";
            this.dataGridViewLinkColumn1.HeaderText = "ProcessID";
            this.dataGridViewLinkColumn1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "Start Time (ms)";
            this.StartTime.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // FinishTime
            // 
            this.FinishTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FinishTime.DataPropertyName = "FinishTime";
            this.FinishTime.HeaderText = "Finish Time (ms)";
            this.FinishTime.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.FinishTime.Name = "FinishTime";
            this.FinishTime.ReadOnly = true;
            // 
            // TurnAroundTime
            // 
            this.TurnAroundTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TurnAroundTime.DataPropertyName = "TurnAroundTime";
            this.TurnAroundTime.HeaderText = "Turn Around Time (ms)";
            this.TurnAroundTime.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.TurnAroundTime.Name = "TurnAroundTime";
            this.TurnAroundTime.ReadOnly = true;
            // 
            // grdHRRNSchedule
            // 
            this.grdHRRNSchedule.AllowUserToAddRows = false;
            this.grdHRRNSchedule.AllowUserToDeleteRows = false;
            this.grdHRRNSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHRRNSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn2,
            this.dataGridViewLinkColumn3,
            this.dataGridViewLinkColumn4,
            this.dataGridViewLinkColumn5});
            this.grdHRRNSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHRRNSchedule.Location = new System.Drawing.Point(3, 23);
            this.grdHRRNSchedule.Name = "grdHRRNSchedule";
            this.grdHRRNSchedule.ReadOnly = true;
            this.grdHRRNSchedule.Size = new System.Drawing.Size(770, 142);
            this.grdHRRNSchedule.TabIndex = 1;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.DataPropertyName = "ProcessID";
            this.dataGridViewLinkColumn2.HeaderText = "ProcessID";
            this.dataGridViewLinkColumn2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            // 
            // dataGridViewLinkColumn3
            // 
            this.dataGridViewLinkColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLinkColumn3.DataPropertyName = "StartTime";
            this.dataGridViewLinkColumn3.HeaderText = "Start Time (ms)";
            this.dataGridViewLinkColumn3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dataGridViewLinkColumn3.Name = "dataGridViewLinkColumn3";
            this.dataGridViewLinkColumn3.ReadOnly = true;
            // 
            // dataGridViewLinkColumn4
            // 
            this.dataGridViewLinkColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLinkColumn4.DataPropertyName = "FinishTime";
            this.dataGridViewLinkColumn4.HeaderText = "Finish Time (ms)";
            this.dataGridViewLinkColumn4.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dataGridViewLinkColumn4.Name = "dataGridViewLinkColumn4";
            this.dataGridViewLinkColumn4.ReadOnly = true;
            // 
            // dataGridViewLinkColumn5
            // 
            this.dataGridViewLinkColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLinkColumn5.DataPropertyName = "TurnAroundTime";
            this.dataGridViewLinkColumn5.HeaderText = "Turn Around Time (ms)";
            this.dataGridViewLinkColumn5.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dataGridViewLinkColumn5.Name = "dataGridViewLinkColumn5";
            this.dataGridViewLinkColumn5.ReadOnly = true;
            // 
            // grdEODRRSchedule
            // 
            this.grdEODRRSchedule.AllowUserToAddRows = false;
            this.grdEODRRSchedule.AllowUserToDeleteRows = false;
            this.grdEODRRSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEODRRSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn6,
            this.dataGridViewLinkColumn7,
            this.dataGridViewLinkColumn8,
            this.dataGridViewLinkColumn9});
            this.grdEODRRSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEODRRSchedule.Location = new System.Drawing.Point(3, 23);
            this.grdEODRRSchedule.Name = "grdEODRRSchedule";
            this.grdEODRRSchedule.ReadOnly = true;
            this.grdEODRRSchedule.Size = new System.Drawing.Size(770, 142);
            this.grdEODRRSchedule.TabIndex = 1;
            // 
            // dataGridViewLinkColumn6
            // 
            this.dataGridViewLinkColumn6.DataPropertyName = "ProcessID";
            this.dataGridViewLinkColumn6.HeaderText = "ProcessID";
            this.dataGridViewLinkColumn6.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.dataGridViewLinkColumn6.Name = "dataGridViewLinkColumn6";
            this.dataGridViewLinkColumn6.ReadOnly = true;
            // 
            // dataGridViewLinkColumn7
            // 
            this.dataGridViewLinkColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLinkColumn7.DataPropertyName = "StartTime";
            this.dataGridViewLinkColumn7.HeaderText = "Start Time (ms)";
            this.dataGridViewLinkColumn7.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dataGridViewLinkColumn7.Name = "dataGridViewLinkColumn7";
            this.dataGridViewLinkColumn7.ReadOnly = true;
            // 
            // dataGridViewLinkColumn8
            // 
            this.dataGridViewLinkColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLinkColumn8.DataPropertyName = "FinishTime";
            this.dataGridViewLinkColumn8.HeaderText = "Finish Time (ms)";
            this.dataGridViewLinkColumn8.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dataGridViewLinkColumn8.Name = "dataGridViewLinkColumn8";
            this.dataGridViewLinkColumn8.ReadOnly = true;
            // 
            // dataGridViewLinkColumn9
            // 
            this.dataGridViewLinkColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLinkColumn9.DataPropertyName = "TurnAroundTime";
            this.dataGridViewLinkColumn9.HeaderText = "Turn Around Time (ms)";
            this.dataGridViewLinkColumn9.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dataGridViewLinkColumn9.Name = "dataGridViewLinkColumn9";
            this.dataGridViewLinkColumn9.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1004);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "CPU Scheduling Simulation and Generation of Process Parameters using Exponential " +
    "Distribution Function";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProcesses)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPPSchedule)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHRRNSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEODRRSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerateProcess;
        private System.Windows.Forms.MaskedTextBox txtNoOfProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdProcesses;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdPPSchedule;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPPAvgTurnAround;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHRRNAvgTurnAround;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblEODRRAvgTurnAround;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewLinkColumn ProcessID;
        private System.Windows.Forms.DataGridViewLinkColumn ArrivalTime;
        private System.Windows.Forms.DataGridViewLinkColumn BurstTime;
        private System.Windows.Forms.DataGridViewLinkColumn IOBlockTime;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn StartTime;
        private System.Windows.Forms.DataGridViewLinkColumn FinishTime;
        private System.Windows.Forms.DataGridViewLinkColumn TurnAroundTime;
        private System.Windows.Forms.DataGridView grdHRRNSchedule;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn3;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn4;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn5;
        private System.Windows.Forms.DataGridView grdEODRRSchedule;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn6;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn7;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn8;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn9;
    }
}

