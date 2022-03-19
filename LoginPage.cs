using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace clone
{


    public partial class LoginPage : UserControl
    {

       

        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            pass_box.PasswordChar = '*'; //hides pass
           

        }

        private void show_pass_panel_CheckedChanged(object sender, EventArgs e)
        {
            if (show_pass_panel.Checked == true)
            {
                pass_box.PasswordChar = '\0'; //shows password
            }
            else
            {
                pass_box.PasswordChar = '*'; //hides pass
            }
        } //checkbox for showing password

        private void button2_Click(object sender, EventArgs e) //button for login
        {
            
            OleDbConnection myDatabase = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source= C:\Users\erknn\Desktop\deneme proje\clone\anki.accdb");
            OleDbCommand myCMD = new OleDbCommand();
            myDatabase.Open(); //i've coded the same thing twice, how to fix this in the function?
            OleDbCommand readCommand = new OleDbCommand("SELECT * from  users ", myDatabase); //why select * but not select username, whats foreach
            OleDbDataReader reader = readCommand.ExecuteReader();
            if (reader.Read())
            {
                string nick = reader.GetString(0);
                string pass = reader.GetString(1);
                if (nick == box_username.Text)
                {
                    if (pass == pass_box.Text)
                    {
                        error_message_username.Text = "";
                        this.Hide();
                        box_username.Text = "";
                        pass_box.Text = "";
                        
                    }
                    else
                    {
                        error_message_username.Text = "Invalid password.";
                    }
                }
                else
                {
                    error_message_username.Text = "Invalid username.";
                }

            }
            myDatabase.Close();
        }
        private void btnRegister_Click(object sender, EventArgs e) //button for register
        {
            OleDbConnection myDatabase = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source= C:\Users\erknn\Desktop\deneme proje\clone\anki.accdb");
            OleDbCommand myCMD = new OleDbCommand();
            myDatabase.Open();
            OleDbCommand readCommand = new OleDbCommand("SELECT * from  users ", myDatabase); //why select * but not select username
            OleDbDataReader reader = readCommand.ExecuteReader();
            
            if (reader.Read())
            { 
                string sql = reader.GetString(0);
                if (box_username.Text != sql)
                {
                    if (box_username.Text == "")
                    {
                        error_message_username.Text = "Enter a username first.";
                    }
                    else
                    {
                        error_message_username.Text = "";
                        if (pass_box.Text == "")
                        {
                            DialogResult dialogresult = MessageBox.Show("Are you sure that you don't want to set a password?", "Important!", MessageBoxButtons.YesNo);

                            if (dialogresult == DialogResult.Yes)
                            {
                                myCMD.Connection = myDatabase;
                                myCMD.CommandText = "Update users SET [Username]= '" + box_username.Text + "' ,[Password]= '" + pass_box.Text + "'";
                                //myCMD.CommandText = "INSERT INTO users([Username], [Password]) VALUES ('" + box_username.Text + "' , '" + pass_box.Text + "')";
                                myCMD.ExecuteNonQuery();
                            }
                            else if (dialogresult == DialogResult.No)
                            {

                            }
                        }
                        else
                        {
                            myCMD.Connection = myDatabase;
                            myCMD.CommandText = "Update users SET [Username]= '" + box_username.Text + "' ,[Password]= '" + pass_box.Text + "'";
                            box_username.Text = "";
                            pass_box.Text = "";
                            error_message_username.Text = "Succesfully registered!";
                            myCMD.ExecuteNonQuery();
                        }

                    }
                }
                else
                {
                    error_message_username.Text = "You've already registered!";
                }
            }

            myDatabase.Close();
        }
    }
}


