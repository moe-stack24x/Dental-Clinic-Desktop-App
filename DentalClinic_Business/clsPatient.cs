using DentalClinic_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_Business
{
    public class clsPatient
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int PatientID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime BirthDate { set; get; }
        public bool Gender { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string FullName
        { get { return FirstName + " " + LastName; } }
        public clsPatient()
        {
            this.FirstName = "";
            this.LastName = "";
            this.BirthDate=DateTime.Now;
            this.Gender = true;
            this.PhoneNumber = "";
            this.Email = "";
            this.Address = "";
            Mode= enMode.AddNew;
        }
         public clsPatient( int patientId, string firstName, string lastName, DateTime birthDate, bool gender, string phoneNumber, string email, string address)
        {
           
            this.PatientID = patientId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            Mode = enMode.Update;
        }


        private bool _AddNewPatient()
        {
            this.PatientID = clsPatientData.AddPatient(this.FirstName, this.LastName, this.BirthDate, this.Gender, this.PhoneNumber, this.Email, this.Address);
            return this.PatientID != 0;
        }
        private bool _UpdatePatient()
        {
            return clsPatientData.UpdatePatient(this.PatientID, this.FirstName, this.LastName, this.BirthDate, this.Gender, this.PhoneNumber, this.Email, this.Address);

        }
        public static clsPatient FindPatientById(int PatientID)
        {
            string FirstName ="" ;
            string LastName= "";
            DateTime BirthDate=DateTime.Now;
            bool Gender=true;
            string PhoneNumber= "";
            string Email= "";
            string Address= "";

            bool isfound = clsPatientData.GetPatientById( PatientID, ref  FirstName, ref  LastName,
                              ref  BirthDate, ref  Gender, ref  PhoneNumber, ref  Email, ref  Address);
            if(isfound)
                return new clsPatient( PatientID, FirstName, LastName, BirthDate, Gender,PhoneNumber, Email, Address);

            else
                return null;
        }


        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewPatient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    case enMode.Update:
                    return _UpdatePatient();
            }
            return false;
        }

        public static bool DeletePatient(int PatientID)
        {
            return clsPatientData.DeletePatient( PatientID );
        }
        public static DataTable GetAllPatients()
        {
            return clsPatientData.GetAllPatients();
        }
    }
}
