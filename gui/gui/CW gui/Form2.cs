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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(String user)
        {
            InitializeComponent();

            if (user == "Guest")
            {
                add.Hide();
                update.Hide();
                delete.Hide();
            }
            else if (user =="Admin")
            {
                order.Hide();
                add.Show();
                update.Show();
                delete.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 c1 = new Form1();
            this.Hide();
            c1.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            additems c2 = new additems();
            this.Hide();
            c2.Show();
        }

        private void order_Click(object sender, EventArgs e)
        {
            placeorder c = new placeorder();
            this.Hide();
            c.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            updateitems n = new updateitems();
            this.Hide();
            n.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            remove m = new remove();
            this.Hide();
            m.Show();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
