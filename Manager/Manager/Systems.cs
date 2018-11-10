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
    public partial class Systems : Form
    {
        public Systems()
        {
            InitializeComponent();
        }
       
        private void Systems_Load_1(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0; 
            LoadData();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
         SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Manager;Integrated Security=True");
         // insert logic

            con.Open();

            bool status = false;
            if (comboBox2.SelectedIndex == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            //if item exits in manager
            var sqlQuery = "";
            if (ifSystemExists(con, textBox3.Text ))
            {
                sqlQuery = @"UPDATE [Systems]SET[SystemName] = '" + textBox4.Text + "' ,[SystemStatus] = '" + status + "' WHERE [SystemSerial] = '" + textBox3.Text + "'";
            }
            else
            {
                sqlQuery = @"INSERT INTO [Manager].[dbo].[Systems]([SystemSerial],[SystemName],[SystemStatus])VALUES ('" + textBox3.Text + "','" + textBox4.Text + "','" + status + "')";
 
            }

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();

            // reading data
            LoadData();

        }
        private bool ifSystemExists(SqlConnection con, string SystemSerial) 
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 from [Manager].[dbo].[Systems] WHERE [SystemSerial] = '" + SystemSerial + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }           
          public void LoadData()
          {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Manager;Integrated Security=True"); 
            SqlDataAdapter sda = new SqlDataAdapter("Select * from [Manager].[dbo].[Systems]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item["SystemSerial"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["SystemName"].ToString();
                if ((bool)item["SystemStatus"])
                {
                    dataGridView2.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView2.Rows[n].Cells[2].Value = "Inactive";
                }
             }
          }
              private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Manager;Integrated Security=True");

            var sqlQuery = "";
            if (ifSystemExists(con, textBox3.Text))
            {
                con.Open();
                sqlQuery = @" DELETE FROM [Systems] WHERE [SystemSerial] = '" + textBox3.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close(); 
            }
            else
            {
                MessageBox.Show("Record not Selected");
            }
                        

            // reading data for delete action to occur
            LoadData();
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView2.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                comboBox2.SelectedIndex = 0 ;
            }
            else
            {
                comboBox2.SelectedIndex = 1 ;
            }
        }    
     }           
 }


        
