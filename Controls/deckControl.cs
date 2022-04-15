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
using Microsoft.VisualBasic;


namespace clone
{
    public partial class deckControl : UserControl
    {
        private static string connectionstring = "Server=LAPTOP-BEQ4MFN7\\ANKICLONE; database =AnkiClone;MultipleActiveResultSets=true; Integrated Security=SSPI;";
        SqlConnection myDatabase = new SqlConnection(connectionstring);
        Deck_User Deck_Owner = new Deck_User();
        List<String> table_list = new List<string>();

        private int userID = 0;
        public int get_UserID()
        {
            return userID;
        }
        public void set_UserID(int variable)
        {
            userID = variable;
        }
        private string username;
        public string get_username()
        {
            return username;
        }
        public void set_username(string variable)
        {
            username = variable;
        }

        private bool isLoggedOff;
        public bool get_isLoggedOff()
        {
            return isLoggedOff;
        }
        public void set_isLoggedOff(bool variable)
        {
            isLoggedOff = variable;
        }

        public deckControl()
        {
            InitializeComponent();
        }

        private void deckControl_Load(object sender, EventArgs e)
        {
            set_user_variables();
        }

        private void btnCreateDeck_Click(object sender, EventArgs e)
        {
            input_box_form create_deck_name_box = new input_box_form(this.get_UserID());
            create_deck_name_box.Show();
            //TO DO : BOSLUKLU DECK NAME VERIRSE HATA VERIYOR, EGER DECK'TE BOSLUK VARSA _ ILE DEGISTIRMESINI SAGLA.... TO DO
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<Control> to_beDisposed = new List<Control>();
            foreach (Control c in this.Controls)
            {
                if (c is LinkLabel || c is Label)
                {
                    if (c.Bounds.Top > label1.Bounds.Top)
                    {
                        to_beDisposed.Add(c);
                    }
                }
            }
            for(var i = 0; i < to_beDisposed.Count; i++)
            {
                if (to_beDisposed[i].Text != lblNoDeck.Text)
                {
                    to_beDisposed[i].Dispose();
                }
            }
            this.set_isLoggedOff(true);
            Deck_Owner.users_decks.Clear();
            lblNoDeck.Text = "Click deck names to start flashcard modes or to edit/add cards!";
            lblNoDeck.Visible = true;
            lblNoDeck.Location = new Point(114, 35);
            table_list.Clear();
            //this.Hide();
        }
        private void set_user_variables()
        {
            Deck_Owner.set_nickname(username);
            set_deck_names(myDatabase);
        }
        private async void set_deck_names(SqlConnection myDatabase)
        {
            myDatabase.Open();
            lblNoDeck.Text = "                                      Loading...Please wait...";
            await Task.Run(() =>
            {
                var selectNames = get_table_names(myDatabase);  //freeze here -used to at least, async here now :D-
                foreach (DataRow item in selectNames.Rows)     //this foreach makes it freeze -used to at least, async here now :D-
                {
                    if (check_for_user_id(Convert.ToString(item["TABLE_NAME"])) == Convert.ToString(this.get_UserID()))
                    {
                        if (Deck_Owner.users_decks.Contains(Convert.ToString(item["TABLE_NAME"])) == false)
                        {
                            if (Convert.ToString(item["TABLE_NAME"]) != "users")
                            {
                                Deck_Owner.users_decks.Add((Convert.ToString(item["TABLE_NAME"])));
                            }
                        }
                    }
                }
            });
            if (Deck_Owner.users_decks.Count() == 0)
            {
                lblNoDeck.Text = "              You haven't created decks yet! Create some to start.";
                myDatabase.Close();
            }
            else
            {
                myDatabase.Close();
                create_Dynamic_label_Texts();
            }
            
        }
        private void btnRefreshDecks_Click(object sender, EventArgs e)
        {  
            set_user_variables();
        }
        private void create_Dynamic_label_Texts()
        {
            int x = 130;
            int y = 35;
            foreach (var deck in Deck_Owner.users_decks)
            {
                if (table_list.Contains(deck) == false)
                {
                    LinkLabel deck_1 = new LinkLabel();
                    deck_1.Text = " " + deck;
                    deck_1.LinkBehavior = LinkBehavior.NeverUnderline;
                    deck_1.LinkVisited = false;
                    deck_1.AutoSize = false;
                    deck_1.BackColor = Color.LightGray;
                    deck_1.LinkColor = Color.Black;
                    deck_1.Location = new Point(x, y);
                    deck_1.Size = new Size(270, 20);
                    deck_1.LinkClicked += (s, e) =>
                    {
                        flashcards flashcard = new flashcards();
                        flashcard.set_deckname(deck_1.Text);
                        Controls.Add(flashcard);
                        foreach (Control c in this.Controls)
                        {
                            c.Visible = false;
                        }
                        flashcard.Show();
                    };
                    Controls.Add(deck_1);
                    table_list.Clear();
                    get_list_of_created_table_labels();
                    y = y + 24;
                    additional_settings_for_dynamic_deck_texts(x, y, deck);
                }
            }
        }
        private void card_count_from_deck(int y_position, string table)
        {
            //open the database and count the cards
            Label lblCount = new Label();
            lblCount.Location = new Point(379, y_position - 20);
            lblCount.Text = Convert.ToString(get_card_count(table));
            lblCount.ForeColor = Color.Green;
            lblCount.BackColor = Color.LightGray;
            lblCount.AutoSize = true;
            Controls.Add(lblCount);
            lblCount.Show();
            lblCount.BringToFront();
        }
        private DataTable get_table_names(SqlConnection myDatabase)
        {
            DataTable table = myDatabase.GetSchema("Tables");
            return table;
        }
        private void get_list_of_created_table_labels()
        {
            foreach (Control c in Controls)
            {
                Label label = c as Label;
                if (label != null)
                {
                    if (table_list.Contains(label.Text) == false)
                    {
                        table_list.Add(label.Text);
                    }
                }
            }
        }
        private int get_card_count(string table)
        {
            myDatabase.Open();
            string sql = "select  count(*) FROM " + table + "";
            SqlCommand cmd = new SqlCommand(sql, myDatabase);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            myDatabase.Close();
            return count; //no clue why but it'll give one point lesser, hence ++
        }
        private string check_for_user_id(string tablename)
        {
            string sql = "select * from " + tablename +" ";
            SqlCommand cmd = new SqlCommand(sql, myDatabase);
            SqlDataReader reader = cmd.ExecuteReader();
            int id =0;
            if (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            return Convert.ToString(id);
        }
        private void delete_deck_label_add(int y, string table_name)
        {
            LinkLabel lblDelete = new LinkLabel();
            lblDelete.Text = "X";
            lblDelete.LinkColor = Color.OrangeRed;
            lblDelete.LinkBehavior = LinkBehavior.NeverUnderline;
            lblDelete.LinkVisited = false;
            lblDelete.AutoSize = false;
            lblDelete.BackColor = Color.LightGray;
            lblDelete.Location = new Point(365, y-20);
            lblDelete.AutoSize = true;
            Controls.Add(lblDelete);
            lblDelete.Show();
            lblDelete.BringToFront();
            lblDelete.LinkClicked += (s, e) =>
            {
                DialogResult dialogresult = MessageBox.Show("Are you sure you want to delete the deck?", "Important!", MessageBoxButtons.YesNo);
                if(dialogresult == DialogResult.Yes)
                {
                    myDatabase.Open();
                    SqlCommand cmd = new SqlCommand("DROP TABLE IF EXISTS "+table_name, myDatabase);
                    cmd.ExecuteNonQuery();
                    myDatabase.Close();
                    Deck_Owner.users_decks.Remove(table_name);
                    List<Control> to_be_disposed = new List<Control>();
                    foreach(Control c in this.Controls)
                    {
                        if (c.Bounds.Top == lblDelete.Bounds.Top || c.Bounds.Top == lblDelete.Bounds.Top - 4) 
                        {
                            to_be_disposed.Add(c);
                        }
                        else if((c is Label || c is LinkLabel) && c.Bounds.Top > lblDelete.Bounds.Top)
                        {
                            c.Top -= 24;   
                        }
                    }
                    for(var i = 0; i < to_be_disposed.Count; i++)
                    {
                        to_be_disposed[i].Dispose();
                    }
                }
                else
                {

                }
            };
        }
        private void additional_settings_for_dynamic_deck_texts(int x, int y, string deck)
        {
            if (Deck_Owner.users_decks.Count != 0)
                lblNoDeck.Text = "Click deck names to start flashcard modes or to edit/add cards!";
            else
                lblNoDeck.Text = "         You haven't created decks yet! Create some to start.";
            lblNoDeck.Location = new Point(x - 15, y + 5);
            card_count_from_deck(y, deck);
            delete_deck_label_add(y, deck);
        }
        
    }
}
