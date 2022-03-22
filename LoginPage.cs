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
        OleDbConnection myDatabase = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source= C:\Users\erknn\Desktop\deneme proje\clone\anki.accdb");
        OleDbCommand myCMD = new OleDbCommand();
        OleDbDataReader reader;

        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            box_pass.PasswordChar = '*'; //hides pass
           

        }

        private void show_pass_panel_CheckedChanged(object sender, EventArgs e)
        {
            if (show_pass_panel.Checked == true)
            {
                box_pass.PasswordChar = '\0'; //shows password
            }
            else
            {
                box_pass.PasswordChar = '*'; //hides pass
            }
        } //checkbox for showing password
        //kayıt kismini coklu kisi yap, tek kisiye calisiyor
        private void button2_Click(object sender, EventArgs e) //button for login
        {
  
            myDatabase.Open(); //i've coded the same thing twice, how to fix this in the function?
            OleDbCommand readCommand = new OleDbCommand("SELECT * from  users ", myDatabase); //why select * but not select username, whats foreach
            reader = readCommand.ExecuteReader();
            while (reader.Read())
            {
                string nick = reader.GetString(1);
                string pass = reader.GetString(2);
                if (nick == box_username.Text)
                {
                    if (pass == box_pass.Text)
                    {
                        error_message_username.Text = "";
                        this.Hide();
                        clean_boxes();
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
            myDatabase.Open();
            OleDbCommand readCommand = new OleDbCommand("SELECT * from  users ", myDatabase); //why select * but not select username
            reader = readCommand.ExecuteReader();
            
            if (reader.Read())
            { 
                if (box_username.Text != "")
                {
                    if (box_username.Text == "")
                    {
                        error_message_username.Text = "Enter a username first.";
                    }
                    else
                    {
                        myCMD.Connection = myDatabase;
                        error_message_username.Text = "";
                        if (box_pass.Text == "")
                        {
                            DialogResult dialogresult = MessageBox.Show("Are you sure that you don't want to set a password?", "Important!", MessageBoxButtons.YesNo);

                            if (dialogresult == DialogResult.Yes)
                            {
                                if (check_if_first_user_being_created())
                                {
                                    myCMD.CommandText = "Update users SET [Username]= '" + box_username.Text + "' ,[Password]= '" + box_pass.Text + "'";
                                    //myCMD.CommandText = "INSERT INTO users([Username], [Password]) VALUES ('" + box_username.Text + "' , '" + pass_box.Text + "')";
                                    myCMD.ExecuteNonQuery();
                                }
                                else
                                {
                                    myCMD.CommandText = "INSERT INTO users([Username], [Password]) VALUES(@Username, @Password)";
                                    myCMD.Parameters.AddWithValue("@Name", box_username.Text);
                                    myCMD.Parameters.AddWithValue("@Password", box_pass.Text);
                                    clean_boxes();
                                    error_message_username.Text = "Succesfully registered!";
                                    myCMD.ExecuteNonQuery();
                                }
                               
                            }
                            else if (dialogresult == DialogResult.No)
                            {

                            }
                        }
                        else
                        {
                            myCMD.Connection = myDatabase;
                            if (check_if_first_user_being_created())
                            {
                                myCMD.CommandText = "Update users SET [Username]= '" + box_username.Text + "' ,[Password]= '" + box_pass.Text + "'";
                                //myCMD.CommandText = "INSERT INTO users([Username], [Password]) VALUES ('" + box_username.Text + "' , '" + pass_box.Text + "')";
                                myCMD.ExecuteNonQuery();
                                clean_boxes();
                            }
                            else
                            {
                                myCMD.CommandText = "INSERT INTO users([Username], [Password]) VALUES(@Username, @Password)";
                                myCMD.Parameters.AddWithValue("@Name", box_username.Text);
                                myCMD.Parameters.AddWithValue("@Password", box_pass.Text);
                                clean_boxes();
                                error_message_username.Text = "Succesfully registered!";
                                myCMD.ExecuteNonQuery();
                            }
                            
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
        private bool check_if_first_user_being_created()
        {
            OleDbCommand readCommand = new OleDbCommand("SELECT * from  users ", myDatabase); //why select * but not select username
            reader = readCommand.ExecuteReader();

            int id;
            string nick;
            if (reader.Read())
            {
                id = reader.GetInt32(0);
                nick = reader.GetString(1);
                if (id == 1 && nick == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }

        private void clean_boxes()
        {
            box_username.Text = "";
            box_pass.Text = "";
        }
    }
}







