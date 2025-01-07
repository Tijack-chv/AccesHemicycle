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
        private FilterInfoCollection captureDevice;
        private VideoCaptureDevice finalVideo;
        #endregion

        #region Form1
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Charge au démarage de l'application les caméras disponibles dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in captureDevice) comboBoxCamera.Items.Add(Device.Name);
            comboBoxCamera.SelectedIndex = 0;
            finalVideo = new VideoCaptureDevice();
        }

        /// <summary>
        /// Démarre la caméra sélectionnée dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            finalVideo = new VideoCaptureDevice(captureDevice[comboBoxCamera.SelectedIndex].MonikerString);
            finalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            finalVideo.Start();
        }

        /// <summary>
        /// Affiche le flux vidéo de la caméra dans le pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
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

        /// <summary>
        /// Arrête la caméra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalVideo.IsRunning == true) { 
                finalVideo.Stop(); 
            }
        }

        /// <summary>
        /// Permet de lire le contenu du Qr Code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCamera_Tick(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBoxCamera.Image);

            try
            {
                string decoded = result?.Text?.Trim();
                if (decoded != "")
                {
                    Form1_FormClosing(sender, null);
                    textBoxContenu.Text = decoded;
                    //MessageBox.Show("Le Qr Code a été reconnu, il est bien de type VCard !");
                } else
                {
                    MessageBox.Show("Le Qr Code n'est pas reconnu !");
                }
            }
            catch
            {
                MessageBox.Show("Impossible de lire le Qr Code !");
            }
        }

        /// <summary>
        /// Arrête la lecture du Qr Code et récupère si reconnu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRead_Click(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBoxCamera.Image);

            try
            {
                string decoded = result?.Text?.Trim();
                if (decoded != "" && IsVcard(decoded))
                {
                    Form1_FormClosing(sender, null);
                    textBoxContenu.Text = decoded;
                    MessageBox.Show("Le Qr Code a été reconnu, il est bien de type VCard !");
                }
                else
                {
                    MessageBox.Show("Le Qr Code n'est pas reconnu !");
                }
            }
            catch
            {
                MessageBox.Show("Impossible de lire le Qr Code !");
            }
        }

        /// <summary>
        /// Vérifie si le contenu du Qr Code est de type VCard
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool IsVcard(string content)
        {
            if (content == null) return false;
            //on peut rajouter d'autres conditions pour être plus précis comme pour N: ou FN: etc, pour le formalisme du Qr Code
            else return content.StartsWith("BEGIN:VCARD") && content.Contains("VERSION:") && content.EndsWith("END:VCARD");
        }
    }
}
