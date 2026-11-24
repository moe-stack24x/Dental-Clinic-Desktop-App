using DentalClinic_Business;
using DentalClinic_Presentation.Appointments;
using DentalClinic_Presentation.Visits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Appointments
{
    public partial class frmManageAppointments : Form
    {
        private DataTable _dtAllAppointments;
        public frmManageAppointments()
        {
            InitializeComponent();
        }



        private void frmManageAppointments_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtAllAppointments = clsAppointment.GetAllAppointments();
            dgvAllAppointments.DataSource = _dtAllAppointments;
            lblRecordes.Text = _dtAllAppointments.DefaultView.Count.ToString();



            if (dgvAllAppointments.Rows.Count > 0)
            {
                dgvAllAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAllAppointments.Columns[1].HeaderText = "Patient Name";
                dgvAllAppointments.Columns[2].HeaderText = "Dentist Name";
                dgvAllAppointments.Columns[3].HeaderText = "Date";
                dgvAllAppointments.Columns[4].HeaderText = "Start Time";
                dgvAllAppointments.Columns[4].DefaultCellStyle.Format = @"hh\:mm";
                dgvAllAppointments.Columns[5].HeaderText = "End Time";
                dgvAllAppointments.Columns[5].DefaultCellStyle.Format = @"hh\:mm";
                dgvAllAppointments.Columns[6].HeaderText = "Status";

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFillterBy.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Status");

            if (cbFilterBy.Text != "None" && cbFilterBy.Text != "Status")
            {
                txtFillterBy.Text = "";
                txtFillterBy.Focus();
            }
            cbAppointmentStatus.Visible = (cbFilterBy.Text == "Status");
            if (cbFilterBy.Text == "Status")
            {
                cbAppointmentStatus.SelectedIndex = 0;
            }
        }


        private void txtfilterby_TextChanged(object sender, EventArgs e)
        {
            string FillterColumn = "";
            switch (cbFilterBy.Text)
            {
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
                _dtAllAppointments.DefaultView.RowFilter = "";
                lblRecordes.Text = _dtAllAppointments.DefaultView.Count.ToString();
                return;
            }
            if (FillterColumn == "AppointmentID")
                _dtAllAppointments.DefaultView.RowFilter = string.Format("[{0}] = {1}", FillterColumn, txtFillterBy.Text.Trim());
            else
                _dtAllAppointments.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FillterColumn, txtFillterBy.Text.Trim());


            lblRecordes.Text = _dtAllAppointments.DefaultView.Count.ToString();



        }

        private void cbStatusFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbAppointmentStatus.Text)
            {
                case "All":
                    _dtAllAppointments.DefaultView.RowFilter = "";
                    break;

                case "Scheduled":
                    _dtAllAppointments.DefaultView.RowFilter = "AppointmentStatus = 'Scheduled'";
                    break;

                case "Completed":
                    _dtAllAppointments.DefaultView.RowFilter = "AppointmentStatus = 'Completed'";
                    break;
                case "Cancelled":
                    _dtAllAppointments.DefaultView.RowFilter = "AppointmentStatus = 'Cancelled'";
                    break;

                case "Unknown":
                    _dtAllAppointments.DefaultView.RowFilter = "AppointmentStatus = 'Unknown'";
                    break;
            }

            lblRecordes.Text = _dtAllAppointments.DefaultView.Count.ToString();
        }

        private void txtFillterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Appointment ID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            }
        }

        private void btnAddAppointments_Click(object sender, EventArgs e)
        {
            frmAddUpdateAppointment frm = new frmAddUpdateAppointment();
            frm.ShowDialog();
            frmManageAppointments_Load(null, null);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddUpdateAppointment frm = new frmAddUpdateAppointment((int)dgvAllAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageAppointments_Load(null, null);
        }


        private void canselPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cansel this Appointment?", "Confirm canselation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int AppointmentID = (int)dgvAllAppointments.CurrentRow.Cells[0].Value;
            if (clsAppointment.CancelAppointment(AppointmentID))
            {
                MessageBox.Show("Appointment has been canseled successfully", "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManageAppointments_Load(null, null);
            }

            else
                MessageBox.Show("Appointment is not canseled due to data connected to it.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmsPatients_Opening(object sender, CancelEventArgs e)
        {
            clsAppointment appointemtnt = clsAppointment.FindAppointmentById((int)dgvAllAppointments.CurrentRow.Cells[0].Value);

            //only scheduled appointments can be canceled
            cancellPToolStripMenuItem.Enabled = appointemtnt.AppointmentStatus == clsAppointment.enAppointmentStatus.Scheduled;

            //only scheduled appointments can be edited
            EditToolStripMenuItem.Enabled =
               appointemtnt.AppointmentStatus == clsAppointment.enAppointmentStatus.Scheduled;

            //only scheduled appointments can have visits added to them,
            AddVisitToolStripMenuItem.Enabled =
                appointemtnt.AppointmentStatus == clsAppointment.enAppointmentStatus.Scheduled;
        }

        private void AddVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int AppointmentID = (int)dgvAllAppointments.CurrentRow.Cells[0].Value;

            frmAddUpdateVisit frm = new frmAddUpdateVisit(AppointmentID);
            frm.ShowDialog();
            frmManageAppointments_Load(null, null);
        }




    }


}

