using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;


namespace Login___Skill_International
{
    public partial class RegistrationForm : Form
    {
        private string selectedValue = ""; // Variable to store the selected value of radio button
        public RegistrationForm()
        {
            InitializeComponent();
            InitializeRadioButtons();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI-DINUKA\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True");

        //initialize radio buttons
        private void InitializeRadioButtons()
        {
            radio_male.CheckedChanged += radio_male_CheckedChanged;
            radio_female.CheckedChanged += radioButton2_CheckedChanged;
            
            // Attach CheckedChanged event handlers for each radio button
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int regNo = int.Parse(combo_regno.Text);
            String firstName = txt_firstname.Text;
            String lastName = txt_lastname.Text;
            DateTime dateOfBirth = datepick.Value;
            String address = txt_address.Text;
            string gender = selectedValue;
            string emails = txt_email.Text;
            //int mobilePhoneNo = int.Parse(txt_mobileno.Text);
            // int homePhoneNo = int.Parse(txtHomeNo.Text);
            string parentName = txtParentname.Text;
            string nic = txt_nic.Text;
            //parentContactNo = int.Parse(txt_parentContactNo.Text);

            //checks values
            Debug.WriteLine(regNo);
            Debug.WriteLine(firstName);
            Debug.WriteLine(lastName);
            Debug.WriteLine(dateOfBirth);
            Debug.WriteLine(address);
            Debug.WriteLine(gender);
            Debug.WriteLine(emails);
            //  Debug.WriteLine(mobilePhoneNo);
            //  Debug.WriteLine(homePhoneNo);
            Debug.WriteLine(parentName);
            Debug.WriteLine(nic);
            //Debug.WriteLine(parentContactNo);

            //update querry
            string updateQuerry = "UPDATE Registration SET regNo = @Value1, firstName=@Value2, lastName=@Value3, dateOfBirth=@Value4, address=@Value5, gender=@Value6, email=@Value7, parentName=@Value10, nic=@Value11)";
            SqlCommand cmd = new SqlCommand(updateQuerry, conn);

            //assign values
            cmd.Parameters.AddWithValue("@Value1", regNo);
            cmd.Parameters.AddWithValue("@Value2", firstName);
            cmd.Parameters.AddWithValue("@Value3", lastName);
            cmd.Parameters.AddWithValue("@Value4", dateOfBirth);
            cmd.Parameters.AddWithValue("@Value5", address);
            cmd.Parameters.AddWithValue("@Value6", gender);
            cmd.Parameters.AddWithValue("@Value7", emails);
            //cmd.Parameters.AddWithValue("@Value8", mobilePhoneNo);
            //cmd.Parameters.AddWithValue("@Value9", homePhoneNo);
            cmd.Parameters.AddWithValue("@Value10", parentName);
            cmd.Parameters.AddWithValue("@Value11", nic);
            //cmd.Parameters.AddWithValue("@Value12", parentContactNo);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully added");
            }
            catch
            {
                MessageBox.Show("Record not added! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radio_male_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null && selectedRadioButton.Checked)
            {
                selectedValue = selectedRadioButton.Text;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null && selectedRadioButton.Checked)
            {
                selectedValue = selectedRadioButton.Text;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            int regNo =  int.Parse(combo_regno.Text);
            String firstName = txt_firstname.Text;
            String lastName = txt_lastname.Text;
            DateTime dateOfBirth = datepick.Value;
            String address = txt_address.Text;
            string gender = selectedValue;
            string emails = txt_email.Text;
            //int mobilePhoneNo = int.Parse(txt_mobileno.Text);
           // int homePhoneNo = int.Parse(txtHomeNo.Text);
            string parentName = txtParentname.Text;
            string nic = txt_nic.Text;
            //parentContactNo = int.Parse(txt_parentContactNo.Text);

            //checks values
            Debug.WriteLine(regNo);
            Debug.WriteLine(firstName);
            Debug.WriteLine(lastName);
            Debug.WriteLine(dateOfBirth);
            Debug.WriteLine(address);
            Debug.WriteLine(gender);
            Debug.WriteLine(emails);
          //  Debug.WriteLine(mobilePhoneNo);
          //  Debug.WriteLine(homePhoneNo);
            Debug.WriteLine(parentName);
            Debug.WriteLine(nic);
           //Debug.WriteLine(parentContactNo);
            

            // insert 
            string insertQuerry = "INSERT INTO Registration (regNo, firstName, lastName, dateOfBirth, address, gender, email, parentName, nic) VALUES (@Value1, @value2, @value3, @value4, @value5, @value6, @value7, @value10, @value11)";
            SqlCommand cmd = new SqlCommand(insertQuerry, conn);

            //, homePhone, parentName, nic, contactNo
            //, @value8, @value9, @value10, @value11, @value12

            //assign values
            cmd.Parameters.AddWithValue("@Value1", regNo);
            cmd.Parameters.AddWithValue("@Value2", firstName);
            cmd.Parameters.AddWithValue("@Value3", lastName);
            cmd.Parameters.AddWithValue("@Value4", dateOfBirth);
            cmd.Parameters.AddWithValue("@Value5", address);
            cmd.Parameters.AddWithValue("@Value6", gender);
            cmd.Parameters.AddWithValue("@Value7", emails);
            //cmd.Parameters.AddWithValue("@Value8", mobilePhoneNo);
            //cmd.Parameters.AddWithValue("@Value9", homePhoneNo);
            cmd.Parameters.AddWithValue("@Value10", parentName);
            cmd.Parameters.AddWithValue("@Value11", nic);
            //cmd.Parameters.AddWithValue("@Value12", parentContactNo);



            try
            { 
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully added");
            }
            catch
            {

                MessageBox.Show("Record not added! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
