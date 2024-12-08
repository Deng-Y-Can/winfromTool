using LibVLCSharp.Shared;
using MediaPlayer = LibVLCSharp.Shared.MediaPlayer;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Threading;
using LibVLCSharp.WinForms;
using static System.Net.Mime.MediaTypeNames;

namespace ZoeWorld
{
    public partial class VlcPlayerForm : Form
    {
        public VlcPlayerForm()
        {
            InitializeComponent();
        }
        string url = $@"E:\home\github\WPFOpenTK\WPF-OpenTK\WpfOpenTKApp\WpfApp1\Tools\Vlc\file\xy.jpg";//01.Docker -Docker 容器的数据管理简介.mp4  xy.jpg
        LibVLC _libvlc;
        MediaPlayer player;
        private Point _mouseDownPoint;
        private List<string> _videoFiles;
        private int _currentVideoIndex;
        private bool _isMouseDown = false;
        float yaw = 0;//左右
        float pitch = 0;//上下
        float roll = 0;
        float changeViewFactor = 0.5f;
        long totalLength = 0;

        private float fov = 80;
        public float Fov
        {
            get
            {
                return fov;
            }
            set
            {
                if (value > 20 && value < 150)
                {
                    fov = value;
                }

            }
        }

        private void VlcPlayerForm_Load(object sender, System.EventArgs e)
        {
            InitializeVlc();
            PlayNextVideo();
            videoView1.MouseWheel += videoView1_MouseWheel;
        }

        private void InitializeVlc()
        {
            var libOptions = new[]
           {
                ":spherical-video",
                ":video-projection=equirectangular",
                "--video-filter=sphere",
                "--video-filter=deinterlace",
            };
            // 加载媒体文件

            _libvlc = new LibVLC();
            player = new MediaPlayer(_libvlc);

            videoView1.MediaPlayer = player;
            videoView1.MediaPlayer.PositionChanged += MediaPlayer_MediaPlayerPositionChanged;
            //通过设置宽高比为窗体宽高可达到视频铺满全屏的效果
            player.AspectRatio = this.Width + ":" + this.Height;
            player.Scale = 0.3f;
           
            var mediaOptions = new[]
            {
            //            ":spherical-video",
            //            ":video-projection=equirectangular",
            //"--spherical=1", // 启用球面视频渲染
            "--video-filter=sphere",
            "--video-filter=deinterlace", // 启用去交错滤镜
   
            //":video-rescale=1280,720", // 设置视频分辨率为1280x720
            //"--sout", "#transcode{vqa=1,fps=24,deinterlace=1}:standard{access=file,mux=ogg,dst=vlc_vr_output.mp4}"
            };

            videoView1.MediaPlayer.EnableMouseInput = false;
            videoView1.MediaPlayer.EnableKeyInput = false;

            _videoFiles = new List<string>
        {
            url
        };
            _currentVideoIndex = 0;
        }

        private void videoView1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (videoView1.MediaPlayer == null)
                return;
            if (e.Delta > 0)
            {
                //videoView1.MediaPlayer.Scale += 0.1f;
                Fov -= 1;
            }
            else
            {
                //videoView1.MediaPlayer.Scale -= 0.1f;
                Fov += 1;
            }

            videoView1.MediaPlayer.UpdateViewpoint(yaw, pitch, roll, Fov, true);
        }

       

        public string GetPlayTime(float NowLength)
        {
            if (videoView1.MediaPlayer == null)
            {
                this.label1.Text = "";
                return "";
            }
            totalLength = videoView1.MediaPlayer.Length / 1000;

            //float NowLength =videoView1.MediaPlayer.Position / 1000;

            string result = totalLength == 0 ? "" : $@"{ConvertSecondsToHMSFormat((int)NowLength)}:{ConvertSecondsToHMSFormat((int)totalLength)}";
            
            return result;
        }

