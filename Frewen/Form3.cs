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
    public partial class Form3 : Form
    {
        OleDbConnection Connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""E:\Downloads\Hatdog-main (1)\Hatdog-main\crest-main\Frewen\Frewen databse.accdb""");
        OleDbDataAdapter oleDbAdapter;
        DataSet ds;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'frewen_databseDataSet1.Information' table. You can move, or remove it, as needed.
            this.informationTableAdapter.Fill(this.frewen_databseDataSet1.Information);
            Display();
        }

        public void Display()
        {
            if (Connection.State.ToString().Equals("Closed"))
            {
                Connection.Open();
            }
            oleDbAdapter = new OleDbDataAdapter();
            ds = new DataSet();


            try
            {
                oleDbAdapter.SelectCommand = new OleDbCommand("SELECT * FROM [Information]", Connection);
                dataGridView1.DataSource = null;
                oleDbAdapter.Fill(ds);
                oleDbAdapter.Dispose();
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (Connection.State.ToString().Equals("Open"))
            {
                Connection.Close();
            }

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Connection.Open();
            OleDbCommand cmd = Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Information values('" + txtfirst.Text + "','" + txtmiddle.Text + "','" + txtlast.Text + "','" + txtemail.Text + "','" + txtnumber.Text + "')";
            cmd.ExecuteNonQuery();
            Connection.Close();

            MessageBox.Show("record inserted successfuy");


            Connection.Close();

            Display();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // create an instance of Form2
            form1.Show(); // show Form2
            this.Hide(); // hide Form1
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtfirst.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            txtmiddle.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            txtlast.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            txtemail.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            txtnumber.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

            txtfirst.Text = "";
            txtmiddle.Text = "";
            txtlast.Text = "";
            txtemail.Text = "";
            txtnumber.Text = "";
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                OleDbCommand cmd = new
                OleDbCommand();
                cmd.Connection = Connection;
                string query = "Delete from Frewendatabse where FirstName=" + txtfirst.Text + "";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Succesfully");
                Connection.Close();
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
