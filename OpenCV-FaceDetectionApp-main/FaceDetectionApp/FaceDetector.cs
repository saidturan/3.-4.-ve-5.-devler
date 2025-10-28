using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO;

public class FaceDetector
{
    private CascadeClassifier _faceCascade;
    private const string HAAR_CASCADE_PATH = "haarcascade_frontalface_default.xml";

    public FaceDetector()
    {
        if (!File.Exists(HAAR_CASCADE_PATH))
        {
            throw new FileNotFoundException($"Haar Cascade dosyası bulunamadı: {HAAR_CASCADE_PATH}");
        }
        _faceCascade = new CascadeClassifier(HAAR_CASCADE_PATH);
    }

    public Image<Bgr, byte> DetectFaces(Image<Bgr, byte> image)
    {
        Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

        Rectangle[] faces = _faceCascade.DetectMultiScale(
            grayImage,
            1.1, 
            10, 
            new Size(20, 20) 
        );

        foreach (Rectangle face in faces)
        {
            image.Draw(face, new Bgr(0, 255, 0), 2);
        }

        return image;
    }
}


