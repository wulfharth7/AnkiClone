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
    public partial class edit_cards : UserControl
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
        private string front_face, back_face;
        public void set_frontface(string variable)
        {
            front_face = variable;
        }
        public void set_backface(string variable)
        {
            back_face = variable;
        }
        public string get_face(string name)
        {
            if(name == "front")
            {
                return front_face;
            }
            else if(name== "back")
            {
                return back_face;
            }
            else
            {
                return "you donged it up";
            }
        }
        public edit_cards(string front_face, string back_face)
        {
            InitializeComponent();
            set_backface(back_face);
            set_frontface(front_face);
            txtBox_term.Text = get_face("front");
            txtBox_definition.Text = get_face("back");
        }

        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            //ADD HERE A COUNT THING AND IF IT IS ONLY ONE 1 LEFT, UPDATE TO SPACE OTHERWISE IT'LL CRASH TO THE DEATH
            string command = "DELETE FROM " + this.get_tablename() + " WHERE [Front_Face]= @new_face and [Back_Face]= @new_back";
            SqlCommand cmd = new SqlCommand(command, myDatabase);
            cmd.Parameters.Clear();
            myDatabase.Open(); 
            cmd.Parameters.AddWithValue("@new_face", txtBox_term.Text);
            cmd.Parameters.AddWithValue("@new_back", txtBox_definition.Text);
            cmd.ExecuteNonQuery();
            myDatabase.Close();
            move_controls_upwards();
            //UpdateStatus();
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e) //edit_button
        {
            string command = "Update " + this.get_tablename() + " SET [Front_Face]= @new_face ,[Back_Face]= @new_back WHERE [Front_Face]= @prev_face and [Back_Face]= @prev_back";
            SqlCommand cmd = new SqlCommand(command,myDatabase);
            myDatabase.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@new_face", txtBox_term.Text);
            cmd.Parameters.AddWithValue("@new_back", txtBox_definition.Text);
            cmd.Parameters.AddWithValue("@prev_face", this.get_face("front"));
            cmd.Parameters.AddWithValue("@prev_back", this.get_face("back"));
            cmd.ExecuteNonQuery();
            myDatabase.Close();
            UpdateStatus();
        }
        private void move_controls_upwards()
        {
            foreach (Control c in this.Parent.Controls)
            {
                if ((c is GroupBox || c is edit_cards || c is add_edit_cards ) && c.Bounds.Top > this.Bounds.Top)
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
