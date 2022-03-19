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
    public partial class input_box_form : Form
    {
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
            OleDbConnection myDatabase = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source= C:\Users\erknn\Desktop\deneme proje\clone\anki.accdb");
            OleDbCommand cmd = myDatabase.CreateCommand();
            myDatabase.Open();

            var schema = myDatabase.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            if (schema.Rows.OfType<DataRow>().Any(r => r.ItemArray[2].ToString().ToLower() == boxInput.Text))
            {
                MessageBox.Show("Deck already exists!");
                myDatabase.Close();//table exists
            }
            else
            {
                try
                {//if doesn't exist, create table
                    string strTemp = " [Front_Face] Text, [Back_Face] Text, [FRONT_LANG] Text, [BACK_LANG] Text ";
                    OleDbCommand myCommand = new OleDbCommand();
                    myCommand.Connection = myDatabase;
                    myCommand.CommandText = "CREATE TABLE " + boxInput.Text + "(" + strTemp + ")";
                    myCommand.ExecuteNonQuery();
                    string space = "";
                    myCommand.CommandText = "INSERT INTO " + boxInput.Text + "([Front_Face], [Back_Face], [FRONT_LANG], [BACK_LANG]) VALUES ('" + space + "' , '" + space + "','" + space + "','" + space + "')";
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
