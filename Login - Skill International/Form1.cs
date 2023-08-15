using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace Login___Skill_International
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI-DINUKA\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True");
        
        
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();

            //focus
            txt_username.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do You want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = txt_username.Text;
            user_password = txt_password.Text;

            Debug.WriteLine(txt_username.Text);
            Debug.WriteLine(txt_password.Text);


            Debug.WriteLine("Button clicked!.");
            try
            {
                Debug.WriteLine("try blog stars....");
                string querry = "SELECT * FROM Login_new WHERE username = '"+ txt_username.Text + "' AND password = '" + txt_password.Text + "'";
                Debug.WriteLine(conn);


                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                Debug.WriteLine(sda.ToString());

                
                DataTable dtable = new DataTable();
                Debug.WriteLine(dtable);
                sda.Fill(dtable);
                Debug.WriteLine("dtable rows = "+dtable.Rows.Count);

                
                if (dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password=txt_password.Text;

                    

                    //page that need load
                    
                    RegistrationForm form2 = new RegistrationForm();
                    form2.Show();
                    this.Hide();
                } 
                

                
                else
                {
                    MessageBox.Show("Invalid login Credentials,Please check Username and Password and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();

                    //focus
                    txt_username.Focus();
                    



                }

            }
            catch
            {
                
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}