using DentalClinic_Presentation.Dentists;
using DentalClinic_Presentation.Global_Classes;
using DentalClinic_Presentation.Login;
using DentalClinic_Presentation.Patients;
using DentalClinic_Presentation.Users;
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

        private void tpManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            LoadForm(frm);
        }

       

       

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            frmManageDentists frm = new frmManageDentists();
            LoadForm(frm);
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            frmManagePatients frm = new frmManagePatients();
            LoadForm(frm);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.ShowDialog();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }
    }
}
