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
            String regNo = combo_regno.Text;
            String firstName = txt_firstname.Text;
            String lastName = txt_lastname.Text;
            String dateOfBirth = datepick.Text;
            String address = txt_address.Text;
            string gender = selectedValue;
            string emails = txt_email.Text;
            String mobilePhoneNo = txt_mobileno.Text;
            string homePhoneNo = txtHomeNo.Text;
            string parentName = txtParentname.Text;
            string nic = txt_nic.Text;
            string parentContactNo = txt_parentContactNo.Text;

            Debug.WriteLine(regNo);
            Debug.WriteLine(firstName);
            Debug.WriteLine(lastName);
            Debug.WriteLine(dateOfBirth);
            Debug.WriteLine(address);
            Debug.WriteLine(gender);
            Debug.WriteLine(emails);
            Debug.WriteLine(mobilePhoneNo);
            Debug.WriteLine(homePhoneNo);
            Debug.WriteLine(parentName);
            Debug.WriteLine(nic);
            Debug.WriteLine(parentContactNo);
            Debug.WriteLine(firstName);

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
