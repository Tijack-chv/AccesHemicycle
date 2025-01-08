using AccesHemiCycle.Controller;
using AccesHemiCycle.Model;
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
    public partial class FormDroitVerification : Form
    {
        public FormDroitVerification()
        {
            InitializeComponent();
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            if (textBoxMail.Text == "" || textBoxPassword.Text == "")
            {
                if (textBoxMail.Text == "")
                {
                    labelMail.ForeColor = Color.Red;
                    textBoxMail.ForeColor = Color.Red;
                }
                else
                {
                    labelMail.ForeColor = Color.MidnightBlue;
                    textBoxMail.ForeColor = Color.MidnightBlue;
                }
                if (textBoxPassword.Text == "")
                {
                    labelPassword.ForeColor = Color.Red;
                    textBoxPassword.ForeColor = Color.Red;
                }
                else
                {
                    labelPassword.ForeColor = Color.MidnightBlue;
                    textBoxPassword.ForeColor = Color.MidnightBlue;
                }
            }
            else
            {
                ModeleDroit droit = new ModeleDroit();
                if (droit.AccesDroitDeputes(textBoxMail.Text, textBoxPassword.Text))
                {
                    Form1 form1 = (Form1)Application.OpenForms["Form1"];
                    if (form1 != null)
                    {
                        form1.sousF.openChildForm(new FormDeputes());
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur de connexion !\nL'email ou le mot de passe est incorrect !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
