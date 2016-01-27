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
    public partial class FrmUnit : Form
    {
        private UnitInfo obj;
        string Qry = "";
        DataTable dtInfo = new DataTable();
        public FrmUnit()
        {
            InitializeComponent();
            this.LoadUnit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.loadTOModel();
        }

        private void FrmUnit_Load(object sender, EventArgs e)
        {
            this.LoadUnit();
        }

        private void LoadUnit()
        {
            Qry = "select * from Unit";
            dtInfo = DbUtility.GetDataTable(Qry);
            dgvunit.DataSource = dtInfo;
        }

        private void loadTOModel()
        {
            obj = new UnitInfo();
            obj.UnitID = txtunitid.Text;
            obj.UnitName = txtunitname.Text;
            
            UnitInfoBLL bllObj = new UnitInfoBLL();
            bllObj.SaveUnit(obj);

            MessageBox.Show("Data successfully Saved!");
            this.LoadUnit();



        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            obj = new UnitInfo();
            obj.UnitID = txtunitid.Text;
            obj.UnitName = txtunitname.Text;

            UnitInfoBLL bllObj = new UnitInfoBLL();
            bllObj.UpdateUnit(obj);

            MessageBox.Show("Data updated  successfully !");
            this.LoadUnit();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            obj = new UnitInfo();
            obj.UnitID = txtunitid.Text;
            obj.UnitName = txtunitname.Text;

            UnitInfoBLL bllObj = new UnitInfoBLL();
            bllObj.Delete(obj);

            MessageBox.Show("Data deleted  successfully !");
            this.LoadUnit();
        }


    }
}
