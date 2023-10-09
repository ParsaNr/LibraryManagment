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
    public partial class ViewBooks : Form
    {
        IViewBook repository;
        public ViewBooks()
        {
            InitializeComponent();
            repository = new ViewBook();
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            dataGridView1.DataSource = repository.SelecAll();
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

            rowid = Int64.Parse(txtBname.Text = dt.Rows[0][0].ToString());

            txtBname.Text = dt.Rows[0][1].ToString();
            txtAuthor.Text = dt.Rows[0][2].ToString();
            txtPublication.Text = dt.Rows[0][3].ToString();
            txtPdate.Text = dt.Rows[0][4].ToString();
            txtPrice.Text = dt.Rows[0][5].ToString();
            txtQuantity.Text = dt.Rows[0][6].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data Will Be Lost.", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                dataGridView1.DataSource = repository.Search(txtBookName.Text);
            }
            else
            {
                dataGridView1.DataSource = repository.SelecAll();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = txtBname.Text;
                String bauthor = txtAuthor.Text;
                String publication = txtPublication.Text;
                string pdate = txtPdate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                bool issuccess = repository.Update(rowid, bname, bauthor, publication, pdate, price, quan);

                if (issuccess == true)
                {
                    ViewBooks_Load(this, null);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Deleted. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bool issuccess = repository.Delete(rowid);

                if (issuccess == true)
                {
                    ViewBooks_Load(this, null);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
