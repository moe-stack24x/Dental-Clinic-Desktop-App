using DentalClinic_Business;
using DentalClinic_Presentation.Dentists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Dentists
{
    public partial class frmManageDentists : Form
    {
      

       
        private DataTable _dtAllDentists;
       
         public frmManageDentists()
        {
            InitializeComponent();
        }

        private void frmManageDentists_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtAllDentists = clsDentist.GetAllDentists();
            dgvAllDentists.DataSource = _dtAllDentists;
            lblRecordes.Text = _dtAllDentists.DefaultView.Count.ToString();



            if (dgvAllDentists.Rows.Count > 0)
            {
                dgvAllDentists.Columns[0].HeaderText = "Dentist ID";
                dgvAllDentists.Columns[1].HeaderText = "First Name";
                dgvAllDentists.Columns[2].HeaderText = "Last Name";
                dgvAllDentists.Columns[3].HeaderText = "Specialization";
                dgvAllDentists.Columns[4].HeaderText = "Phone Number";
                dgvAllDentists.Columns[5].HeaderText = "Is Active";

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFillterBy.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Active");
            if (cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Active")
            {
                txtFillterBy.Text = "";
                txtFillterBy.Focus();
            }
            cbIsActive.Visible = (cbFilterBy.Text == "Is Active");
            if (cbFilterBy.Text == "Is Active")
            {
                cbIsActive.SelectedIndex = 0;
            }
        }


        private void txtfilterby_TextChanged(object sender, EventArgs e)
        {
            string FillterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Dentist ID":
                    FillterColumn = "DentistID";
                    break;
                case "First Name":
                    FillterColumn = "FirstName";
                    break;
                case "Last Name ":
                    FillterColumn = "LastName";
                    break;
                case "Specialization":
                    FillterColumn = "Specialization";
                    break;
                default:
                    FillterColumn = "None";
                    break;
            }

            if (FillterColumn == "None" || txtFillterBy.Text.Trim() == "")
            {
                _dtAllDentists.DefaultView.RowFilter = "";
                lblRecordes.Text = _dtAllDentists.DefaultView.Count.ToString();
                return;
            }
            if ( FillterColumn == "DentistID")
                _dtAllDentists.DefaultView.RowFilter = string.Format("[{0}] = {1}", FillterColumn, txtFillterBy.Text.Trim());
            else
                _dtAllDentists.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FillterColumn, txtFillterBy.Text.Trim());


            lblRecordes.Text = _dtAllDentists.DefaultView.Count.ToString();



        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            bool FilterValue = true;

            switch (cbIsActive.Text)
            {
                case "All":
                    _dtAllDentists.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    FilterValue = true;
                    break;

                case "No":
                    FilterValue = false;
                    break;
            }

            if (cbIsActive.Text != "All") _dtAllDentists.DefaultView.RowFilter =string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordes.Text = _dtAllDentists.DefaultView.Count.ToString();
        }
      
       
        private void txtFillterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Dentist ID" )
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            }
        }

       private void btnAddDentists_Click(object sender, EventArgs e)
        {
            frmAddUpdateDentist frm = new frmAddUpdateDentist();
            frm.ShowDialog();
            frmManageDentists_Load(null, null);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateDentist frm = new frmAddUpdateDentist((int)dgvAllDentists.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageDentists_Load(null, null);
        }
        
        
       
        private void DeActivePToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to deactivate this Dentist?", "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int DentistID = (int)dgvAllDentists.CurrentRow.Cells[0].Value;
            if (clsDentist.DeactivateDentist(DentistID))
            {
                MessageBox.Show("Dentist has been deactivated successfully", "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManageDentists_Load(null, null);
            }

            else
                MessageBox.Show("Dentist is not deactivated due to data connected to it.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

