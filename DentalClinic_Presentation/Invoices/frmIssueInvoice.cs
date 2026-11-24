using DentalClinic_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Invoices
{
    public partial class frmIssueInvoice : Form
    {
        private int _VisitID;
        private clsInvoice _Invoice;
        private DataTable _dtPerformedTreatments;

        public frmIssueInvoice(int VisitID)
        {
            InitializeComponent();

            _VisitID = VisitID;
        }

        private void frmAddUpdateInvoice_Load(object sender, EventArgs e)
        {
            _Invoice = clsInvoice.FindByVisitID(_VisitID);

            if (_Invoice != null)
            {
                MessageBox.Show(
                    "An invoice has already been issued for this visit.",
                    "Invoice Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
                return;
            }

            lblInvoiceID.Text = "N/A";
            lblVisitID.Text = _VisitID.ToString();
            dtpInvoiceIssueDate.Value = DateTime.Now;

            _LoadPerformedTreatments();

            _CalculateTotalAmount();
        }

        private void _LoadPerformedTreatments()
        {
            _dtPerformedTreatments =
                clsPerformedTreatment.GetAllPerformedTreatmentsByVisitID(_VisitID);

            dgvInvoiceItems.DataSource = _dtPerformedTreatments;

            if (dgvInvoiceItems.Rows.Count > 0)
            {
                dgvInvoiceItems.Columns[0].HeaderText = "Performed Treatment ID";
                dgvInvoiceItems.Columns[1].HeaderText = "Treatment Type";
                dgvInvoiceItems.Columns[2].HeaderText = "Treatment Date";
                dgvInvoiceItems.Columns[3].HeaderText = "Price";
            }
        }

        private void _CalculateTotalAmount()
        {
            decimal TotalAmount = 0;

            foreach (DataRow Row in _dtPerformedTreatments.Rows)
            {
                TotalAmount += Convert.ToDecimal(Row["DefaultPrice"]);
            }

            lblTotalAmount.Text = TotalAmount.ToString("0.00");
            lblTotalPaid.Text = "0.00";
            lblRemainingAmount.Text = TotalAmount.ToString("0.00");
        }

        private void btnIssueInvoice_Click(object sender, EventArgs e)
        {
            if (_dtPerformedTreatments.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There are no performed treatments to invoice.",
                    "No Treatments",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (clsInvoice.FindByVisitID(_VisitID) != null)
            {
                MessageBox.Show(
                    "An invoice has already been issued for this visit.",
                    "Invoice Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (MessageBox.Show(
                "Are you sure you want to issue this invoice?",
                "Confirm Invoice",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _Invoice = new clsInvoice();

            _Invoice.VisitID = _VisitID;
            _Invoice.InvoiceIssueDate = dtpInvoiceIssueDate.Value;
            _Invoice.InvoiceStatus = clsInvoice.enInvoiceStatus.Unpaid;

            if (!_Invoice.Save())
            {
                MessageBox.Show(
                    "Invoice was not issued.",
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            foreach (DataRow Row in _dtPerformedTreatments.Rows)
            {
                clsInvoiceItem InvoiceItem = new clsInvoiceItem();

                InvoiceItem.InvoiceID = _Invoice.InvoiceID;

                InvoiceItem.PerformedTreatmentID =
                    Convert.ToInt32(Row["PerformedTreatmentID"]);

                InvoiceItem.Price =
                    Convert.ToDecimal(Row["DefaultPrice"]);

                if (!InvoiceItem.Save())
                {
                    MessageBox.Show(
                        "An error occurred while adding invoice items.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

            lblInvoiceID.Text = _Invoice.InvoiceID.ToString();

            MessageBox.Show(
                "Invoice has been issued successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
