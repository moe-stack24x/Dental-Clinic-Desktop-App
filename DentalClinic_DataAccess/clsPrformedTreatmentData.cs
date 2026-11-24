using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsPerformedTreatmentData
    {
        public static bool GetPerformedTreatmentById(int PerformedTreatmentID,
            ref DateTime PerformedTreatmentDateTime, ref int VisitID, ref int TreatmentTypeID)
        {
            bool isfound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM PerformedTreatments WHERE PerformedTreatmentID = @PerformedTreatmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PerformedTreatmentID", PerformedTreatmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;

                    PerformedTreatmentDateTime = Convert.ToDateTime(reader["PerformedTreatmentDateTime"]);
                    VisitID = Convert.ToInt32(reader["VisitID"]);
                    TreatmentTypeID = Convert.ToInt32(reader["TreatmentTypeID"]);
                }
                else
                {
                    isfound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the performed treatment.", ex);
            }
            finally
            {
                connection.Close();
            }

            return isfound;
        }

        public static DataTable GetAllPerformedTreatmentsByVisitID(int VisitID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                                PerformedTreatments.PerformedTreatmentID,
                                TreatmentTypes.TreatmentTypeName,
                                PerformedTreatments.PerformedTreatmentDateTime,
                                TreatmentTypes.DefaultPrice
                             FROM PerformedTreatments
                             INNER JOIN TreatmentTypes
                             ON PerformedTreatments.TreatmentTypeID = TreatmentTypes.TreatmentTypeID
                             WHERE PerformedTreatments.VisitID = @VisitID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VisitID", VisitID);

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
                throw new Exception("An error occurred while retrieving performed treatments.", ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddPerformedTreatment(DateTime PerformedTreatmentDateTime,
            int VisitID, int TreatmentTypeID)
        {
            int newPerformedTreatmentID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO PerformedTreatments
                             (PerformedTreatmentDateTime, VisitID, TreatmentTypeID)
                             VALUES
                             (@PerformedTreatmentDateTime, @VisitID, @TreatmentTypeID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PerformedTreatmentDateTime", PerformedTreatmentDateTime);
            command.Parameters.AddWithValue("@VisitID", VisitID);
            command.Parameters.AddWithValue("@TreatmentTypeID", TreatmentTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int performedTreatmentID))
                {
                    newPerformedTreatmentID = performedTreatmentID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the performed treatment.", ex);
            }
            finally
            {
                connection.Close();
            }

            return newPerformedTreatmentID;
        }

        public static bool UpdatePerformedTreatment(int PerformedTreatmentID,
            DateTime PerformedTreatmentDateTime, int VisitID, int TreatmentTypeID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE PerformedTreatments
                             SET PerformedTreatmentDateTime = @PerformedTreatmentDateTime,
                                 VisitID = @VisitID,
                                 TreatmentTypeID = @TreatmentTypeID
                             WHERE PerformedTreatmentID = @PerformedTreatmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PerformedTreatmentID", PerformedTreatmentID);
            command.Parameters.AddWithValue("@PerformedTreatmentDateTime", PerformedTreatmentDateTime);
            command.Parameters.AddWithValue("@VisitID", VisitID);
            command.Parameters.AddWithValue("@TreatmentTypeID", TreatmentTypeID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the performed treatment.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool DeletePerformedTreatment(int PerformedTreatmentID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "DELETE FROM PerformedTreatments WHERE PerformedTreatmentID = @PerformedTreatmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PerformedTreatmentID", PerformedTreatmentID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the performed treatment.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}