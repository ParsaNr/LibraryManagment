﻿using System;
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
    public partial class ReturnBook : Form
    {
        IReturnBookRepository repository;
        public ReturnBook()
        {
            InitializeComponent();
            repository = new ReturnBooks();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = repository.SelectRow(txtStudentNo.Text);

            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Invalid Student No or No Book Issued.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            txtStudentNo.Clear();
        }

        string bname;
        string bdate;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            txtBookName.Text = bname;
            txtBookIssueDate.Text = bdate;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            bool issuccess = repository.Update(dateTimePicker1.Text, txtStudentNo.Text, rowid);

            if (issuccess == true)
            {
                ReturnBook_Load(this, null);
            }

        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentNo.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtStudentNo_TextChanged_1(object sender, EventArgs e)
        {
            if (txtStudentNo.Text == "")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            }
        }
    }
}
