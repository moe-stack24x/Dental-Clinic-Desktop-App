using DentalClinic_Business;
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

namespace DentalClinic_Presentation.Users
{
    public partial class frmManageUsers : Form
    {

        private DataTable _dtAllUsers;
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtAllUsers = clsUser.GetAllUsers();
            dgvAllUsers.DataSource = _dtAllUsers;
            lblRecordes.Text = _dtAllUsers.DefaultView.Count.ToString();



            if (dgvAllUsers.Rows.Count > 0)
            {
                dgvAllUsers.Columns[0].HeaderText = "User ID";
                dgvAllUsers.Columns[1].HeaderText = "User Name";
                dgvAllUsers.Columns[2].HeaderText = "Is Active";

            }
        }
      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFillterBy.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Active");
            if (cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Active")
            {
                txtFillterBy.Text = "";
                txtFillterBy.Focus();
            }
            cbIsActive.Visible = (cbFilterBy.Text == "Is Active");
            if (cbFilterBy.Text == "Is Active")
            {
                cbIsActive.SelectedIndex = 0;
            }
        }


        private void txtfilterby_TextChanged(object sender, EventArgs e)
        {
            string FillterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FillterColumn = "UserID";
                    break;
                case "User Name":
                    FillterColumn = "UserName";
                    break;
                default:
                    FillterColumn = "None";
                    break;
            }

            if (FillterColumn == "None" || txtFillterBy.Text.Trim() == "")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordes.Text = _dtAllUsers.DefaultView.Count.ToString();
                return;
            }
            if (FillterColumn == "UserID")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FillterColumn, txtFillterBy.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FillterColumn, txtFillterBy.Text.Trim());


            lblRecordes.Text = _dtAllUsers.DefaultView.Count.ToString();



        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            bool FilterValue = true;

            switch (cbIsActive.Text)
            {
                case "All":
                    _dtAllUsers.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    FilterValue = true;
                    break;

                case "No":
                    FilterValue = false;
                    break;
            }

            if (cbIsActive.Text != "All") _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordes.Text = _dtAllUsers.DefaultView.Count.ToString();
        }


        private void txtFillterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User ID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            }
        }

        private void DeletePToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int UserID = (int)dgvAllUsers.CurrentRow.Cells[0].Value;
            if (clsUser.DeleteUser(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManageUsers_Load(null, null);
            }

            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      
         private void btnAddUsers_Click(object sender, EventArgs e)
         {
             frmAddUpdateUser frm = new frmAddUpdateUser();
             frm.ShowDialog();
             frmManageUsers_Load(null, null);
         }

         private void EditToolStripMenuItem_Click(object sender, EventArgs e)
         {
             frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
             frm.ShowDialog();
             frmManageUsers_Load(null, null);
         }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }
    }
}

