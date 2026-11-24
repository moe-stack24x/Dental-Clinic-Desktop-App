using DentalClinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_Business
{
    public class clsUser
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
      
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public clsUser()

        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, string Username, string Password,
            bool IsActive)

        {
            this.UserID = UserID;
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUserData.AddNewUser( this.UserName,
                this.Password, this.IsActive);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUserData.UpdateUser(this.UserID,  this.UserName,
                this.Password, this.IsActive);
        }
        public static clsUser FindByUserID(int UserID)
        {
          
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID
                                (UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserName, Password, IsActive);
            else
                return null;
        }
     
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
           

            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserName, Password, IsActive);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool isUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

   public bool changePassword( string NewPassword)
        {
            return clsUserData.ChangePassword(this.UserID, NewPassword);
        }

    }
}
