using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    class NewStudent : INewStudentRepository
    {
        private string connectionString = "data source = DESKTOP-R4LBK9B; database = library; integrated security = True";
        public bool Insert(string sname, string sno, string sem, Int64 contact, string email)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "insert into NewStudent (sname,sno,sem,contact,email) values (@name,@no,@sem,@mobile,@email)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", sname);
            cmd.Parameters.AddWithValue("@no", sno);
            cmd.Parameters.AddWithValue("@sem", sem);
            cmd.Parameters.AddWithValue("@mobile", contact);
            cmd.Parameters.AddWithValue("@email", email);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return true;
        }
    }
}
