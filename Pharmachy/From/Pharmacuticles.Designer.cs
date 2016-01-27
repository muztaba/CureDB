namespace Pharmachy
{
    partial class FrmPharmacuticles
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPharmaId = new System.Windows.Forms.TextBox();
            this.txtPharmaAddress = new System.Windows.Forms.TextBox();
            this.txtPharmaName = new System.Windows.Forms.TextBox();
            this.txtPharmaCatagories = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.dgvpharmacuticle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpharmacuticle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PharmaId";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PharmaName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Catagories";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-325, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "label4";
            // 
            // txtPharmaId
            // 
            this.txtPharmaId.Location = new System.Drawing.Point(125, 21);
            this.txtPharmaId.Name = "txtPharmaId";
            this.txtPharmaId.Size = new System.Drawing.Size(266, 20);
            this.txtPharmaId.TabIndex = 7;
            // 
            // txtPharmaAddress
            // 
            this.txtPharmaAddress.Location = new System.Drawing.Point(125, 89);
            this.txtPharmaAddress.Name = "txtPharmaAddress";
            this.txtPharmaAddress.Size = new System.Drawing.Size(266, 20);
            this.txtPharmaAddress.TabIndex = 8;
            // 
            // txtPharmaName
            // 
            this.txtPharmaName.Location = new System.Drawing.Point(125, 55);
            this.txtPharmaName.Name = "txtPharmaName";
            this.txtPharmaName.Size = new System.Drawing.Size(266, 20);
            this.txtPharmaName.TabIndex = 7;
            // 
            // txtPharmaCatagories
            // 
            this.txtPharmaCatagories.Location = new System.Drawing.Point(125, 122);
            this.txtPharmaCatagories.Name = "txtPharmaCatagories";
            this.txtPharmaCatagories.Size = new System.Drawing.Size(266, 20);
            this.txtPharmaCatagories.TabIndex = 7;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(125, 173);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(95, 33);
            this.btnsave.TabIndex = 9;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(248, 173);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(95, 33);
            this.btnupdate.TabIndex = 10;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(372, 174);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(95, 33);
            this.btndelete.TabIndex = 11;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // dgvpharmacuticle
            // 
            this.dgvpharmacuticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpharmacuticle.Location = new System.Drawing.Point(625, 39);
            this.dgvpharmacuticle.Name = "dgvpharmacuticle";
            this.dgvpharmacuticle.Size = new System.Drawing.Size(240, 150);
            this.dgvpharmacuticle.TabIndex = 12;
            // 
            // FrmPharmacuticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 262);
            this.Controls.Add(this.dgvpharmacuticle);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtPharmaAddress);
            this.Controls.Add(this.txtPharmaCatagories);
            this.Controls.Add(this.txtPharmaName);
            this.Controls.Add(this.txtPharmaId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPharmacuticles";
            this.Text = "FrmPharmacuticles";
            this.Load += new System.EventHandler(this.FrmPharmacuticles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpharmacuticle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPharmaId;
        private System.Windows.Forms.TextBox txtPharmaAddress;
        private System.Windows.Forms.TextBox txtPharmaName;
        private System.Windows.Forms.TextBox txtPharmaCatagories;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.DataGridView dgvpharmacuticle;
    }
}