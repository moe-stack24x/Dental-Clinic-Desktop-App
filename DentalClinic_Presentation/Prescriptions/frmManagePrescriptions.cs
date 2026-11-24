
using DentalClinic_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Prescriptions
{
    public partial class frmManagePrescriptions : Form
    {
        private DataTable _dtAllPrescriptions;
        private int _VisitID;

        public frmManagePrescriptions(int VisitID)
        {
            InitializeComponent();
            _VisitID = VisitID;
        }

        private void frmManagePrescriptions_Load(object sender, EventArgs e)
        {
            _dtAllPrescriptions =
                clsPrescription.GetAllPrescriptionsByVisitID(_VisitID);
           
            dgvAllPrescriptions.DataSource = _dtAllPrescriptions;
            lblRecords.Text =
                _dtAllPrescriptions.DefaultView.Count.ToString();
           
            if (dgvAllPrescriptions.Rows.Count > 0)
            {
                dgvAllPrescriptions.Columns[0].HeaderText = "Prescription ID";
                dgvAllPrescriptions.Columns[1].HeaderText = "Prescription Date";
                dgvAllPrescriptions.Columns[2].HeaderText = "Notes";
                dgvAllPrescriptions.Columns[3].HeaderText = "Items Count";
            }
            dgvAllPrescriptions.RightToLeft = RightToLeft.No;
            dgvAllPrescriptions.AutoGenerateColumns = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePrescription frm =
                new frmAddUpdatePrescription(_VisitID);

            frm.ShowDialog();

            frmManagePrescriptions_Load(null, null);
        }
     
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PrescriptionID =
                (int)dgvAllPrescriptions.CurrentRow.Cells[0].Value;

            frmAddUpdatePrescription frm =
                new frmAddUpdatePrescription(_VisitID, PrescriptionID);

            frm.ShowDialog();

            frmManagePrescriptions_Load(null, null);
        }


        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPrescriptions.CurrentRow == null)
                return;

            if (MessageBox.Show(
                "Are you sure you want to delete this prescription?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            int PrescriptionID =
                Convert.ToInt32(dgvAllPrescriptions.CurrentRow.Cells[0].Value);

            // Get all prescription items.
            DataTable dtPrescriptionItems =
                clsPrescriptionItem.GetAllPrescriptionItemsByPrescriptionID(PrescriptionID);

            // Delete prescription items first.
            foreach (DataRow Row in dtPrescriptionItems.Rows)
            {
                int PrescriptionItemID =
                    Convert.ToInt32(Row["PrescriptionItemID"]);

                if (!clsPrescriptionItem.DeletePrescriptionItem(PrescriptionItemID))
                {
                    MessageBox.Show(
                        "Failed to delete prescription items.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

            // Delete the prescription.
            if (clsPrescription.DeletePrescription(PrescriptionID))
            {
                MessageBox.Show(
                    "Prescription has been deleted successfully.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                frmManagePrescriptions_Load(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Prescription was not deleted.",
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



    }
}
