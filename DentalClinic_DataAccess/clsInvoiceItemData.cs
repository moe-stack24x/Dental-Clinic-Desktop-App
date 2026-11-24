using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsInvoiceItemData
    {

        public static bool GetInvoiceItemById(
            int InvoiceItemsID,
            ref decimal Price,
            ref int InvoiceID,
            ref int PerformedTreatmentID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM InvoiceItems
                             WHERE InvoiceItemsID = @InvoiceItemsID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InvoiceItemsID", InvoiceItemsID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    Price = Convert.ToDecimal(Reader["Price"]);
                    InvoiceID = Convert.ToInt32(Reader["InvoiceID"]);
                    PerformedTreatmentID = Convert.ToInt32(Reader["PerformedTreatmentID"]);

                    IsFound = true;
                }

                Reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }


        public static DataTable GetAllInvoiceItemsByInvoiceID(int InvoiceID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT
                                InvoiceItems.InvoiceItemsID,
                                TreatmentTypes.TreatmentTypeName,
                                PerformedTreatments.PerformedTreatmentDateTime,
                                InvoiceItems.Price
                             FROM InvoiceItems
                             INNER JOIN PerformedTreatments
                             ON InvoiceItems.PerformedTreatmentID = PerformedTreatments.PerformedTreatmentID
                             INNER JOIN TreatmentTypes
                             ON PerformedTreatments.TreatmentTypeID = TreatmentTypes.TreatmentTypeID
                             WHERE InvoiceItems.InvoiceID = @InvoiceID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }

                Reader.Close();
            }
            catch
            {
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }


        public static int AddNewInvoiceItem(
            decimal Price,
            int InvoiceID,
            int PerformedTreatmentID)
        {
            int InvoiceItemsID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO InvoiceItems
                             (Price, InvoiceID, PerformedTreatmentID)
                             VALUES
                             (@Price, @InvoiceID, @PerformedTreatmentID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Price", Price);
            Command.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            Command.Parameters.AddWithValue("@PerformedTreatmentID", PerformedTreatmentID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    InvoiceItemsID = ID;
                }
            }
            catch
            {
                InvoiceItemsID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return InvoiceItemsID;
        }


        public static bool UpdateInvoiceItem(
            int InvoiceItemsID,
            decimal Price,
            int InvoiceID,
            int PerformedTreatmentID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE InvoiceItems
                             SET Price = @Price,
                                 InvoiceID = @InvoiceID,
                                 PerformedTreatmentID = @PerformedTreatmentID
                             WHERE InvoiceItemsID = @InvoiceItemsID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InvoiceItemsID", InvoiceItemsID);
            Command.Parameters.AddWithValue("@Price", Price);
            Command.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            Command.Parameters.AddWithValue("@PerformedTreatmentID", PerformedTreatmentID);

            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();
            }
            catch
            {
                RowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }


        public static bool DeleteInvoiceItem(int InvoiceItemsID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM InvoiceItems
                             WHERE InvoiceItemsID = @InvoiceItemsID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InvoiceItemsID", InvoiceItemsID);

            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();
            }
            catch
            {
                RowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static decimal GetInvoiceTotalAmount(int InvoiceID)
        {
            decimal TotalAmount = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT ISNULL(SUM(Price), 0)
                     FROM InvoiceItems
                     WHERE InvoiceID = @InvoiceID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

            try
            {
                Connection.Open();

                TotalAmount = Convert.ToDecimal(Command.ExecuteScalar());
            }
            catch
            {
                TotalAmount = 0;
            }
            finally
            {
                Connection.Close();
            }

            return TotalAmount;
        }
    }
}