using DentalClinic_DataAccess;
using System;
using System.Data;
using static DentalClinic_Business.clsInvoice;

namespace DentalClinic_Business
{
    public class clsPayment
    {
        public enum enMode { AddNew, Update }

        public enMode Mode { get; set; }

        public int PaymentID { get; set; }

        public decimal PaymentAmount { get; set; }

        public DateTime PaymentDatetime { get; set; }

        public int InvoiceID { get; set; }


        public clsPayment()
        {
            PaymentID = -1;
            PaymentAmount = 0;
            PaymentDatetime = DateTime.Now;
            InvoiceID = -1;

            Mode = enMode.AddNew;
        }


        private clsPayment(
            int PaymentID,
            decimal PaymentAmount,
            DateTime PaymentDatetime,
            int InvoiceID)
        {
            this.PaymentID = PaymentID;
            this.PaymentAmount = PaymentAmount;
            this.PaymentDatetime = PaymentDatetime;
            this.InvoiceID = InvoiceID;

            Mode = enMode.Update;
        }


        public static clsPayment Find(int PaymentID)
        {
            decimal PaymentAmount = 0;
            DateTime PaymentDatetime = DateTime.Now;
            int InvoiceID = -1;

            bool IsFound = clsPaymentData.GetPaymentById(
                PaymentID,
                ref PaymentAmount,
                ref PaymentDatetime,
                ref InvoiceID);

            if (IsFound)
            {
                return new clsPayment(
                    PaymentID,
                    PaymentAmount,
                    PaymentDatetime,
                    InvoiceID);
            }

            return null;
        }


        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(
                this.PaymentAmount,
                this.PaymentDatetime,
                this.InvoiceID);

            return (this.PaymentID != -1);
        }


        private bool _UpdatePayment()
        {
            return clsPaymentData.UpdatePayment(
                this.PaymentID,
                this.PaymentAmount,
                this.PaymentDatetime,
                this.InvoiceID);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPayment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdatePayment();
            }

            return false;
        }


        public static DataTable GetAllPaymentsByInvoiceID(int InvoiceID)
        {
            return clsPaymentData.GetAllPaymentsByInvoiceID(InvoiceID);
        }


        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentData.DeletePayment(PaymentID);
        }

        public static decimal GetTotalPaidAmount(int InvoiceID)
        {
            return clsPaymentData.GetTotalPaidAmount(InvoiceID);
        }


      
    }
}