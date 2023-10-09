using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    class ViewBook : IViewBook
    {
        private string connectionString = "data source = DESKTOP-R4LBK9B; database = library; integrated security = True";
        public bool Delete(Int64 bid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string query = "delete from NewBook where bid = @rowid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@rowid", bid);
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

        public DataTable Search(string txtBookName)
        {
            string query = "select * from NewBook where bName LIKE @txtBookName";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.Parameters.AddWithValue("@txtBookName", "%" + txtBookName + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelecAll()
        {
            string query = "select * from NewBook";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int bid)
        {
            string query = "select * from NewBook where bid=" + bid + "";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(Int64 bid, string bname, string bauthor, string publication, string pdate, long price, long quan)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string query = "update NewBook set bName = @bname, bAuthor = @bauthor, bPubl = @publication, bPDate = @pdate, bPrice = @price, bQuan = @quan where bid = @rowid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@rowid", bid);
                cmd.Parameters.AddWithValue("@bname", bname);
                cmd.Parameters.AddWithValue("@bauthor", bauthor);
                cmd.Parameters.AddWithValue("@publication", publication);
                cmd.Parameters.AddWithValue("@pdate", pdate);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@quan", quan);
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
