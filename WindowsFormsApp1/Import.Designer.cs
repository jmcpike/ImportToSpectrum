namespace WindowsFormsApp1
{
    partial class Import
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
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.lblCustomerCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvProjects = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProjectsCount = new System.Windows.Forms.Label();
            this.btnCreateImport = new System.Windows.Forms.Button();
            this.tbxProjectId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(235, 38);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(256, 22);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "End Date:";
            // 
            // dgvJobs
            // 
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.Location = new System.Drawing.Point(110, 116);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.RowTemplate.Height = 24;
            this.dgvJobs.Size = new System.Drawing.Size(1403, 324);
            this.dgvJobs.TabIndex = 2;
            // 
            // lblCustomerCount
            // 
            this.lblCustomerCount.AutoSize = true;
            this.lblCustomerCount.Location = new System.Drawing.Point(324, 86);
            this.lblCustomerCount.Name = "lblCustomerCount";
            this.lblCustomerCount.Size = new System.Drawing.Size(46, 17);
            this.lblCustomerCount.TabIndex = 3;
            this.lblCustomerCount.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Customers:";
            // 
            // dgvProjects
            // 
            this.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjects.Location = new System.Drawing.Point(110, 484);
            this.dgvProjects.Name = "dgvProjects";
            this.dgvProjects.RowTemplate.Height = 24;
            this.dgvProjects.Size = new System.Drawing.Size(1403, 324);
            this.dgvProjects.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 464);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "New Projects:";
            // 
            // lblProjectsCount
            // 
            this.lblProjectsCount.AutoSize = true;
            this.lblProjectsCount.Location = new System.Drawing.Point(338, 464);
            this.lblProjectsCount.Name = "lblProjectsCount";
            this.lblProjectsCount.Size = new System.Drawing.Size(46, 17);
            this.lblProjectsCount.TabIndex = 6;
            this.lblProjectsCount.Text = "label2";
            // 
            // btnCreateImport
            // 
            this.btnCreateImport.Location = new System.Drawing.Point(1519, 756);
            this.btnCreateImport.Name = "btnCreateImport";
            this.btnCreateImport.Size = new System.Drawing.Size(75, 52);
            this.btnCreateImport.TabIndex = 8;
            this.btnCreateImport.Text = "Create Imports";
            this.btnCreateImport.UseVisualStyleBackColor = true;
            this.btnCreateImport.Click += new System.EventHandler(this.btnCreateImport_Click);
            // 
            // tbxProjectId
            // 
            this.tbxProjectId.Location = new System.Drawing.Point(660, 45);
            this.tbxProjectId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxProjectId.Name = "tbxProjectId";
            this.tbxProjectId.Size = new System.Drawing.Size(210, 22);
            this.tbxProjectId.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "ProjectId:";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(906, 34);
            this.btnGet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 35);
            this.btnGet.TabIndex = 11;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1823, 862);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxProjectId);
            this.Controls.Add(this.btnCreateImport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProjectsCount);
            this.Controls.Add(this.dgvProjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCustomerCount);
            this.Controls.Add(this.dgvJobs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFrom);
            this.Name = "Import";
            this.Text = "Import";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Import_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Import_FormClosed);
            this.Load += new System.EventHandler(this.Import_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvJobs;
        private System.Windows.Forms.Label lblCustomerCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvProjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProjectsCount;
        private System.Windows.Forms.Button btnCreateImport;
        private System.Windows.Forms.TextBox tbxProjectId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGet;
    }
}