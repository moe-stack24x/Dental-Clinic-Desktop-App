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
using TheArtOfDevHtmlRenderer.Adapters;

namespace DentalClinic_Presentation.Dentists
{
    public partial class frmAddUpdateDentist : Form
    {



        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int DentistID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _DentistId = -1;
        private clsDentist _Dentist;


        public frmAddUpdateDentist(int DentistID)
        {
            InitializeComponent();
            _DentistId = DentistID;
            _Mode = enMode.Update;
        }
        public frmAddUpdateDentist()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void frmAddUpdateDentist_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Dentist";
                this.Text = "Add New Dentist";
                _Dentist = new clsDentist();
            }
            else
            {
                lblTitle.Text = "Update Dentist";
                this.Text = "Update Dentist";
            }
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtSpecialization.Text = "";
            txtPhoneNumber.Text = "";

            chkIsActive.Checked = true;
        }
        private void _LoadData()
        {
            _Dentist = clsDentist.FindDentistById(_DentistId);
            if (_Dentist == null)
            {
                MessageBox.Show("No Dentist with ID " + _DentistId, "Dentist Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblDentistID.Text = _Dentist.DentistID.ToString();
            txtFirstName.Text = _Dentist.FirstName;
            txtLastName.Text = _Dentist.LastName;
            txtPhoneNumber.Text = _Dentist.PhoneNumber;
            txtSpecialization.Text = _Dentist.Specialization;
            chkIsActive.Checked = _Dentist.IsActive;


        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _Dentist.FirstName = txtFirstName.Text;
            _Dentist.LastName = txtLastName.Text;

            _Dentist.IsActive = chkIsActive.Checked;
            _Dentist.PhoneNumber = txtPhoneNumber.Text;
            _Dentist.Specialization = txtSpecialization.Text;

            if (_Dentist.Save())
            {
                lblDentistID.Text = _Dentist.DentistID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Dentist";
                this.Text = "Update Dentist";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Dentist.DentistID);
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhoneNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhoneNumber, "This field is required!");
            }
         
            else if(!clsValidatoin.IsNumber(txtPhoneNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhoneNumber, "Invalid Phone Number Format!");
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, null);
            }
        }
    }
}

