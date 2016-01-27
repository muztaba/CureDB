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
    public partial class FrmDosage : Form
    {
        private DosageInfo obj;

        string Qry = "";
        DataTable dtInfo = new DataTable(); 
        
        public FrmDosage()
        {
            InitializeComponent();
            LoadDosage();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void FrmDosage_Load(object sender, EventArgs e)
        {
           // this.loadMasterData();
            this.LoadDosage();
        }

        private void LoadDosage()
        {
           
            Qry = "select * from DosageForm";
            dtInfo = DbUtility.GetDataTable(Qry);
            dgvdosage.DataSource = dtInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.loadTOModel();
        }

        private void loadTOModel()
        {
            this.LoadDosage();
            obj = new DosageInfo();
            obj.DosageId = txtdosageid.Text;
            obj.DosageName = txtdosagename.Text;

            DosageBLL bllObj=new DosageBLL();
            bllObj.SaveDosage(obj);

            MessageBox.Show("Data successfully Saved!");
            



        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            
            obj = new DosageInfo();
            obj.DosageId = txtdosageid.Text;
            obj.DosageName = txtdosagename.Text;
            DosageBLL bllObj = new DosageBLL();
            bllObj.UpdateDosage(obj);
            MessageBox.Show("Data Updated Successfully");
            this.LoadDosage();
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            obj = new DosageInfo();
            obj.DosageId = txtdosageid.Text;
            obj.DosageName = txtdosagename.Text;
            DosageBLL bllObj = new DosageBLL();
            bllObj.DeleteDosage(obj);
            MessageBox.Show("Data Deleted Successfully");
            this.LoadDosage();
        }




    }
}
