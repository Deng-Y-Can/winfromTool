using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CandyMedia
{


    /// <summary>
    /// 有损压缩格式：
    //JPEG（.jpg/.jpeg）：广泛用于照片等色彩丰富图像，牺牲细节减小文件大小，支持 8 位 RGB 色彩模式。
    //WebP：新兴格式，压缩比高，兼容 JPEG、PNG 特性，能有效减少图像文件大小，提升网页加载速度。
    //无损压缩格式：
    //PNG（.png）：支持透明背景，常用于图标、UI 设计。采用无损压缩，保留图像细节，24 位真彩色或 8 位索引色。
    //GIF（.gif）：支持动画，最多 256 色，适合简单动画、网页小图标。无损压缩，文件小。
    //FLIF（.flif）：新无损格式，压缩率超 PNG，支持多图像存储、元数据嵌入，兼容多种色彩模式。
    //矢量图形格式：
    //SVG（.svg）：文本格式描述图形，缩放不失真，适合图标、插画、图表，广泛用于网页。
    //EPS（.eps）：专业印刷和设计领域常用，支持矢量和位图，可嵌入字体和图像。
    //专业与特殊用途格式：
    //RAW（.raw、.nef、.cr2 等）：相机原始数据格式，保留图像传感器原始信息，方便后期专业调整。
    //TIFF（.tiff）：常用于印刷、摄影后期处理，支持多种色彩模式和图像类型，无损存储。
    //BMP（.bmp）：简单点阵图格式，几乎不压缩，保留图像完整像素信息，文件大。
    //ICO（.ico）：Windows 系统图标专用格式，支持透明背景和多种图像格式。
    /// </summary>
    public enum PictureType
    {
        JPG,
        JPEG,
        WEBP,
        PNG,
        GIF,
        FLIF,
        SVG,
        EPS,
        RAW,
        NEF,
        CR2,
        TIFF,
        BMP,
        ICO
    }
    public class CandyPicture
    {
    }
}
