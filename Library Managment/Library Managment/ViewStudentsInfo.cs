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
    public partial class ViewStudentsInfo : Form
    {
        IViewStudentInfoRepository repository;
        public ViewStudentsInfo()
        {
            repository = new ViewStudentInfoo();
            InitializeComponent();
        }

        private void ViewStudentsInfo_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            dataGridView1.DataSource = repository.SelecAll();
        }

        private void txtSearchStudentNo_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchStudentNo.Text != "")
            {
                dataGridView1.DataSource = repository.Search(txtSearchStudentNo.Text);
            }
            else
            {
                dataGridView1.DataSource = repository.SelecAll();
            }
        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            DataTable dt = repository.SelectRow(bid);

            rowid = Int64.Parse(txtName.Text = dt.Rows[0][0].ToString());

            txtName.Text = dt.Rows[0][1].ToString();
            txtNo.Text = dt.Rows[0][2].ToString();
            txtSemester.Text = dt.Rows[0][3].ToString();
            txtContact.Text = dt.Rows[0][4].ToString();
            txtEmail.Text = dt.Rows[0][5].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string no = txtNo.Text;
            string semester = txtSemester.Text;
            string email = txtEmail.Text;
            Int64 contact = int.Parse(txtContact.Text);

            if (MessageBox.Show("Data Will Be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool issuccess = repository.Update(bid, name, no, semester, contact, email);

                if (issuccess == true)
                {
                    ViewStudentsInfo_Load(this, null);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchStudentNo.Clear();
            panel2.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Deleted. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bool issuccess = repository.Delete(bid);

                if (issuccess == true)
                {
                    ViewStudentsInfo_Load(this, null);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data Will Be Lost.", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
