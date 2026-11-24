using System;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic_DataAccess
{
    public class clsPaymentData
    {
        public static bool GetPaymentById(
            int PaymentID,
            ref decimal PaymentAmount,
            ref DateTime PaymentDatetime,
            ref int InvoiceID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM Payments
                             WHERE PaymentID = @PaymentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PaymentAmount = Convert.ToDecimal(Reader["PaymentAmount"]);
                    PaymentDatetime = Convert.ToDateTime(Reader["PaymentDatetime"]);
                    InvoiceID = Convert.ToInt32(Reader["InvoiceID"]);

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


        public static DataTable GetAllPaymentsByInvoiceID(int InvoiceID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM Payments
                             WHERE InvoiceID = @InvoiceID
                             ORDER BY PaymentDatetime";

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


        public static int AddNewPayment(
            decimal PaymentAmount,
            DateTime PaymentDatetime,
            int InvoiceID)
        {
            int PaymentID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Payments
                             (PaymentAmount, PaymentDatetime, InvoiceID)
                             VALUES
                             (@PaymentAmount, @PaymentDatetime, @InvoiceID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);
            Command.Parameters.AddWithValue("@PaymentDatetime", PaymentDatetime);
            Command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    PaymentID = Convert.ToInt32(Result);
                }
            }
            catch
            {
                PaymentID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return PaymentID;
        }


        public static bool UpdatePayment(
            int PaymentID,
            decimal PaymentAmount,
            DateTime PaymentDatetime,
            int InvoiceID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Payments
                             SET PaymentAmount = @PaymentAmount,
                                 PaymentDatetime = @PaymentDatetime,
                                 InvoiceID = @InvoiceID
                             WHERE PaymentID = @PaymentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PaymentID", PaymentID);
            Command.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);
            Command.Parameters.AddWithValue("@PaymentDatetime", PaymentDatetime);
            Command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

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


        public static bool DeletePayment(int PaymentID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM Payments
                             WHERE PaymentID = @PaymentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PaymentID", PaymentID);

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

        public static decimal GetTotalPaidAmount(int InvoiceID)
        {
            decimal TotalPaid = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT ISNULL(SUM(PaymentAmount), 0)
                     FROM Payments
                     WHERE InvoiceID = @InvoiceID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

            try
            {
                Connection.Open();

                TotalPaid = Convert.ToDecimal(Command.ExecuteScalar());
            }
            catch
            {
                TotalPaid = 0;
            }
            finally
            {
                Connection.Close();
            }

            return TotalPaid;
        }
    }
}