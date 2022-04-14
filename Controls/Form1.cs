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

    public partial class Form1 : Form
    {
        deckControl deck_page = new deckControl();
        LoginPage loginPage1;
        private static string connectionstring = "Server=LAPTOP-BEQ4MFN7\\ANKICLONE; database =AnkiClone;MultipleActiveResultSets=true; Integrated Security=SSPI;";
        SqlConnection myDatabase = new SqlConnection(connectionstring);
        private int userID = 0;

        public int get_UserID()
        {
            return userID;
        }
        public void set_UserID(int variable)
        {
            userID = variable;
        }
        public Form1()
        {
            InitializeComponent();
            timer_settings();
            user_database_settings();
            LoginPage login_page = new LoginPage(Decks_Button);
            loginPage1 = login_page;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(loginPage1);
        }

        private void Decks_Button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loginPage1.Visible == false)
            {
                this.set_UserID(loginPage1.get_UserID());
                deck_page.set_UserID(this.get_UserID());
                panel1.Controls.Clear();
                panel1.Controls.Add(deck_page);
                deck_page.Show();
            }
        }

        private void Add_Button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loginPage1.Visible == false)
            {
                panel1.Controls.Clear();
            }
        }

        private void Brows_Button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loginPage1.Visible == false)
            {
                panel1.Controls.Clear();
            }
        }

        private void Stats_Button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loginPage1.Visible == false)
            {
                panel1.Controls.Clear();
                //panel1.Controls.Add(stat_page);
                //stat_page.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = "Date: " + DateTime.Now.ToString();
            set_user_name_label();
            check_for_user_login();//delete these from the timer

        }
        private void timer_settings() //a function to keep the timer running
        {
            dateLabel.Text = "Date: " + DateTime.Now.ToString();
            timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;

        }
        private void user_database_settings()
        {   
            string readingCommand = "Select * from users";
            myDatabase.Open();
            try
            { 
                SqlCommand cmd = new SqlCommand(readingCommand);
                cmd.Connection = myDatabase;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                }
                catch
                {
                    cmd.Parameters.Clear();
                    //if doesn't exist, create table
                    string strTemp = "create table users (UserID int NOT NULL    IDENTITY    PRIMARY KEY,[Username] varchar(50),[Password] varchar(50));";
                    cmd.CommandText = strTemp;
                    cmd.ExecuteNonQuery();
                    string space = "";
                    string saveStaff = "INSERT into dbo.users ([Username],[Password]) VALUES (@name,@pass)";
                    cmd.CommandText = saveStaff;
                    cmd.Parameters.AddWithValue("@name", space);
                    cmd.Parameters.AddWithValue("@pass", space);
                    cmd.ExecuteNonQuery();
                    //if doesn't exist, create table
                }
                myDatabase.Close();
            }
            catch
            {
 
            }
        } //creates a table if doesn't exist at the beginning of the program for users.
        private void set_user_name_label()
        {
            myDatabase.Open();
            string readingCommand = "SELECT * from  users ";
            SqlCommand readCommand = new SqlCommand(readingCommand, myDatabase); //why select * but not select username
            SqlDataReader reader = readCommand.ExecuteReader();
            
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                if (deck_page.get_isLoggedOff() == false && loginPage1.Visible == false)
                {
                    if (loginPage1.get_UserID() == id)
                    {
                        lblUserName.Text = "  Logged user: " + reader.GetString(1);
                        deck_page.set_username(reader.GetString(1));
                        deck_page.set_UserID(this.get_UserID());
                    }
                }
            }
            if (deck_page.get_isLoggedOff() == true)
            {
                lblUserName.Text = "Logged user: -";    
            }
            myDatabase.Close();

        }
        private void check_for_user_login()
        {
            if (deck_page.get_isLoggedOff() == true) //if logged off
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(loginPage1);
                deck_page.set_isLoggedOff(false);
                loginPage1.Show();
            }
        }

    }
}
