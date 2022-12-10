using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gruppsex
{
    public partial class Form2 : Form
    {

        MySqlConnection conn;

        public Form2()
        {
            InitializeComponent();

            string server = "localhost";
            string database = "groupp6";
            string user = "root";
            string password = "1234";
            string connString = $"SERVER={server}; DATABASE ={database};UID={user};PASSWORD={password};";

            conn = new MySqlConnection(connString);

            string strSql = $"SELECT * FROM groupp6.viewAll";

            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            label1.Text = "Name";
            label2.Text = "Age";
            label3.Text = "Color";
            label4.Text = "Species";
            label8.Text = "ID";

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label1.Text += Environment.NewLine + reader["animals_name"];
                label2.Text += Environment.NewLine + reader["animals_age"];
                label3.Text += Environment.NewLine + reader["animals_color"];
                label4.Text += Environment.NewLine + reader["species_name"];
                label8.Text += Environment.NewLine + reader["animals_id"];

            }

            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Deletefunktion
            int choice = Convert.ToInt32(textBox1.Text);

            string strSql = $"DELETE FROM groupp6.animals WHERE animals_id = {choice}";
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            conn.Close();

            textBox1.Clear();

            MessageBox.Show("Deletion successful");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Updatefunktion






        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Refresh View
            string strSql = $"SELECT * FROM groupp6.viewAll";

            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            label1.Text = "Name";
            label2.Text = "Age";
            label3.Text = "Color";
            label4.Text = "Species";
            label8.Text = "ID";

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label1.Text += Environment.NewLine + reader["animals_name"];
                label2.Text += Environment.NewLine + reader["animals_age"];
                label3.Text += Environment.NewLine + reader["animals_color"];
                label4.Text += Environment.NewLine + reader["species_name"];
                label8.Text += Environment.NewLine + reader["animals_id"];

            }

            conn.Close();


        }
    }
}
