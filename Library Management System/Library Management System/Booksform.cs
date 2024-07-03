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

namespace Library_Management_System
{
    public partial class Booksform : Form
    {
        public Booksform()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\oazab\OneDrive\Desktop\Library Management System\Library Management System\Database.mdf"";Integrated Security=True");
        public void populate()
        {
            conn.Open();
            string query = "select * from booksTBL";
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var dt = new DataSet();
            adapter.Fill(dt);
            dataGridView1.DataSource= dt.Tables[0];
            conn.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_page home_Page = new Home_page();
            home_Page.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (txt_bookname.Text == "" || txt_author.Text == "" || txt_price.Text == "" || txt_publisher.Text == ""||txt_quantity.Text=="")
            {
                MessageBox.Show("missing info");
            }
            conn.Open();
            string query = "insert into booksTBL values('" + txt_bookname.Text + "','" + txt_publisher.Text + "','" + txt_author.Text + "'," + txt_price.Text + "," + txt_quantity.Text + ") ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("books has benn added");
            conn.Close();
            populate();


        }

        private void Booksform_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_bookname.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_author.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_publisher.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_price.Text= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_quantity.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (txt_bookname.Text == "" || txt_author.Text == "" || txt_price.Text == "" || txt_publisher.Text == "" || txt_quantity.Text == "")
            {
                MessageBox.Show("missing info");
            }
            conn.Open();
            string query = "update booksTBL set bookName='"+txt_bookname.Text+"',Author='"+txt_author.Text+"',Publisher='"+txt_publisher.Text+"',Price="+txt_price.Text+"where Qty="+txt_quantity.Text+"";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Books has been updated");
            conn.Close();
            populate();

        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (txt_bookname.Text == "")
            {
                MessageBox.Show("please enter book name","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                conn.Open();
                string query = "delete from booksTBL where bookName='"+txt_bookname.Text+"'";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("book has been deleted");
                conn.Close();
                populate();
            }
        }
    }
}
