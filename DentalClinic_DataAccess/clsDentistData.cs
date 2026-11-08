using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_DataAccess
{
    public class clsDentistData
    {

        public static bool GetDentistById(int DentistId, ref string FirstName, ref string LastName,
           ref string Specialization, ref string PhoneNumber, ref bool IsActive)
        {

            bool isfound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Dentists WHERE DentistId = @DentistId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DentistId", DentistId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    FirstName = reader["FirstName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Specialization = reader["Specialization"].ToString();
                    PhoneNumber = reader["PhoneNumber"].ToString();
                    IsActive = (bool)reader["IsActive"];
                   
                }
                else
                {
                    // Dentist not found
                    isfound = false;
                }

            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while retrieving the Dentist.", ex);
            }
            finally
            {
                connection.Close();
            }
            return isfound;
        }

        public static DataTable GetAllDentists()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * From Dentists";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                // throw new Exception("An error occurred while retrieving the Dentist.", ex);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int AddDentist(string FirstName, string LastName,
            string Specialization, string PhoneNumber, bool IsActive)
        {
            int newDentistId = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Dentists (FirstName, LastName, Specialization, PhoneNumber, IsActive) 
                                    VALUES (@FirstName, @LastName, @Specialization, @PhoneNumber, @IsActive)
                                      select SCOPE_IDENTITY()";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Specialization", Specialization);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@IsActive", IsActive);
        
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int DentistId))
                {
                    newDentistId = DentistId;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while adding the Dentist.", ex);
            }
            finally
            {
                connection.Close();
            }
            return newDentistId;






        }

        public static bool UpdateDentist(int DentistId, string FirstName, string LastName,
            string Specialization, string PhoneNumber, bool IsActive)

        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Dentists 
                             SET FirstName = @FirstName, LastName = @LastName, Specialization = @Specialization, 
                                  PhoneNumber = @PhoneNumber, IsActive = @IsActive
                             WHERE DentistId = @DentistId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DentistId", DentistId);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Specialization", Specialization);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while updating the Dentist.", ex);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);

        }

        public static bool DeleteDentist(int DentistId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete from Dentists where DentistID=@DentistID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DentistID", DentistId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;



        }

        public static bool DeactivateDentist(int DentistID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Dentists
                     SET IsActive = 0
                     WHERE DentistID = @DentistID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DentistID", DentistID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception("An error occurred while deactivating the Dentist.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }


    }
}
