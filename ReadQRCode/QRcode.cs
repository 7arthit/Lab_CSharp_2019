using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode;
using ZXing;

namespace ReadQRCode
{
    public partial class QRcode : Form
    {
        FilterInfoCollection webcams;
        VideoCaptureDevice videoIn;
        public QRcode()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo webcam in webcams)
            {
                comboBox1.Items.Add(webcam.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoIn = new VideoCaptureDevice(webcams[comboBox1.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = videoIn;
            videoSourcePlayer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (videoIn != null && videoIn.IsRunning)
            videoSourcePlayer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.CharacterSet = "UTF-8";
            options.Width = 200;
            options.Height = 130;

            BarcodeWriter writer = new BarcodeWriter();
            writer.Options = options;
            if (radioButton1.Checked)
                writer.Format = BarcodeFormat.CODE_39;
            else
                writer.Format = BarcodeFormat.QR_CODE;

            var result = writer.Write(textBox1.Text);
            pictureBox1.Image = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("Code.jpg");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var capture = videoSourcePlayer1.GetCurrentVideoFrame();
            if (capture != null)
            {
                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(capture);
                if (result != null)
                {
                    listBox1.Items.Insert(0, result.Text + " "
                        + result.BarcodeFormat.ToString());
                }
            }
        }
    }
}
