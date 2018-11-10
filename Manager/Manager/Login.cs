using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //To-do: check loging user name & password
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Manager;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
  FROM [Manager].[dbo].[Login] where UserName='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //validate login details
            if (dt.Rows.Count == 1)
            {

                this.Hide();
                ManagerMain mm = new ManagerMain();
                mm.Show();
            }
            else
            {
                MessageBox.Show("invalid userName & passWord........!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
        }
    }
}
