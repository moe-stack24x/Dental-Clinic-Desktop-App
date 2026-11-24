using DentalClinic_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.PerformedTreatments
{
    public partial class frmManagePerformedTreatments : Form
    {
        private DataTable _dtAllPerformedTreatments;
        private int _VisitID;

        public frmManagePerformedTreatments(int VisitID)
        {
            InitializeComponent();
            _VisitID = VisitID;
        }

        private void frmManagePerformedTreatments_Load(object sender, EventArgs e)
        {
            _dtAllPerformedTreatments =
                clsPerformedTreatment.GetAllPerformedTreatmentsByVisitID(_VisitID);

            dgvAllPerformedTreatments.DataSource = _dtAllPerformedTreatments;

            lblRecords.Text = _dtAllPerformedTreatments.DefaultView.Count.ToString();

            if (dgvAllPerformedTreatments.Rows.Count > 0)
            {
                dgvAllPerformedTreatments.Columns[0].HeaderText = "Performed Treatment ID";
                dgvAllPerformedTreatments.Columns[1].HeaderText = "Treatment Type";
                dgvAllPerformedTreatments.Columns[2].HeaderText = "Treatment Date";
                dgvAllPerformedTreatments.Columns[3].HeaderText = "Price";

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerformedTreatment frm =
                new frmAddUpdatePerformedTreatment(_VisitID);

            frm.ShowDialog();

            frmManagePerformedTreatments_Load(null, null);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PerformedTreatmentID =
                (int)dgvAllPerformedTreatments.CurrentRow.Cells[0].Value;

            frmAddUpdatePerformedTreatment frm =
                new frmAddUpdatePerformedTreatment(_VisitID,PerformedTreatmentID);

            frm.ShowDialog();

            frmManagePerformedTreatments_Load(null, null);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to delete this performed treatment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            int PerformedTreatmentID =
                (int)dgvAllPerformedTreatments.CurrentRow.Cells[0].Value;

            if (clsPerformedTreatment.DeletePerformedTreatment(PerformedTreatmentID))
            {
                MessageBox.Show(
                    "Performed treatment has been deleted successfully",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                frmManagePerformedTreatments_Load(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Performed treatment was not deleted.",
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}