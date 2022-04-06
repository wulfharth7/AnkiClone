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
    public partial class add_edit_cards : UserControl
    {
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        private static string connectionstring = "Server=LAPTOP-BEQ4MFN7\\ANKICLONE; database =AnkiClone;MultipleActiveResultSets=true; Integrated Security=SSPI;";
        SqlConnection myDatabase = new SqlConnection(connectionstring);
        private string table_name;
        public string get_tablename()
        {
            return table_name;
        }
        public void set_tablename(string table)
        {
            table_name = table;
        }
        public add_edit_cards()
        {
            InitializeComponent();
        }

        private void btn_add_card_Click(object sender, EventArgs e)
        {
            
            if(txtBox_term.Text == "" || txtBox_definition.Text == "")
            {
                lbl_Error_text.Text = "You have to enter both cards!";
            }
            else
            {
                if(check_if_first_card() == true)
                {
                    update_table();
                    UpdateStatus();
                }
                else
                {
                    insert_table();
                    UpdateStatus();
                }
                this.Dispose();
            }
            
        }
        private bool check_if_first_card()
        {
            myDatabase.Open();
            SqlCommand readCommand = new SqlCommand("SELECT * from "+ this.get_tablename(), myDatabase); //why select * but not select username
            SqlDataReader reader = readCommand.ExecuteReader();

            string nick;
            if (reader.Read())
            { 
                nick = reader.GetString(1);
                //MessageBox.Show(nick);
                if (nick == "")
                {
                    myDatabase.Close();
                    return true;
                }
                else
                {
                    myDatabase.Close();
                    return false;
                }
            }
            else
            {
                myDatabase.Close();
                return true;
            }
            
        }
        private void update_table()
        {
            myDatabase.Open();
            SqlCommand myCMD = new SqlCommand();
            myCMD.Connection = myDatabase;
            myCMD.CommandText = "Update "+ this.get_tablename()+ " SET [Front_Face]= @name ,[Back_Face]= @pass";
            myCMD.Parameters.Clear();
            myCMD.Parameters.AddWithValue("@name", txtBox_term.Text);
            myCMD.Parameters.AddWithValue("@pass", txtBox_definition.Text);
            myCMD.ExecuteNonQuery();
            lbl_Error_text.Text = "";
            myDatabase.Close();
        }
        private void insert_table()
        {
            myDatabase.Open();
            SqlCommand myCMD = new SqlCommand();  
            myCMD.CommandText = "INSERT into " + this.get_tablename() + " ([Front_Face],[Back_Face]) VALUES (@name,@pass)";
            myCMD.Parameters.Clear();
            myCMD.Connection = myDatabase;
            myCMD.Parameters.AddWithValue("@Name", txtBox_term.Text);
            myCMD.Parameters.AddWithValue("@pass", txtBox_definition.Text);
            lbl_Error_text.Text = "";
            myCMD.ExecuteNonQuery();
            myDatabase.Close();
        }

        private void btnDeleteControl_Click(object sender, EventArgs e)
        {
            move_controls_upwards();
            this.Dispose();
        }

        private void move_controls_upwards()
        {
            foreach (Control c in this.Parent.Controls)
            {
                if ((c is GroupBox || c is edit_cards || c is add_edit_cards) && c.Bounds.Top > this.Bounds.Top)
                {
                    c.Top -= 100;
                }
            }
        }
        private void UpdateStatus()
        {
            //Create arguments.  You should also have custom one, or else return EventArgs.Empty();
            EventArgs args = new EventArgs();

            //Call any listeners
            OnUpdateStatus?.Invoke(this, args);
        }
    }
}
