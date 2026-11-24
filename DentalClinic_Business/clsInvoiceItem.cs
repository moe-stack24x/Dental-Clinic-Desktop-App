using DentalClinic_DataAccess;
using System;
using System.Data;

namespace DentalClinic_Business
{
    public class clsInvoiceItem
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;

        public int InvoiceItemsID { get; set; }

        public decimal Price { get; set; }

        public int InvoiceID { get; set; }

        public int PerformedTreatmentID { get; set; }


        public clsInvoiceItem()
        {
            InvoiceItemsID = -1;
            Price = 0;
            InvoiceID = -1;
            PerformedTreatmentID = -1;

            Mode = enMode.AddNew;
        }


        private clsInvoiceItem(
            int InvoiceItemsID,
            decimal Price,
            int InvoiceID,
            int PerformedTreatmentID)
        {
            this.InvoiceItemsID = InvoiceItemsID;
            this.Price = Price;
            this.InvoiceID = InvoiceID;
            this.PerformedTreatmentID = PerformedTreatmentID;

            Mode = enMode.Update;
        }


        public static clsInvoiceItem Find(int InvoiceItemsID)
        {
            decimal Price = 0;
            int InvoiceID = -1;
            int PerformedTreatmentID = -1;

            bool IsFound = clsInvoiceItemData.GetInvoiceItemById(
                InvoiceItemsID,
                ref Price,
                ref InvoiceID,
                ref PerformedTreatmentID);

            if (IsFound)
            {
                return new clsInvoiceItem(
                    InvoiceItemsID,
                    Price,
                    InvoiceID,
                    PerformedTreatmentID);
            }

            return null;
        }


        private bool _AddNewInvoiceItem()
        {
            this.InvoiceItemsID = clsInvoiceItemData.AddNewInvoiceItem(
                this.Price,
                this.InvoiceID,
                this.PerformedTreatmentID);

            return (this.InvoiceItemsID != -1);
        }


        private bool _UpdateInvoiceItem()
        {
            return clsInvoiceItemData.UpdateInvoiceItem(
                this.InvoiceItemsID,
                this.Price,
                this.InvoiceID,
                this.PerformedTreatmentID);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewInvoiceItem())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateInvoiceItem();
            }

            return false;
        }


        public static DataTable GetAllInvoiceItemsByInvoiceID(int InvoiceID)
        {
            return clsInvoiceItemData.GetAllInvoiceItemsByInvoiceID(InvoiceID);
        }


        public static bool DeleteInvoiceItem(int InvoiceItemsID)
        {
            return clsInvoiceItemData.DeleteInvoiceItem(InvoiceItemsID);
        }

        public static decimal GetInvoiceTotalAmount(int InvoiceID)
        {
            return clsInvoiceItemData.GetInvoiceTotalAmount(InvoiceID);
        }
    }
}