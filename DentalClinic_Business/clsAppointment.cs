
using DentalClinic_DataAccess;
using System;
using System.Data;

namespace DentalClinic_Business
{
    public class clsAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enum enAppointmentStatus
        {
            Scheduled = 1, Cancelled = 2, Completed = 3
        }

        public enMode Mode = enMode.AddNew;

        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DentistID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentStartTime { get; set; }
        public TimeSpan AppointmentEndTime { get; set; }
        public enAppointmentStatus AppointmentStatus { get; set; }
        public int CreatedByUserID { get; set; }

        public string AppointmentStatusText
        {
            get
            {
                switch (AppointmentStatus)
                {
                    case enAppointmentStatus.Scheduled:
                        return "Scheduled";

                    case enAppointmentStatus.Cancelled:
                        return "Cancelled";

                    case enAppointmentStatus.Completed:
                        return "Completed";

                    default:
                        return "Unknown";
                }
            }
        }
        public clsAppointment()
        {
            AppointmentID = -1;
            PatientID = -1;
            DentistID = -1;
            AppointmentDate = DateTime.Now;
            AppointmentStartTime = TimeSpan.Zero;
            AppointmentEndTime = TimeSpan.Zero;
            AppointmentStatus = enAppointmentStatus.Scheduled;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsAppointment(
            int AppointmentID,
            int PatientID,
            int DentistID,
            DateTime AppointmentDate,
            TimeSpan AppointmentStartTime,
            TimeSpan AppointmentEndTime,
            enAppointmentStatus AppointmentStatus,
            int CreatedByUserID)
        {
            this.AppointmentID = AppointmentID;
            this.PatientID = PatientID;
            this.DentistID = DentistID;
            this.AppointmentDate = AppointmentDate;
            this.AppointmentStartTime = AppointmentStartTime;
            this.AppointmentEndTime = AppointmentEndTime;
            this.AppointmentStatus = AppointmentStatus;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewAppointment()
        {
            this.AppointmentID = clsAppointmentData.AddAppointment(
                this.PatientID,
                this.DentistID,
                this.AppointmentDate,
                this.AppointmentStartTime,
                this.AppointmentEndTime,
                (byte)this.AppointmentStatus,
                this.CreatedByUserID);

            return (this.AppointmentID != 0);
        }

        private bool _UpdateAppointment()
        {
            return clsAppointmentData.UpdateAppointment(
                this.AppointmentID,
                this.PatientID,
                this.DentistID,
                this.AppointmentDate,
                this.AppointmentStartTime,
                this.AppointmentEndTime,
                (byte)this.AppointmentStatus);
        }

        public static clsAppointment FindAppointmentById(int AppointmentID)
        {
            int PatientID = -1;
            int DentistID = -1;
            DateTime AppointmentDate = DateTime.Now;
            TimeSpan AppointmentStartTime = TimeSpan.Zero;
            TimeSpan AppointmentEndTime = TimeSpan.Zero;
            byte AppointmentStatus = (byte)enAppointmentStatus.Scheduled;
            int CreatedByUserID = -1;

            bool IsFound = clsAppointmentData.GetAppointmentById(
                AppointmentID,
                ref PatientID,
                ref DentistID,
                ref AppointmentDate,
                ref AppointmentStartTime,
                ref AppointmentEndTime,
                ref AppointmentStatus,
                ref CreatedByUserID);

            if (IsFound)
            {
                return new clsAppointment(
                    AppointmentID,
                    PatientID,
                    DentistID,
                    AppointmentDate,
                    AppointmentStartTime,
                    AppointmentEndTime,
                    (enAppointmentStatus)AppointmentStatus,
                    CreatedByUserID);
            }

            return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateAppointment();
            }

            return false;
        }

        public static DataTable GetAllAppointments()
        {
            return clsAppointmentData.GetAllAppointments();
        }

        public static bool CancelAppointment(int AppointmentID)
        {
            return clsAppointmentData.CancelAppointment(AppointmentID);
        }
        public static bool IsDentistAvailable(int DentistID, DateTime AppointmentDate, TimeSpan StartTime, TimeSpan EndTime,int AppointmentID =-1)
        {
            return clsAppointmentData.IsDentistAvailable(DentistID, AppointmentDate, StartTime, EndTime,AppointmentID);
        }
    }
}
