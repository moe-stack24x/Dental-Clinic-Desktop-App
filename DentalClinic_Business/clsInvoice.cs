using DentalClinic_DataAccess;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace DentalClinic_Business
{
    public class clsInvoice
    {
        public enum enMode { AddNew, Update }

        public enum enInvoiceStatus : byte
        {
            Unpaid = 0,
            PartiallyPaid = 1,
            Paid = 2
        }

        public enMode Mode { get; set; }

        public int InvoiceID { get; set; }

        public enInvoiceStatus InvoiceStatus { get; set; }

        public DateTime InvoiceIssueDate { get; set; }

        public int VisitID { get; set; }


        public clsInvoice()
        {
            InvoiceID = -1;
            InvoiceStatus = enInvoiceStatus.Unpaid;
            InvoiceIssueDate = DateTime.Now;
            VisitID = -1;

            Mode = enMode.AddNew;
        }


        private clsInvoice(
            int InvoiceID,
            enInvoiceStatus InvoiceStatus,
            DateTime InvoiceIssuedDate,
            int VisitID)
        {
            this.InvoiceID = InvoiceID;
            this.InvoiceStatus = InvoiceStatus;
            this.InvoiceIssueDate = InvoiceIssuedDate;
            this.VisitID = VisitID;

            Mode = enMode.Update;
        }


        public static clsInvoice Find(int InvoiceID)
        {
            byte InvoiceStatus = 0;
            DateTime InvoiceIssuedDate = DateTime.Now;
            int VisitID = -1;

            bool IsFound = clsInvoiceData.GetInvoiceById(InvoiceID,ref InvoiceStatus, ref InvoiceIssuedDate,ref VisitID);

            if (IsFound)
            {
                return new clsInvoice(
                    InvoiceID,
                    (enInvoiceStatus)InvoiceStatus,
                    InvoiceIssuedDate,
                    VisitID);
            }

            return null;
        }


        public static clsInvoice FindByVisitID(int VisitID)
        {
            int InvoiceID = -1;
            byte InvoiceStatus = 0;
            DateTime InvoiceIssuedDate = DateTime.Now;

            bool IsFound = clsInvoiceData.GetInvoiceByVisitID(
                VisitID,
                ref InvoiceID,
                ref InvoiceStatus,
                ref InvoiceIssuedDate);

            if (IsFound)
            {
                return new clsInvoice(
                    InvoiceID,
                    (enInvoiceStatus)InvoiceStatus,
                    InvoiceIssuedDate,
                    VisitID);
            }

            return null;
        }


        private bool _AddNewInvoice()
        {
            this.InvoiceID = clsInvoiceData.AddInvoice(
                (byte)this.InvoiceStatus,
                this.InvoiceIssueDate,
                this.VisitID);

            return (this.InvoiceID != -1);
        }


        private bool _UpdateInvoice()
        {
            return clsInvoiceData.UpdateInvoice(
                this.InvoiceID,
                (byte)this.InvoiceStatus,
                this.InvoiceIssueDate,
                this.VisitID);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewInvoice())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateInvoice();
            }

            return false;
        }


        public static bool DeleteInvoice(int InvoiceID)
        {
            return clsInvoiceData.DeleteInvoice(InvoiceID);
        }

        public bool UpdateInvoiceStatus()
        {
            decimal TotalAmount = clsInvoiceItem.GetInvoiceTotalAmount(this.InvoiceID);

            decimal TotalPaid =clsPayment.GetTotalPaidAmount(this.InvoiceID);

            if (TotalPaid == 0)
                this.InvoiceStatus = enInvoiceStatus.Unpaid;

            else if (TotalPaid < TotalAmount)
                this.InvoiceStatus = enInvoiceStatus.PartiallyPaid;

            else
                this.InvoiceStatus = enInvoiceStatus.Paid;

            return this.Save();
        }

        public static DataTable GetAllInvoicesByVisitID(int visitID)
        {
          return  clsInvoiceData.GetAllInvoicesByVisitID(visitID);
        }
    }
}