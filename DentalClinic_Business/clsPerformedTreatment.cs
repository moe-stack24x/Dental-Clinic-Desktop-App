
using DentalClinic_DataAccess;
using System;
using System.Data;

namespace DentalClinic_Business
{
    public class clsPerformedTreatment
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        public enMode Mode { get; set; }

        public int PerformedTreatmentID { get; set; }

        public DateTime PerformedTreatmentDateTime { get; set; }

        public int VisitID { get; set; }

        public int TreatmentTypeID { get; set; }

        public clsTreatmentType TreatmentTypeInfo { get; set; }


        public clsPerformedTreatment()
        {
            PerformedTreatmentID = -1;
            PerformedTreatmentDateTime = DateTime.Now;
            VisitID = -1;
            TreatmentTypeID = -1;
            TreatmentTypeInfo = new clsTreatmentType();

            Mode = enMode.AddNew;
        }


        private clsPerformedTreatment(
            int PerformedTreatmentID,
            DateTime PerformedTreatmentDateTime,
            int VisitID,
            int TreatmentTypeID)
        {
            this.PerformedTreatmentID = PerformedTreatmentID;
            this.PerformedTreatmentDateTime = PerformedTreatmentDateTime;
            this.VisitID = VisitID;
            this.TreatmentTypeID = TreatmentTypeID;

            this.TreatmentTypeInfo =
                clsTreatmentType.Find(TreatmentTypeID);

            Mode = enMode.Update;
        }


        public static clsPerformedTreatment Find(int PerformedTreatmentID)
        {
            DateTime PerformedTreatmentDateTime = DateTime.Now;
            int VisitID = -1;
            int TreatmentTypeID = -1;

            bool IsFound =
                clsPerformedTreatmentData.GetPerformedTreatmentInfoByID(
                    PerformedTreatmentID,
                    ref PerformedTreatmentDateTime,
                    ref VisitID,
                    ref TreatmentTypeID);

            if (IsFound)
            {
                return new clsPerformedTreatment(
                    PerformedTreatmentID,
                    PerformedTreatmentDateTime,
                    VisitID,
                    TreatmentTypeID);
            }

            return null;
        }


        private bool _AddNewPerformedTreatment()
        {
            this.PerformedTreatmentID =
                clsPerformedTreatmentData.AddNewPerformedTreatment(
                    this.PerformedTreatmentDateTime,
                    this.VisitID,
                    this.TreatmentTypeID);

            return this.PerformedTreatmentID != -1;
        }


        private bool _UpdatePerformedTreatment()
        {
            return clsPerformedTreatmentData.UpdatePerformedTreatment(
                this.PerformedTreatmentID,
                this.PerformedTreatmentDateTime,
                this.VisitID,
                this.TreatmentTypeID);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerformedTreatment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdatePerformedTreatment();
            }

            return false;
        }


        public static DataTable GetAllPerformedTreatmentsByVisitID(int VisitID)
        {
            return clsPerformedTreatmentData
                .GetAllPerformedTreatmentsByVisitID(VisitID);
        }


        public static bool DeletePerformedTreatment(int PerformedTreatmentID)
        {
            return clsPerformedTreatmentData
                .DeletePerformedTreatment(PerformedTreatmentID);
        }
    }
}
