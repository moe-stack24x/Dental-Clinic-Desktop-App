
using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsPrescriptionData
    {
        public static bool GetPrescriptionById(int PrescriptionID,
            ref DateTime PrescriptionDate, ref string Notes,
            ref int VisitID)
        {
            bool isfound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Prescriptions
                             WHERE PrescriptionID = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;

                    PrescriptionDate = Convert.ToDateTime(reader["PrescriptionDate"]);

                    Notes = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString();

                    VisitID = Convert.ToInt32(reader["VisitID"]);
                }
                else
                {
                    isfound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while retrieving the prescription.", ex);
            }
            finally
            {
                connection.Close();
            }

            return isfound;
        }

        public static DataTable GetAllPrescriptionsByVisitID(int VisitID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                    Prescriptions.PrescriptionID,
                    Prescriptions.PrescriptionDate,
                    Prescriptions.Notes,
                    COUNT(PrescriptionItems.PrescriptionItemID) AS ItemsCount
                 FROM Prescriptions
                 INNER JOIN PrescriptionItems
                 ON Prescriptions.PrescriptionID =
                    PrescriptionItems.PrescriptionID
                 WHERE Prescriptions.VisitID = @VisitID
                 GROUP BY
                    Prescriptions.PrescriptionID,
                    Prescriptions.PrescriptionDate,
                    Prescriptions.Notes;";

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
                throw new Exception(
                    "An error occurred while retrieving prescriptions.", ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddPrescription(DateTime PrescriptionDate,
            string Notes, int VisitID)
        {
            int newPrescriptionID = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Prescriptions
                             (PrescriptionDate, Notes, VisitID)
                             VALUES
                             (@PrescriptionDate, @Notes, @VisitID);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PrescriptionDate", PrescriptionDate);

            command.Parameters.AddWithValue("@Notes",
                string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);

            command.Parameters.AddWithValue("@VisitID", VisitID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null &&
                    int.TryParse(result.ToString(), out int prescriptionID))
                {
                    newPrescriptionID = prescriptionID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while adding the prescription.", ex);
            }
            finally
            {
                connection.Close();
            }

            return newPrescriptionID;
        }

        public static bool UpdatePrescription(int PrescriptionID,
            DateTime PrescriptionDate, string Notes, int VisitID)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Prescriptions
                             SET PrescriptionDate = @PrescriptionDate,
                                 Notes = @Notes,
                                 VisitID = @VisitID
                             WHERE PrescriptionID = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
            command.Parameters.AddWithValue("@PrescriptionDate", PrescriptionDate);

            command.Parameters.AddWithValue("@Notes",
                string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);

            command.Parameters.AddWithValue("@VisitID", VisitID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while updating the prescription.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool DeletePrescription(int PrescriptionID)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Prescriptions
                             WHERE PrescriptionID = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while deleting the prescription.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}
