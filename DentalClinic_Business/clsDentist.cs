using DentalClinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_Business
{
    public class clsDentist
    {
      
         public enum enMode { AddNew = 0, Update = 1 };
         public enMode Mode = enMode.AddNew;


        public int DentistID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Specialization { set; get; }
        public string PhoneNumber { set; get; }
        public bool IsActive { set; get; }
        public string FullName 
        { get { return FirstName + " " + LastName; } }

        public clsDentist()
            {
                this.FirstName = "";
                this.LastName = "";
                this.Specialization = "";
                this.PhoneNumber = "";
                this.IsActive = true;
                Mode = enMode.AddNew;
            }
            public clsDentist(int DentistId, string firstName, string lastName, string specialization, string phoneNumber, bool isactive)
            {

                this.DentistID = DentistId;
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Specialization = specialization;
                this.PhoneNumber = phoneNumber;
                this.IsActive = isactive;
                Mode = enMode.Update;
            }


            private bool _AddNewDentist()
            {
                this.DentistID = clsDentistData.AddDentist(this.FirstName, this.LastName, this.Specialization, this.PhoneNumber, this.IsActive);
                return this.DentistID != 0;
            }
            private bool _UpdateDentist()
            {
                return clsDentistData.UpdateDentist(this.DentistID, this.FirstName, this.LastName,this.Specialization, this.PhoneNumber, this.IsActive);

            }
            public static clsDentist FindDentistById(int DentistID)
            {
                string FirstName = "";
                string LastName = "";
                string Specialization = "";
                string PhoneNumber = "";
                bool Isactive = true;

                bool isfound = clsDentistData.GetDentistById(DentistID, ref FirstName, ref LastName,
                                  ref Specialization, ref PhoneNumber, ref Isactive);
                if (isfound)
                    return new clsDentist(DentistID, FirstName, LastName, Specialization, PhoneNumber, Isactive);

                else
                    return null;
            }


            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewDentist())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case enMode.Update:
                        return _UpdateDentist();
                }
                return false;
            }

            public static bool DeleteDentist(int DentistID)
            {
                return clsDentistData.DeleteDentist(DentistID);
            }

        public static bool DeactivateDentist(int DentistID)
        {
            return clsDentistData.DeactivateDentist(DentistID);
        }
        public static DataTable GetAllDentists()
            {
                return clsDentistData.GetAllDentists();
            }
        }

    }

