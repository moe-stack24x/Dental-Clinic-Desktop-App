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
    public partial class ctrlPatientInfo : UserControl
    {
        public ctrlPatientInfo()
        {
            InitializeComponent();
        }

        private void ctrlPatientInfo_Load(object sender, EventArgs e)
        {

        }
        private clsPatient _Patient;
        private int _PatientID = -1;

        public int PatientID
        {
            get { return _PatientID; }
        }
       
        public clsPatient SelectedPatientInfo
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
            lblID.Text = _Patient.PatientID.ToString();
            lblName.Text = _Patient.FirstName.ToString();

          

        }

        private void _ResetPersonInfo()
        {


            lblID.Text = "";
            lblName.Text = "";
           
        }

    }
}
