using DentalClinic_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Patients.Controls
{
    public partial class ctrlPatientcard : UserControl
    {

        private clsPatient _Patient;
        private int _PatientID = -1;

        public int PatientID
        {
            get { return _PatientID; }
        }

        public clsPatient SelectedPatient
        {
            get { return _Patient; }
        }

        public void LoadPatientInfo(int PatientID)
        {

            _Patient = clsPatient.FindPatientById(PatientID);
            if (_Patient == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Patient with PatientID = " + PatientID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPatientInfo();
        }

        private void _FillPatientInfo()
        {

            _PatientID = _Patient.PatientID;
            txtPatientID.Text = _Patient.PatientID.ToString();
            txtFirstName.Text = _Patient.FirstName;
            txtLastName.Text = _Patient.LastName;
            txtPhoneNumber.Text = _Patient.PhoneNumber;
            txtEmail.Text = _Patient.Email;
            txtAdrees.Text = _Patient.Address;
            txtGender.Text = _Patient.Gender ? "Male" : "Female";

            if (_Patient.BirthDate!=null    )
            {
                dtpBirthDate.Value = _Patient.BirthDate;
            }
            else
            {
                dtpBirthDate.Value = DateTime.Now;
            }



        }

        private void _ResetPersonInfo()
        {


            txtPatientID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAdrees.Text = "";
            txtGender.Text = "";
            dtpBirthDate.Value = DateTime.Now;

        }


        public ctrlPatientcard()
        {
            InitializeComponent();
        }
        private void ctrlPatientcard_Load(object sender, EventArgs e)
        {

        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient frm = new frmAddUpdatePatient(_PatientID);
            frm.DataBack += Frm_DataBack;
            frm.Show();
        }
        public void Frm_DataBack(object sender, int PatientID)
        {
            LoadPatientInfo(PatientID);
        }
    }
}
