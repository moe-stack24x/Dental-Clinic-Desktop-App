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
    public partial class ctrlDentistInfo : UserControl
    {
        public ctrlDentistInfo()
        {
            InitializeComponent();
        }

        private void ctrlDentistInfo_Load(object sender, EventArgs e)
        {

        }
        private clsDentist _Dentist;
        private int _DentistID = -1;

        public int DentistID
        {
            get { return _DentistID; }
        }
        public clsDentist SelectedDentistInfo
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
            lblID.Text = _Dentist.DentistID.ToString();
            lblName.Text = _Dentist.FirstName.ToString();



        }

        private void _ResetPersonInfo()
        {


            lblID.Text = "";
            lblName.Text = "";

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

