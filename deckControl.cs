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
using Microsoft.VisualBasic;


namespace clone
{
    public partial class deckControl : UserControl
    {
        Deck_User Deck_Owner = new Deck_User();

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

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.set_isLoggedOff(true);
        }
        private void set_user_variables()
        {
            OleDbConnection myDatabase = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source= C:\Users\erknn\Desktop\deneme proje\clone\anki.accdb");
            OleDbCommand cmd = myDatabase.CreateCommand();
            set_deck_names(myDatabase, cmd);
        }
        private void set_deck_names(OleDbConnection myDatabase, OleDbCommand mycmd)
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
                        lblNoDeck.Dispose();
                    }
                    else
                    {
                        lblNoDeck.Text = "You haven't created decks yet! Create some to start.";
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
        {
            try
            {
                int x = 130;
                int y = 35;
                foreach (var deck in Deck_Owner.users_decks)
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
                    Controls.Add(deck_1);
                    deck_1.Show();
                    deck_1.BringToFront();
                    y = y + 24;
                }
            }
            catch
            {
                lblNoDeck.Text = "You haven't created decks yet! Create some to start.";
            }

        }
        private DataRow[] get_table_names(OleDbConnection myDatabase)
        {
            DataTable dt = myDatabase.GetSchema("Tables");
            return dt.Rows.Cast<DataRow>().Where(c => !c["TABLE_NAME"].ToString().Contains("MSys")).ToArray();
        }
    }
}
