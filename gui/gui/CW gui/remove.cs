using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_gui
{
    public partial class remove : Form
    {
        function fn = new function();
        String query;
        public remove()
        {
            InitializeComponent();
        }

        private void remove_Load(object sender, EventArgs e)
        {
            label3.Text = "How to Delete?";
            label3.ForeColor = Color.Blue;
            loaddata();
        }
        public void loaddata()
        {
            query = " select * from Books";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select * from Books where Name like '" + guna2TextBox1.Text + "%'";
            DataSet ds = fn.getData(query); 
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Delete this Book?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "Delete from Books where Id="+id+"";
                fn.setData(query);
                loaddata();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.ForeColor= Color.Red;
            label3.Text = "*Click on Row to Delete the Book!";
        }

        private void remove_Enter(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();  
            this.Hide();
            f.Show();
        }
    }
}
