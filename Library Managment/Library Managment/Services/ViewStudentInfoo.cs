using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    class ViewStudentInfoo : IViewStudentInfoRepository
    {
        private string connectionString = "data source = DESKTOP-R4LBK9B; database = library; integrated security = True";

        public bool Delete(long stuid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string query = "delete from NewStudent where stuid = @rowid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@rowid", stuid);
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

        public DataTable Search(string txtSearchStudentNo)
        {
            string query = "select * from NewStudent where sname LIKE @txtSearchStudentNo";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.Parameters.AddWithValue("@txtSearchStudentNo", "%" + txtSearchStudentNo + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelecAll()
        {
            string query = "select * from NewStudent";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int bid)
        {
            string query = "select * from NewStudent where stuid=" + bid + "";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(long bid, string name, string no, string semester, Int64 contact, string email)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string query = "update NewStudent set sname = @name, sno = @no, sem = @semester, contact = @contact, email = @email where stuid = @rowid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@rowid", bid);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@no", no);
                cmd.Parameters.AddWithValue("@semester", semester);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@email", email);
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
