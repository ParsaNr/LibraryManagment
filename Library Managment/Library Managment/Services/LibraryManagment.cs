using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library_Managment
{
    class LoginTableRepository : ILoginTableRepository
    {
        private string connectionString = "data source = DESKTOP-R4LBK9B; database = master; integrated security = True";
        public bool Insert(string username, string pass)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "insert into logintable (username,pass) values (@uname,@pass)"; 
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@uname", username);
            cmd.Parameters.AddWithValue("@pass", pass);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public DataTable SelectAll(string username, string pass)
        {
            string query = "Select * from loginTable where username='"+username+"' and pass = '"+pass+"'";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            return data;
        }
    }
}
