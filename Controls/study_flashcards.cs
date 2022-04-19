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
    public partial class study_flashcards : UserControl
    {
        LinkedList<Decks> decks_to_be_shown_again = new LinkedList<Decks>();
        LinkedList<Decks> shuffled_deck_linkedlist = new LinkedList<Decks>();
        LinkedList<Decks> non_shuffled_linkedlist = new LinkedList<Decks>();
        LinkedList<Decks> linkedlistdeck = new LinkedList<Decks>();

        public int card_index = 0;
        public int card_correct = 0;
        public int card_repeat = 0;

        public study_flashcards(LinkedList<Decks> decklinkedlist)
        {
            InitializeComponent();
            btnStudyAgain.Hide();
            if (decklinkedlist.Count() != 0)
            {
                card_index = 1;
                start_study(decklinkedlist);
                set_label_infos(decklinkedlist);
                progressBar.Maximum = decklinkedlist.Count();
                progressBar.Minimum = 0;
                progressBar.Step = 1;
            }
            //starred deck...add it
        }
        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            foreach (Control c in this.Parent.Controls)
            {
                c.Visible = true;
            }
            this.Dispose();
        }

        private void start_study(LinkedList<Decks> decklinkedlist)
        {
            foreach (var item in decklinkedlist)
            {
                linkedlistdeck.AddLast(item);
            }
            lblCards.Text = linkedlistdeck.First.Value.getFront_Face();
            foreach (var item in linkedlistdeck)
            {
                non_shuffled_linkedlist.AddLast(item);
            }
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            button_great_or_again_click("again");
            progressBar.PerformStep();
        }

        private void btnGreat_Click(object sender, EventArgs e)
        {
            button_great_or_again_click();
            progressBar.PerformStep();
            
        }
        private void set_label_infos(LinkedList<Decks> decklinkedlist)
        {
            if (linkedlistdeck.Count() != 0)
            {
                lblCardCorrect.Text = "Correct: " + Convert.ToString(card_correct);
                lblCardRepeat.Text = "Repeat: " + Convert.ToString(card_repeat);
                lblCardProgress.Text = Convert.ToString(card_index) + "/" + Convert.ToString(decklinkedlist.Count());
                lblCardOutOf.Text = "Card: " + Convert.ToString(card_index) + " out of " + Convert.ToString(decklinkedlist.Count()); 
            }
            //add a snap of code here to make it full, if the deck is empty.also implement the change of code
        }
        private void lblCards_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            show_other_face_of_card();
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            show_other_face_of_card();
        }
        private void show_other_face_of_card()
        {
            foreach (var item in linkedlistdeck)
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
        private void change_shown_card()
        {
            string smth = "uninitialized_string";
            foreach (var item in linkedlistdeck)
            {
                if (lblCards.Text == linkedlistdeck.Find(item).Value.getFront_Face() || lblCards.Text == linkedlistdeck.Find(item).Value.getBack_Face())
                {
                    var stmh = linkedlistdeck.Find(item).Next.Value.getFront_Face();
                    smth = stmh;
                }
            }
            lblCards.Text = smth; //try this with a break clause
        }
        private void add_to_repeated_llist()
        {
            foreach (var item in linkedlistdeck)
            {
                if (lblCards.Text == linkedlistdeck.Find(item).Value.getFront_Face() || lblCards.Text == linkedlistdeck.Find(item).Value.getBack_Face())
                {
                    decks_to_be_shown_again.AddLast(item);
                }
            }

        }
        private void button_great_or_again_click(string again)
        {
            if (linkedlistdeck.Count() != 0)
            {
                ++card_repeat;
                ++card_index;
                if (card_index <= linkedlistdeck.Count())
                {
                    add_to_repeated_llist();
                    change_shown_card();
                }
                else
                {
                    --card_index;
                    add_to_repeated_llist();
                    ask_if_want_to_play_to_be_shown_cards_again();


                }
            }
            set_label_infos(linkedlistdeck);
        }
        private void button_great_or_again_click()
        {
            if (linkedlistdeck.Count() != 0)
            {
                ++card_correct;
                ++card_index;
                if (card_index <= linkedlistdeck.Count())
                {
                    change_shown_card();
                }
                else
                {
                    --card_index;
                    ask_if_want_to_play_to_be_shown_cards_again();

                }
            }
            set_label_infos(linkedlistdeck);
        }
        private void ask_if_want_to_play_to_be_shown_cards_again()
        {
            btnAgain.Hide();
            btnGreat.Hide();
            btnStudyAgain.Show();
            if (decks_to_be_shown_again.Count() != 0)
            {
                lblCards.Text = "Congratulations! You've learnt " + card_correct + " terms, keep studying to learn more!";
            }
            else
            {
                lblCards.Text = "Congratulations! You've learnt studied all of the terms, study again later to improve more!";
                btnStudyAgain.Text = "Go Back";

            }

        }
        private void btnStudyAgain_Click(object sender, EventArgs e)
        {
            btnStudyAgain.Hide();
            btnAgain.Show();
            btnGreat.Show();
            progressBar.Value = 0;
            card_index = 1;
            linkedlistdeck.Clear();
            foreach (var item in decks_to_be_shown_again)
            {
                linkedlistdeck.AddLast(item);
            }
            decks_to_be_shown_again.Clear();
            if (linkedlistdeck.Count() != 0)
            {
                lblCards.Text = linkedlistdeck.First.Value.getFront_Face();
                card_correct = 0;
                card_repeat = 0;
                set_label_infos(linkedlistdeck);
            }
            else
            {
                ((IButtonControl)lblBack).PerformClick();
            }

        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            Random Rand = new Random();

            foreach (var item in linkedlistdeck)
            {
                shuffled_deck_linkedlist.AddLast(item);
            }
            int size = shuffled_deck_linkedlist.Count;

            shuffled_deck_linkedlist = new LinkedList<Decks>(shuffled_deck_linkedlist.OrderBy((flashcard) =>
            {
                return (Rand.Next() % size);
            }));

            linkedlistdeck.Clear();
            foreach (var item in shuffled_deck_linkedlist)
            {
                linkedlistdeck.AddLast(item);
            }
            card_index = 1;
            lblCards.Text = linkedlistdeck.First.Value.getFront_Face();
            card_correct = 0;
            card_repeat = 0;
            shuffled_deck_linkedlist.Clear();
            set_label_infos(linkedlistdeck);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            card_index = 1;
            card_correct = 0;
            card_repeat = 0;
            linkedlistdeck.Clear();
            foreach (var item in non_shuffled_linkedlist)
            {
                linkedlistdeck.AddLast(item);
            }
            lblCards.Text = linkedlistdeck.First.Value.getFront_Face();
            set_label_infos(linkedlistdeck);
            btnGreat.Visible = true;
            btnAgain.Visible = true;
            btnStudyAgain.Visible = false;

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
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
    }
}
