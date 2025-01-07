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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;

namespace AccesHemiCycle
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection captureDevice;
        private VideoCaptureDevice finalVideo;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in captureDevice) { comboBoxCamera.Items.Add(Device.Name); }

            comboBoxCamera.SelectedIndex = 0;
            finalVideo = new VideoCaptureDevice();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            finalVideo = new VideoCaptureDevice(captureDevice[comboBoxCamera.SelectedIndex].MonikerString);
            finalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            finalVideo.Start();
        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBoxCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalVideo.IsRunning == true) { finalVideo.Stop(); }
        }

        private void timerCamera_Tick(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBoxCamera.Image);

            try
            {
                string decoded = result.ToString().Trim();
                if (decoded != "")
                {
                    textBoxContenu.Text = decoded;
                }
            }
            catch (Exception ex)
            {
            
            }
        }
    }
}
