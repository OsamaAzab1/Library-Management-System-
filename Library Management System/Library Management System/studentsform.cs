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
    public partial class studentsform : Form
    {
        public studentsform()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\oazab\OneDrive\Desktop\Library Management System\Library Management System\Database.mdf"";Integrated Security=True");
        public void populate()
        {
           conn.Open();
            string query = "select * from studentTBL";
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var dt= new DataSet();
            adapter.Fill(dt);
            dataGridView1.DataSource= dt.Tables[0];
            conn.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_page home_Page = new Home_page();
            home_Page.Show();
            
        }

        private void studentsform_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_id.Text == "" || txt_department.Text == "" || txt_phone.Text == "" || comboBox_semester.SelectedItem.ToString() == "")
            {
                MessageBox.Show("missing info");
            }
            conn.Open();
            string query = "insert into studentTBL values('"+txt_name.Text+"','"+txt_department.Text+"'," + comboBox_semester.SelectedItem.ToString() + "," +txt_phone.Text+","+txt_id.Text+")";
            SqlCommand cmd= new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("student has been added");
            conn.Close();
            populate();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_name.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_department.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_phone.Text= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_id.Text= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox_semester.SelectedItem= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_id.Text == "" || txt_department.Text == "" || txt_phone.Text == "")
            {
                MessageBox.Show("missing info");
            }
            conn.Open();
            string query = "update studentTBL set stdName='"+txt_name.Text+"',stdSemester="+comboBox_semester.SelectedItem.ToString()+",stdDepartment='"+txt_department.Text+"',stdPhone="+txt_phone.Text+"where stdID="+txt_id.Text+" ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("student has been updated");
            conn.Close();
            populate();

        }


        private void button_remove_Click(object sender, EventArgs e)
        {
            if(txt_name.Text == "")
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                conn.Open();
                string query = "delete from studentTBL where stdName='"+txt_name.Text+"'";
                SqlCommand cmd =new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                populate();

            }
        }

        private void dataGrindView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }
    }
}
