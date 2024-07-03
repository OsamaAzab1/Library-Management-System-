using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class borrow : Form
    {
        public borrow()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\oazab\OneDrive\Desktop\Library Management System\Library Management System\Database.mdf"";Integrated Security=True");


        private void txt_phone_TextChanged(object sender, EventArgs e)
        {

        }
        private void std_id()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select stdID from studentTBL",conn);
            SqlDataReader dr=cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("stdID",typeof(int));
            dt.Load(dr);
            id_cb.ValueMember = "stdID";
            id_cb.DataSource=dt;
            conn.Close();

        }
        private void update_book_qty()
        {
            int Qty, new_Qty;
            conn.Open();
            string query = "select * from booksTBL where bookName='" + book_cb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                 Qty = Convert.ToInt32(dr["Qty"].ToString());
                 new_Qty = Qty - 1;
                string q = "update booksTBL set Qty=" + new_Qty + " where bookName='" + book_cb.SelectedValue.ToString() + "'";
                SqlCommand cmd1 = new SqlCommand(q,conn);
                cmd1.ExecuteNonQuery();
            }
            conn.Close();
        }
        private void std_data_fill()
        {
            conn.Open();
            string query = "select * from studentTBL where stdID="+id_cb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query,conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txt_name.Text=dr["stdName"].ToString();
                txt_department.Text= dr["stdDepartment"].ToString();
                txt_phone.Text= dr["stdPhone"].ToString();
            }
            conn.Close();
        }
        public void populate()
        {
            conn.Open();
            string query = "select * from borrowTBL";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var dt = new DataSet();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            conn.Close();

        }
        private void book_fill()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select bookName from booksTBL where Qty>"+0+"", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("bookName", typeof(string));
            dt.Load(dr);
            book_cb.ValueMember = "bookName";
            book_cb.DataSource = dt;
            conn.Close();

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            Home_page home_Page = new Home_page();  
            home_Page.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_borrow.Text == "")
            {
                MessageBox.Show("missing info");
            }
            else
            {
                string borrowDate = borrow_date.Value.Day.ToString() + "/" + borrow_date.Value.Month.ToString()+"/"+ borrow_date.Value.Year.ToString();
                conn.Open();
                string query = "insert into borrowTBL values("+txt_borrow.Text+","+ id_cb.SelectedValue.ToString() + ",'"+txt_name.Text+"','"+txt_department.Text+"',"+txt_phone.Text+",'"+book_cb.SelectedValue.ToString()+"','"+borrowDate+"');";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("student borrowed a book");
                conn.Close();
                update_book_qty();
                populate();
                
            }

        }

        private void borrow_Load(object sender, EventArgs e)
        {
            std_id();
            book_fill();
            populate();
        }

        private void id_cb_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void id_cb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            std_data_fill();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (id_cb.SelectedValue== "")
            {
                MessageBox.Show("Please enter id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                conn.Open();
                string query = "delete from borrowTBL where bID=" + id_cb.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                populate();

            }
        }
    }
}
