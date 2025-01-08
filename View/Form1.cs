using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesHemiCycle.Controller;
using AccesHemiCycle.View;
using AForge;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;


namespace AccesHemiCycle
{
    public partial class Form1 : Form
    {
        #region Attribut
        SousFormulaire sousF;
        #endregion

        #region Form1
        public Form1()
        {
            InitializeComponent();
            sousF = new SousFormulaire(panelBody);
            sousF.openChildForm(new FormAccueil());
        }
        #endregion

        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Permet de réaliser l'intéraction Hover sur les différents labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Label Hover 
        private void labelExit_MouseHover(object sender, EventArgs e)
        {
            panelExit.BackColor = Color.Gray;
            panelExit.BackColor = Color.FromArgb(120, 127, 127, 127);
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            panelExit.BackColor = Color.Transparent;
        }

        private void labelAccueil_MouseHover(object sender, EventArgs e)
        {
            panelLabelAccueil.BackColor = labelAccueil.ForeColor;
            panelLabelAccueil.Visible = true;
        }

        private void labelAccueil_MouseLeave(object sender, EventArgs e)
        {
            panelLabelAccueil.Visible = false;
        }

        private void labelDeputes_MouseHover(object sender, EventArgs e)
        {
            panelLabelDeputes.BackColor = labelDeputes.ForeColor;
            panelLabelDeputes.Visible = true;
        }

        private void labelDeputes_MouseLeave(object sender, EventArgs e)
        {
            panelLabelDeputes.Visible = false;
        }

        private void labelHemicycle_MouseHover(object sender, EventArgs e)
        {
            panelLabelHemicycle.BackColor = labelHemicycle.ForeColor;
            panelLabelHemicycle.Visible = true;
        }

        private void labelHemicycle_MouseLeave(object sender, EventArgs e)
        {
            panelLabelHemicycle.Visible = false;
        }
        #endregion

        private void labelAccueil_Click(object sender, EventArgs e)
        {
            labelAccueil.ForeColor = Color.Red;
            labelAccueil.Font = new Font(labelAccueil.Font, FontStyle.Bold);
            panelLabelAccueil.BackColor = labelAccueil.ForeColor;

            labelDeputes.ForeColor = Color.MidnightBlue;
            labelDeputes.Font = new Font(labelAccueil.Font, FontStyle.Regular);

            labelHemicycle.ForeColor = Color.MidnightBlue;
            labelHemicycle.Font = new Font(labelAccueil.Font, FontStyle.Regular);

            sousF.openChildForm(new FormAccueil());
        }

        private void labelDeputes_Click(object sender, EventArgs e)
        {
            labelAccueil.ForeColor = Color.MidnightBlue;
            labelAccueil.Font = new Font(labelAccueil.Font, FontStyle.Regular);

            labelDeputes.ForeColor = Color.Red;
            labelDeputes.Font = new Font(labelAccueil.Font, FontStyle.Bold);
            panelLabelDeputes.BackColor = labelDeputes.ForeColor;

            labelHemicycle.ForeColor = Color.MidnightBlue;
            labelHemicycle.Font = new Font(labelAccueil.Font, FontStyle.Regular);

            sousF.openChildForm(new FormDeputes());
        }

        private void labelHemicycle_Click(object sender, EventArgs e)
        {
            labelAccueil.ForeColor = Color.MidnightBlue;
            labelAccueil.Font = new Font(labelAccueil.Font, FontStyle.Regular);

            labelDeputes.ForeColor = Color.MidnightBlue;
            labelDeputes.Font = new Font(labelAccueil.Font, FontStyle.Regular);

            labelHemicycle.ForeColor = Color.Red;
            labelHemicycle.Font = new Font(labelAccueil.Font, FontStyle.Bold);
            panelLabelHemicycle.BackColor = labelHemicycle.ForeColor;

            sousF.openChildForm(new FormHemicycle());
        }

        #region Lien Réseaux Sociaux
        private void pictureBoxTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://x.com/AssembleeNat");
        }

        private void pictureBoxFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/AssembleeNationale");
        }

        private void pictureBoxInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/assembleenationale/");
        }

        private void pictureBoxLinkedin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/company/assemblee-nationale/");
        }

        private void pictureBoxYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/user/AssembleeNationale");
        }
        #endregion
    }
}
