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

    public partial class Form1 : Form
    {
        deckControl deck_page = new deckControl();
        LoginPage loginPage1 = new LoginPage();
        
        public Form1()
        {
            InitializeComponent();
            timer_settings();
            user_database_settings();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(loginPage1);
            panel1.Controls.Add(deck_page);
            
        }

        private void Decks_Button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loginPage1.Visible == false)
            {
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
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = "Date: " + DateTime.Now.ToString();
            set_user_name_label();
            check_for_user_login();
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
            try { 
            OleDbConnection myDatabase = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source= C:\Users\erknn\Desktop\deneme proje\clone\anki.accdb");
            OleDbCommand cmd = myDatabase.CreateCommand();
            myDatabase.Open();
            
            var schema = myDatabase.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            if (schema.Rows.OfType<DataRow>().Any(r => r.ItemArray[2].ToString().ToLower() == "users"))
            {
                myDatabase.Close();//table exists
            }
            else
            {
                //if doesn't exist, create table
                string strTemp = "UserID AUTOINCREMENT PRIMARY KEY, [Username] Text, [Password] Text ";
                OleDbCommand myCommand = new OleDbCommand();
                myCommand.Connection = myDatabase;

                myCommand.CommandText = "CREATE TABLE users(" + strTemp + ")";
                myCommand.ExecuteNonQuery();
                string space = "";
               // myCommand.CommandText = "INSERT INTO users([Username], [Password]) VALUES ('" + space + "' , '" + space + "')";
                    myCommand.CommandText= "INSERT INTO users([Username], [Password]) VALUES(@Username, @Password)";
                    myCommand.Parameters.AddWithValue("@Name", space);
                    myCommand.Parameters.AddWithValue("@Password", space);
                    myCommand.ExecuteNonQuery();
                myDatabase.Close();
                //if doesn't exist, create table
            }
            }
            catch
            {
                //create .accdb
            }
        } //creates a table if doesn't exist at the beginning of the program for users.
        private void set_user_name_label()
        {
            OleDbConnection myDatabase = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source= C:\Users\erknn\Desktop\deneme proje\clone\anki.accdb");
            OleDbCommand cmd = myDatabase.CreateCommand();
            myDatabase.Open();
            OleDbCommand readCommand = new OleDbCommand("SELECT * from  users ", myDatabase); //why select * but not select username, whats foreach
            OleDbDataReader reader = readCommand.ExecuteReader();

            if (reader.Read() && deck_page.get_isLoggedOff() == false && loginPage1.Visible==false)
            {
                lblUserName.Text = "  Logged user: " + reader.GetString(1);
                deck_page.set_username(reader.GetString(1));
                
            }
            if( deck_page.get_isLoggedOff()==true)
            {
                lblUserName.Text = "  Logged user: -";
            }
            myDatabase.Close();
        }
        private void check_for_user_login() {
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
