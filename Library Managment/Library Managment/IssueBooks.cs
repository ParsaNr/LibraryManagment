using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment
{
    public partial class IssueBooks : Form
    {
        IIssueBook repository;
        public IssueBooks()
        {
            InitializeComponent();
            repository = new IssueBook();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-R4LBK9B; database = library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bname from NewBook", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    comboBoxBooks.Items.Add(sdr.GetSqlString(i));
                }
            }
            sdr.Close();
            con.Close();
        }

        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string no = txtStudentNo.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-R4LBK9B; database = library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where sno='" + no + "'";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            //How Many Book Issued 
            cmd.CommandText = "select count(std_no) from ISBook where std_no='" + no + "' and book_return_date is null";
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            sda.Fill(ds1);

            count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

            //Panel TextBoxes
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtNo.Text = ds.Tables[0].Rows[0][2].ToString();
                txtSemester.Text = ds.Tables[0].Rows[0][3].ToString();
                txtContact.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
            }
            else
            {
                txtName.Clear();
                txtNo.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
                MessageBox.Show("Invalid Input...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (comboBoxBooks.SelectedIndex != -1 && count <= 2)
                {
                    string sno = txtNo.Text;
                    string sname = txtName.Text;
                    string sem = txtSemester.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    string email = txtEmail.Text;
                    string bookname = comboBoxBooks.Text;
                    string bookIssueDate = dateTimePicker.Text;

                    string no = txtStudentNo.Text;
                    repository.Insert(sno, sname, sem, contact, email, bookname, bookIssueDate);

                    MessageBox.Show("Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Selected Book. Or Maximum number of book has been issued", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid Input...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            if (txtStudentNo.Text == "")
            {
                txtName.Clear();
                txtNo.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentNo.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
