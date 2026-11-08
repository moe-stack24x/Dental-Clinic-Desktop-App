using DentalClinic_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Patients
{
    public partial class frmManagePatients : Form
    {
        private DataTable _dtAllPatients;
        public frmManagePatients()
        {
            InitializeComponent();
        }

        private void frmManagePatients_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtAllPatients = clsPatient.GetAllPatients();
            dgvAllPatients.DataSource = _dtAllPatients;
            lblRecordes.Text = _dtAllPatients.DefaultView.Count.ToString();



            if (dgvAllPatients.Rows.Count > 0)
            {
                dgvAllPatients.Columns[0].HeaderText = "Patient ID";
                dgvAllPatients.Columns[1].HeaderText = "First Name";
                dgvAllPatients.Columns[2].HeaderText = "Last Name";
                dgvAllPatients.Columns[3].HeaderText = "Gender";
                dgvAllPatients.Columns[4].HeaderText = "Phone Number";
                dgvAllPatients.Columns[5].HeaderText = "Birth Date";

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFillterBy.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Gender");
            if (cbFilterBy.Text != "None" && cbFilterBy.Text != "Gender")
            {
                txtFillterBy.Text = "";
                txtFillterBy.Focus();
            }
            cbGenderFillter.Visible = (cbFilterBy.Text == "Gender");
            if (cbFilterBy.Text == "Gender")
            {
                cbGenderFillter.SelectedIndex = 0;
            }
        }


        private void txtfilterby_TextChanged(object sender, EventArgs e)
        {
            string FillterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Patient ID":
                    FillterColumn = "PatientID";
                    break;
                case "First Name":
                    FillterColumn = "FirstName";
                    break;
                case "Last Name":
                    FillterColumn = "LastName";
                    break;
                case "Phone Number":
                    FillterColumn = "PhoneNumber";
                    break;
                case "Gender":
                    FillterColumn = "Gender";
                    break;
                default:
                    FillterColumn = "None";
                    break;
            }

            if (FillterColumn == "None" || txtFillterBy.Text.Trim() == "")
            {
                _dtAllPatients.DefaultView.RowFilter = "";
                lblRecordes.Text = _dtAllPatients.DefaultView.Count.ToString();
                return;
            }
            if (FillterColumn == "PhoneNumber" || FillterColumn == "PatientID")
                _dtAllPatients.DefaultView.RowFilter = string.Format("[{0}] = {1}", FillterColumn, txtFillterBy.Text.Trim());
            else
                _dtAllPatients.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FillterColumn, txtFillterBy.Text.Trim());


            lblRecordes.Text = _dtAllPatients.DefaultView.Count.ToString();



        }

        private void cbGenderFillter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFillterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Patient ID" || cbFilterBy.Text == "Phone Number")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            }
        }

        private void btnAddPatients_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient frm = new frmAddUpdatePatient();
            frm.ShowDialog();
            frmManagePatients_Load(null, null);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient frm = new frmAddUpdatePatient((int)dgvAllPatients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManagePatients_Load(null, null);
        }

        private void DeletePToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this patient?","Confirm Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                return;

            int PatientID = (int)dgvAllPatients.CurrentRow.Cells[0].Value;
            if (clsPatient.DeletePatient(PatientID))
            {
                MessageBox.Show("Patient has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManagePatients_Load(null, null);
            }

            else
                MessageBox.Show("Patient is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cbGenderFillter_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

