using DentalClinic_Business;
using DentalClinic_Presentation.Dentists;
using DentalClinic_Presentation.Invoices;
using DentalClinic_Presentation.Patients;
using DentalClinic_Presentation.PerformedTreatments;
using DentalClinic_Presentation.Prescriptions;
using System;
using System.Windows.Forms;

namespace DentalClinic_Presentation.Visits.WorkFlow
{
    public partial class frmVisitWorkFlow : Form
    {
        private int _VisitID;
        private clsVisit _Visit;
        private clsAppointment _Appointment;

        public frmVisitWorkFlow(int VisitID)
        {
            InitializeComponent();

            _VisitID = VisitID;
        }

        private void frmVisitWorkFlow_Load(object sender, EventArgs e)
        {
            _LoadVisitInfo();
            _LoadTabs();
        }

        private void _LoadVisitInfo()
        {
            try
            {
                _Visit = clsVisit.Find(_VisitID);

                if (_Visit == null)
                {
                    MessageBox.Show("Visit was not found.",
                        "Visit Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Close();
                    return;
                }

                txtPatientComplaint.Text = _Visit.PatientComplaint;
                txtClinicalNotes.Text = _Visit.ClinicalNotes;

                _Appointment =
                    clsAppointment.FindAppointmentById(_Visit.AppointmentID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void _LoadTabs()
        {
            _OpenFormInTab( new frmManagePerformedTreatments(_VisitID),tbPerformedTreatments) ;

            _OpenFormInTab(new frmManagePrescriptions(_VisitID), tbPerscriptions);
            _OpenFormInTab(new frmManageInvoices(_VisitID), tbInvoices);

        }

        private void _OpenFormInTab(Form FormToOpen, TabPage Tab)
        {
            FormToOpen.TopLevel = false;
            FormToOpen.FormBorderStyle = FormBorderStyle.None;
            FormToOpen.Dock = DockStyle.Fill;

            Tab.Controls.Clear();
            Tab.Controls.Add(FormToOpen);

            FormToOpen.Show();
        }

        private void btnPatientInfo_Click(object sender, EventArgs e)
        {
            frmPatientCard frm =
                new frmPatientCard(_Appointment.PatientID);

            frm.ShowDialog();
        }

        private void btnDentistInfo_Click(object sender, EventArgs e)
        {
            frmDentistCard frm =
                new frmDentistCard(_Appointment.DentistID);

            frm.ShowDialog();
        }
    }
}