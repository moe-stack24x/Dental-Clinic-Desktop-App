using DentalClinic_Presentation.Appointments;
using DentalClinic_Presentation.Dentists;
using DentalClinic_Presentation.Global_Classes;
using DentalClinic_Presentation.Login;
using DentalClinic_Presentation.Patients;
using DentalClinic_Presentation.Prescriptions;
using DentalClinic_Presentation.Settings;
using DentalClinic_Presentation.Users;
using DentalClinic_Presentation.Visits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic_Presentation
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }
        private void LoadForm(Form frm)
        {
            panel.Controls.Clear(); // تفريغ الـ Panel
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel.Controls.Add(frm);
            frm.Show();
        }


        private void btnAppointments_Click(object sender, EventArgs e)
        {
            frmManageAppointments frm = new frmManageAppointments();
            LoadForm(frm);
        }

        private void btnVisits_Click(object sender, EventArgs e)
        {
            frmManageVisits frm = new frmManageVisits();
            LoadForm(frm);
        }
        private void btnPatients_Click(object sender, EventArgs e)
        {
            frmManagePatients frm = new frmManagePatients();
            LoadForm(frm);
        }
        private void btnDentists_Click(object sender, EventArgs e)
        {
            frmManageDentists frm = new frmManageDentists();
            LoadForm(frm);
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            LoadForm(frm);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            this.Close();
            this.Hide();
            _frmLogin.ShowDialog();
          
        }

      
        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmsettings frm = new frmsettings();
            frm.ShowDialog();
        }

        private void btnCurrentUser_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
           frm.ShowDialog();
        }
    }
}
