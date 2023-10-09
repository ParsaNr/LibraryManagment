using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library_Managment
{
    class NewBook : INewBookRepository
    {
        private string connectionString = "data source = DESKTOP-R4LBK9B; database = library; integrated security = True";
        public bool Insert(string bName, string bAuthor, string bPubl, string bPDate, long bPrice, long bQuan)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values (@bname,@bauthor,@publication,@bpdate,@price,@quan)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@bname", bName);
            cmd.Parameters.AddWithValue("@bauthor", bAuthor);
            cmd.Parameters.AddWithValue("@publication", bPubl);
            cmd.Parameters.AddWithValue("@bpdate", bPDate);
            cmd.Parameters.AddWithValue("@price", bPrice);
            cmd.Parameters.AddWithValue("@quan", bQuan);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
    }
}
