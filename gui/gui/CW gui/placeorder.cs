using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CW_gui
{
    public partial class placeorder : Form
    {
        private int userId;
        function fn = new function();
        string query;
        public placeorder(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        public placeorder()
        {
        }

        private void placeorder_Load(object sender, EventArgs e)
        {
            // Load genres into the ComboBox
            query = "SELECT DISTINCT Genre FROM Books";
            DataSet ds = fn.getData(query);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                guna2ComboBox1.Items.Add(row["Genre"].ToString());
            }
        
    }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            guna2TextBox5.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            guna2TextBox2.Text = text;

            query = "SELECT Title, Author FROM Books WHERE Name = @Name";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Name", text);
            DataSet ds = fn.getData(cmd);

            try
            {
                guna2TextBox3.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                guna2TextBox5.Text = ds.Tables[0].Rows[0]["Author"].ToString();
            }
            catch { }

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            guna2Panel1.BackColor = Color.FromArgb(170, 255, 255, 255);

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String category = guna2ComboBox1.Text;
            query = "SELECT Name FROM Books WHERE Genre = @Genre";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Genre", category);
            DataSet ds = fn.getData(cmd);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                listBox1.Items.Add(row["Name"].ToString());
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String category = guna2ComboBox1.Text;
            query = "SELECT Name FROM Books WHERE Genre = @Genre AND Name LIKE @Name AND Title LIKE @Title AND Author LIKE @Author";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Genre", category);
            cmd.Parameters.AddWithValue("@Name", guna2TextBox1.Text + "%");
            cmd.Parameters.AddWithValue("@Title", guna2TextBox3.Text + "%");
            cmd.Parameters.AddWithValue("@Author", guna2TextBox5.Text + "%");
            DataSet ds = fn.getData(cmd);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                listBox1.Items.Add(row["Name"].ToString());
            }
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        //protected int n, total = 0;

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 cc = new Form2();//check this
            this.Hide();
            cc.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string css = @"Data Source = DESKTOP - V8K3K2C; Initial Catalog = Library; Integrated Security = True; Encrypt = False";
            SqlConnection conn = new SqlConnection(css);
            conn.Open();

            string sql2 = "Select * from cart";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);

            SqlDataAdapter dp = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            dp.Fill(ds);

            this.guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(guna2TextBox2.Text))
            {
                string cs = @"Data Source=DESKTOP-V8K3K2C;Initial Catalog=Library;Integrated Security=True;Encrypt=False";
                SqlConnection con = new SqlConnection(cs);
                con.Open();

                // Get the selected book's ID
                query = "SELECT Id FROM Books WHERE Name = @Name AND Title = @Title AND Author = @Author";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@Title", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@Author", guna2TextBox5.Text);

                int bookId = (int)cmd.ExecuteScalar();

                // Insert the borrowing record
                string sql = "INSERT INTO BorrowedBooks (UserId, BookId, BorrowedDate) VALUES (@UserId, @BookId, GETDATE())";
                SqlCommand insertCmd = new SqlCommand(sql, con);
                insertCmd.Parameters.AddWithValue("@UserId", userId);
                insertCmd.Parameters.AddWithValue("@BookId", bookId);

                insertCmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Book borrowed successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a book to borrow.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
