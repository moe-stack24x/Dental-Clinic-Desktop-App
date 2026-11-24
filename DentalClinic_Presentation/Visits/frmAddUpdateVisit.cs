
using DentalClinic_Business;
using DentalClinic_Presentation.Dentists;
using DentalClinic_Presentation.Global_Classes;
using DentalClinic_Presentation.Patients;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Visits
{
    public partial class frmAddUpdateVisit : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int VisitID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _AppointmentID = -1;
        private clsAppointment _Appointment;
        private int _VisitID = -1;
        private clsVisit _Visit;


        // Constructor for Add New Visit
        public frmAddUpdateVisit(int AppointmentID)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _Mode = enMode.AddNew;
        }


        // Constructor for Update Visit
        public frmAddUpdateVisit(int AppointmentID, int VisitID)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _VisitID = VisitID;

            _Mode = enMode.Update;
        }


        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Visit";
                this.Text = "Add New Visit";
                _Visit = new clsVisit();
            }
            else
            {
                lblTitle.Text = "Update Visit";
                this.Text = "Update Visit";

                lblVisitID.Text = _VisitID.ToString();
            }

            // Load Appointment Information
            _Appointment = clsAppointment.FindAppointmentById(_AppointmentID);

            lblAppointmentID.Text = _AppointmentID.ToString();

            lblAppointmentDate.Text =
                clsFormat.DateToShort(_Appointment.AppointmentDate);

            lblDentist.Text = _Appointment.DentistInfo.FullName;
            lblPatient.Text = _Appointment.PatientInfo.FullName;

            txtClinicalNotes.Text = "";
            txtPatientComplaint.Text = "";
        }


        private void _LoadData()
        {
            _Visit = clsVisit.Find(_VisitID);

            if (_Visit == null)
            {
                MessageBox.Show("Visit was not found.",
                    "Visit Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }

            txtClinicalNotes.Text = _Visit.ClinicalNotes;

            txtPatientComplaint.Text = _Visit.PatientComplaint;
        }


        private void frmAddUpdateVisit_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            if (_Mode == enMode.AddNew)
            {
               
                _Visit.AppointmentID = _AppointmentID;
                _Visit.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }

            _Visit.PatientComplaint = txtPatientComplaint.Text.Trim();
            _Visit.ClinicalNotes = txtClinicalNotes.Text.Trim();

            if (_Visit.Save())
            {
                MessageBox.Show("Data Saved Successfully.");

                _Mode = enMode.Update;
                _VisitID = _Visit.VisitID;

                DataBack?.Invoke(this, _VisitID);
            }
            else
            {
                MessageBox.Show("Error: Data Was Not Saved.");
            }
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            // Set AutoValidate property of your Form to EnableAllowFocusChange in Designer

            Guna2TextBox Temp = ((Guna2TextBox)sender);

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnPatientInfo_Click(object sender, EventArgs e)
        {
           
            frmPatientCard frm = new frmPatientCard(_Appointment.PatientID);
            frm.ShowDialog();
        }


        private void btnDentistInfo_Click(object sender, EventArgs e)
        {
           

            frmDentistCard frm =new frmDentistCard(_Appointment.DentistID);
            frm.ShowDialog();
        }
    }
}
