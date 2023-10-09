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
    public partial class Login : Form
    {
        ILoginTableRepository repository;
        public Login()
        {
            InitializeComponent();
            repository = new LoginTableRepository();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }


        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "data source = DESKTOP-R4LBK9B; database = master; integrated security = True";
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;

            //cmd.CommandText = "select * from loginTable where username ='" + txtUsername.Text + "' and pass = '" + txtPassword.Text + "'";
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            if (repository.SelectAll(txtUsername.Text, txtPassword.Text).Rows.Count != 0)
            {
                this.Hide();
                Dashbord dsa = new Dashbord();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Enter a Username OR Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string uname = txtUsername.Text;
            string pass = txtPassword.Text;

            bool issuccess = repository.Insert(uname, pass);

            if (issuccess == true)
            {
                if (uname != "" && pass != "")
                {
                    MessageBox.Show("Sign Up Successfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Please Fill The Empty Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
