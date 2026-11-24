using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsPrescriptionItemData
    {
        public static bool GetPrescriptionItemById(int PrescriptionItemID,
            ref string MedicationName, ref string Instructions, ref int Duration,
            ref byte Frequency, ref string Dosage, ref int PrescriptionID)
        {
            bool isfound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM PrescriptionItems WHERE PrescriptionItemID = @PrescriptionItemID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PrescriptionItemID", PrescriptionItemID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;

                    MedicationName = reader["MedicationName"].ToString();
                    Instructions = reader["Instructions"] == DBNull.Value ? "" : reader["Instructions"].ToString();
                    Duration = Convert.ToInt32(reader["Duration"]);
                    Frequency = Convert.ToByte(reader["Frequency"]);
                    Dosage = reader["Dosage"].ToString();
                    PrescriptionID = Convert.ToInt32(reader["PrescriptionID"]);
                }
                else
                {
                    isfound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the prescription item.", ex);
            }
            finally
            {
                connection.Close();
            }

            return isfound;
        }

        public static DataTable GetAllPrescriptionItemsByPrescriptionID(int PrescriptionID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PrescriptionItemID, MedicationName, Instructions,
                                    Duration, Frequency, Dosage
                             FROM PrescriptionItems
                             WHERE PrescriptionID = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

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
                throw new Exception("An error occurred while retrieving prescription items.", ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddPrescriptionItem(string MedicationName, string Instructions,
            int Duration, byte Frequency, string Dosage, int PrescriptionID)
        {
            int newPrescriptionItemID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO PrescriptionItems
                             (MedicationName, Instructions, Duration, Frequency, Dosage, PrescriptionID)
                             VALUES
                             (@MedicationName, @Instructions, @Duration, @Frequency, @Dosage, @PrescriptionID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MedicationName", MedicationName);
            command.Parameters.AddWithValue("@Instructions",
                string.IsNullOrEmpty(Instructions) ? (object)DBNull.Value : Instructions);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Frequency", Frequency);
            command.Parameters.AddWithValue("@Dosage", Dosage);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int prescriptionItemID))
                {
                    newPrescriptionItemID = prescriptionItemID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the prescription item.", ex);
            }
            finally
            {
                connection.Close();
            }

            return newPrescriptionItemID;
        }

        public static bool UpdatePrescriptionItem(int PrescriptionItemID,
            string MedicationName, string Instructions, int Duration,
            byte Frequency, string Dosage, int PrescriptionID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE PrescriptionItems
                             SET MedicationName = @MedicationName,
                                 Instructions = @Instructions,
                                 Duration = @Duration,
                                 Frequency = @Frequency,
                                 Dosage = @Dosage,
                                 PrescriptionID = @PrescriptionID
                             WHERE PrescriptionItemID = @PrescriptionItemID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PrescriptionItemID", PrescriptionItemID);
            command.Parameters.AddWithValue("@MedicationName", MedicationName);
            command.Parameters.AddWithValue("@Instructions",
                string.IsNullOrEmpty(Instructions) ? (object)DBNull.Value : Instructions);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Frequency", Frequency);
            command.Parameters.AddWithValue("@Dosage", Dosage);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the prescription item.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool DeletePrescriptionItem(int PrescriptionItemID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "DELETE FROM PrescriptionItems WHERE PrescriptionItemID = @PrescriptionItemID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PrescriptionItemID", PrescriptionItemID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the prescription item.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}