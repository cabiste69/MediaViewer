using MediaViewer.zeze;
using System.Diagnostics;
using System.Windows.Forms;

namespace MediaViewer
{
    public partial class Form1 : Form
    {
        private string _image { get; set; }
        private int _WindowWidth { get; set; }
        private int _WindowHeight { get; set; }
        private int _imageWidth { get; set; }
        private int _imageHeight { get; set; }
        private int _zoomModifier { get; set; } = 0;
        private float _zoomLevel { get; set; } = 0;
        private int imgx = 0;
        private int imgy = 0;

        public Form1(string[] args)
        {
            InitializeComponent();
            SetImage(args);
            this.SizeChanged += Window_SizeChanged;
            PictureOpened.MouseMove += MoveImage_MouseMove;
            this.MouseWheel += NewZoomImage_MouseWheel;
        }

        private void PictureOpened_MouseClick(object? sender, MouseEventArgs e)
        {
            Debug.WriteLine(e.Location);
        }

        private void Form1_MouseClick(object? sender, MouseEventArgs e)
        {
            Debug.WriteLine(e.Location);
        }

        private void Window_SizeChanged(object? sender, EventArgs e)
        {
            _WindowHeight = this.Height;
            _WindowWidth = this.Width;
        }

        private void SetImage(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            List<string> supportedExtensions = new List<string> { "BMP", "PNG", "JPG", "JPEG", "ICO", "GIF" };

            if (supportedExtensions.Contains(Path.GetExtension(args[0]).ToUpperInvariant()))
            {
                return;
            }

            _image = args[0];
            //Debug.WriteLine(Screen.FromControl(this).Bounds.ToString());
            PictureOpened.Image = Image.FromFile(_image);
            //this.Size = PictureOpened.Image.Size;
            int titleBarHeight = this.RectangleToScreen(this.ClientRectangle).Top - this.Top;
            //this.Size = new Size(PictureOpened.Image.Size.Width + 50, PictureOpened.Image.Size.Height + 50 + titleBarHeight);
            //4, 
            //this.FormBorderStyle = (System.Windows.Forms.FormBorderStyle)6;

            _WindowWidth = Convert.ToInt32(Screen.FromControl(this).Bounds.Width * 0.7);
            _WindowHeight = Convert.ToInt32(Screen.FromControl(this).Bounds.Height * 0.7);
            _imageWidth = _WindowWidth;
            _imageHeight = _WindowHeight;

            PictureOpened.Size = new Size(_WindowWidth, _WindowHeight);
            this.Size = new Size(_WindowWidth, _WindowHeight + titleBarHeight);
            //Debug.WriteLine(PictureOpened.MinimumSize);
        }

        //private void ZoomImage_MouseWheel(object? sender, MouseEventArgs e)
        //{
        //    //Debug.WriteLine(e.Delta);
        //    if (e.Delta > 0)
        //    {
        //        _imageHeight += 20;
        //        _imageWidth += 20;
        //        _zoomLevel++;
        //        int y = (_zoomLevel * 20) - (e.Y - 1); 
        //        int x = (_zoomLevel * 20) - (e.X - 1);
        //        PictureOpened.Location = new Point(x, y);
        //        PictureOpened.Size = new Size(_imageWidth, _imageHeight);

        //        //PictureOpened.Bounds = new Rectangle(0, 0, ImageWidth , ImageHeight);
        //        //PictureOpened.Location = new Point(PictureOpened.Location.X + e.X, PictureOpened.Location.Y + e.Y)
        //        _zoomModifier+= 2;
        //    }
        //    else
        //    {
        //        _imageHeight -= 20;
        //        _imageWidth -= 20;
        //        _zoomModifier -= 2;
        //        _zoomLevel--;
        //        int y = e.Y - (_zoomLevel * 20);
        //        int x = e.X - (_zoomLevel * 20);
        //        PictureOpened.Location = new Point(x, y);
        //        PictureOpened.Size = new Size(_imageWidth, _imageHeight);
        //        if (_zoomModifier == 0)
        //        {
        //            PictureOpened.Location = new Point(0,0);
        //        }
        //    }

        //    //PictureOpened.Bounds = new Rectangle(0, 0, ImageWidth, ImageHeight);
        //}

        private void NewZoomImage_MouseWheel(object? sender, MouseEventArgs e)
        {
            float oldzoom = _zoomLevel;

            if (e.Delta > 0)
            {
                _zoomLevel += 0.1F;
            }
            else if (e.Delta < 0)
            {
                _zoomLevel = Math.Max(_zoomLevel - 0.1F, 0.01F);
            }

            Point mousePosNow = e.Location;

            // Where location of the mouse in the pictureframe
            int x = mousePosNow.X - PictureOpened.Location.X;
            int y = mousePosNow.Y - PictureOpened.Location.Y;

            // Where in the IMAGE is it now
            int oldimagex = (int)(x / oldzoom);
            int oldimagey = (int)(y / oldzoom);

            // Where in the IMAGE will it be when the new zoom i made
            int newimagex = (int)(x / _zoomLevel);
            int newimagey = (int)(y / _zoomLevel);

            // Where to move image to keep focus on one point
            imgx = newimagex - oldimagex + imgx;
            imgy = newimagey - oldimagey + imgy;
            _imageWidth = Convert.ToInt32(_imageWidth * _zoomLevel);
            _imageHeight = Convert.ToInt32(_imageHeight * _zoomLevel);

            PictureOpened.Size = new Size(_imageWidth, _imageHeight);
            PictureOpened.Location = new Point(imgx, imgy);
        }

        private Point _mouseLocationOnDragEnter { get; set; }
        private void MoveImage_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                _mouseLocationOnDragEnter = new Point(0,0);
                return;
            }

            if (_mouseLocationOnDragEnter.IsEmpty)
            {
                _mouseLocationOnDragEnter = e.Location;
            }

            Point distanceMoved = PointsMath.Subtract(_mouseLocationOnDragEnter, e.Location);
            PictureOpened.Location = PointsMath.Subtract(PictureOpened.Location, distanceMoved);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'r' || e.KeyChar == 'R')
            {
                PictureOpened.Location = new Point();
                PictureOpened.Size = new Size(_WindowWidth, _WindowHeight);
            }
        }
    }
}
