using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesHemiCycle.View
{
    public partial class FormCarteInfoDepute : Form
    {
        public FormCarteInfoDepute(string value, string nom, string prenom, string mail)
        {
            InitializeComponent();
            labelName.Text = nom;
            labelFirstName.Text = prenom;
            labelMail.Text = mail;
            pictureBoxDepute.ImageLocation = "https://datan.fr/assets/imgs/deputes_original/depute_" + value + ".png";
        }
    }
}
