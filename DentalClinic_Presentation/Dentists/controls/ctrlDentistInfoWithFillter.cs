using DentalClinic_Business;
using DentalClinic_Presentation.Dentists.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Dentists.controls
{
    public partial class ctrlDentistInfoWithFillter : UserControl
    {
      
        // Define a custom event handler delegate with parameters
        public event Action<int> OnDentistSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void DentistSelected(int DentistID)
        {
            Action<int> handler = OnDentistSelected;
            if (handler != null)
            {
                handler(DentistID); // Raise the event with the parameter
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

        public int DentistID
        {
            get { return ctrlDentistInfo1.DentistID; }
        }
        public clsDentist SelectedDentistInfo
        {
            get { return ctrlDentistInfo1.SelectedDentistInfo; }
        }

        public ctrlDentistInfoWithFillter()
        {
            InitializeComponent();
        }

        private void ctrlDentistInfoWithFillter_Load(object sender, EventArgs e)
        {

        }

        public void LoadDentistInfo(int DentistID)
        {
            gbFillter.Enabled = false;
            txtsearch.Text = DentistID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            ctrlDentistInfo1.LoadDentistInfo(Convert.ToInt32(txtsearch.Text.Trim()));

            if (OnDentistSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnDentistSelected(ctrlDentistInfo1.DentistID);
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
            if (txtsearch.Text == "Search  Dentis By ID")
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
    }
}
