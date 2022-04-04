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
            Deck_Owner.set_nickname(username);
            set_user_variables();
            create_Dynamic_label_Texts();
        }

        private void btnCreateDeck_Click(object sender, EventArgs e)
        {
            input_box_form create_deck_name_box = new input_box_form();
            create_deck_name_box.Show();
            //TO DO : BOSLUKLU DECK NAME VERIRSE HATA VERIYOR, EGER DECK'TE BOSLUK VARSA _ ILE DEGISTIRMESINI SAGLA.... TO DO
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.set_isLoggedOff(true);
            //this.Hide();

        }
        private void set_user_variables()
        {
            SqlCommand cmd = myDatabase.CreateCommand();
            set_deck_names(myDatabase, cmd);
        }
        private void set_deck_names(SqlConnection myDatabase, SqlCommand mycmd)
        {
            myDatabase.Open();
            var selectNames = get_table_names(myDatabase);
            foreach (var item in selectNames)
            {
                if (Deck_Owner.users_decks.Contains(Convert.ToString(item["TABLE_NAME"])) == false)
                {
                    if (Convert.ToString(item["TABLE_NAME"]) != "users")
                    {
                        Deck_Owner.users_decks.Add((Convert.ToString(item["TABLE_NAME"])));
                    }
                    else
                    {
                        lblNoDeck.Text = "              You haven't created decks yet! Create some to start.";
                    }
                }
            }
            myDatabase.Close();
        }
        private void btnRefreshDecks_Click(object sender, EventArgs e)
        {
            set_user_variables();
            create_Dynamic_label_Texts();
        }
        private void create_Dynamic_label_Texts()
        {//you keep creating same labels, be careful and tidy this place up!

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
                    flashcards flashcard = new flashcards();
                    flashcard.set_deckname(deck_1.Text);
                    deck_1.LinkClicked += (s, e) =>
                    {
                        Controls.Add(flashcard);
                        flashcard.Hide();
                        foreach (Control c in this.Controls)
                        {
                            c.Visible = false;
                        }
                        flashcard.Show();
                    };
                    Controls.Add(deck_1);
                    deck_1.Show();
                    get_list_of_created_table_labels();
                    y = y + 24;
                    lblNoDeck.Text = "Click deck names to start flashcard modes or to edit/add cards!";
                    lblNoDeck.Location = new Point(x - 15, y + 5);
                    card_count_from_deck(y, deck);
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

        private DataRow[] get_table_names(SqlConnection myDatabase)
        {
            DataTable table = myDatabase.GetSchema("Tables");
            DataRow[] rows = table.Select();
            return rows;
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
            int count = Convert.ToInt32(cmd.ExecuteNonQuery());
            myDatabase.Close();
            return ++count; //no clue why but it'll give one point lesser, hence ++

        }
    }
}
