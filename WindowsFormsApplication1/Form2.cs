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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        SqlConnection Form2Connection = new SqlConnection(@"Data Source=DESKTOP-DGGMBMA\SQLEXPRESS;Initial Catalog=SkillsInternational;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string Gender;
        string Qry;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

             //Register
            try
            {
                Qry = "INSERT INTO tblRegistration (regNo, firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, homePhone, parentName, nic, contactNo) VALUES('" +
                    textBox3.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + Gender + "','" + txtAddress.Text +"','" + txtEmail1.Text +"','"+
                        txtMobilePhone.Text + "','" + txtHomePhone.Text + "','" + txtParentName.Text + "','" + txtNIC.Text + "','" + txtContactNumber.Text + "')";
                cmd = new SqlCommand(Qry, Form2Connection);
                Form2Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record Added Successfully","StudentRegistration",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Records were added","StudentRegistration",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Adding Recording", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Form2Connection.Close();
            }

        }

        private void rdbmale_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void rbdfemale_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Qry = "Update tblRegistration Set FirstName = '" + txtFirstName.Text + "', LastName = '" + txtLastName.Text + "', DateOfBirth = '" +
                    dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', Gender = '" +
                    Gender + "', Address = '" + txtAddress.Text + "', Email = '" +
                    txtEmail.Text + "', MobilePhone = '" + txtMobilePhone.Text + "', HomePhone = '" +
                    txtHomePhone.Text + "', ParentName = '" + txtParentName.Text + "', NIC = '" +
                    txtNIC.Text + "', ContactNO = '" + txtContactNumber.Text + "' Where RegNo = '" +
                    textBox3.Text + "'";
                cmd = new SqlCommand(Qry, Form2Connection);
                Form2Connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully", "StudentRegistration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Updating Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Form2Connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             //Delete
            DialogResult delete = MessageBox.Show("Are you sure you want to delete the record?", "Delete the Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (delete == DialogResult.Yes)
                {
                    try
                    { 
                        Qry = "Delete from tblRegistration Where RegNo= '" + textBox3.Text + "'";
                        cmd = new SqlCommand(Qry, Form2Connection);
                        Form2Connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted Successfully", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Updating Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        Form2Connection.Close();
                    }
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             //Clear
            textBox3.Clear();
            txtFirstName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtMobilePhone.Clear();
            txtHomePhone.Clear();
            txtParentName.Clear();
            txtNIC.Clear();
            txtContactNumber.Clear();

            rdbmale.Checked = false;
            rbdfemale.Checked = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Logout
            DialogResult ext = MessageBox.Show("Are you sure,Do you really want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ext == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Exit
            DialogResult exit = MessageBox.Show("Are you sure want to Exit?", "Exit Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
