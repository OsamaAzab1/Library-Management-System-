using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Library_Management_System

{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\oazab\OneDrive\Desktop\Library Management System\Library Management System\Database.mdf"";Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//login_button
        {
            string username, password;
            username = txt_username.Text;
            password = txt_password.Text;
            try
            {
                string querry ="SELECT * FROM login WHERE username='"+ txt_username.Text+"'AND password ='"+txt_password.Text+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(querry,conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    password = txt_password.Text;
                    Home_page home_Page = new Home_page();
                    home_Page.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("invalid login detailss","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();
                    txt_username.Focus();
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("invalid password or username");
            }
            finally
            {
                conn.Close();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_username.Focus();
            
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res=MessageBox.Show("Do you want to exit","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_password.UseSystemPasswordChar= true;
            }
            else
            {
                txt_password.UseSystemPasswordChar = false;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}