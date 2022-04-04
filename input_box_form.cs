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
    public partial class input_box_form : Form
    {
        private static string connectionstring = "Server=LAPTOP-BEQ4MFN7\\ANKICLONE; database =AnkiClone;MultipleActiveResultSets=true; Integrated Security=SSPI;";
        SqlConnection myDatabase = new SqlConnection(connectionstring);
        public input_box_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//cancel button
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            create_table();
            this.Dispose();
        }
        private void create_table()
        {
            SqlCommand cmd = myDatabase.CreateCommand();
            myDatabase.Open();
            
            if (get_table_names() == true)
            {
                MessageBox.Show("Deck already exists!");
            }
            else
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand("create table "+ boxInput.Text +" (UserID int NOT NULL    IDENTITY    PRIMARY KEY,[Front_Face] varchar(50),[Back_Face] varchar(50),[FRONT_LANG] varchar(50),[BACK_LANG] varchar(50))");
                    myCommand.Connection = myDatabase;
                    myCommand.ExecuteNonQuery();
                    string space = "";
                    myCommand.CommandText = "INSERT INTO " + boxInput.Text + " ([Front_Face], [Back_Face], [FRONT_LANG], [BACK_LANG]) VALUES (@2,@3,@4,@5)";
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@2", space);
                    myCommand.Parameters.AddWithValue("@3", space);
                    myCommand.Parameters.AddWithValue("@4", space);
                    myCommand.Parameters.AddWithValue("@5", space);
                    myCommand.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Deck name has to be written!");
                }
            }
            myDatabase.Close();
        }
        private bool get_table_names()
        {
            DataTable schema = myDatabase.GetSchema("Tables");
            List<string> tableNames = new List<string>();
            foreach (DataRow row in schema.Rows)
            {
                tableNames.Add(row[2].ToString());
            }
            return check_if_table_exists(tableNames);
        }
        private bool check_if_table_exists(List<string> tablenames)
        {
            if (tablenames.Contains(boxInput.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
