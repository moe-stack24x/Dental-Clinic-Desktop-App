
using DentalClinic_Business;
using DentalClinic_Presentation.Patients;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Payments
{
    public partial class frmManagePayments : Form
    {
        private DataTable _dtAllPayments;
        private int _InvoiceID;

        public frmManagePayments(int InvoiceID)
        {
            InitializeComponent();

            _InvoiceID = InvoiceID;
        }

        private void frmManagePayments_Load(object sender, EventArgs e)
        {
            _dtAllPayments =
                clsPayment.GetAllPaymentsByInvoiceID(_InvoiceID);

            dgvAllPayments.DataSource = _dtAllPayments;

            lblRecords.Text =
                _dtAllPayments.DefaultView.Count.ToString();

            if (dgvAllPayments.Rows.Count > 0)
            {
                dgvAllPayments.Columns[0].HeaderText = "Payment ID";
                dgvAllPayments.Columns[1].HeaderText = "Payment Amount";
                dgvAllPayments.Columns[2].HeaderText = "Payment Date";
                dgvAllPayments.Columns[3].HeaderText = "Invoice ID";
            }
        }

       private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePayment frm =
                new frmAddUpdatePayment(_InvoiceID);

            frm.ShowDialog();

            frmManagePayments_Load(null, null);
        }

       private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PaymentID =
                Convert.ToInt32(dgvAllPayments.CurrentRow.Cells[0].Value);

            frmAddUpdatePayment frm =
                new frmAddUpdatePayment(_InvoiceID, PaymentID);

            frm.ShowDialog();

            frmManagePayments_Load(null, null);
        }


        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPayments.CurrentRow == null)
                return;

            int PaymentID =
                Convert.ToInt32(dgvAllPayments.CurrentRow.Cells[0].Value);

            if (MessageBox.Show(
                "Are You Sure You Want To Delete This Payment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (clsPayment.DeletePayment(PaymentID))
            {
                clsInvoice Invoice = clsInvoice.Find(_InvoiceID);

                if (Invoice != null)
                    Invoice.UpdateInvoiceStatus();

                MessageBox.Show("Payment Deleted Successfully.");

                frmManagePayments_Load(null, null);
            }
            else
            {
                MessageBox.Show("Error: Payment Was Not Deleted.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
