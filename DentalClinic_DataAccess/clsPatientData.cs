using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_DataAccess
{
    public class clsPatientData
    {

        public static bool GetPatientById(int patientId, ref string FirstName, ref string LastName,
            ref DateTime BirthDate, ref bool Gender, ref string PhoneNumber, ref string Email, ref string Address)
        {

            bool isfound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Patients WHERE PatientId = @PatientId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientId", patientId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    FirstName = reader["FirstName"].ToString();
                    LastName = reader["LastName"].ToString();
                    BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                    Gender =(bool)(reader["Gender"]);
                    PhoneNumber = reader["PhoneNumber"].ToString();
                    Email = reader["Email"].ToString();
                    Address = reader["Address"].ToString();
                }
                else
                {
                    // Patient not found
                    isfound = false;
                }

            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while retrieving the patient.", ex);
            }
            finally
            {
                connection.Close();
            }
            return isfound;
        }

        public static DataTable GetAllPatients()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT PatientID,FirstName,LastName, 
                              case
                               when Gender=1 then 'Male'
                               when Gender=0 then 'Female'
                                 else 'Unknown'
                                 end as Gender,
                               PhoneNumber,BirthDate from Patients; ";

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
                // throw new Exception("An error occurred while retrieving the patient.", ex);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int AddPatient(string FirstName, string LastName,
            DateTime BirthDate, bool Gender, string PhoneNumber, string Email, string Address)
        {
            int newPatientId = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Patients (FirstName, LastName, BirthDate, Gender, PhoneNumber, Email, Address) 
                                    VALUES (@FirstName, @LastName, @BirthDate, @Gender, @PhoneNumber, @Email, @Address)
                                      select SCOPE_IDENTITY()";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int patientId))
                {
                    newPatientId = patientId;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while adding the patient.", ex);
            }
            finally
            {
                connection.Close();
            }
            return newPatientId;






        }

        public static bool UpdatePatient(int PatientId, string FirstName, string LastName,
            DateTime BirthDate, bool Gender, string PhoneNumber, string Email, string Address)

        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Patients 
                             SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate, 
                                 Gender = @Gender, PhoneNumber = @PhoneNumber, Email = @Email, Address = @Address
                             WHERE PatientId = @PatientId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientId", PatientId);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while updating the patient.", ex);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);

        }

        public static bool DeletePatient(int PatientId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete from Patients where PatientID=@PatientID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientId);

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
    }
}
