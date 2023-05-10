using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frewen
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sql; int row;
            OleDbConnection con = new OleDbConnection();
            // establish connection
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"E:\\Downloads\\Hatdog-main (1)\\Hatdog-main\\crest-main\\Frewen\\Frewen databse.accdb\"";
            con.Open(); // connection open
            sql = "select count(*) from login where username='" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            // row = (int)cmd.ExecuteScalar(); // cast into integer and ExecuteScalar() get single value from database.
            con.Close();

           
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
