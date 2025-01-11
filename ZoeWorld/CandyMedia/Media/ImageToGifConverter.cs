using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace ZoeWorld.DLL.Media
{
    public class ImageToGifConverter
    {
       

        // 对外公开的转换方法
        public void ConvertToGif(string inputPath, string outputPath, int width, int height)
        {
            string extension = Path.GetExtension(inputPath).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".bmp":
                case ".tiff":
                case ".ico":
                    
                    break;
                case ".webp":
                    
                    break;
                case ".svg":
                   
                    break;
                case ".nef":
                case ".cr2":
                   
                    break;
                case ".eps":
                   
                    break;
                default:
                    throw new NotSupportedException("Unsupported image format");
            }
        }
    }
}
