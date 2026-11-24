using DentalClinic_Presentation.Global_Classes;
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

namespace DentalClinic_Presentation.Settings
{
    public partial class frmsettings : Form
    {
        public frmsettings()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void btnClinicInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clinic Information not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dental Clinic Management System\nVersion 1.0\n© 2026 Dental Clinic", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
