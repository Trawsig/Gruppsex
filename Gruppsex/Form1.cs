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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //Här har vi vad som händer när man trycker på new

            //först lägger jag till classen eller form saken
            AddAnimal addAnimal = new AddAnimal();

            //Och det här gör så att fönstret poppar upp 
            addAnimal.ShowDialog();
        }
    }
}
