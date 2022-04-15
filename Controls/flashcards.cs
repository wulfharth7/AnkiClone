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
using System.IO;

namespace clone
{
    public partial class flashcards : UserControl
    {
        private static string connectionstring = "Server=LAPTOP-BEQ4MFN7\\ANKICLONE; database =AnkiClone;MultipleActiveResultSets=true; Integrated Security=SSPI;";
        SqlConnection myDatabase = new SqlConnection(connectionstring);
        LinkedList<Decks> deck_linked_list = new LinkedList<Decks>();
        public string path = "uninited_path"; //make it private

        private int deck_count = 0;
        public int card_index_in_linkedlist = 1;
        public int get_count()
        {
            return deck_count;
        }
        public void set_count(int variable)
        {
            deck_count = variable;
        }
        private string deck_name;
        public string get_deckname()
        {
            return deck_name;
        }
        public void set_deckname(string variable)
        {
            deck_name = variable;
        }
        public flashcards()
        {
            InitializeComponent();
        }

        private void btn_study_Click(object sender, EventArgs e) //test button
        {
            
        }

        private void button2_Click(object sender, EventArgs e) //flashcard study button
        {
            //when this code was under the btn_study_click event function, there was a bug happening about visibility of the controls hence i changed the code to another event function
            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            study_flashcards study_Flashcards = new study_flashcards(deck_linked_list);
            Controls.Add(study_Flashcards);
        }

        private void flashcards_Load(object sender, EventArgs e)
        {
            lblDeckname.Text = this.get_deckname();
            read_cards();
            set_scroolbar();
        }
        private void read_cards()
        {

            myDatabase.Open();
            string readingCommand = "SELECT * FROM " + this.get_deckname() + "";
            SqlCommand readCommand = new SqlCommand(readingCommand, myDatabase); //why select * but not select username
            SqlDataReader reader = readCommand.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetString(1) == "") //if no card exists
                {
                    design_shown_cards(); //will set to 0/0, overloaded function
                    break;
                }
                else
                {
                    Decks flashcard = new Decks();
                    get_cards_to_LinkedList(reader, flashcard); // will keep the cards to be shown in a linked list by reading from the DB
                    design_shown_cards(1);
                }
            }

