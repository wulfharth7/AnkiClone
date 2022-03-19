using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace clone
{
    
    public class Decks
    {
        private string front_face, back_face, front_language, back_language;
        private string Deck_Name;
        private int Card_Count;


        public Decks(){ }

        public string getFront_Face()
        {
            return front_face;
        }
        public void setFront_Face(string front_face_)
        {
            front_face = front_face_;
        }

        public string getBack_Face()
        {
            return back_face;
        }
        public void setBack_Face(string back_face_)
        {
            back_face = back_face_;
        }

        public string getFront_Lang()
        {
            return front_face;
        }
        public void setFront_Lang(string front_face_lang)
        {
            front_language = front_face_lang;
        }

        public string getBack_Lang()
        {
            return back_language;
        }
        public void setBack_Lang(string back_face_lang)
        {
            back_language = back_face_lang;
        }

    }

    public class Deck_User
    {
        private string user_nickname;
        private string user_password;
        private List<string> users_decks = new List<string>();

        public string get_nickname()
        {
            return user_nickname;
        }
        public void set_nickname(string front_face_lang)
        {
            user_nickname = front_face_lang;
        }
        public string set_nickname()
        {
            return user_nickname;
        }
        public void set_password(string front_face_lang)
        {
            user_password = front_face_lang;
        }
    }

    static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
