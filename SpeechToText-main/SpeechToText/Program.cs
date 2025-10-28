using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whisper;
using Whisper.net;

namespace SpeechToText 
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private TextBox txtOutput;
        private Button btnStart;
        private WhisperWrapper whisper;

        public MainForm()
        {
            this.Text = "Canlı Dinlemeye Hoşgeldin";
            this.Width = 600;
            this.Height = 400;

            txtOutput = new TextBox();
            txtOutput.Multiline = true;
            txtOutput.Dock = DockStyle.Fill;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.ReadOnly = true;
            this.Controls.Add(txtOutput);

            btnStart = new Button();
            btnStart.Text = "Dinlemeyi Başlat";
            btnStart.Dock = DockStyle.Top;
            btnStart.Click += BtnStart_Click;
            this.Controls.Add(btnStart);
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            txtOutput.Clear();
            txtOutput.AppendText("🎤 Dinleniyor, konuşmaya başlayın...\r\n");

            whisper = WhisperFactory.CreateBuilder()
                                    .WithLanguage("tr")
                                    .WithModelSize(WhisperModelSize.Small)
                                    .Build();

            await StartListeningAsync();
        }

        private async Task StartListeningAsync()
        {
            while (true)
            {
                var result = await whisper.FromMicrophoneAsync();

                if (!string.IsNullOrWhiteSpace(result.Text))
                {
                    txtOutput.AppendText(result.Text + "\r\n");
                }

                await Task.Delay(100);
            }
        }
    }
}