namespace FaceDetectionApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnStartWebcam = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
       
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox1.Location = new System.Drawing.Point(0, 0);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(800, 500);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
      
            this.btnLoadImage.Location = new System.Drawing.Point(12, 10);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(150, 30);
            this.btnLoadImage.TabIndex = 3;
            this.btnLoadImage.Text = "Resim Yükle";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
      
            this.btnStartWebcam.Location = new System.Drawing.Point(168, 10);
            this.btnStartWebcam.Name = "btnStartWebcam";
            this.btnStartWebcam.Size = new System.Drawing.Size(150, 30);
            this.btnStartWebcam.TabIndex = 4;
            this.btnStartWebcam.Text = "Webcam\'i Başlat";
            this.btnStartWebcam.UseVisualStyleBackColor = true;
            this.btnStartWebcam.Click += new System.EventHandler(this.btnStartWebcam_Click);
   
            this.panelControls.Controls.Add(this.btnLoadImage);
            this.panelControls.Controls.Add(this.btnStartWebcam);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 500);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(800, 50);
            this.panelControls.TabIndex = 5;
       
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.panelControls);
            this.Name = "Form1";
            this.Text = "C# Yüz Tespiti (Emgu CV)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnStartWebcam;
        private System.Windows.Forms.Panel panelControls;
    }
}
