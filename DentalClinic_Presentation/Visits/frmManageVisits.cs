
using DentalClinic_Business;
using DentalClinic_Presentation.PerformedTreatments;
using DentalClinic_Presentation.Visits.WorkFlow;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Visits
{
    public partial class frmManageVisits : Form
    {
        private DataTable _dtAllVisits;

        public frmManageVisits()
        {
            InitializeComponent();
        }

        private void frmManageVisits_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            _dtAllVisits = clsVisit.GetAllVisits();

            dgvAllVisits.DataSource = _dtAllVisits;

            lblRecordes.Text = _dtAllVisits.DefaultView.Count.ToString();

            if (dgvAllVisits.Rows.Count > 0)
            {
                dgvAllVisits.Columns[0].HeaderText = "Visit ID";
                dgvAllVisits.Columns[1].HeaderText = "Appointment ID";
                dgvAllVisits.Columns[2].HeaderText = "Patient Name";
                dgvAllVisits.Columns[3].HeaderText = "Dentist Name";
                dgvAllVisits.Columns[4].HeaderText = "Patient Complaint";
                dgvAllVisits.Columns[5].HeaderText = "Clinical Notes";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFillterBy.Visible = cbFilterBy.Text != "None";

            if (cbFilterBy.Text != "None")
            {
                txtFillterBy.Text = "";
                txtFillterBy.Focus();
            }
        }

        private void txtfilterby_TextChanged(object sender, EventArgs e)
        {
            string FillterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Visit ID":
                    FillterColumn = "VisitID";
                    break;

                case "Appointment ID":
                    FillterColumn = "AppointmentID";
                    break;

                case "Patient Name":
                    FillterColumn = "PatientName";
                    break;

                case "Dentist Name":
                    FillterColumn = "DentistName";
                    break;

                default:
                    FillterColumn = "None";
                    break;
            }

            if (FillterColumn == "None" || txtFillterBy.Text.Trim() == "")
            {
                _dtAllVisits.DefaultView.RowFilter = "";
                lblRecordes.Text = _dtAllVisits.DefaultView.Count.ToString();
                return;
            }

            if (FillterColumn == "VisitID" || FillterColumn == "AppointmentID")
            {
                _dtAllVisits.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", FillterColumn, txtFillterBy.Text.Trim());
            }
            else
            {
                _dtAllVisits.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '{1}%'", FillterColumn, txtFillterBy.Text.Trim());
            }

            lblRecordes.Text = _dtAllVisits.DefaultView.Count.ToString();
        }

        private void txtFillterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Visit ID" ||
                cbFilterBy.Text == "Appointment ID")
            {
                e.Handled = !char.IsControl(e.KeyChar) &&
                            !char.IsDigit(e.KeyChar);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int VisitID = (int)dgvAllVisits.CurrentRow.Cells[0].Value;
            clsVisit _visit =clsVisit.Find(VisitID);

            frmAddUpdateVisit frm = new frmAddUpdateVisit(_visit.AppointmentID, _visit.VisitID);
            frm.ShowDialog();

            frmManageVisits_Load(null, null);
        }

        private void cmsVisits_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvAllVisits.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }
        }

        private void manageTreatmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int VisitID = (int)dgvAllVisits.CurrentRow.Cells[0].Value;
            frmManagePerformedTreatments frm = new frmManagePerformedTreatments(VisitID);
            frm.ShowDialog();

        }

        private void btnAddPatients_Click(object sender, EventArgs e)
        {
            int VisitID = (int)dgvAllVisits.CurrentRow.Cells[0].Value;
            frmVisitWorkFlow frm = new frmVisitWorkFlow(VisitID);
            frm.ShowDialog();
        }
    }
}