            //cards do exist
            myDatabase.Close();

        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (Control c in this.Parent.Controls)
            {
                if (c is flashcards)
                {
                    c.Visible = false;
                }
                else
                {   
                    c.Visible = true;
                }
            }
            this.Hide();
        }
        private void set_scroolbar()
        {
            this.AutoScroll = false;
            this.HorizontalScroll.Enabled = false;
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Maximum = 0;
            this.AutoScroll = true;
        }
        private void get_cards_to_LinkedList(SqlDataReader reader, Decks flashcard)
        {
            flashcard.set_deckname(this.get_deckname());
            flashcard.setFront_Face(reader.GetString(1));
            flashcard.setBack_Face(reader.GetString(2));
            if (deck_linked_list.Contains(flashcard) == false)
            {
                if (deck_linked_list.Count() == 0)
                {
                    deck_linked_list.AddFirst(flashcard);
                    creating_box_for_cards_to_edit(reader, ref flashcard, deck_linked_list);
                }
                else
                {
                    deck_linked_list.AddLast(flashcard);
                    creating_box_for_cards_to_edit(reader, ref flashcard, deck_linked_list);
                }
            }
        }
        private void design_shown_cards()
        {
            card_index_in_linkedlist--;
            lblCardCount.Text = Convert.ToString(card_index_in_linkedlist) + "/" + deck_linked_list.Count();
            lblCards.Text = "You haven't added cards...yet!";
        }
        private void design_shown_cards(int cards_do_exist)
        {
            lblCardCount.Text = Convert.ToString(card_index_in_linkedlist) + "/" + deck_linked_list.Count();
            lblCards.Text = deck_linked_list.First.Value.getFront_Face();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            show_other_face_of_card();
        }

        private void lblCards_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            show_other_face_of_card();
        }
        private void show_other_face_of_card()
        {
            foreach (var item in deck_linked_list)
            {
                if (lblCards.Text == item.getBack_Face())
                {
                    lblCards.Text = item.getFront_Face();
                    break;
                }
                if (lblCards.Text == item.getFront_Face())
                {
                    lblCards.Text = item.getBack_Face();
                    break;
                }
            }
        }

        private void show_next_card_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (card_index_in_linkedlist != deck_linked_list.Count())
            {
                card_index_in_linkedlist++;
                lblCardCount.Text = Convert.ToString(card_index_in_linkedlist) + "/" + deck_linked_list.Count();

                if (lblCards.Text != deck_linked_list.First.Value.getFront_Face() || lblCards.Text != deck_linked_list.First.Value.getBack_Face())
                {
                    string smth = "uninitialized_string";
                    foreach (var item in deck_linked_list)
                    {
                        if (lblCards.Text == deck_linked_list.Find(item).Value.getFront_Face() || lblCards.Text == deck_linked_list.Find(item).Value.getBack_Face())
                        {
                            var stmh = deck_linked_list.Find(item).Next.Value.getFront_Face();
                            smth = stmh;
                        }
                    }
                    lblCards.Text = smth;//try this with a break clause
                }
            }
        }

        private void show_previous_card_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (card_index_in_linkedlist != 1 && card_index_in_linkedlist != 0)
            {
                card_index_in_linkedlist--;
                lblCardCount.Text = Convert.ToString(card_index_in_linkedlist) + "/" + deck_linked_list.Count();

                if (lblCards.Text != deck_linked_list.First.Value.getFront_Face() || lblCards.Text != deck_linked_list.First.Value.getBack_Face())
                {
                    string smth = "uninitialized_string";
                    foreach (var item in deck_linked_list)
                    {
                        if (lblCards.Text == deck_linked_list.Find(item).Value.getFront_Face() || lblCards.Text == deck_linked_list.Find(item).Value.getBack_Face())
                        {
                            var stmh = deck_linked_list.Find(item).Previous.Value.getFront_Face();
                            smth = stmh;
                        }
                    }
                    lblCards.Text = smth;
                }
            }
        }

        private void btn_add_cards_Click(object sender, EventArgs e)
        {
            creating_box_for_cards_to_add();
            move_card_controls_box();
        }
        private void creating_box_for_cards_to_add()
        {
            add_edit_cards group_box_add_cards = new add_edit_cards(deck_linked_list);
            group_box_add_cards.OnUpdateStatus += group_box_add_cards_OnUpdateStatus;
            group_box_add_cards.Location = new Point(group_box_card_controls.Location.X, group_box_card_controls.Location.Y);
            group_box_add_cards.set_tablename(deck_name);
            Controls.Add(group_box_add_cards);
        }

        private void creating_box_for_cards_to_edit(SqlDataReader reader, ref Decks flashcard, LinkedList<Decks> linkedlistdeck)
        {
            edit_cards group_box_edit_cards = new edit_cards(ref flashcard, linkedlistdeck);
            group_box_edit_cards.OnUpdateStatus += group_box_edit_cards_OnUpdateStatus;
            group_box_edit_cards.Location = new Point(group_box_card_controls.Location.X, group_box_card_controls.Location.Y);
            Controls.Add(group_box_edit_cards);
            move_card_controls_box();
        }
        private void move_card_controls_box()
        {
            group_box_card_controls.Location = new Point(group_box_card_controls.Location.X, group_box_card_controls.Location.Y + 100);
        }
        private void group_box_add_cards_OnUpdateStatus(object sender, EventArgs e)
        {
            card_index_in_linkedlist = 1;
            design_shown_cards(1);
        }
        private void group_box_edit_cards_OnUpdateStatus(object sender, EventArgs e)
        {
            card_index_in_linkedlist = 1;
            design_shown_cards(1);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (myPanel.Visible == true)
            {
                if (keyData == Keys.Right)
                {
                    ((IButtonControl)show_next_card).PerformClick();
                    return true;
                }
                else if (keyData == Keys.Left)
                {
                    ((IButtonControl)show_previous_card).PerformClick();
                    return true;
                }
                else if (keyData == Keys.Up)
                {
                    show_other_face_of_card();
                    return true;
                }
                else if (keyData == Keys.Down)
                {
                    show_other_face_of_card();
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void btnExprtFile_Click(object sender, EventArgs e)
        {
            check_textfile_for_deck();
            write_decks_into_text_file();
        }
        private void check_textfile_for_deck()
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // gets to the project folder
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "\\" + lblDeckname.Text.TrimStart() + ".txt";
            path = projectDirectory;

            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path); //creates the text file
                sw.Close();
            }
            else
            {
                File.Create(path).Close(); //clears the text file
            }
        }
        private void write_decks_into_text_file()
        {
            myDatabase.Open();
            string readingCommand = "SELECT * FROM " + this.get_deckname() + "";
            SqlCommand readCommand = new SqlCommand(readingCommand, myDatabase); //why select * but not select username
            SqlDataReader reader = readCommand.ExecuteReader();
            StreamWriter outputFile = new StreamWriter(path,append: true);
            while (reader.Read())
            {
                outputFile.WriteLine(reader.GetString(1)+"\t\t"+reader.GetString(2));
            }

            outputFile.Close();
            myDatabase.Close();
        }
    }
}
