using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
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
    public partial class Form3 : Form
    {
        MySqlConnection conn;


        public Form3()
        {
            InitializeComponent();

            string server = "localhost";
            string database = "groupp6";
            string user = "root";
            string password = "1234";
            string connString = $"SERVER={server}; DATABASE ={database};UID={user};PASSWORD={password};";

            conn = new MySqlConnection(connString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hämta text från textfält
            string strName = textBox1.Text;
            string strColor = textBox2.Text;
            int intAge = Convert.ToInt32(textBox3.Text);
            int intSpecies = Convert.ToInt32(comboBox1.SelectedItem.ToString()[0]);
            int intClass = Convert.ToInt32(comboBox2.SelectedItem.ToString()[0]);
            

            //Insert statement
            string strSql = $"INSERT INTO groupp6.animals(Animals_name, Animals_color, Animals_age, species_species_id, class_class_id) VALUES ('{strName}', '{strColor}', {intAge}, {intSpecies - 48}, {intClass - 48});";
            

            //Skapa en MySQLCommande objekt
            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            //Öppna koppling till databas
            conn.Open();

            //Skicka iväg MySqlCommad till databas
            cmd.ExecuteReader();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
            //Stänga koppling till databas
            conn.Close();

            //Bekfräftelse på completion
            MessageBox.Show("Addition successful!");
        }
    }
}
