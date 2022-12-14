using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace GeoPet.Rest;

public static class QrCodeGenerator
{
  public static Bitmap GenerateImage(string petData)
  {
    QRCodeGenerator qrCodeGenerator = new();
    QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(petData, QRCodeGenerator.ECCLevel.Q);
    QRCode qrCode = new(qrCodeData);
    return qrCode.GetGraphic(10);
  }

  public static string GenerateByteArray(string petData)
  {
    Bitmap qrCodeImage = GenerateImage(petData);
    byte[] image = ImageToByte(qrCodeImage);
    return ByteToString(image);
  }

  private static byte[] ImageToByte(Image img)
  {
    using var stream = new MemoryStream();
    img.Save(stream, ImageFormat.Png);
    return stream.ToArray();
  }

  private static string ByteToString(byte[] byteData)
  {
    string imreBase64Data = Convert.ToBase64String(byteData);
    return string.Format("data:image/png;base64,{0}", imreBase64Data);
  }
}
