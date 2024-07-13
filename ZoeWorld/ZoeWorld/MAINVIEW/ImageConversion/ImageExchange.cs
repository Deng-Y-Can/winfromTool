using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoeWorld.MAINVIEW.Excel
{
    public partial class ImageExchange : Form
    {
        public ImageExchange()
        {
            InitializeComponent();
            ImageExchange_Load();
        }
        private System.Drawing.Bitmap MyBitmap;

        private void ImageExchange_Load()
        {
            string[] imageFormat = { "bmp", "jpg", "png", "gif", "tif", "wmf", "emf" }; //添加图片类型
            comboBox1.Items.AddRange(imageFormat);               //将字符串数组添加至comboBox1.Items属性中
            this.comboBox1.SelectedIndex = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //打开图像文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 图像文件(*.jpg;*.jpeg)|*.jpg;*.jpeg |GIF 图像文件(*.gif)|*.gif |BMP图像文件(*.bmp)|*.bmp|Tiff图像文件(*.tif;*.tiff)|*.tif;*.tiff|Png图像文件(*.png)| *.png |所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //得到原始大小的图像
                Bitmap SrcBitmap = new Bitmap(openFileDialog.FileName);
                //得到缩放后的图像
                MyBitmap = new Bitmap(SrcBitmap);
                this.pictureBox1.Image = MyBitmap;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //转换图像文件
            if (MyBitmap == null)
            {
                MessageBox.Show("请首先选择一幅图像！", "信息提示");
                return;
            }
            SaveFileDialog saveDlg = new SaveFileDialog();
            if (saveDlg.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = saveDlg.FileName;
            try
            {
                if (this.comboBox1.SelectedIndex == 0)
                {
                    MyBitmap.Save(fileName + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                }
                if (this.comboBox1.SelectedIndex == 1)
                {
                    MyBitmap.Save(fileName + ".jpg", System.Drawing.Imaging.ImageFormat.Gif);
                }
                if (this.comboBox1.SelectedIndex == 2)
                {
                    MyBitmap.Save(fileName + ".png", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (this.comboBox1.SelectedIndex == 3)
                {
                    MyBitmap.Save(fileName + ".gif", System.Drawing.Imaging.ImageFormat.Png);
                }
                if (this.comboBox1.SelectedIndex == 4)
                {
                    MyBitmap.Save(fileName + ".tif", System.Drawing.Imaging.ImageFormat.Tiff);
                }
                if (this.comboBox1.SelectedIndex == 5)
                {
                    MyBitmap.Save(fileName + ".wmf", System.Drawing.Imaging.ImageFormat.Wmf);
                }
                if (this.comboBox1.SelectedIndex == 6)
                {
                    MyBitmap.Save(fileName + ".emf", System.Drawing.Imaging.ImageFormat.Emf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
