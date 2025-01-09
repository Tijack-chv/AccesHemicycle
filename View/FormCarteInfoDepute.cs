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
        #region Constructeur
        public FormCarteInfoDepute(string value, string nom, string prenom, string mail)
        {
            InitializeComponent();
            labelName.Text = nom;
            labelFirstName.Text = prenom;
            labelMail.Text = mail;

            CenterLabel(labelName, panelLabelName);
            CenterLabel(labelFirstName, panelLabelFirstName);
            CenterLabel(labelMail, panelLabelMail);

            pictureBoxDepute.ImageLocation = "https://datan.fr/assets/imgs/deputes_original/depute_" + value + ".png";
        }

        /// <summary>
        /// Centre un label par rapport à la taille de la fenêtre
        /// </summary>
        /// <param name="label"></param>
        private void CenterLabel(Label label,Panel panel)
        {
            label.Left = (this.ClientSize.Width - label.Width) / 2;
            panel.Width = label.Width;
            panel.Left = (this.ClientSize.Width - panel.Width) / 2;

        }
        #endregion
    }
}
