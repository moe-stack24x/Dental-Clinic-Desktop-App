
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace DentalClinic_DataAccess
{
    public class clsInvoiceData
    {
        public static bool GetInvoiceById(int InvoiceID,
            ref byte InvoiceStatus, ref DateTime InvoiceIssueDate,
            ref int VisitID)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Invoices
                             WHERE InvoiceID = @InvoiceID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    InvoiceStatus = Convert.ToByte(reader["InvoiceStatus"]);
                    InvoiceIssueDate = Convert.ToDateTime(reader["InvoiceIssueDate"]);
                    VisitID = Convert.ToInt32(reader["VisitID"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while retrieving the invoice.", ex);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool GetInvoiceByVisitID(int VisitID,
            ref int InvoiceID, ref byte InvoiceStatus,
            ref DateTime InvoiceIssueDate)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Invoices
                             WHERE VisitID = @VisitID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VisitID", VisitID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    InvoiceID = Convert.ToInt32(reader["InvoiceID"]);
                    InvoiceStatus = Convert.ToByte(reader["InvoiceStatus"]);
                    InvoiceIssueDate = Convert.ToDateTime(reader["InvoiceIssueDate"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while retrieving the invoice by visit ID.", ex);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllInvoicesByVisitID(int VisitID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
        SELECT
            Invoices.InvoiceID,
            Invoices.InvoiceIssueDate,

            CASE Invoices.InvoiceStatus
                WHEN 0 THEN 'Unpaid'
                WHEN 1 THEN 'Partially Paid'
                WHEN 2 THEN 'Paid'
            END AS InvoiceStatus,

            (SELECT SUM(Price)
             FROM InvoiceItems
             WHERE InvoiceID = Invoices.InvoiceID) AS TotalAmount,

            (SELECT SUM(PaymentAmount)
             FROM Payments
             WHERE InvoiceID = Invoices.InvoiceID) AS TotalPaid,

            (SELECT SUM(Price)
             FROM InvoiceItems
             WHERE InvoiceID = Invoices.InvoiceID)
            -
            (SELECT SUM(PaymentAmount)
             FROM Payments
             WHERE InvoiceID = Invoices.InvoiceID) AS RemainingAmount

        FROM Invoices
        WHERE Invoices.VisitID = @VisitID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@VisitID", VisitID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    dt.Load(Reader);

                Reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }
        public static int AddInvoice(byte InvoiceStatus,
            DateTime InvoiceIssueDate, int VisitID)
        {
            int newInvoiceID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Invoices
                             (InvoiceStatus, InvoiceIssueDate, VisitID)
                             VALUES
                             (@InvoiceStatus, @InvoiceIssueDate, @VisitID);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InvoiceStatus", InvoiceStatus);
            command.Parameters.AddWithValue("@InvoiceIssueDate", InvoiceIssueDate);
            command.Parameters.AddWithValue("@VisitID", VisitID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    newInvoiceID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while adding the invoice.", ex);
            }
            finally
            {
                connection.Close();
            }

            return newInvoiceID;
        }


        public static bool UpdateInvoice(int InvoiceID,
            byte InvoiceStatus, DateTime InvoiceIssueDate, int VisitID)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Invoices
                             SET InvoiceStatus = @InvoiceStatus,
                                 InvoiceIssueDate = @InvoiceIssueDate,
                                 VisitID = @VisitID
                             WHERE InvoiceID = @InvoiceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            command.Parameters.AddWithValue("@InvoiceStatus", InvoiceStatus);
            command.Parameters.AddWithValue("@InvoiceIssueDate", InvoiceIssueDate);
            command.Parameters.AddWithValue("@VisitID", VisitID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while updating the invoice.", ex);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }



        public static bool DeleteInvoice(int InvoiceID)
        {
            if (clsPaymentData.GetTotalPaidAmount(InvoiceID) > 0)
                return false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        DELETE FROM InvoiceItems
        WHERE InvoiceID = @InvoiceID;

        DELETE FROM Invoices
        WHERE InvoiceID = @InvoiceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

            try
            {
                connection.Open();

                int RowsAffected = command.ExecuteNonQuery();

                return RowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the invoice.", ex);
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
