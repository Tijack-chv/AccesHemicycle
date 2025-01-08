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
    public partial class FormDeputes : Form
    {
        #region Attribut
        private int minPage;
        private int maxPage;
        #endregion

        #region Constructeur
        public FormDeputes()
        {
            InitializeComponent();

            affichage();
            minPage = 1;
            buttonPrécédent.Enabled = false;
            nbPages();
            buttonSuivant.Enabled = maxPage == 1 ? false : true;
        }
        #endregion

        /// <summary>
        /// Affiche les députés dans le dataGridView avec une vérification de si une recherche est effectuée ou non
        /// </summary>
        #region affichage
        private void affichage()
        {
            ModeleDepute deputes = new ModeleDepute();
            DataView dataView;
            if (textBoxSearch.Text == "")
            {
                dataView = new DataView(deputes.ListDepute(Convert.ToInt32(textBoxPage.Text)));
            } else
            {
                dataView = new DataView(deputes.ListDepute(textBoxSearch.Text));
            }

            dataGridViewDeputes.DataSource = dataView;
            dataGridViewDeputes.Columns[0].Visible = false;
        }
        #endregion

        /// <summary>
        /// Calcul le nombre de pages en fonction du nombre de députés
        /// </summary>
        #region nbPages
        private void nbPages()
        {
            ModeleDepute deputes = new ModeleDepute();
            if (deputes.CountDeputes() % 20 == 0)
            {
                maxPage = deputes.CountDeputes() / 20;
            }
            else
            {
                maxPage = (deputes.CountDeputes() / 20) + 1;
            }
        }
        #endregion

        /// <summary>
        /// Permet de gérer la possibilité de rentrer dans l'Hémicycle pour un député en cas d'oublie de carte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region dataGridViewDeputes_DoubleClick
        private void dataGridViewDeputes_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Acceptez-vous que le député"+ dataGridViewDeputes.CurrentRow.Cells[1].Value.ToString() 
               + " " + dataGridViewDeputes.CurrentRow.Cells[2].Value.ToString()  + " puisse accéder à l'Hémicycle sans badge ?", "Accès député", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show("Accès autorisé", "Accès député", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModeleDepute modeleDepute = new ModeleDepute();

                if (modeleDepute.EntreeDepute(dataGridViewDeputes.CurrentRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Entrée enregistrée !");
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'enregistrement de l'entrée !");
                }
            }
            else
            {
                MessageBox.Show("Accès refusé", "Accès député", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        /// Permet de gérer toute la pagination de la datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Pagination
        private void textBoxPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxPage_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPage.Text != "")
            {
                if (Convert.ToInt32(textBoxPage.Text) <= 0)
                {
                    textBoxPage.Text = "1";
                }

                if (Convert.ToInt32(textBoxPage.Text) >= maxPage)
                {
                    textBoxPage.Text = maxPage.ToString();
                    buttonSuivant.Enabled = false;
                }
                else
                {
                    buttonSuivant.Enabled = true;
                }
                if (Convert.ToInt32(textBoxPage.Text) == minPage)
                {
                    buttonPrécédent.Enabled = false;
                }
                else
                {
                    buttonPrécédent.Enabled = true;
                }
            }
            else
            {
                textBoxPage.Text = "1";
            }
            affichage();
        }

        private void buttonSuivant_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(textBoxPage.Text);
            page++;
            textBoxPage.Text = page.ToString();
        }

        private void buttonPrécédent_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(textBoxPage.Text);
            page--;
            textBoxPage.Text = page.ToString();
        }
        #endregion

        /// <summary>
        /// Permet de rechercher un député en fonction de son nom ou prénom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region textBoxSearch_TextChanged
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            affichage();
        }
        #endregion

        /// <summary>
        /// Permet d'afficher la photo du député en fonction de son id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region afficherLaPhotoToolStripMenuItem_Click
        private void afficherLaPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = dataGridViewDeputes.CurrentRow.Cells[0].Value.ToString();
            value = value.Substring(2);
            string url = "https://datan.fr/assets/imgs/deputes_original/depute_" + value + ".png";
            pictureBoxDepute.ImageLocation = url;
            pictureBoxDepute.Visible = true;
        }
        #endregion
    }
}
