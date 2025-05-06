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
    public partial class additems : Form
    {
        private int userId;
        function fn = new function();
        String query;
        public additems()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            guna2Panel1.BackColor = Color.FromArgb(170, 255, 255, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 k = new Form2();
            this.Hide();
            k.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            query = "insert into Books (Name,Title,Author,Genre) values ('" + guna2TextBox1.Text+"','" + guna2TextBox2.Text+","+ guna2TextBox3.Text+",'"+guna2ComboBox1.Text+"')";
            fn.setData(query);
            clearall();
        }
        public void clearall()
        {
            guna2TextBox2.Clear();
            guna2ComboBox1.SelectedItem = -1;
            guna2TextBox2.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            itemdata c = new itemdata();
            c.Show();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
