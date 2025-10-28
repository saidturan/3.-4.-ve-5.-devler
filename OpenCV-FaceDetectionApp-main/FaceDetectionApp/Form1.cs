using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI; 

namespace FaceDetectionApp
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture = null;
        private FaceDetector _faceDetector;

        public Form1()
        {
            InitializeComponent();
            try
            {
                _faceDetector = new FaceDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dedektör yüklenirken bir hata oluştu. XML dosyasının doğru dizinde olduğundan emin olun.\nHata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            StopWebcam();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image<Bgr, byte> image = new Image<Bgr, byte>(ofd.FileName);
                        ProcessImage(image);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Görüntü yüklenirken hata: " + ex.Message);
                    }
                }
            }
        }

        private void btnStartWebcam_Click(object sender, EventArgs e)
        {
            if (_capture == null)
            {
                try
                {
                    _capture = new VideoCapture(0);
                    _capture.ImageGrabbed += ProcessFrame;
                    _capture.Start();
                    btnStartWebcam.Text = "Webcam'i Durdur";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Webcam başlatılamadı: " + ex.Message);
                    _capture = null;
                }
            }
            else
            {
                StopWebcam();
            }
        }

        private void StopWebcam()
        {
            if (_capture != null)
            {
                _capture.Stop();
                _capture.Dispose();
                _capture = null;
                btnStartWebcam.Text = "Webcam'i Başlat";
                imageBox1.Image = null;
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                Mat frame = new Mat();
                _capture.Retrieve(frame); 

                Image<Bgr, byte> image = frame.ToImage<Bgr, byte>();

                ProcessImage(image);
            }
        }

        private void ProcessImage(Image<Bgr, byte> image)
        {
            if (image == null) return;

            Image<Bgr, byte> processedImage = image.Clone();

            if (_faceDetector != null)
            {
                processedImage = _faceDetector.DetectFaces(processedImage);
            }

            imageBox1.Image = processedImage;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopWebcam();
        }
    }
}