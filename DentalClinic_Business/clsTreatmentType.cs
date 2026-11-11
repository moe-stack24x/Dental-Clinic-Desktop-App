
using DentalClinic_DataAccess;
using System.Data;

namespace DentalClinic_Business
{
    public class clsTreatmentType
    {
        public int TreatmentTypeID { get; set; }
        public string TreatmentTypeName { get; set; }
        public string TreatmentTypeDescription { get; set; }
        public decimal DefaultPrice { get; set; }

        public clsTreatmentType()
        {
            TreatmentTypeID = -1;
            TreatmentTypeName = "";
            TreatmentTypeDescription = null;
            DefaultPrice = 0;
        }

        private clsTreatmentType(
            int TreatmentTypeID,
            string TreatmentTypeName,
            string TreatmentTypeDescription,
            decimal DefaultPrice)
        {
            this.TreatmentTypeID = TreatmentTypeID;
            this.TreatmentTypeName = TreatmentTypeName;
            this.TreatmentTypeDescription = TreatmentTypeDescription;
            this.DefaultPrice = DefaultPrice;
        }

        public static clsTreatmentType Find(int TreatmentTypeID)
        {
            string TreatmentTypeName = "";
            string TreatmentTypeDescription = null;
            decimal DefaultPrice = 0;

            bool IsFound =
                clsTreatmentTypeData.GetTreatmentTypeInfoByID(
                    TreatmentTypeID,
                    ref TreatmentTypeName,
                    ref TreatmentTypeDescription,
                    ref DefaultPrice);

            if (IsFound)
            {
                return new clsTreatmentType(
                    TreatmentTypeID,
                    TreatmentTypeName,
                    TreatmentTypeDescription,
                    DefaultPrice);
            }

            return null;
        }

        public static DataTable GetAllTreatmentTypes()
        {
            return clsTreatmentTypeData.GetAllTreatmentTypes();
        }
    }
}
