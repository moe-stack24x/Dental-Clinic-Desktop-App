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
    public partial class ctrlPatientInfoWithFillter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPatientSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PatientSelected(int PatientID)
        {
            Action<int> handler = OnPatientSelected;
            if (handler != null)
            {
                handler(PatientID); // Raise the event with the parameter
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {   
                _FilterEnabled = value;
                gbFillter.Enabled = _FilterEnabled;
            }
        }

        public int PatientID
        {
            get { return ctrlPatientInfo1.PatientID; }
        }
        public clsPatient SelectedPatient
        {
            get {return ctrlPatientInfo1.SelectedPatientInfo; }
        }
        public ctrlPatientInfoWithFillter()
        {
            InitializeComponent();
        }
        public void LoadPatientInfo(int PatientID)
        {
            gbFillter.Enabled = false;
            txtsearch.Text = PatientID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            ctrlPatientInfo1.LoadPatientInfo(Convert.ToInt32(txtsearch.Text.Trim()));

            if (OnPatientSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPatientSelected(ctrlPatientInfo1.PatientID);
        }

        public void FilterFocus()
        {
            txtsearch.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            FindNow();
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtsearch.Text == "Search  Patient By ID")
            {
                txtsearch.Text = "";
                txtsearch.ForeColor = Color.Black;
            }

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

           
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void ctrlPatientInfoWithFillter_Load(object sender, EventArgs e)
        {

        }
    }
}
