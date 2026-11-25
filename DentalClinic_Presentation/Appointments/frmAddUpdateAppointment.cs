using DentalClinic_Business;
using DentalClinic_Presentation.Global_Classes;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace DentalClinic_Presentation.Appointments
{
    public partial class frmAddUpdateAppointment : Form
    {
        private int _ApppointmentID = -1;
        private clsAppointment _Apppointment;

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int ApppointmentID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
       

       
        public frmAddUpdateAppointment(int ApppointmentID)
        {
            InitializeComponent();
            _ApppointmentID = ApppointmentID;
            _Mode = enMode.Update;
        }
        public frmAddUpdateAppointment()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void frmAddUpdateAppointment_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Apppointment";
                this.Text = "Add New Apppointment";
                _Apppointment = new clsAppointment();
                ctrlPatientInfoWithFillter1.FilterFocus();
                dtpAppointmentDate.MinDate = DateTime.Now;
                dtpstartTime.Value = DateTime.Now.AddHours(1);
                dtpEndTime.Value = DateTime.Now.AddHours(2);
                cbStatuslist.SelectedIndex = 0;
              
            }
            else
            {
                lblTitle.Text = "Update Apppointment";
                this.Text = "Update Apppointment";
            }

            cbStatuslist.Enabled = false;
            btnSave.Enabled = true;
        }
        private void _LoadData()
        {

           
            _Apppointment = clsAppointment.FindAppointmentById(_ApppointmentID);
            if (_Apppointment == null)
            {
                MessageBox.Show("No Apppointment with ID " + _ApppointmentID, "Apppointment Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            ctrlPatientInfoWithFillter1.LoadPatientInfo(_Apppointment.PatientID);
            ctrlDentistInfoWithFillter1.LoadDentistInfo(_Apppointment.DentistID);
            dtpAppointmentDate.MinDate = _Apppointment.AppointmentDate;
            dtpAppointmentDate.Value = _Apppointment.AppointmentDate;
            dtpstartTime.Value = DateTime.Today.Add(_Apppointment.AppointmentStartTime);
            dtpEndTime.Value = DateTime.Today.Add(_Apppointment.AppointmentEndTime);
            cbStatuslist.SelectedIndex = (int)_Apppointment.AppointmentStatus-1;


        }
     

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
          
            if (dtpEndTime.Value.TimeOfDay <= dtpstartTime.Value.TimeOfDay)
            {
                MessageBox.Show("End Time must be greater than Start Time", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
      

            _Apppointment.PatientID = ctrlPatientInfoWithFillter1.PatientID;
            _Apppointment.DentistID = ctrlDentistInfoWithFillter1.DentistID;
            clsDentist Dentist = clsDentist.FindDentistById(_Apppointment.DentistID);

            if (Dentist == null || !Dentist.IsActive)
            {
                MessageBox.Show("Dentist is not active or does not exist.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //we take just the date without time.
            _Apppointment.AppointmentDate = dtpAppointmentDate.Value.Date;
            //to calculate the time we take just the time without date.
            _Apppointment.AppointmentStartTime = (TimeSpan)dtpstartTime.Value.TimeOfDay;
            _Apppointment.AppointmentEndTime = (TimeSpan)dtpEndTime.Value.TimeOfDay;

            DateTime AppointmentDateTime =  dtpAppointmentDate.Value.Date.Add(dtpstartTime.Value.TimeOfDay);

            if (AppointmentDateTime <= DateTime.Now)
            {
                MessageBox.Show("Appointment time must be in the future.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
           

            if (clsAppointment.IsDentistAvailable( _Apppointment.DentistID, _Apppointment.AppointmentDate, _Apppointment.AppointmentStartTime,
                                                     _Apppointment.AppointmentEndTime, _Apppointment.AppointmentID))
            {
                MessageBox.Show("Dentist already has an appointment at this time.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                _Apppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _Apppointment.AppointmentStatus = clsAppointment.enAppointmentStatus.Scheduled;
            }


            if (_Apppointment.Save())
            {
                lblAppointmentID.Text = _Apppointment.AppointmentID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Apppointment";
                this.Text = "Update Apppointment";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Apppointment.AppointmentID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

   
    }
}
