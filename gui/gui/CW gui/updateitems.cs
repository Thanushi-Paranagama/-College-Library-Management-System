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
    public partial class updateitems : Form
    {
        function fn = new function();
        String query;
        public updateitems()
        {
            InitializeComponent();
        }

        private void updateitems_Load(object sender, EventArgs e)
        {
            
            loaddata();  
        }
        public void loaddata()
        {
            query = "select * from items"; 
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            guna2Panel1.BackColor = Color.FromArgb(170, 255, 255, 255);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            query = "select * from items where name like'" + search.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource=ds.Tables[0];
        }
        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String category = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtcategory.Text = category;
            txtitem.Text = name;
            txtprice.Text = price.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            query = "update items set name='" + txtitem.Text + "',category='" + txtcategory.Text + "',price=" + txtprice.Text + " where iid="+id+"";
            fn.setData(query);
            loaddata();

            txtcategory.Clear();
            txtitem.Clear();
            txtprice.Clear();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();  
            this.Hide();
            f.Show();
        }
    }
}
