
using DentalClinic_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Prescriptions
{
    public partial class frmAddUpdatePrescription : Form
    {
        private enum enMode { AddNew, Update }

        private enMode _Mode;

        private int _VisitID = -1;
        private int _PrescriptionID = -1;

        private clsPrescription _Prescription;

        private DataTable _dtPrescriptionItems;

        public frmAddUpdatePrescription(int VisitID)
        {
            InitializeComponent();

            _CreatePrescriptionItemsDataTable();

            _VisitID = VisitID;
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePrescription(int VisitID, int PrescriptionID)
        {
            InitializeComponent();

            _CreatePrescriptionItemsDataTable();

            _VisitID = VisitID;
            _PrescriptionID = PrescriptionID;
            _Mode = enMode.Update;
        }

        private void _CreatePrescriptionItemsDataTable()
        {
            _dtPrescriptionItems = new DataTable();

            _dtPrescriptionItems.Columns.Add("PrescriptionItemID", typeof(int));
            _dtPrescriptionItems.Columns.Add("MedicationName", typeof(string));
            _dtPrescriptionItems.Columns.Add("Dosage", typeof(string));
            _dtPrescriptionItems.Columns.Add("Frequency", typeof(byte));
            _dtPrescriptionItems.Columns.Add("Duration", typeof(int));
            _dtPrescriptionItems.Columns.Add("Instructions", typeof(string));

            dgvPrescriptionItems.DataSource = _dtPrescriptionItems;

            _LoadPrescriptionItemsColumns();
        }

        private void _LoadPrescriptionItemsColumns()
        {
            dgvPrescriptionItems.Columns["PrescriptionItemID"].HeaderText = "Prescription Item ID";
            dgvPrescriptionItems.Columns["MedicationName"].HeaderText = "Medication Name";
            dgvPrescriptionItems.Columns["Dosage"].HeaderText = "Dosage";
            dgvPrescriptionItems.Columns["Frequency"].HeaderText = "Frequency";
            dgvPrescriptionItems.Columns["Duration"].HeaderText = "Duration";
            dgvPrescriptionItems.Columns["Instructions"].HeaderText = "Instructions";
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblPrescriptionID.Text = "??";
                lblTitle.Text = "Add New Prescription";
                this.Text = "Add New Prescription";

                _Prescription = new clsPrescription();
            }
            else
            {
                lblPrescriptionID.Text = _PrescriptionID.ToString();
                lblTitle.Text = "Update Prescription";
                this.Text = "Update Prescription";
            }

            dtpPrescriptionDate.Value = DateTime.Now;
            lblVisitID.Text = _VisitID.ToString();
            txtNotes.Clear();

            _ClearPrescriptionItemFields();
        }

        private void _ClearPrescriptionItemFields()
        {
            txtMedicationName.Clear();
            txtDosage.Clear();
            txtFrequency.Clear();
            txtDuration.Clear();
            txtInstructions.Clear();

            btnAddItem.Text = "Add Item";
        }

        private void _LoadData()
        {
            _Prescription = clsPrescription.Find(_PrescriptionID);

            if (_Prescription == null)
            {
                MessageBox.Show("Prescription Not Found.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }

            lblPrescriptionID.Text = _Prescription.PrescriptionID.ToString();

            dtpPrescriptionDate.Value = _Prescription.PrescriptionDate;
            txtNotes.Text = _Prescription.Notes;

            _LoadPrescriptionItems();
        }

        private void _LoadPrescriptionItems()
        {
            _dtPrescriptionItems =
                clsPrescriptionItem.GetAllPrescriptionItemsByPrescriptionID(_PrescriptionID);

            dgvPrescriptionItems.DataSource = _dtPrescriptionItems;

          

         
        }

        private void frmAddUpdatePrescription_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

    

        private void dgvPrescriptionItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPrescriptionItems.CurrentRow == null ||
                dgvPrescriptionItems.CurrentRow.IsNewRow)
                return;

            txtMedicationName.Text =
                dgvPrescriptionItems.CurrentRow.Cells["MedicationName"].Value.ToString();

            txtDosage.Text =
                dgvPrescriptionItems.CurrentRow.Cells["Dosage"].Value.ToString();

            txtFrequency.Text =
                dgvPrescriptionItems.CurrentRow.Cells["Frequency"].Value.ToString();

            txtDuration.Text =
                dgvPrescriptionItems.CurrentRow.Cells["Duration"].Value.ToString();

            txtInstructions.Text =
                dgvPrescriptionItems.CurrentRow.Cells["Instructions"].Value.ToString();

            btnAddItem.Text = "Update Item";
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicationName.Text) ||txtMedicationName.Text.Trim().Length > 50)
            {
                MessageBox.Show("Please Enter A Valid Medication Name (Max 50 Characters).");
                txtMedicationName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDosage.Text) ||txtDosage.Text.Trim().Length > 30)
            {
                MessageBox.Show("Please Enter A Valid Dosage (Max 30 Characters).");
                txtDosage.Focus();
                return;
            }

            if (txtInstructions.Text.Trim().Length > 100)
            {
                MessageBox.Show("Instructions Cannot Exceed 100 Characters.");
                txtInstructions.Focus();
                return;
            }


            if (btnAddItem.Text == "Update Item")
            {
                if (dgvPrescriptionItems.CurrentRow == null)
                    return;

                dgvPrescriptionItems.CurrentRow.Cells["MedicationName"].Value = txtMedicationName.Text.Trim();

                dgvPrescriptionItems.CurrentRow.Cells["Dosage"].Value = txtDosage.Text.Trim();

                dgvPrescriptionItems.CurrentRow.Cells["Frequency"].Value = Convert.ToByte(txtFrequency.Text.Trim());

                dgvPrescriptionItems.CurrentRow.Cells["Duration"].Value = Convert.ToInt32(txtDuration.Text.Trim());

                dgvPrescriptionItems.CurrentRow.Cells["Instructions"].Value = txtInstructions.Text.Trim();
            }
            else
            {
                _dtPrescriptionItems.Rows.Add(-1, txtMedicationName.Text.Trim(),  txtDosage.Text.Trim(),   Convert.ToByte(txtFrequency.Text.Trim()),
                                             Convert.ToInt32(txtDuration.Text.Trim()),   txtInstructions.Text.Trim());
            }

            _ClearPrescriptionItemFields();
        }

        private bool _SavePrescriptionItems()
        {
            foreach (DataGridViewRow Row in dgvPrescriptionItems.Rows)
            {
                if (Row.IsNewRow)
                    continue;

                int ItemID = Convert.ToInt32(Row.Cells["PrescriptionItemID"].Value);

                clsPrescriptionItem Item;

                if (ItemID == -1)
                    Item = new clsPrescriptionItem();
                else
                    Item = clsPrescriptionItem.Find(ItemID);

                if (Item == null)
                    return false;

                Item.PrescriptionID = _Prescription.PrescriptionID;
                Item.MedicationName = Row.Cells["MedicationName"].Value.ToString();
                Item.Dosage =         Row.Cells["Dosage"].Value.ToString();
                Item.Frequency =   Convert.ToByte( Row.Cells["Frequency"].Value);
                Item.Duration =    Convert.ToInt32(Row.Cells["Duration"].Value);
                Item.Instructions =   Row.Cells["Instructions"].Value.ToString();

                if (!Item.Save())
                    return false;

                //if item is new
                if (ItemID == -1)
                    Row.Cells["PrescriptionItemID"].Value = Item.PrescriptionItemID;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnAddItem.Text == "Update Item")
            {
                MessageBox.Show("Please Update The Selected Item First.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvPrescriptionItems.Rows.Count == 0)
            {
                MessageBox.Show("Please Add At Least One Medication.");
                return;
            }

            if (txtNotes.Text.Trim().Length > 100)
            {
                MessageBox.Show("Notes Cannot Exceed 100 Characters.");
                txtNotes.Focus();
                return;
            }
            //--------------------------------------------------------------------


            _Prescription.PrescriptionDate = dtpPrescriptionDate.Value;
            _Prescription.Notes = txtNotes.Text.Trim();
            _Prescription.VisitID = _VisitID;

            //save prescription first cause prescriptionItems has a foreign key prescriptionID.
            if (!_Prescription.Save())
            {
                MessageBox.Show("Error: Data Was Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_SavePrescriptionItems())
            {
                MessageBox.Show("Prescription Was Saved, But Some Items Were Not Saved.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Data Saved Successfully.","Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _Mode = enMode.Update;
            _PrescriptionID = _Prescription.PrescriptionID;

            lblPrescriptionID.Text = _PrescriptionID.ToString();
            lblTitle.Text = "Update Prescription";
            this.Text = "Update Prescription";
            btnSave.Text = "Update";
        }




        private void DeletePToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionItems.CurrentRow == null)
                return;

          if (MessageBox.Show("Are you sure you want to delete this item?","Confirm Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            int ItemID = Convert.ToInt32( dgvPrescriptionItems.CurrentRow.Cells["PrescriptionItemID"].Value);

            if (ItemID != -1 && !clsPrescriptionItem.DeletePrescriptionItem(ItemID))
            {
                MessageBox.Show("Failed to delete item.");
               
                return;
            }
          
            dgvPrescriptionItems.Rows.Remove(dgvPrescriptionItems.CurrentRow);

            _ClearPrescriptionItemFields();
        }

        private void txtNumericFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

       
    }
}
