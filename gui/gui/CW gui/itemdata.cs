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

namespace CW_gui
{
    public partial class itemdata : Form
    {
        private int userId;
        public itemdata(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        public itemdata()
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-V8K3K2C;Initial Catalog=Library;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM BorrowedBooks WHERE UserId = @UserId";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@UserId", userId);

            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];

            con.Close();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
