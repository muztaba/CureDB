﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmachy
{
    public partial class PharmaMDI : Form
    {
        private int childFormNumber = 0;

        public PharmaMDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedicineInfo frm=new FrmMedicineInfo();
            frm.Show();
        }

        private void dosageInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDosage frm = new FrmDosage();
            frm.Show();
        }

        private void pharmacutileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPharmacuticles frm=new FrmPharmacuticles();
            frm.Show();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnit frm=new FrmUnit();
            frm.Show();
        }

        private void medicineGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FrmMedicineGrp frm= new FrmMedicineGrp();
            frm.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void purchaseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmPurchase frmPurchase = new FrmPurchase();
            frmPurchase.Show();
        }
    }
}
