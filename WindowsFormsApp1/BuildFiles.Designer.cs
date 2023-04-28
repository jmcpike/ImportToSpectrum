namespace WindowsFormsApp1
{
    partial class BuildFiles
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
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnCVS = new System.Windows.Forms.Button();
            this.lblSection = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(30, 45);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(1519, 711);
            this.dgvResults.TabIndex = 0;
            // 
            // btnCVS
            // 
            this.btnCVS.Location = new System.Drawing.Point(1473, 773);
            this.btnCVS.Name = "btnCVS";
            this.btnCVS.Size = new System.Drawing.Size(76, 51);
            this.btnCVS.TabIndex = 1;
            this.btnCVS.Text = "Create File";
            this.btnCVS.UseVisualStyleBackColor = true;
            this.btnCVS.Click += new System.EventHandler(this.btnCVS_Click);
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(746, 19);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(46, 17);
            this.lblSection.TabIndex = 2;
            this.lblSection.Text = "label1";
            // 
            // BuildFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 850);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.btnCVS);
            this.Controls.Add(this.dgvResults);
            this.Name = "BuildFiles";
            this.Text = "BuildFiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuildFiles_FormClosing);
            this.Load += new System.EventHandler(this.BuildFiles_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnCVS;
        private System.Windows.Forms.Label lblSection;
    }
}