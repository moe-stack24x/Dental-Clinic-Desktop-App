
using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsTreatmentTypeData
    {
        public static bool GetTreatmentTypeInfoByID( int TreatmentTypeID, ref string TreatmentTypeName, ref string TreatmentTypeDescription, ref decimal DefaultPrice)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM TreatmentTypes
                             WHERE TreatmentTypeID = @TreatmentTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@TreatmentTypeID", TreatmentTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TreatmentTypeName =
                        (string)reader["TreatmentTypeName"];

                    TreatmentTypeDescription =
                        reader["TreatmentTypeDescription"] == DBNull.Value  ? null  : (string)reader["TreatmentTypeDescription"];

                    DefaultPrice = (decimal)reader["DefaultPrice"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while retrieving Treatment Type.", ex);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllTreatmentTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                                TreatmentTypeID,
                                TreatmentTypeName,
                                TreatmentTypeDescription,
                                DefaultPrice
                             FROM TreatmentTypes
                             ORDER BY TreatmentTypeName";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while retrieving Treatment Types.", ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
