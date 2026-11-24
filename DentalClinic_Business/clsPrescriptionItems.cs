using System;
using System.Data;
using DentalClinic_DataAccess;

namespace DentalClinic_Business
{
    public class clsPrescriptionItem
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode = enMode.AddNew;

        public int PrescriptionItemID { get; set; }
        public string MedicationName { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
        public byte Frequency { get; set; }
        public string Dosage { get; set; }
        public int PrescriptionID { get; set; }

        public clsPrescriptionItem()
        {
            PrescriptionItemID = -1;
            MedicationName = "";
            Instructions = "";
            Duration = 0;
            Frequency = 0;
            Dosage = "";
            PrescriptionID = -1;

            Mode = enMode.AddNew;
        }

        private clsPrescriptionItem(int PrescriptionItemID, string MedicationName,
            string Instructions, int Duration, byte Frequency, string Dosage,
            int PrescriptionID)
        {
            this.PrescriptionItemID = PrescriptionItemID;
            this.MedicationName = MedicationName;
            this.Instructions = Instructions;
            this.Duration = Duration;
            this.Frequency = Frequency;
            this.Dosage = Dosage;
            this.PrescriptionID = PrescriptionID;

            Mode = enMode.Update;
        }

        public static clsPrescriptionItem Find(int PrescriptionItemID)
        {
            string MedicationName = "";
            string Instructions = "";
            int Duration = 0;
            byte Frequency = 0;
            string Dosage = "";
            int PrescriptionID = -1;

            if (clsPrescriptionItemData.GetPrescriptionItemById(
                PrescriptionItemID,
                ref MedicationName,
                ref Instructions,
                ref Duration,
                ref Frequency,
                ref Dosage,
                ref PrescriptionID))
            {
                return new clsPrescriptionItem(
                    PrescriptionItemID,
                    MedicationName,
                    Instructions,
                    Duration,
                    Frequency,
                    Dosage,
                    PrescriptionID);
            }

            return null;
        }

        private bool _AddNewPrescriptionItem()
        {
            this.PrescriptionItemID = clsPrescriptionItemData.AddPrescriptionItem(
                this.MedicationName,
                this.Instructions,
                this.Duration,
                this.Frequency,
                this.Dosage,
                this.PrescriptionID);

            return this.PrescriptionItemID != 0;
        }

        private bool _UpdatePrescriptionItem()
        {
            return clsPrescriptionItemData.UpdatePrescriptionItem(
                this.PrescriptionItemID,
                this.MedicationName,
                this.Instructions,
                this.Duration,
                this.Frequency,
                this.Dosage,
                this.PrescriptionID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPrescriptionItem())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdatePrescriptionItem();
            }

            return false;
        }

        public static bool DeletePrescriptionItem(int PrescriptionItemID)
        {
            return clsPrescriptionItemData.DeletePrescriptionItem(PrescriptionItemID);
        }

        public static DataTable GetAllPrescriptionItemsByPrescriptionID(int PrescriptionID)
        {
            return clsPrescriptionItemData.GetAllPrescriptionItemsByPrescriptionID(PrescriptionID);
        }
    }
}