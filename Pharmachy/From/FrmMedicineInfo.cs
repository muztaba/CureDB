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
    public partial class FrmMedicineInfo : Form
    {
        private MedicineInfo obj;

        string Qry = "";
        DataTable dtInfo=new DataTable(); 
        public FrmMedicineInfo()
        {
            InitializeComponent();
            this.LoadMedicine();
            this.loadMasterData();
        }

        private void FrmMedicineInfo_Load(object sender, EventArgs e)
        {
            this.loadMasterData();
            this.LoadMedicine();
        }

        private void LoadMedicine()
        {
            Qry = "select * from MedicineInfo";
            dtInfo = DbUtility.GetDataTable(Qry);
            dgvInfo.DataSource = dtInfo;
        }


        private void loadMasterData()
        {
            Qry = "select DosageID, DosageName from DosageForm";
            dtInfo = DbUtility.GetDataTable(Qry);
            cmbDosage.DataSource = dtInfo;
            cmbDosage.DisplayMember = "DosageName";
            cmbDosage.ValueMember = "DosageID";

            Qry = "select PharmaID, PharmaName from Pharmacuticles";
            dtInfo = DbUtility.GetDataTable(Qry);
            cmbPharma.DataSource = dtInfo;
            cmbPharma.DisplayMember = "PharmaName";
            cmbPharma.ValueMember = "PharmaID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.loadTOModel();
        }

        private void loadTOModel()
        {
          obj=new MedicineInfo();
            obj.MedicineID = txtID.Text;
            obj.MedicineBrandName = txtName.Text;
            obj.Contains = txtContains.Text;
            obj.Manufacturar = cmbPharma.SelectedValue.ToString();
            obj.Dosage = cmbDosage.SelectedValue.ToString();
            obj.Price = Convert.ToDecimal(txtPrice.Text);
            MedicineInfoBLL bllObj=new  MedicineInfoBLL();
            bllObj.SaveMedicine(obj);

            MessageBox.Show("Data successfully Saved!");
            this.LoadMedicine();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            obj = new MedicineInfo();
            obj.MedicineID = txtID.Text;
            obj.MedicineBrandName = txtName.Text;
            obj.Contains = txtContains.Text;
            obj.Manufacturar = cmbPharma.SelectedValue.ToString();
            obj.Dosage = cmbDosage.SelectedValue.ToString();
            obj.Price = Convert.ToDecimal(txtPrice.Text);
            MedicineInfoBLL bllObj = new MedicineInfoBLL();
            bllObj.UpdateMedicine(obj);
            MessageBox.Show("Data Updated Successfully");
            this.LoadMedicine();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            obj = new MedicineInfo();
            obj.MedicineID = txtID.Text;
            obj.MedicineBrandName = txtName.Text;
            obj.Contains = txtContains.Text;
            obj.Manufacturar = cmbPharma.SelectedValue.ToString();
            obj.Dosage = cmbDosage.SelectedValue.ToString();
            obj.Price = Convert.ToDecimal(txtPrice.Text);
            MedicineInfoBLL bllObj = new MedicineInfoBLL();
            bllObj.DeleteMedicine(obj);
            MessageBox.Show("Data Deleted Successfully");
            this.LoadMedicine();
        }

        private void dgvInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            obj = new MedicineInfo();
            obj.MedicineID = txtID.Text;
            obj.MedicineBrandName = txtName.Text;
            obj.Contains = txtContains.Text;
            obj.Manufacturar = cmbPharma.SelectedValue.ToString();
            obj.Dosage = cmbDosage.SelectedValue.ToString();
           // obj.Price = Convert.ToDecimal(txtPrice.Text);

            obj.MedicineID = dgvInfo.SelectedRows[0].Cells[0].Value.ToString();
            obj.MedicineID = dgvInfo.SelectedRows[0].Cells[1].Value.ToString();
            obj.Contains = dgvInfo.SelectedRows[0].Cells[2].Value.ToString();
            obj.Dosage = dgvInfo.SelectedRows[0].Cells[3].Value.ToString();
            obj.Manufacturar = dgvInfo.SelectedRows[0].Cells[4].Value.ToString();
            obj.Price = Convert.ToDecimal(dgvInfo.SelectedRows[0].Cells[5].Value.ToString());
        }

        
    }
}
