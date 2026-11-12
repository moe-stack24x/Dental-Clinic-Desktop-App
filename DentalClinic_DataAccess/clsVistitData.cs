
using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsVisitData
    {
        // Get Visit Info By ID
        public static bool GetVisitInfoByID(
            int VisitID,
            ref int AppointmentID,
            ref string PatientComplaint,
            ref string ClinicalNotes,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM Visits
                             WHERE VisitID = @VisitID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VisitID", VisitID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    AppointmentID = (int)reader["AppointmentID"];

                    PatientComplaint = reader["PatientComplaint"] == DBNull.Value
                        ? null : (string)reader["PatientComplaint"];

                    ClinicalNotes = reader["ClinicalNotes"] == DBNull.Value
                        ? null : (string)reader["ClinicalNotes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        // Get Visit Info By Appointment ID
        public static bool GetVisitInfoByAppointmentID(
            int AppointmentID,
            ref int VisitID,
            ref string PatientComplaint,
            ref string ClinicalNotes,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM Visits
                             WHERE AppointmentID = @AppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    VisitID = (int)reader["VisitID"];

                    PatientComplaint = reader["PatientComplaint"] == DBNull.Value
                        ? null : (string)reader["PatientComplaint"];

                    ClinicalNotes = reader["ClinicalNotes"] == DBNull.Value
                        ? null : (string)reader["ClinicalNotes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        // Get All Visits
        public static DataTable GetAllVisits()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                                Visits.VisitID,  Visits.AppointmentID, Patients.FirstName + ' ' + Patients.LastName AS PatientName,
                                Dentists.FirstName + ' ' + Dentists.LastName AS DentistName,
                                Visits.PatientComplaint,Visits.ClinicalNotes
                        FROM Visits
                    INNER JOIN Appointments
            ON Visits.AppointmentID = Appointments.AppointmentID
                    INNER JOIN Patients
            ON Appointments.PatientID = Patients.PatientID
                   INNER JOIN Dentists
            ON Appointments.DentistID = Dentists.DentistID
                   ORDER BY Visits.VisitID DESC;";

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
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }


        // Add New Visit
        public static int AddNewVisit(
            int AppointmentID,
            string PatientComplaint,
            string ClinicalNotes,
            int CreatedByUserID)
        {
            int VisitID = -1;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Visits
                             (AppointmentID, PatientComplaint,
                              ClinicalNotes, CreatedByUserID)
                             VALUES
                             (@AppointmentID, @PatientComplaint,
                              @ClinicalNotes, @CreatedByUserID);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            command.Parameters.AddWithValue("@PatientComplaint",
                (object)PatientComplaint ?? DBNull.Value);

            command.Parameters.AddWithValue("@ClinicalNotes",
                (object)ClinicalNotes ?? DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    VisitID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return VisitID;
        }


        // Update Visit
        public static bool UpdateVisit(
            int VisitID,
            int AppointmentID,
            string PatientComplaint,
            string ClinicalNotes)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Visits
                             SET AppointmentID = @AppointmentID,
                                 PatientComplaint = @PatientComplaint,
                                 ClinicalNotes = @ClinicalNotes
                             WHERE VisitID = @VisitID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VisitID", VisitID);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            command.Parameters.AddWithValue("@PatientComplaint",
                (object)PatientComplaint ?? DBNull.Value);

            command.Parameters.AddWithValue("@ClinicalNotes",
                (object)ClinicalNotes ?? DBNull.Value);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }
    }
}
