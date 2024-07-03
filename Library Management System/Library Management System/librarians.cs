using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class librarians : Form
    {
        public librarians()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\oazab\OneDrive\Desktop\Library Management System\Library Management System\Database.mdf"";Integrated Security=True");

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void populate()
        {
            conn.Open();
            string query = "select * from librariansTBL";
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var dt = new DataSet();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            conn.Close();

        }

        private void button_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_page home_Page = new Home_page();
            home_Page.Show();

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (txtt_name.Text == "" || txt_id.Text == "" || txt_phone.Text == ""||txt_email.Text=="")
            {
                MessageBox.Show("missing info");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into librariansTBL values('"+txtt_name.Text+"',"+txt_id.Text+",'"+txt_phone.Text+"','"+txt_email.Text+"')",conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("librarian added");
                conn.Close();
                populate();
            }
        }

        private void librarians_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (txtt_name.Text == "")
            {
                MessageBox.Show("Please enter name","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                conn.Open();
                string query= "delete from librariansTBL where libname='" + txtt_name.Text + "';";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("librarians has been deleted");
                conn.Close();
                populate();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtt_name.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_id.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_phone.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtt_name.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_id.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_phone.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_email.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (txtt_name.Text == "" || txt_id.Text == ""|| txt_phone.Text == ""|| txt_email.Text=="")
            {
                MessageBox.Show("missing info");
            }
            else
            {
                conn.Open();
                string query = "update librariansTBL set libname='"+txtt_name.Text+"',libphone='"+txt_phone.Text+"',libemail='"+txt_email.Text+"'where libid="+txt_id.Text+"";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("librarians has been updated");
                conn.Close();
                populate();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
