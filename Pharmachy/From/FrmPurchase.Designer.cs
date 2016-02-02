namespace Pharmachy
{
    partial class FrmPurchase
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
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPurchaseQty = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dgvPurchaseInfo = new System.Windows.Forms.DataGridView();
            this.cmbSupplierId = new System.Windows.Forms.ComboBox();
            this.cmbMedicineID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(638, 116);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 24;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(535, 116);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 23);
            this.btnupdate.TabIndex = 23;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(427, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Price";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "PurchaseQty";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "SupplierID";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "PurchaseID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Location = new System.Drawing.Point(452, 59);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(215, 20);
            this.txtPrice.TabIndex = 10;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtPurchaseQty
            // 
            this.txtPurchaseQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseQty.Location = new System.Drawing.Point(106, 59);
            this.txtPurchaseQty.Name = "txtPurchaseQty";
            this.txtPurchaseQty.Size = new System.Drawing.Size(215, 20);
            this.txtPurchaseQty.TabIndex = 12;
            this.txtPurchaseQty.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(106, 28);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(215, 20);
            this.txtID.TabIndex = 13;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // dgvPurchaseInfo
            // 
            this.dgvPurchaseInfo.AllowUserToOrderColumns = true;
            this.dgvPurchaseInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseInfo.Location = new System.Drawing.Point(29, 165);
            this.dgvPurchaseInfo.Name = "dgvPurchaseInfo";
            this.dgvPurchaseInfo.Size = new System.Drawing.Size(1038, 393);
            this.dgvPurchaseInfo.TabIndex = 25;
            this.dgvPurchaseInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // cmbSupplierId
            // 
            this.cmbSupplierId.FormattingEnabled = true;
            this.cmbSupplierId.Location = new System.Drawing.Point(452, 35);
            this.cmbSupplierId.Name = "cmbSupplierId";
            this.cmbSupplierId.Size = new System.Drawing.Size(215, 21);
            this.cmbSupplierId.TabIndex = 26;
            // 
            // cmbMedicineID
            // 
            this.cmbMedicineID.FormattingEnabled = true;
            this.cmbMedicineID.Location = new System.Drawing.Point(765, 35);
            this.cmbMedicineID.Name = "cmbMedicineID";
            this.cmbMedicineID.Size = new System.Drawing.Size(215, 21);
            this.cmbMedicineID.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(693, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "MedicineID";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // FrmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 580);
            this.Controls.Add(this.cmbMedicineID);
            this.Controls.Add(this.cmbSupplierId);
            this.Controls.Add(this.dgvPurchaseInfo);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtPurchaseQty);
            this.Controls.Add(this.txtID);
            this.Name = "FrmPurchase";
            this.Text = "FrmPurchase";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPurchaseQty;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridView dgvPurchaseInfo;
        private System.Windows.Forms.ComboBox cmbSupplierId;
        private System.Windows.Forms.ComboBox cmbMedicineID;
        private System.Windows.Forms.Label label4;
    }
}