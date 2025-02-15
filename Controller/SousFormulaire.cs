﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesHemiCycle.Controller
{
    public class SousFormulaire
    {
        #region Attribut
        public Panel PanelSousFormlaire;
        public Form activeForm = null;
        #endregion

        #region Constructeur
        public SousFormulaire(Panel panelenvoit)
        {
            PanelSousFormlaire = panelenvoit;
        }
        #endregion

        /// <summary>
        /// Permet d'ouvrir un formulaire enfant dans le panel
        /// </summary>
        /// <param name="formEnfant"></param>
        #region openChildForm
        public void openChildForm(Form formEnfant)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = formEnfant;
            formEnfant.TopLevel = false;
            formEnfant.FormBorderStyle = FormBorderStyle.None;
            formEnfant.Dock = DockStyle.Fill;
            PanelSousFormlaire.Controls.Add(formEnfant);
            PanelSousFormlaire.Tag = formEnfant;
            formEnfant.BringToFront();
            formEnfant.Show();
        }
        #endregion

        /// <summary>
        /// Permet de fermer un formulaire enfant
        /// </summary>
        #region closeChildForm
        public void closeChildForm()
        {
            if (activeForm != null)
                activeForm.Close();
        }
        #endregion
    }
}
