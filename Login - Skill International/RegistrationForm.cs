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
            this.Load += new EventHandler(RegistrationForm_Load);

        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI-DINUKA\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True");
        

        //initialize radio buttons
        private void InitializeRadioButtons()
        {
            radio_male.CheckedChanged += radio_male_CheckedChanged;
            radio_female.CheckedChanged += radioButton2_CheckedChanged;
            
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("automatically execute....");
            LoadData();

        }

        private void LoadData()
        {
            
            {
                conn.Open();
                string query = "SELECT regNo FROM Registration";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                Debug.WriteLine("dtable rows = " + dataTable.Rows.Count);
                //groupBox1.DataSource = dataTable;

                combo_regno.DisplayMember = "regNo";
                combo_regno.ValueMember = "regNo";
                combo_regno.DataSource = dataTable;

                conn.Close();

             
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string registerNo = combo_regno.Text;
            String fName = txt_firstname.Text;
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
            Debug.WriteLine("This is new register no: "+registerNo);
            Debug.WriteLine("This is new name: " + fName);
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
            string updateQuerry = "UPDATE Registration SET firstName=@Value2, lastName=@Value3, dateOfBirth = @Value4, address = @Value5, gender = @Value6, email = @Value7, mobilePhone = @Value8, homePhone = @Value9, parentName = @Value10, nic = @Value11, contactNo = @Value12 WHERE regNo= @Value1";

            SqlCommand cmd1 = new SqlCommand(updateQuerry, conn);
            Debug.WriteLine(conn);

            //assign values
            cmd1.Parameters.AddWithValue("@Value1", combo_regno.Text);
            cmd1.Parameters.AddWithValue("@Value2", txt_firstname.Text);
            Debug.WriteLine(updateQuerry);
            cmd1.Parameters.AddWithValue("@Value3", txt_lastname.Text);
            cmd1.Parameters.AddWithValue("@Value4", datepick.Value);
            cmd1.Parameters.AddWithValue("@Value5", txt_address.Text);
            cmd1.Parameters.AddWithValue("@Value6", selectedValue);
            cmd1.Parameters.AddWithValue("@Value7", txt_email.Text);
            cmd1.Parameters.AddWithValue("@Value8", txt_mobileno.Text);
            cmd1.Parameters.AddWithValue("@Value9", txtHomeNo.Text);
            cmd1.Parameters.AddWithValue("@Value10", txtParentname.Text);
            cmd1.Parameters.AddWithValue("@Value11", txt_nic.Text);
            cmd1.Parameters.AddWithValue("@Value12", txt_parentContactNo.Text);

            try
            {
                conn.Open();
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("Record Not Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }




        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //delete
        private void button4_Click(object sender, EventArgs e)
        {
            int registrationNo = Convert.ToInt32(combo_regno.Text);

            {
                conn.Open();
                string query = "DELETE FROM Registration WHERE regNo = @value1";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@value1", registrationNo);
                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    DialogResult result = MessageBox.Show("Are You sure, Do you Really want to Delete this Record...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Deletion failed.");
                }
            }
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
            if (combo_regno.SelectedItem != null && combo_regno.SelectedValue != DBNull.Value)
            {
                // Assuming ValueMember property to "selectedRegno"
                DataRowView selectedRow = (DataRowView)combo_regno.SelectedItem;
                int selectedRegno = Convert.ToInt32(selectedRow["regNo"]);
                Debug.WriteLine($"Selected Product ID: {selectedRegno}");


                
                // MessageBox.Show($"Selected Product ID: {selectedRegno}");
                Debug.WriteLine($"Selected Product ID: {selectedRegno}");


                //read data according to regNo
                {
                    //conn.Open();
                    string query = "SELECT * FROM Registration WHERE regNo = '" + selectedRegno + "' ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    Debug.WriteLine("filtered rows = " + dataTable.Rows.Count);
                    //groupBox1.DataSource = dataTable;

                    if(dataTable.Rows.Count > 0)
                    {
                        //recruit values
                        DataRow row = dataTable.Rows[0];
                        string fname = row["firstName"] == DBNull.Value ? string.Empty : row["firstName"].ToString();
                        string lname = row["lastName"] == DBNull.Value ? string.Empty : row["lastName"].ToString();
                        string birthday = row["dateOfBirth"] == DBNull.Value ? string.Empty : row["dateOfBirth"].ToString();
                        string Gender = row["gender"] == DBNull.Value ? string.Empty : row["gender"].ToString();
                        string Address = row["address"] == DBNull.Value ? string.Empty : row["address"].ToString();
                        string Email = row["email"] == DBNull.Value ? string.Empty : row["email"].ToString();
                        string MobileNo = row["mobilePhone"] == DBNull.Value ? string.Empty : row["mobilePhone"].ToString();
                        string HomeNo = row["homePhone"] == DBNull.Value ? string.Empty : row["homePhone"].ToString();
                        string parent = row["parentName"] == DBNull.Value ? string.Empty : row["parentName"].ToString();
                        string NIC = row["nic"] == DBNull.Value ? string.Empty : row["nic"].ToString();
                        string ParentNo = row["contactNo"] == DBNull.Value ? string.Empty : row["contactNo"].ToString();

                        //testing
                        Debug.WriteLine($"First Name: {fname}");
                        Debug.WriteLine($"lname Name: {lname}");
                        Debug.WriteLine($"birthday: {birthday}");
                        Debug.WriteLine($"Gender: {Gender}");
                        Debug.WriteLine($"Address : {Address}");
                        Debug.WriteLine($"Email : {Email}");
                        Debug.WriteLine($"mobilePhone : {MobileNo}");
                        Debug.WriteLine($"HomePhone : {HomeNo}");
                        Debug.WriteLine($"parent : {parent}");
                        Debug.WriteLine($"NIC : {NIC}");
                        Debug.WriteLine($"parentPhone : {ParentNo}");
                        


                        //assigning to UI

                        txt_firstname.Text = fname;
                        txt_lastname.Text = lname;
                        datepick.Value = DateTime.Parse(birthday);
                        txt_address.Text = Address;
                        if(Gender == "Male")
                        {
                            radio_male.Checked = true;
                        }else
                        {
                            radio_female.Checked = true;
                        }
                        selectedValue = Gender;
                        txt_email.Text = Email;
                        txt_mobileno.Text = MobileNo;
                        txtHomeNo.Text = HomeNo;
                        txtParentname.Text = parent;
                        txt_nic.Text = NIC;
                        txt_parentContactNo.Text = ParentNo;
                        



                    }



                    conn.Close();

                    /*foreach (DataRow row in dataTable.Rows)
                    {
                        //int registrationNo = Convert.ToInt32(row["regNo"]);
                        int registrationNo = Convert.IsDBNull(row["regNo"]) ? 0 : Convert.ToInt32(row["regNo"]);
                        //


                        // Do something with the values, such as displaying them or processing them
                        Debug.WriteLine($"regNo: {registrationNo}");
                    }*/
                }
            }
            
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
            int mobilePhoneNo = Convert.ToInt32(txt_mobileno.Text);
            int homePhoneNo = Convert.ToInt32(txtHomeNo.Text);
            string parentName = txtParentname.Text;
            string nic = txt_nic.Text;
            int parentContactNo = Convert.ToInt32(txt_parentContactNo.Text);

            //checks values
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
            

            // insert 
            string insertQuerry = "INSERT INTO Registration (regNo, firstName, lastName, dateOfBirth, address, gender, email, mobilePhone, homePhone, parentName, nic, contactNo) VALUES (@Value1, @value2, @value3, @value4, @value5, @value6, @value7, @Value8, @Value9, @value10, @value11, @Value12 )";
            SqlCommand cmd = new SqlCommand(insertQuerry, conn);
            //, , , contactNo,  ,  


            //assign values
            cmd.Parameters.AddWithValue("@Value1", regNo);
            cmd.Parameters.AddWithValue("@Value2", firstName);
            cmd.Parameters.AddWithValue("@Value3", lastName);
            cmd.Parameters.AddWithValue("@Value4", dateOfBirth);
            cmd.Parameters.AddWithValue("@Value5", address);
            cmd.Parameters.AddWithValue("@Value6", gender);
            cmd.Parameters.AddWithValue("@Value7", emails);
            cmd.Parameters.AddWithValue("@Value8", mobilePhoneNo);
            cmd.Parameters.AddWithValue("@Value9", homePhoneNo);
            cmd.Parameters.AddWithValue("@Value10", parentName);
            cmd.Parameters.AddWithValue("@Value11", nic);
            cmd.Parameters.AddWithValue("@Value12", parentContactNo);



            try
            { 
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("Record Not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel_Exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure, Do you really want to Exit..?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();

            }
        }

        private void linkLabel_logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do You want to Logout", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {

                //page that need load
                LoginForm form1 = new LoginForm();
                form1.Show();
                this.Hide();
                
            }
            else
            {
                this.Show();

            }
        }

        private void RegistrationForm_Load_1(object sender, EventArgs e)
        {

        }

        private void txt_mobileno_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            combo_regno.Text = "";
            txt_firstname.Clear();
            txt_lastname.Clear();
            
            txt_address.Clear();
            //datepick.Value = new DateTime(0, 0, 0);
            radio_male.Checked = false;
            radio_female.Checked = false;
            txt_email.Clear();
            txt_mobileno.Clear();
            txtHomeNo.Clear();
            txtParentname.Clear();
            txt_nic.Clear();
            txt_parentContactNo.Clear();

        }
    }
}
