using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    class ReturnBooks : IReturnBookRepository
    {
        private string connectionString = "data source = DESKTOP-R4LBK9B; database = library; integrated security = True";
        public DataTable SelectRow(string txtStudentNo)
        {
            string query = "select * from ISBook where std_no = " + txtStudentNo + " and book_return_date is NULL";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(string book_return_date, string std_no, Int64 id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string query = "update ISBook set book_return_date = @dateTimePicker1 where std_no = @txtStudentNo and id =@rowid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@dateTimePicker1", book_return_date);
                cmd.Parameters.AddWithValue("@txtStudentNo", std_no);
                cmd.Parameters.AddWithValue("@rowid", id);

                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
