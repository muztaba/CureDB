using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharma.Utility;

namespace Pharmachy
{
    public partial class FrmPurchase : Form
    {
        public FrmPurchase()
        {
            InitializeComponent();
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            DataTable table = LoadPurchaseTable();
            if (table != null)
            {
                dgvPurchaseInfo.DataSource = table;
            }

        }
        private DataTable LoadPurchaseTable()
        {
            const String query = "select * from PurchaseInfo";
            DataTable table = DbUtility.GetDataTable(query);
            return table;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            PurchaseInfo purchaseInfo = new PurchaseInfo();

            GetTxtFieldData(purchaseInfo);
            purchaseInfo.AddUpdateDate(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            purchaseInfo.UpdateComputer = Environment.MachineName;

            PurchaseBLL objUpdate = new PurchaseBLL();
            objUpdate.Update(purchaseInfo);
            FillDataGridView();
            ClearTxtField();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PurchaseInfo purchaseInfo = new PurchaseInfo();

            // Validation should be in separate class.
            GetTxtFieldData(purchaseInfo);
            purchaseInfo.UpdateComputer = Environment.MachineName;
            purchaseInfo.AddPurchaseDate(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            purchaseInfo.AddUpdateDate(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

            // Inserting value by a data link layer.
            // Should be via BLL. Change will come
            PurchaseDLL purchaseDll = new PurchaseDLL();
            purchaseDll.Save(purchaseInfo);
            FillDataGridView();
            ClearTxtField();
        }

       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbDosage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPharma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContains_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            PurchaseInfo deleteInfo = new PurchaseInfo();
            GetTxtFieldData(deleteInfo);
            DialogResult dialog = MessageBox.Show("Do you want to delete the selected row?","Delete",  MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                PurchaseBLL objBll = new PurchaseBLL();
                objBll.Delete(deleteInfo);
            }
            FillDataGridView();
            ClearTxtField();
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = dgvPurchaseInfo.CurrentRow.Index;
            PurchaseInfo purchaseInfo = new PurchaseInfo();

            purchaseInfo.PurchaseId = dgvPurchaseInfo[1, row].Value.ToString();
            purchaseInfo.SupplierId = dgvPurchaseInfo[3, row].Value.ToString();
            purchaseInfo.Quantity = Convert.ToInt32(dgvPurchaseInfo[4, row].Value);
            purchaseInfo.Price = Convert.ToInt32(dgvPurchaseInfo[6, row].Value);

            FillTxtField(purchaseInfo);

        }

        private void GetTxtFieldData(PurchaseInfo purchaseInfo)
        {
            purchaseInfo.PurchaseId = txtID.Text;
            purchaseInfo.SupplierId = txtSupplierId.Text;
            purchaseInfo.Price = Convert.ToDecimal(txtPrice.Text);
            purchaseInfo.Quantity = Convert.ToInt32(txtPurchaseQty.Text);
        }

        private void FillTxtField(PurchaseInfo purchaseInfo)
        {
            txtID.Text = purchaseInfo.PurchaseId;
            txtSupplierId.Text = purchaseInfo.SupplierId;
            txtPurchaseQty.Text = purchaseInfo.Quantity.ToString();
            txtPrice.Text = purchaseInfo.Price.ToString();
        }

        private void ClearTxtField()
        {
            txtID.Text = String.Empty;
            txtSupplierId.Text = String.Empty;
            txtPurchaseQty.Text = String.Empty;
            txtPrice.Text = String.Empty;
        }
    }
}
