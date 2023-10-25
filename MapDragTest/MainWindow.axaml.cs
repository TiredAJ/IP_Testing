using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Diagnostics;
using SD =  System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Avalonia;

namespace MapDragTest
{
    public partial class MainWindow : Window
    {
        public Point Start { get; set; } = new Point(0,0);
        public Point End { get; set; } = new Point(0, 0);

        public MainWindow()
        {
            InitializeComponent();

            GenerateImage(Properties.Resources.Fox, img_Main);

            img_Main.Stretch = Stretch.Uniform;

            cnvs_Main.PointerPressed += Cnvs_Main_PointerPressed;
            cnvs_Main.PointerReleased += Cnvs_Main_PointerReleased;
            cnvs_Main.PointerMoved += Cnvs_Main_PointerMoved;
        }

        private void Cnvs_Main_PointerMoved(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Cnvs_Main_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
        {End = e.GetPosition(cnvs_Main);}

        private void Cnvs_Main_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {Start = e.GetPosition(cnvs_Main);}

        public void GenerateImage(byte[] _Data, Image _Ctrl)
        {
            using (Stream S = new MemoryStream(_Data))
            { _Ctrl.Source = new Bitmap(S); }
        }

        public void GenerateImage(SD.Bitmap _Data, Image _Ctrl)
        {
            using (MemoryStream S = new MemoryStream())
            {
                _Data.Save(S, SD.Imaging.ImageFormat.Png);
                GenerateImage(S.ToArray(), _Ctrl);
            }
        }
    }
}