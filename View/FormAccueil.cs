using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesHemiCycle.Controller;
using AForge;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;

namespace AccesHemiCycle.View
{
    public partial class FormAccueil : Form
    {
        #region Attribut
        private FilterInfoCollection captureDevice;
        private VideoCaptureDevice finalVideo;
        SousFormulaire sousF;
        #endregion

        #region Constructeur
        public FormAccueil()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Charge au démarage de l'application les caméras utilisables dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region FormAccueil_Load
        private void FormAccueil_Load(object sender, EventArgs e)
        {
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in captureDevice) comboBoxCamera.Items.Add(Device.Name);
            comboBoxCamera.SelectedIndex = 0;
            finalVideo = new VideoCaptureDevice();
        }
        #endregion

        /// <summary>
        /// Démarre la caméra sélectionnée dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region buttonStart_Click
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (sousF != null)
            {
                sousF.closeChildForm();
            }
            finalVideo = new VideoCaptureDevice(captureDevice[comboBoxCamera.SelectedIndex].MonikerString);
            finalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            finalVideo.Start();
        }
        #endregion

        /// <summary>
        /// Affiche le flux vidéo de la caméra dans le pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        #region FinalVideo_NewFrame
        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                // On clone l'image pour éviter les problèmes de mémoire
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                // Le filtre va permètre de remettre l'image dans le bon sens
                var filter = new Mirror(false, true);
                filter.ApplyInPlace(bitmap);
                pictureBoxCamera.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Arrête la caméra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region FormAccueil_FormClosing
        private void FormAccueil_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalVideo.IsRunning == true)
            {
                finalVideo.Stop();
            }
        }
        #endregion

        /// <summary>
        /// Analyse le rendu de la caméra afin de lire le contenu du Qr Code si celui-ci est de type VCard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region buttonRead_Click
        private void buttonRead_Click(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBoxCamera.Image);

            try
            {
                string decoded = result?.Text?.Trim();
                if (decoded != "" && IsVcard(decoded))
                {
                    FormAccueil_FormClosing(sender, null);

                    Dictionary<string, string> listVCard = new Dictionary<string, string>();
                    listVCard = RecuperationVCard(decoded);
                    ModeleDepute modeleDepute = new ModeleDepute();
                    //MessageBox.Show("Le Qr Code a été reconnu, il est bien de type VCard !");

                    if (modeleDepute.AccesDepute(listVCard["Organization"], listVCard["Name"], listVCard["FirstName"], listVCard["Email"]))
                    {
                        //MessageBox.Show("Accès autorisé !");

                        sousF = new SousFormulaire(panelBackCamera);
                        string value = listVCard["Organization"].Substring(2);

                        sousF.openChildForm(new FormCarteInfoDepute(value, listVCard["Name"], listVCard["FirstName"], listVCard["Email"]));

                        if (modeleDepute.EntreeDepute(listVCard["Organization"]))
                        {
                            //MessageBox.Show("Entrée enregistrée !");
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de l'enregistrement de l'entrée !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Accès refusé !");
                    }
                }
                else
                {
                    MessageBox.Show("Le Qr Code n'est pas reconnu !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Vérifie si le contenu du Qr Code est de type VCard
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        #region IsVcard
        public bool IsVcard(string content)
        {
            if (content == null) return false;
            //on peut rajouter d'autres conditions pour être plus précis comme pour N: ou FN: etc, pour le formalisme du Qr Code
            else return content.StartsWith("BEGIN:VCARD") && content.Contains("VERSION:") && content.EndsWith("END:VCARD");
        }
        #endregion

        /// <summary>
        /// Permet de récupérer les éléments composant un Qr Code de type VCard
        /// </summary>
        /// <param name="vcardContent"></param>
        /// <returns></returns>
        #region RecuperationVCard
        private Dictionary<string, string> RecuperationVCard(string vCardContenu)
        {
            var vcardData = new Dictionary<string, string>();
            var lines = vCardContenu.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.StartsWith("N:")) // Nom complet
                {
                    vcardData["Name"] = line.Substring(2).Trim();
                    string[] nameParts = vcardData["Name"].Split(';');
                    string name = "";
                    string firstname = "";
                    foreach (var item in nameParts)
                    {
                        if (name == "")
                        {
                            name = item;
                        }
                        else
                        {
                            firstname = item;
                        }
                    }
                    vcardData["Name"] = name;
                    vcardData["FirstName"] = firstname;
                }
                else if (line.StartsWith("FN:")) // Nom formaté
                {
                    vcardData["FormattedName"] = line.Substring(3).Trim();
                }
                else if (line.StartsWith("ORG:")) // Organisation
                {
                    vcardData["Organization"] = line.Substring(4).Trim();
                }
                else if (line.StartsWith("EMAIL;")) // Email
                {
                    vcardData["Email"] = line.Substring(14).Trim().Substring(6); // récupérer l'email après EMAIL;TYPE=INTERNET:ERNET:
                }
            }
            return vcardData;
        }
        #endregion
    }
}
