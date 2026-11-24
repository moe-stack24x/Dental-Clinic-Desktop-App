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

namespace DentalClinic_Presentation.Patients
{
    public partial class frmPatientCard : Form
    {

       
        private int _PatientID = -1;

        public int PatientID
        {
            get { return ctrlPatientcard1.PatientID; }
        }

        public clsPatient SelectedPatientInfo
        {
            get { return ctrlPatientcard1.SelectedPatient; }
        }
        public frmPatientCard(int PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID;
        }

        private void frmPatientCard_Load(object sender, EventArgs e)
        {
            ctrlPatientcard1.LoadPatientInfo(_PatientID);
        }

        private void ctrlPatientcard1_Load(object sender, EventArgs e)
        {

        }
    }
}
