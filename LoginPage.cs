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

namespace clone
{
    public partial class LoginPage : UserControl
    {
        private int userID = 0;
        public int get_UserID()
        {
            return userID;
        }
        public void set_UserID(int variable)
        {
            userID = variable;
        }
        private static string connectionstring = "Server=LAPTOP-BEQ4MFN7\\ANKICLONE; database =AnkiClone;MultipleActiveResultSets=true; Integrated Security=SSPI;";
        SqlConnection myDatabase = new SqlConnection(connectionstring);
        SqlCommand myCMD = new SqlCommand();
        SqlDataReader reader;

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
        private void button2_Click(object sender, EventArgs e) //button for login
        {
            myDatabase.Open();
            SqlCommand readCommand = new SqlCommand("SELECT * from  users ", myDatabase); //why select * but not select username, whats foreach
            reader = readCommand.ExecuteReader();
            while (reader.Read())
            {
                string nick = reader.GetString(1);
                string pass = reader.GetString(2);
                if (nick == box_username.Text)
                {
                    if (pass == box_pass.Text)
                    {
                        int id = reader.GetInt32(0);
                        error_message_username.Text = "";
                        this.set_UserID(id);
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
            string reader_command = "SELECT * from  users ";
            SqlCommand readCommand = new SqlCommand(reader_command, myDatabase); //why select * but not select username
            reader = readCommand.ExecuteReader();
            if (reader.Read())
            {
                if (box_username.Text != "")
                {
                    myCMD.Connection = myDatabase;
                    error_message_username.Text = "";
                    if (box_pass.Text == "")
                    {
                        DialogResult dialogresult = MessageBox.Show("Are you sure that you don't want to set a password?", "Important!", MessageBoxButtons.YesNo);

                        if (dialogresult == DialogResult.Yes)
                        {
                            if (check_if_first_user_being_created() == true)
                            {
                                update_register();
                            }
                            else 
                            {  
                                bool already_exists_user = check_if_user_exists_already(box_username.Text);
                                if (already_exists_user == true)
                                {
                                    error_message_username.Text = "You've already registered!";
                                }
                                insert_register(already_exists_user);
                            }

                        }
                        else if (dialogresult == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        if (check_if_first_user_being_created() == true)
                        {
                            update_register();
                        }
                        else
                        {
                            bool already_exists_user = check_if_user_exists_already(box_username.Text);
                            if (already_exists_user == true)
                            {
                                error_message_username.Text = "You've already registered!";
                            }
                            insert_register(already_exists_user);
                        }

                    }
                }
                else
                {
                    error_message_username.Text = "Enter a username first.";
                }
            }

            myDatabase.Close();
        }
        private bool check_if_first_user_being_created()
        {
            SqlCommand readCommand = new SqlCommand("SELECT * from  users ", myDatabase); //why select * but not select username
            reader = readCommand.ExecuteReader();

            int id;
            string nick;
            if (reader.Read())
            {
                id = reader.GetInt32(0);
                nick = reader.GetString(1);
                //MessageBox.Show(nick);
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
        private bool check_if_user_exists_already(string name)
        {
            myCMD.Parameters.Clear();
            //SELECT COUNT(*) from users where user_name like @username
            string reader_command = "SELECT COUNT(*) from [users] where [username]=@name";
            SqlCommand readCommand = new SqlCommand(reader_command, myDatabase);
            readCommand.Parameters.AddWithValue("@name", name);
            int userCount = (int)readCommand.ExecuteScalar();
            if (userCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }




        }
        private void clean_boxes()
        {
            box_username.Text = "";
            box_pass.Text = "";
        }
        private void insert_register(bool already_exists_user)
        {
            if (already_exists_user == false)
            {
                myCMD.Parameters.Clear();
                myCMD.CommandText = "INSERT into dbo.users ([Username],[Password]) VALUES (@name,@pass)";
                myCMD.Parameters.AddWithValue("@Name", box_username.Text);
                myCMD.Parameters.AddWithValue("@pass", box_pass.Text);
                clean_boxes();
                error_message_username.Text = "Succesfully registered!";
                myCMD.ExecuteNonQuery();
            }
            else
            {
                clean_boxes();
            }
        }
        private void update_register()
        {
            myCMD.Parameters.Clear();
            myCMD.CommandText = "Update users SET [Username]= @name ,[Password]= @pass";
            myCMD.Parameters.AddWithValue("@name", box_username.Text);
            myCMD.Parameters.AddWithValue("@pass", box_pass.Text);
            myCMD.ExecuteNonQuery();
            clean_boxes();
            error_message_username.Text = "Register Successfull!";
        }
    }
}







