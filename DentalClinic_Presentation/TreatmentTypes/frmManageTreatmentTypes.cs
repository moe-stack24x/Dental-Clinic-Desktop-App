
using DentalClinic_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.TreatmentTypes
{
    public partial class frmManageTreatmentTypes : Form
    {
        private DataTable _dtAllTreatmentTypes;

        public frmManageTreatmentTypes()
        {
            InitializeComponent();
        }

        private void frmManageTreatmentTypes_Load(object sender, EventArgs e)
        {
            _dtAllTreatmentTypes =
                clsTreatmentType.GetAllTreatmentTypes();

            dgvAllTreatmentTypes.DataSource = _dtAllTreatmentTypes;

            lblRecords.Text =
                 dgvAllTreatmentTypes.Rows.Count.ToString();

            if (dgvAllTreatmentTypes.Columns.Count > 0)
            {
                dgvAllTreatmentTypes.Columns["TreatmentTypeID"].HeaderText =
                    "Treatment Type ID";

                dgvAllTreatmentTypes.Columns["TreatmentTypeName"].HeaderText =
                    "Treatment Type Name";

                dgvAllTreatmentTypes.Columns["TreatmentTypeDescription"].HeaderText =
                    "Description";

                dgvAllTreatmentTypes.Columns["DefaultPrice"].HeaderText =
                    "Default Price";
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
