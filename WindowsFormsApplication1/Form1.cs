using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            //login
            if (txtusername.Text == "Admin" && txtpassword.Text == "Skills@123")
            {
                new Form2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login,Please Check Username and password and try again", "Invalid login details", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtusername.Clear();
                txtpassword.Clear();
                txtusername.Focus();
            }
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            //Exit
            var result = MessageBox.Show("Do you really want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            //Clear
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '●';
        }
    }
}
