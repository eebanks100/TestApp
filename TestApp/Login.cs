using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        /*        private void Login_Load(object sender, EventArgs e)
                {
                    SQLiteConnection conn = new SQLiteConnection(@"data source = nAccountDb.db");
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        Console.WriteLine("DB conn open erorr");
                    }

                    SQLiteDataReader dataReader;
                    SQLiteCommand command = conn.CreateCommand();
                    command.CommandText = "SELECT * FROM Account";

                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Console.WriteLine(dataReader.GetInt32(0));
                    }
                }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection con = new SQLiteConnection(@"data source = nAccountDb.db");
                con.Open();
                //command object
                //string query = ("SELECT COUNT(*) FROM ACCOUNT WHERE name='"+ textBox1.Text + "' AND password='" + textBox2.Text + "'");
                string query = "SELECT * from Account";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                //adapter
                //datatable
                DataSet dt = new DataSet();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Tables[0].Rows)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = row["accountID"].ToString();
                    lvi.SubItems.Add(row["name"].ToString());
                    lvi.SubItems.Add(row["password"].ToString());
                    lvi.SubItems.Add(row["type"].ToString());
                    //listView1.Items.Add(lvi);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
