
using System;
using System.Data;
using DentalClinic_DataAccess;

namespace DentalClinic_Business
{
    public class clsPrescription
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode = enMode.AddNew;

        public int PrescriptionID { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Notes { get; set; }
        public int VisitID { get; set; }

        public clsPrescription()
        {
            PrescriptionID = -1;
            PrescriptionDate = DateTime.Now;
            Notes = "";
            VisitID = -1;

            Mode = enMode.AddNew;
        }

        private clsPrescription(int PrescriptionID,
            DateTime PrescriptionDate, string Notes, int VisitID)
        {
            this.PrescriptionID = PrescriptionID;
            this.PrescriptionDate = PrescriptionDate;
            this.Notes = Notes;
            this.VisitID = VisitID;

            Mode = enMode.Update;
        }

        public static clsPrescription Find(int PrescriptionID)
        {
            DateTime PrescriptionDate = DateTime.Now;
            string Notes = "";
            int VisitID = -1;

            if (clsPrescriptionData.GetPrescriptionById( PrescriptionID, ref PrescriptionDate, ref Notes, ref VisitID))
            {
                return new clsPrescription( PrescriptionID,PrescriptionDate,  Notes, VisitID);
            }

            return null;
        }

        private bool _AddNewPrescription()
        {
            this.PrescriptionID = clsPrescriptionData.AddPrescription(this.PrescriptionDate, this.Notes, this.VisitID);

            return this.PrescriptionID > 0;
        }

        private bool _UpdatePrescription()
        {
            return clsPrescriptionData.UpdatePrescription(
                this.PrescriptionID,
                this.PrescriptionDate,
                this.Notes,
                this.VisitID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPrescription())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdatePrescription();
            }

            return false;
        }

        public static bool DeletePrescription(int PrescriptionID)
        {
            return clsPrescriptionData.DeletePrescription(PrescriptionID);
        }

        public static DataTable GetAllPrescriptionsByVisitID(int VisitID)
        {
            return clsPrescriptionData.GetAllPrescriptionsByVisitID(VisitID);
        }
    }
}
