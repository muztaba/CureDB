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
    
    public partial class FrmPharmacuticles : Form
    {
        private PharmacuticlesInfo obj;
        string Qry = "";
        DataTable dtInfo = new DataTable(); 
        public FrmPharmacuticles()
        {
            InitializeComponent();
            this.LoadPharmacuticles();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            this.loadTOModel();
        }
        private void loadTOModel()
        {
            obj = new PharmacuticlesInfo();
            obj.pharmaId = txtPharmaId.Text;
            obj.pharmaName = txtPharmaName.Text;
            obj.address = txtPharmaAddress.Text;
            obj.catagories = txtPharmaCatagories.Text;
            PharmacuticlesInfoBLL bllObj = new PharmacuticlesInfoBLL();
            bllObj.SavePharmacuticles(obj);
            this.LoadPharmacuticles();
            MessageBox.Show("Data successfully Saved!");
            



        }

        private void FrmPharmacuticles_Load(object sender, EventArgs e)
        {
            
            this.LoadPharmacuticles();
        }

        private void LoadPharmacuticles()
        {
            Qry = "select * from Pharmacuticles";
            dtInfo = DbUtility.GetDataTable(Qry);
            dgvpharmacuticle.DataSource = dtInfo;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            obj = new PharmacuticlesInfo();
            obj.pharmaId = txtPharmaId.Text;
            obj.pharmaName = txtPharmaName.Text;
            obj.address = txtPharmaAddress.Text;
            obj.catagories = txtPharmaCatagories.Text;
            PharmacuticlesInfoBLL bllObj = new PharmacuticlesInfoBLL();
            bllObj.UpdatePharmacuticles(obj);
            
            MessageBox.Show("Data Updated successfully !");
            this.LoadPharmacuticles();

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            obj = new PharmacuticlesInfo();
            obj.pharmaId = txtPharmaId.Text;
            obj.pharmaName = txtPharmaName.Text;
            obj.address = txtPharmaAddress.Text;
            obj.catagories = txtPharmaCatagories.Text;
            PharmacuticlesInfoBLL bllObj = new PharmacuticlesInfoBLL();
            bllObj.DeletePharmacuticles(obj);

            MessageBox.Show("Data Deleted successfully !");
            this.LoadPharmacuticles();
        }

       
    }
}
