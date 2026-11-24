
using DentalClinic_Business;
using System;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Payments
{
    public partial class frmAddUpdatePayment : Form
    {
        private enum enMode { AddNew, Update }

        private enMode _Mode;

        private int _InvoiceID = -1;
        private int _PaymentID = -1;

        private clsPayment _Payment;

        public frmAddUpdatePayment(int InvoiceID)
        {
            InitializeComponent();

            _InvoiceID = InvoiceID;
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePayment(int InvoiceID, int PaymentID)
        {
            InitializeComponent();

            _InvoiceID = InvoiceID;
            _PaymentID = PaymentID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            dtpPaymentDate.Value = DateTime.Now;

            if (_Mode == enMode.AddNew)
            {
                lblPaymentID.Text = "??";
                btnSave.Text = "Add";
                lblTitle.Text = "Add New Payment";

                _Payment = new clsPayment();
            }
            else
            {
                lblPaymentID.Text = _PaymentID.ToString();
                btnSave.Text = "Update";
                lblTitle.Text = "Update Payment";
            }

            _LoadRemainingAmount();
        }

        private void _LoadData()
        {
            _Payment = clsPayment.Find(_PaymentID);

            if (_Payment == null)
            {
                MessageBox.Show("Payment Not Found.");

                this.Close();
                return;
            }

            lblPaymentID.Text = _Payment.PaymentID.ToString();

            txtPaymentAmount.Text =
                _Payment.PaymentAmount.ToString();

            dtpPaymentDate.Value =
                _Payment.PaymentDatetime;

            _LoadRemainingAmount();
        }

        private void _LoadRemainingAmount()
        {
            decimal TotalAmount =
                clsInvoiceItem.GetInvoiceTotalAmount(_InvoiceID);

            decimal TotalPaid =
                clsPayment.GetTotalPaidAmount(_InvoiceID);

            decimal RemainingAmount =
                TotalAmount - TotalPaid;

            if (_Mode == enMode.Update && _Payment != null)
            {
                RemainingAmount += _Payment.PaymentAmount;
            }

            lblRemainingAmount.Text =
                RemainingAmount.ToString("0.00");
        }

        private void frmAddUpdatePayment_Load(
            object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtPaymentAmount_KeyPress(
            object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar == '.' &&
                !txtPaymentAmount.Text.Contains("."))
            {
                e.Handled = false;
                return;
            }

            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal PaymentAmount;

            if (!decimal.TryParse(
                txtPaymentAmount.Text, out PaymentAmount))
            {
                MessageBox.Show("Please Enter Payment Amount.");
                txtPaymentAmount.Focus();
                return;
            }

            if (PaymentAmount <= 0)
            {
                MessageBox.Show("Payment Amount Must Be Greater Than Zero.");
                txtPaymentAmount.Focus();
                return;
            }

            decimal TotalAmount =
                clsInvoiceItem.GetInvoiceTotalAmount(_InvoiceID);

            decimal TotalPaid =
                clsPayment.GetTotalPaidAmount(_InvoiceID);

            decimal RemainingAmount =
                TotalAmount - TotalPaid;

            if (_Mode == enMode.Update)
                RemainingAmount += _Payment.PaymentAmount;

            if (PaymentAmount > RemainingAmount)
            {
                MessageBox.Show(
                    "Payment Amount Cannot Be Greater Than Remaining Amount.");

                txtPaymentAmount.Focus();
                return;
            }

            _Payment.PaymentAmount = PaymentAmount;

            _Payment.PaymentDatetime =
                dtpPaymentDate.Value;

            _Payment.InvoiceID = _InvoiceID;

            if (_Payment.Save())
            {
                clsInvoice Invoice = clsInvoice.Find(_InvoiceID);

                if (Invoice != null)
                    Invoice.UpdateInvoiceStatus();

                MessageBox.Show("Data Saved Successfully.");

                _Mode = enMode.Update;

                _PaymentID = _Payment.PaymentID;

                lblPaymentID.Text =
                    _PaymentID.ToString();

                btnSave.Text = "Update";
                lblTitle.Text = "Update Payment";

                _LoadRemainingAmount();
            }
            else
            {
                MessageBox.Show("Error: Data Was Not Saved.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
