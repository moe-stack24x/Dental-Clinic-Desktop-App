using DentalClinic_Business;
using DentalClinic_Presentation.Payments;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Invoices
{
    public partial class frmManageInvoices : Form
    {
        private DataTable _dtAllInvoices;
        private int _VisitID;

        public frmManageInvoices(int VisitID)
        {
            InitializeComponent();
            _VisitID = VisitID;
        }

        private void frmManageInvoices_Load(object sender, EventArgs e)
        {
            _dtAllInvoices = clsInvoice.GetAllInvoicesByVisitID(_VisitID);

            dgvAllInvoices.DataSource = _dtAllInvoices;

            lblRecords.Text = _dtAllInvoices.DefaultView.Count.ToString();

            if (dgvAllInvoices.Rows.Count > 0)
            {
                dgvAllInvoices.Columns[0].HeaderText = "Invoice ID";
                dgvAllInvoices.Columns[1].HeaderText = "Invoice Date";
                dgvAllInvoices.Columns[2].HeaderText = "Invoice Status";
                dgvAllInvoices.Columns[3].HeaderText = "Total Amount";
                dgvAllInvoices.Columns[4].HeaderText = "Total Paid";
                dgvAllInvoices.Columns[5].HeaderText = "Remaining Amount";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIssueInvoice frm = new frmIssueInvoice(_VisitID);

            frm.ShowDialog();

            frmManageInvoices_Load(null, null);
        }

       
    
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to delete this invoice?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            int InvoiceID = (int)dgvAllInvoices.CurrentRow.Cells[0].Value;

            if (clsInvoice.DeleteInvoice(InvoiceID))
            {
                MessageBox.Show(
                    "Invoice has been deleted successfully.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                frmManageInvoices_Load(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Cannot delete this invoice because it has payments.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void managePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePayments frm = new frmManagePayments((int)dgvAllInvoices.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}