        public static string ConvertSecondsToHMSFormat(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString("hh\\:mm\\:ss");
        }
        private void PlayNextVideo()
        {
            if (videoView1.MediaPlayer == null)
            {
                return;
            }
            if (_currentVideoIndex >= _videoFiles.Count)
            {
                _currentVideoIndex = 0;
            }

            string videoFile = _videoFiles[_currentVideoIndex];
            videoView1.MediaPlayer.Play(new Media(_libvlc, videoFile, FromType.FromPath));
            totalLength = this.videoView1.MediaPlayer.Length;
            _currentVideoIndex++;
            trackBar1.Value = 0;
            this.button3.Text = "暂停";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (videoView1.MediaPlayer == null)
                return;
            videoView1.MediaPlayer.Scale += 0.1f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (videoView1.MediaPlayer == null)
                return;
            yaw += 5;
            videoView1.MediaPlayer.UpdateViewpoint(yaw, pitch, roll, Fov, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (videoView1.MediaPlayer != null && videoView1.MediaPlayer.IsPlaying)
            {
                this.button3.Text = "播放";
                videoView1.MediaPlayer.Pause();
            }
            if (videoView1.MediaPlayer != null && videoView1.MediaPlayer.State == VLCState.Paused)
            {
                this.button3.Text = "暂停";
                videoView1.MediaPlayer.Play();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (videoView1.MediaPlayer != null)
            {
                PlayNextVideo();

            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (videoView1.MediaPlayer == null)
                return;
            if (this.button5.Text == "加速")
            {
                videoView1.MediaPlayer.SetRate(1.5f);
                this.button5.Text = "1.5倍速播放中";
            }
            else if (this.button5.Text == "1.5倍速播放中")
            {
                videoView1.MediaPlayer.SetRate(2f);
                this.button5.Text = "2倍速播放中";
            }
            else if (this.button5.Text == "2倍速播放中")
            {
                videoView1.MediaPlayer.SetRate(3f);
                this.button5.Text = "3倍速播放中";
            }
            else
            {
                videoView1.MediaPlayer.SetRate(1.0f);
                this.button5.Text = "加速";
            }
        }
        
      
        private void videoView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                _mouseDownPoint = new Point(e.X, e.Y);
            }
        }

        private void videoView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = false;
            }
        }

        private void videoView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left&& _isMouseDown)
            {
                //System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                //button.Left += e.X - offset.X;
                //button.Top += e.Y - offset.Y;
                Point newPoint=new Point(e.X, e.Y);
                double offsetX = (e.X - _mouseDownPoint.X) * changeViewFactor;
                double offsetY = (e.Y - _mouseDownPoint.Y) * changeViewFactor;
                _mouseDownPoint = newPoint;
                if (videoView1.MediaPlayer == null || Math.Abs(offsetX) > 10 || Math.Abs(offsetY) > 10)
                    return;
                yaw += (float)offsetX;
                pitch -= (float)offsetY;
                videoView1.MediaPlayer.UpdateViewpoint(yaw, pitch, roll, Fov, true);
            }
            
        }

        private void VlcPlayerForm_Resize(object sender, EventArgs e)
        {
             videoView1.Width = (int)(this.Width * 0.8);
             videoView1.Height = (int)(this.Height * 0.8);

        }

        
      

        private void button6_Click(object sender, EventArgs e)
        {
            if (videoView1.MediaPlayer == null)
                return;
            videoView1.MediaPlayer.Volume += 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (videoView1.MediaPlayer == null)
                return;
            videoView1.MediaPlayer.Volume -= 1;
        }
        private void MediaPlayer_MediaPlayerPositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            trackBar1.ValueChanged -= trackBar1_ValueChanged;

            double newPosition = (float)e.Position;
            videoView1.MediaPlayer.Pause();
            trackBar1.Invoke((MethodInvoker)delegate ()
            {
                trackBar1.Value = (int)(newPosition * 100);
            });
           
            label1.Invoke((MethodInvoker)delegate ()
            {
                label1.Text = GetPlayTime(e.Position * totalLength);
            });
           
            videoView1.MediaPlayer.Play();
            trackBar1.ValueChanged += trackBar1_ValueChanged;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (videoView1.MediaPlayer != null)
            {
                videoView1.MediaPlayer.PositionChanged -= MediaPlayer_MediaPlayerPositionChanged;
                videoView1.MediaPlayer.Position = (float)trackBar1.Value / 100;
                label1.Invoke((MethodInvoker)delegate ()
                {
                    label1.Text = GetPlayTime(videoView1.MediaPlayer.Position * totalLength);
                });              
                videoView1.MediaPlayer.PositionChanged += MediaPlayer_MediaPlayerPositionChanged;
            }
        }
    }
}
