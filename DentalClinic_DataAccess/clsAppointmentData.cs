
using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsAppointmentData
    {
        public static bool GetAppointmentById(
            int AppointmentId,
            ref int PatientID,
            ref int DentistID,
            ref DateTime AppointmentDate,
            ref TimeSpan AppointmentStartTime,
            ref TimeSpan AppointmentEndTime,
            ref byte AppointmentStatus,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM Appointments
                             WHERE AppointmentID = @AppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentId);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PatientID = (int)reader["PatientID"];
                    DentistID = (int)reader["DentistID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    AppointmentStartTime = (TimeSpan)reader["AppointmentStartTime"];
                    AppointmentEndTime = (TimeSpan)reader["AppointmentEndTime"];
                    AppointmentStatus = (byte)reader["AppointmentStatus"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while retrieving the Appointment.", ex);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllAppointments()
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
          A.AppointmentID,
          P.FirstName + ' ' + P.LastName AS PatientName,
          D.FirstName + ' ' + D.LastName AS DentistName,
          A.AppointmentDate,
          A.AppointmentStartTime,
          A.AppointmentEndTime,
          CASE A.AppointmentStatus
              WHEN 1 THEN 'Scheduled'
              WHEN 2 THEN 'Cancelled'
              WHEN 3 THEN 'Completed'
              ELSE 'Unknown'
           END AS AppointmentStatus

       FROM Appointments A
      INNER JOIN Patients P
          ON A.PatientID = P.PatientID

      INNER JOIN Dentists D
         ON A.DentistID = D.DentistID

      ORDER BY A.AppointmentDate, A.AppointmentStartTime;";



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
                throw new Exception(
                    "An error occurred while retrieving Appointments.", ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddAppointment(
            int PatientID,
            int DentistID,
            DateTime AppointmentDate,
            TimeSpan AppointmentStartTime,
            TimeSpan AppointmentEndTime,
            byte AppointmentStatus,
            int CreatedByUserID)
        {
            int newAppointmentID = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                INSERT INTO Appointments
                (
                    PatientID,
                    DentistID,
                    AppointmentDate,
                    AppointmentStartTime,
                    AppointmentEndTime,
                    AppointmentStatus,
                    CreatedByUserID
                )
                VALUES
                (
                    @PatientID,
                    @DentistID,
                    @AppointmentDate,
                    @AppointmentStartTime,
                    @AppointmentEndTime,
                    @AppointmentStatus,
                    @CreatedByUserID
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@DentistID", DentistID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate.Date);
            command.Parameters.AddWithValue("@AppointmentStartTime", AppointmentStartTime);
            command.Parameters.AddWithValue("@AppointmentEndTime", AppointmentEndTime);
            command.Parameters.AddWithValue("@AppointmentStatus", AppointmentStatus);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    newAppointmentID = insertedID;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while adding the Appointment.", ex);
            }
            finally
            {
                connection.Close();
            }

            return newAppointmentID;
        }

        public static bool UpdateAppointment(
            int AppointmentID,
            int PatientID,
            int DentistID,
            DateTime AppointmentDate,
            TimeSpan AppointmentStartTime,
            TimeSpan AppointmentEndTime,
            byte AppointmentStatus)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                UPDATE Appointments
                SET
                    PatientID = @PatientID,
                    DentistID = @DentistID,
                    AppointmentDate = @AppointmentDate,
                    AppointmentStartTime = @AppointmentStartTime,
                    AppointmentEndTime = @AppointmentEndTime,
                    AppointmentStatus = @AppointmentStatus
                WHERE AppointmentID = @AppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@DentistID", DentistID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate.Date);
            command.Parameters.AddWithValue("@AppointmentStartTime", AppointmentStartTime);
            command.Parameters.AddWithValue("@AppointmentEndTime", AppointmentEndTime);
            command.Parameters.AddWithValue("@AppointmentStatus", AppointmentStatus);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while updating the Appointment.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool CancelAppointment(int AppointmentID)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                UPDATE Appointments
                SET AppointmentStatus = 2
                WHERE AppointmentID = @AppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while cancelling the Appointment.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool IsDentistAvailable( int DentistID, DateTime AppointmentDate, TimeSpan StartTime, TimeSpan EndTime, int AppointmentID = -1)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1
                     FROM Appointments
                     WHERE DentistID = @DentistID
                     AND AppointmentDate = @AppointmentDate
                     AND AppointmentStatus =1
                     AND AppointmentID <> @AppointmentID
                     AND AppointmentStartTime < @EndTime
                     AND AppointmentEndTime > @StartTime";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DentistID", DentistID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate.Date);
            command.Parameters.AddWithValue("@StartTime", StartTime);
            command.Parameters.AddWithValue("@EndTime", EndTime);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                IsFound = (result != null);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
    }
}
