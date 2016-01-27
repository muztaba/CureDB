namespace Pharmachy
{
    partial class FrmDosage
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtdosageid = new System.Windows.Forms.TextBox();
            this.txtdosagename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvdosage = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdosage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DosageID";
            // 
            // txtdosageid
            // 
            this.txtdosageid.Location = new System.Drawing.Point(116, 36);
            this.txtdosageid.Name = "txtdosageid";
            this.txtdosageid.Size = new System.Drawing.Size(100, 20);
            this.txtdosageid.TabIndex = 1;
            // 
            // txtdosagename
            // 
            this.txtdosagename.Location = new System.Drawing.Point(116, 76);
            this.txtdosagename.Name = "txtdosagename";
            this.txtdosagename.Size = new System.Drawing.Size(100, 20);
            this.txtdosagename.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DosageName";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(298, 141);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 12;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(179, 141);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 23);
            this.btnupdate.TabIndex = 11;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(66, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvdosage
            // 
            this.dgvdosage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdosage.Location = new System.Drawing.Point(132, 280);
            this.dgvdosage.Name = "dgvdosage";
            this.dgvdosage.Size = new System.Drawing.Size(423, 184);
            this.dgvdosage.TabIndex = 13;
            // 
            // FrmDosage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 492);
            this.Controls.Add(this.dgvdosage);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtdosagename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdosageid);
            this.Controls.Add(this.label1);
            this.Name = "FrmDosage";
            this.Text = "FrmDosage";
            ((System.ComponentModel.ISupportInitialize)(this.dgvdosage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdosageid;
        private System.Windows.Forms.TextBox txtdosagename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvdosage;
    }
}