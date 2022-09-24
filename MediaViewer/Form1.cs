using System.Diagnostics;

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

        public Form1(string[] args)
        {
            InitializeComponent();
            SetImage(args);
            this.MouseWheel += ZoomImage_MouseWheel;
            PictureOpened.MouseMove += MoveImage_MouseMove;
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
            //PictureOpened.ImageLocation = image;
            Debug.WriteLine(Screen.FromControl(this).Bounds.ToString());
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
            Debug.WriteLine(PictureOpened.MinimumSize);
        }

        private void ZoomImage_MouseWheel(object? sender, MouseEventArgs e)
        {
            //Debug.WriteLine(e.Delta);
            if (e.Delta > 0)
            {
                _imageHeight += 20;
                _imageWidth += 20;
                PictureOpened.Location = new Point((PictureOpened.Location.X - e.X) + (_WindowWidth / 2) - _zoomModifier, (PictureOpened.Location.Y - e.Y) + (_WindowHeight / 2) - _zoomModifier);
                PictureOpened.Size = new Size(_imageWidth, _imageHeight);
                //PictureOpened.Bounds = new Rectangle(0, 0, ImageWidth , ImageHeight);
                //PictureOpened.Location = new Point(PictureOpened.Location.X + e.X, PictureOpened.Location.Y + e.Y)
                _zoomModifier+= 2;
            }
            else
            {
                _imageHeight -= 20;
                _imageWidth -= 20;
                PictureOpened.Size = new Size(_imageWidth, _imageHeight);
            }

            //PictureOpened.Bounds = new Rectangle(0, 0, ImageWidth, ImageHeight);
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

            Point distanceMoved = new Point(_mouseLocationOnDragEnter.X - e.Location.X, _mouseLocationOnDragEnter.Y - e.Location.Y);
            PictureOpened.Location = new Point(PictureOpened.Location.X - distanceMoved.X, PictureOpened.Location.Y - distanceMoved.Y);
        }
    }
}