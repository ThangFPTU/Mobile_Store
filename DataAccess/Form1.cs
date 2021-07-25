using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataAccess
{
    public partial class Form1 : Form
    {
        static String strConn = ConfigurationManager.ConnectionStrings["MusicStoreConnectionString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Users where UserName = 'admin'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    textBox1.Text = sdr["FirstName"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Genres(Name,Description) values(@name,@des)", conn);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@des", textBox3.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex) { }
            

        }
    }
}
