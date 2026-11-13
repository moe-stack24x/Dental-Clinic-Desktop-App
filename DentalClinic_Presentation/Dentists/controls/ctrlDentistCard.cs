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

namespace DentalClinic_Presentation.Dentists.controls
{
    public partial class ctrlDentistCard : UserControl
    {
      

      
        private clsDentist _Dentist;
        private int _DentistID = -1;

        public int DentistID
        {
            get { return _DentistID; }
        }

        public clsDentist SelectedDentist
        {
            get { return _Dentist; }
        }

        public void LoadDentistInfo(int DentistID)
        {

            _Dentist = clsDentist.FindDentistById(DentistID);
            if (_Dentist == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Dentist with DentistID = " + DentistID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillDentistInfo();
        }

        private void _FillDentistInfo()
        {

            _DentistID = _Dentist.DentistID;
            txtDentistID.Text = _Dentist.DentistID.ToString();
            txtFirstName.Text = _Dentist.FirstName;
            txtLastName.Text = _Dentist.LastName;
            txtSpecialization.Text = _Dentist.Specialization;
            txtphoneNumber.Text = _Dentist.PhoneNumber;
            txtisActive.Text = _Dentist.IsActive ? "Yes" : "No";

        }

        private void _ResetPersonInfo()
        {


            txtDentistID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtSpecialization.Text = "";
            txtphoneNumber.Text = "";
            txtisActive.Text = "";
           

        }


        public ctrlDentistCard()
        {
            InitializeComponent();
        }
     

        private void btnEditDentist_Click(object sender, EventArgs e)
        {
            frmAddUpdateDentist frm = new frmAddUpdateDentist(_DentistID);
            frm.DataBack += Frm_DataBack;
            frm.ShowDialog();
        }
        public void Frm_DataBack(object sender, int DentistID)
        {
            LoadDentistInfo(DentistID);
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ctrlDentistCard_Load_1(object sender, EventArgs e)
        {

        }
    }
}
