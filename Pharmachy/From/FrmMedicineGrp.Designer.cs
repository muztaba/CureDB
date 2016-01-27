namespace Pharmachy
{
    partial class FrmMedicineGrp
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
            this.dgvmedicinegrp = new System.Windows.Forms.DataGridView();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtgrpname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtgrpid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmedicinegrp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvmedicinegrp
            // 
            this.dgvmedicinegrp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmedicinegrp.Location = new System.Drawing.Point(287, 253);
            this.dgvmedicinegrp.Name = "dgvmedicinegrp";
            this.dgvmedicinegrp.Size = new System.Drawing.Size(423, 184);
            this.dgvmedicinegrp.TabIndex = 29;
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(453, 114);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 28;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(334, 114);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 23);
            this.btnupdate.TabIndex = 27;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(221, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtgrpname
            // 
            this.txtgrpname.Location = new System.Drawing.Point(278, 63);
            this.txtgrpname.Name = "txtgrpname";
            this.txtgrpname.Size = new System.Drawing.Size(100, 20);
            this.txtgrpname.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Group Name";
            // 
            // txtgrpid
            // 
            this.txtgrpid.Location = new System.Drawing.Point(278, 23);
            this.txtgrpid.Name = "txtgrpid";
            this.txtgrpid.Size = new System.Drawing.Size(100, 20);
            this.txtgrpid.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "GroupID";
            // 
            // FrmMedicineGrp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 460);
            this.Controls.Add(this.dgvmedicinegrp);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtgrpname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtgrpid);
            this.Controls.Add(this.label1);
            this.Name = "FrmMedicineGrp";
            this.Text = "FrmMedicineGrp";
            this.Load += new System.EventHandler(this.FrmMedicineGrp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmedicinegrp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvmedicinegrp;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtgrpname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtgrpid;
        private System.Windows.Forms.Label label1;
    }
}