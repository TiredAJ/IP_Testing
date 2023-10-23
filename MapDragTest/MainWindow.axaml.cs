using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System.IO;

namespace MapDragTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //GenerateImage(Properties.Resources.Fox., img_Main);

            img_Main.Source = new Bitmap(Properties.Resources.Fox);
        }

        public void GenerateImage(byte[] _Data, Image _Ctrl)
        {
            using (Stream S = new MemoryStream(_Data))
            { _Ctrl.Source = new Bitmap(S); }
        }
    }
}