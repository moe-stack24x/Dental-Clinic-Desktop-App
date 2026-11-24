
using DentalClinic_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.PerformedTreatments
{
    public partial class frmAddUpdatePerformedTreatment : Form
    {
        private enum enMode { AddNew, Update }

        private enMode _Mode;

        private int _VisitID = -1;
        private int _PerformedTreatmentID = -1;

        private clsPerformedTreatment _PerformedTreatment;

        public frmAddUpdatePerformedTreatment(int VisitID)
        {
            InitializeComponent();

            _VisitID = VisitID;
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerformedTreatment(int VisitID, int PerformedTreatmentID)
        {
            InitializeComponent();

            _VisitID = VisitID;
            _PerformedTreatmentID = PerformedTreatmentID;
            _Mode = enMode.Update;
        }

        private void _LoadTreatmentTypes()
        {
            cbTreatmentTypes.DataSource = clsTreatmentType.GetAllTreatmentTypes();

            cbTreatmentTypes.DisplayMember = "TreatmentTypeName";
            cbTreatmentTypes.ValueMember = "TreatmentTypeID";
        }

        private void _ResetDefaultValues()
        {
            _LoadTreatmentTypes();

            txtTreatmentDescription.ReadOnly = true;
            txtFees.ReadOnly = true;

            dtpTreatmentDate.Value = DateTime.Now;

            if (_Mode == enMode.AddNew)
            {
                lblPerformedTreatmentID.Text = "??";
                btnSave.Text = "Add";
                lblTitle.Text= "Add New Performed Treatment";

                _PerformedTreatment = new clsPerformedTreatment();
            }
            else
            {
                lblPerformedTreatmentID.Text = _PerformedTreatmentID.ToString();
                btnSave.Text = "Update";
                lblTitle.Text = "Update Performed Treatment";
            }
        }

        private void _LoadData()
        {
            _PerformedTreatment =
                clsPerformedTreatment.Find(_PerformedTreatmentID);

            if (_PerformedTreatment == null)
            {
                MessageBox.Show("Performed Treatment Not Found.");

                this.Close();
                return;
            }

            cbTreatmentTypes.SelectedValue =
                _PerformedTreatment.TreatmentTypeID;

            dtpTreatmentDate.Value =
                _PerformedTreatment.PerformedTreatmentDateTime;

            _LoadTreatmentTypeInfo();
        }

        private void _LoadTreatmentTypeInfo()
        {
            if (cbTreatmentTypes.SelectedItem == null)
                return;

            DataRowView Row =  (DataRowView)cbTreatmentTypes.SelectedItem;

            txtTreatmentDescription.Text = Row["TreatmentTypeDescription"].ToString();

            txtFees.Text =Row["DefaultPrice"].ToString();
        }

        private void frmAddUpdatePerformedTreatment_Load(
            object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void cbTreatmentTypes_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            _LoadTreatmentTypeInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            if (cbTreatmentTypes.SelectedValue == null)
            {
                MessageBox.Show("Please Select Treatment Type.");
                return;
            }

            _PerformedTreatment.VisitID = _VisitID;

            _PerformedTreatment.TreatmentTypeID =
                Convert.ToInt32(cbTreatmentTypes.SelectedValue);

            _PerformedTreatment.PerformedTreatmentDateTime =
                dtpTreatmentDate.Value;

            if (_PerformedTreatment.Save())
            {
                MessageBox.Show("Data Saved Successfully.");

                _Mode = enMode.Update;
                _PerformedTreatmentID = _PerformedTreatment.PerformedTreatmentID;

                lblPerformedTreatmentID.Text =
                    _PerformedTreatmentID.ToString();

                btnSave.Text = "Update";
            }
            else
            {
                MessageBox.Show("Error: Data Was Not Saved.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
