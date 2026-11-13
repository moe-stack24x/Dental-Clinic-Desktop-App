using DentalClinic_Business;
using DentalClinic_Presentation.Global_Classes;
using Guna.UI2.WinForms;
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
    public partial class frmAddUpdatePatient : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PatientID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        public enum enGendor { Male = 0, Female = 1 };

        private int _PatientId=-1;
        private clsPatient _Patient;


        public frmAddUpdatePatient(int PatientID)
        {
            InitializeComponent();
            _PatientId = PatientID;
            _Mode = enMode.Update;
        }
        public frmAddUpdatePatient()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Patient";
                this.Text= "Add New Patient";
                _Patient =new clsPatient();
            }
            else
            {
                lblTitle.Text = "Update Patient";
                this.Text = "Update Patient";
            }
            txtFirstName.Text = "";
            txtLstName.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            dtpDateTime.Value=DateTime.Now;
            rbMale.Checked = true;
        }
        private void _LoadData()
        {
            _Patient = clsPatient.FindPatientById(_PatientId);
            if(_Patient==null)
            {
                MessageBox.Show("No patient with ID "+_PatientId,"Patient Not Found",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblPatientID.Text = _Patient.PatientID.ToString();
            txtFirstName.Text = _Patient.FirstName;
            txtLstName.Text = _Patient.LastName;
            txtPhoneNumber.Text = _Patient.PhoneNumber;
            txtEmail.Text = _Patient.Email;
            txtAddress.Text = _Patient.Address;
            dtpDateTime.Value =  _Patient.BirthDate;
            rbMale.Checked = _Patient.Gender;
            rbFemale.Checked = !_Patient.Gender;

        }
        private void frmAddUpdatePatient_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _Patient.FirstName= txtFirstName.Text;
            _Patient.LastName=txtLstName.Text;
            _Patient.BirthDate= dtpDateTime.Value;
            _Patient.Gender = rbMale.Checked;
            _Patient.PhoneNumber= txtPhoneNumber.Text;
            _Patient.Email=txtEmail.Text;
            _Patient.Address=txtAddress.Text;
            

            if(_Patient.Save())
            {
                lblPatientID.Text = _Patient.PatientID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Patient";
                this.Text = "Update Patient";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Patient.PatientID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            Guna2TextBox Temp = ((Guna2TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }
        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhoneNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhoneNumber, "This field is required!");
            }

            else if (!clsValidatoin.IsNumber(txtPhoneNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhoneNumber, "Invalid Phone Number Format!");
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, null);
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidatoin.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            ;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
