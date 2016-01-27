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
    public partial class FrmMedicineGrp : Form
    {
        private MedicinegrpInfo obj;
        string Qry = "";
        DataTable dtInfo = new DataTable();
        public FrmMedicineGrp()
        {
            InitializeComponent();
            this.LoadMedicinegrp();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.loadTOModel();
            
        }

        private void FrmMedicineGrp_Load(object sender, EventArgs e)
        {
            this.LoadMedicinegrp();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            this.LoadMedicinegrp();
            obj = new MedicinegrpInfo();
            obj.GroupID = txtgrpid.Text;
            obj.GroupName = txtgrpname.Text;

            MedicinegrpInfoDAL bllObj = new MedicinegrpInfoDAL();
            bllObj.UpdateMedicinegrp(obj);

            MessageBox.Show("Data successfully Updated!");
            this.LoadMedicinegrp();



        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            this.LoadMedicinegrp();

            obj = new MedicinegrpInfo();
            obj.GroupID = txtgrpid.Text;
            obj.GroupName = txtgrpname.Text;

            MedicinegrpInfoDAL bllObj = new MedicinegrpInfoDAL();
            bllObj.DeleteMedicinegrp(obj);

            MessageBox.Show("Data successfully deleted!");
            this.LoadMedicinegrp();


        }

        private void LoadMedicinegrp()
        {
            Qry = "select * from MedicineGroup";
            dtInfo = DbUtility.GetDataTable(Qry);
            dgvmedicinegrp.DataSource = dtInfo;
        }


        private void loadTOModel()
        {
            obj = new MedicinegrpInfo();
            obj.GroupID = txtgrpid.Text;
            obj.GroupName = txtgrpname.Text;

            MedicinegrpInfoDAL bllObj = new MedicinegrpInfoDAL();
            bllObj.DeleteMedicinegrp(obj);

            MessageBox.Show("Data successfully Saved!");
            this.LoadMedicinegrp();



        }
    }
}
