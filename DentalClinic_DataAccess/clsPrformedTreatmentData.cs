
using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsPerformedTreatmentData
    {
        // Get Performed Treatment By ID
        public static bool GetPerformedTreatmentInfoByID(
            int PerformedTreatmentID,
            ref DateTime PerformedTreatmentDateTime,
            ref int VisitID,
            ref int TreatmentTypeID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT *
                                 FROM PerformedTreatments
                                 WHERE PerformedTreatmentID = @PerformedTreatmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@PerformedTreatmentID", PerformedTreatmentID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            PerformedTreatmentDateTime =
                                (DateTime)reader["PerformedTreatmentDateTime"];

                            VisitID = (int)reader["VisitID"];

                            TreatmentTypeID = (int)reader["TreatmentTypeID"];
                        }
                    }
                }
            }

            return IsFound;
        }

        // Get All Performed Treatments By Visit ID
        public static DataTable GetAllPerformedTreatmentsByVisitID(int VisitID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT
                                    PerformedTreatmentID,
                                    PerformedTreatmentDateTime,
                                    VisitID,
                                    TreatmentTypeID
                                 FROM PerformedTreatments
                                 WHERE VisitID = @VisitID
                                 ORDER BY PerformedTreatmentDateTime";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VisitID", VisitID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }

        // Add New Performed Treatment
        public static int AddNewPerformedTreatment(
            DateTime PerformedTreatmentDateTime,
            int VisitID,
            int TreatmentTypeID)
        {
            int PerformedTreatmentID = -1;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO PerformedTreatments
                                 (PerformedTreatmentDateTime, VisitID, TreatmentTypeID)
                                 VALUES
                                 (@PerformedTreatmentDateTime, @VisitID, @TreatmentTypeID);

                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@PerformedTreatmentDateTime", PerformedTreatmentDateTime);

                    command.Parameters.AddWithValue("@VisitID", VisitID);
                    command.Parameters.AddWithValue("@TreatmentTypeID", TreatmentTypeID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        PerformedTreatmentID = Convert.ToInt32(result);
                    }
                }
            }

            return PerformedTreatmentID;
        }

        // Delete Performed Treatment
        public static bool DeletePerformedTreatment(int PerformedTreatmentID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM PerformedTreatments
                                 WHERE PerformedTreatmentID = @PerformedTreatmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@PerformedTreatmentID", PerformedTreatmentID);

                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();
                }
            }

            return RowsAffected > 0;
        }
        public static bool UpdatePerformedTreatment( int PerformedTreatmentID, DateTime PerformedTreatmentDateTime,  int VisitID,  int TreatmentTypeID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE PerformedTreatments
                         SET PerformedTreatmentDateTime = @PerformedTreatmentDateTime,
                             VisitID = @VisitID,
                             TreatmentTypeID = @TreatmentTypeID
                         WHERE PerformedTreatmentID = @PerformedTreatmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PerformedTreatmentID", PerformedTreatmentID);
                    command.Parameters.AddWithValue("@PerformedTreatmentDateTime", PerformedTreatmentDateTime);
                    command.Parameters.AddWithValue("@VisitID", VisitID);
                    command.Parameters.AddWithValue("@TreatmentTypeID", TreatmentTypeID);

                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
            }

            return RowsAffected > 0;
        }
    }
}
