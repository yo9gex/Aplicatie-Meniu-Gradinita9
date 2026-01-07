using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Aplicatie_Meniu_Gradinita9
{
    public partial class RegisterForm : Form
    {
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connect;
        public RegisterForm()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connect = new SqlConnection(connectionString);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signin_button_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        

        private void signup_loginbutton_Click(object sender, EventArgs e)
        {
            if (signup_username.Text == "" || signup_password.Text == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {

                        connect.Open();
                        // Check if the username already exists
                        string selectUsername = "SELECT COUNT(id) FROM users WHERE username = @username";
                        using (SqlCommand checkUser = new SqlCommand(selectUsername, connect))
                        {
                            checkUser.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                            int count = (int)checkUser.ExecuteScalar();
                            if (count >= 1)
                            {
                                MessageBox.Show(signup_username.Text.Trim() + " Username already exists. Please choose a different username.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                            }
                            else
                            {
                                DateTime today = DateTime.Today;

                                string insertData = "INSERT INTO users " + "(username, password, date_register)" + "VALUES (@username, @password, @dateReg)";

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", signup_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dateReg", today);
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Form1 loginForm = new Form1();
                                    loginForm.Show();
                                    this.Hide();

                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {

                        connect.Close();
                    }
                }
            }
        }

        private void signup_showpass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showpass.Checked ? '\0' : '*';
        }
    }
}
