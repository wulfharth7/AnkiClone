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
    public partial class input_box_form : Form
    {
        private static string connectionstring = "Server=LAPTOP-BEQ4MFN7\\ANKICLONE; database =AnkiClone;MultipleActiveResultSets=true; Integrated Security=SSPI;";
        SqlConnection myDatabase = new SqlConnection(connectionstring);
        public input_box_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//cancel button
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            database_settings_for_decks();
            this.Dispose();
        }
        private void database_settings_for_decks()
        {
            
            SqlCommand cmd = myDatabase.CreateCommand();
            myDatabase.Open();
            DataTable table = myDatabase.GetSchema("Tables");
            if (table.Rows.Contains(boxInput))
            {
                MessageBox.Show("Deck already exists!");
                myDatabase.Close();//table exists
            }
            else
            {
                try
                {//if doesn't exist, create table
                    SqlCommand myCommand = new SqlCommand("create table users (UserID int NOT NULL    IDENTITY    PRIMARY KEY,[Front_Face] varchar(50),[Back_Face] varchar(50),[FRONT_LANG] varchar(50),[BACK_LANG] varchar(50));", myDatabase);
                    myCommand.Connection = myDatabase;
                    myCommand.ExecuteNonQuery();
                    string space = "";
                    myCommand.CommandText = "INSERT INTO dbo.@1 ([Front_Face], [Back_Face], [FRONT_LANG], [BACK_LANG]) VALUES (@2,@3,@4,@5)";
                    myCommand.Parameters.AddWithValue("@1", boxInput); 
                    myCommand.Parameters.AddWithValue("@2", space); myCommand.Parameters.AddWithValue("@3", space);
                    myCommand.Parameters.AddWithValue("@4", space); myCommand.Parameters.AddWithValue("@5", space);
                    myCommand.ExecuteNonQuery();
                    myDatabase.Close();
                    //if doesn't exist, create table
                }
                catch
                {
                    MessageBox.Show("Deck name has to be written!");
                }
            }

        }
    }
}
