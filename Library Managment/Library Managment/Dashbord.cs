using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }


        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks abs = new AddBooks();
            abs.ShowDialog();
        }

        private void addNewStudentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddStudent ads = new AddStudent();
            ads.ShowDialog();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBooks vbs = new ViewBooks();
            vbs.ShowDialog();
        }

        private void viewStudentInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewStudentsInfo vsi = new ViewStudentsInfo();
            vsi.ShowDialog();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks ib = new IssueBooks();
            ib.ShowDialog();
        }

        private void LogOut(object sender, EventArgs e)
        {
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook rb = new ReturnBook();
            rb.ShowDialog();
        }

        private void Dashbord_Load(object sender, EventArgs e)
        {

        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
