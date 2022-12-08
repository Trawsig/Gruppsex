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
using MySql.Data.MySqlClient;

namespace Gruppsex
{
    public partial class Form1 : Form
    {

        MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();

            string server = "localhost";
            string database = "groupp6";
            string user = "root";
            string password = "1234";
            string connString = $"SERVER={server}; DATABASE ={database};UID={user};PASSWORD={password};";

            conn = new MySqlConnection(connString);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choice = comboBox1.SelectedItem.ToString().ToLower();
            
            
            string strSql = $"SELECT * FROM groupp6.view{choice}";

            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            label1.Text = "Name";
            label2.Text = "Age";
            label3.Text = "Color";
            label4.Text = "Species";

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label1.Text += Environment.NewLine + reader["animals_name"];
                label2.Text += Environment.NewLine + reader["animals_age"];
                label3.Text += Environment.NewLine + reader["animals_color"];
                label4.Text += Environment.NewLine + reader["species_name"];

            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }


    }
}
