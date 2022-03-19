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
            MessageBox.Show(Deck_Owner.get_nickname());

        }

        private void btnCreateDeck_Click(object sender, EventArgs e)
        {
            input_box_form deck_name = new input_box_form();
            
            deck_name.Show();

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

        }

    }
}
