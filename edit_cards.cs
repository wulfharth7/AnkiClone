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

     
        private Decks temp;
        private LinkedList<Decks> temp_llist;
        public edit_cards(ref Decks flashcard, LinkedList<Decks> linkedlistdeck)
        {
            InitializeComponent();
            temp_llist = linkedlistdeck;
            fill_text_boxes(ref flashcard);
            temp = flashcard;
            
        }

        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            //ADD HERE A COUNT THING AND IF IT IS ONLY ONE 1 LEFT, UPDATE TO SPACE OTHERWISE IT'LL CRASH TO THE DEATH
            string command = "DELETE FROM " + temp.get_deckname() + " WHERE [Front_Face]= @new_face and [Back_Face]= @new_back";
            SqlCommand cmd = new SqlCommand(command, myDatabase);
            cmd.Parameters.Clear();
            myDatabase.Open(); 
            cmd.Parameters.AddWithValue("@new_face", txtBox_term.Text);
            cmd.Parameters.AddWithValue("@new_back", txtBox_definition.Text);
            cmd.ExecuteNonQuery();
            myDatabase.Close();
            move_controls_upwards();
            temp_llist.Remove(temp);
            UpdateStatus();
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e) //edit_button
        {
            MessageBox.Show(temp.getFront_Face());
            string command = "Update " + temp.get_deckname() + " SET [Front_Face]= @new_face ,[Back_Face]= @new_back WHERE [Front_Face]= @prev_face and [Back_Face]= @prev_back";
            SqlCommand cmd = new SqlCommand(command,myDatabase);
            myDatabase.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@new_face", txtBox_term.Text);
            cmd.Parameters.AddWithValue("@new_back", txtBox_definition.Text);
            cmd.Parameters.AddWithValue("@prev_face", temp.getFront_Face());//bug is here
            cmd.Parameters.AddWithValue("@prev_back", temp.getBack_Face());//bug is here
            temp.setFront_Face(txtBox_term.Text);
            temp.setBack_Face(txtBox_definition.Text);
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
        private void fill_text_boxes( ref Decks flashcard)
        {
            txtBox_term.Text = flashcard.getFront_Face();
            txtBox_definition.Text = flashcard.getBack_Face();
        }

    }
}
