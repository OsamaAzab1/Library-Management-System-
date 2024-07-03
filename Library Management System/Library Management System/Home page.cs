using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Home_page : Form
    {
        public Home_page()
        {
            InitializeComponent();
        }

        private void Home_page_Load(object sender, EventArgs e)
        {

        }

        private void button_books_Click(object sender, EventArgs e)
        {
            Booksform booksform = new Booksform();
            booksform.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_students_Click(object sender, EventArgs e)
        {
            studentsform studentsform = new studentsform();
            studentsform.Show();
            this.Hide();
        }

        private void button_librarians_Click(object sender, EventArgs e)
        {
            librarians librarians=new librarians();
            librarians.Show();
            this.Hide();
        }

        private void button_return_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            borrow borrow=new borrow();
            borrow.Show();
            this.Hide();
        }
    }
}
