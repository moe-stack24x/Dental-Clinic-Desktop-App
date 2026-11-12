
using System;
using System.Data;
using DentalClinic_DataAccess;

namespace DentalClinic_Business
{
    public class clsVisit
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        public enMode Mode { get; set; }

        public int VisitID { get; set; }
        public int AppointmentID { get; set; }
        public string PatientComplaint { get; set; }
        public string ClinicalNotes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsAppointment AppointmentInfo { get; set; }
       
        public clsVisit()
        {
            VisitID = -1;
            AppointmentID = -1;
            PatientComplaint = null;
            ClinicalNotes = null;
            CreatedByUserID = -1;
            AppointmentInfo = new clsAppointment();

            Mode = enMode.AddNew;
        }

        private clsVisit(
            int VisitID,
            int AppointmentID,
            string PatientComplaint,
            string ClinicalNotes,
            int CreatedByUserID)
        {
            this.VisitID = VisitID;
            this.AppointmentID = AppointmentID;
            this.PatientComplaint = PatientComplaint;
            this.ClinicalNotes = ClinicalNotes;
            this.CreatedByUserID = CreatedByUserID;
            AppointmentInfo =clsAppointment.FindAppointmentById(AppointmentID);

            Mode = enMode.Update;
        }

        public static clsVisit Find(int VisitID)
        {
            int AppointmentID = -1;
            string PatientComplaint = null;
            string ClinicalNotes = null;
            int CreatedByUserID = -1;

            bool IsFound = clsVisitData.GetVisitInfoByID(
                VisitID,
                ref AppointmentID,
                ref PatientComplaint,
                ref ClinicalNotes,
                ref CreatedByUserID);

            if (IsFound)
            {
                return new clsVisit(
                    VisitID,
                    AppointmentID,
                    PatientComplaint,
                    ClinicalNotes,
                    CreatedByUserID);
            }

            return null;
        }

        public static clsVisit FindByAppointmentID(int AppointmentID)
        {
            int VisitID = -1;
            string PatientComplaint = null;
            string ClinicalNotes = null;
            int CreatedByUserID = -1;

            bool IsFound = clsVisitData.GetVisitInfoByAppointmentID(
                AppointmentID,
                ref VisitID,
                ref PatientComplaint,
                ref ClinicalNotes,
                ref CreatedByUserID);

            if (IsFound)
            {
                return new clsVisit(
                    VisitID,
                    AppointmentID,
                    PatientComplaint,
                    ClinicalNotes,
                    CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewVisit()
        {
            this.VisitID = clsVisitData.AddNewVisit(
                this.AppointmentID,
                this.PatientComplaint,
                this.ClinicalNotes,
                this.CreatedByUserID);

            return this.VisitID != -1;
        }

        private bool _UpdateVisit()
        {
            return clsVisitData.UpdateVisit(
                this.VisitID,
                this.AppointmentID,
                this.PatientComplaint,
                this.ClinicalNotes);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewVisit())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateVisit();
            }

            return false;
        }

        public static DataTable GetAllVisits()
        {
            return clsVisitData.GetAllVisits();
        }
    }
}
