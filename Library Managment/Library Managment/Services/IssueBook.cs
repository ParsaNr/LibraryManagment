using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment
{
    class IssueBook : IIssueBook
    {
        private string connectionString = "data source = DESKTOP-R4LBK9B; database = library; integrated security = True";
        public bool Insert(string sno, string sname, string sem, long contact, string email, string bookname, string bookIssueDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "insert into ISBook (std_no,std_name,std_sem,std_contact,std_email,book_name, book_issue_date) values (@sno,@sname,@sem,@contact,@email,@bookname,@bookIssueDate)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sno", sno);
            cmd.Parameters.AddWithValue("@sname", sname);
            cmd.Parameters.AddWithValue("@sem", sem);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@bookname", bookname);
            cmd.Parameters.AddWithValue("@bookIssueDate", bookIssueDate);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

    }
}
