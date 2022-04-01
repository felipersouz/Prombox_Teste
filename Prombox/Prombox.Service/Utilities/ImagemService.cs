using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Service.Utilities
{
    public class ImagemService
    {
        public static void GerarThumbnail(int novaLargura, string origem, string destino)
        {
            Image originalImage = System.Drawing.Image.FromFile(origem);
            Image resizedImage = originalImage.GetThumbnailImage(novaLargura, (novaLargura * originalImage.Height) / originalImage.Width, null, IntPtr.Zero);
            resizedImage.Save(destino, ImageFormat.Png);

            originalImage.Dispose();
            originalImage = null;

            resizedImage.Dispose();
            resizedImage = null;

            if (System.IO.File.Exists(origem))
                System.IO.File.Delete(origem);
        }

        public static string GerarNomeThumbnail()
        {
            return Guid.NewGuid().ToString().ToLower() + ".png";
        }
    }
}
