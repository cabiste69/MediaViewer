using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
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
        private int _zoomLevel { get; set; } = 1;
        private List<string> _otherImages { get; set; }
        private List<string> supportedExtensions = new List<string> { ".BMP", ".PNG", ".JPG", ".JPEG", ".ICO", ".GIF" };
        private int _currentImageindex { get; set; } = -1;

        public Form1(string[] args)
        {
            InitializeComponent();
            SetImage(args[0]);
            this.SizeChanged += Window_SizeChanged;
            PictureOpened.MouseMove += MoveImage_MouseMove;
            this.MouseWheel += ZoomImage_MouseWheel;
            CheckForOtherImages();
        }

        private void CheckForOtherImages()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            _otherImages = Directory.GetFiles(currentDirectory).ToList();

            // filter only supported images
            for (int i = 0; i < _otherImages.Count; i++)
            {
                if (_image == _otherImages[i])
                {
                    _currentImageindex = i;
                }
                if (!supportedExtensions.Contains(Path.GetExtension(_otherImages[i]).ToUpperInvariant()))
                {
                    _otherImages.RemoveAt(i);
                    i--;
                }
            }

            // if there're no other images no need to continue
            if (_otherImages.Count == 0)
            {
                return;
            }

            // for debugging
            for (int i = 0; i < _otherImages.Count; i++)
            {
                Debug.WriteLine(_otherImages[i]);
            }

            // set the previous and next image buttons
            button_PreviousImage.Visible = _currentImageindex != 0 ? true : false;
            button_NextImage.Visible = _currentImageindex != _otherImages.Count - 1 ? true : false;
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

        private void SetImage(string arg)
        {
            if (arg is null)
            {
                return;
            }

            if (! supportedExtensions.Contains(Path.GetExtension(arg).ToUpperInvariant()))
            {
                return;
            }

            _image = arg;
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

        private void ZoomImage_MouseWheel(object? sender, MouseEventArgs e)
        {
            //Debug.WriteLine(e.Delta);
            if (e.Delta > 0)
            {
                _imageHeight += 20;
                _imageWidth += 20;
                _zoomLevel++;
                int y = (_zoomLevel * 20) - (e.Y - 1);
                int x = (_zoomLevel * 20) - (e.X - 1);
                //PictureOpened.Location = new Point(x, y);
                PictureOpened.Size = new Size(_imageWidth, _imageHeight);

                //PictureOpened.Bounds = new Rectangle(0, 0, ImageWidth , ImageHeight);
                //PictureOpened.Location = new Point(PictureOpened.Location.X + e.X, PictureOpened.Location.Y + e.Y)
                _zoomModifier += 2;
            }
            else
            {
                _imageHeight -= 20;
                _imageWidth -= 20;
                _zoomModifier -= 2;
                _zoomLevel--;
                int y = e.Y - (_zoomLevel * 20);
                int x = e.X - (_zoomLevel * 20);
                //PictureOpened.Location = new Point(x, y);
                PictureOpened.Size = new Size(_imageWidth, _imageHeight);
                if (_zoomModifier == 0)
                {
                    PictureOpened.Location = new Point(0, 0);
                }
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

        private void button_NextImage_Click(object sender, EventArgs e)
        {
            SetImage(_otherImages[_currentImageindex + 1]);
            CheckForOtherImages();
        }

        private void button_PreviousImage_Click(object sender, EventArgs e)
        {

            SetImage(_otherImages[_currentImageindex - 1]);
            CheckForOtherImages();
        }
    }
}
