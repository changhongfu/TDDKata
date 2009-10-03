using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Legend
{
    public partial class MainWindow
    {
        private int count = 1;
        private readonly Image spirit;
        private readonly DispatcherTimer dispatcherTimer;
        private readonly BitmapFrame bitmapFrame;

        private bool runing;

        public MainWindow()
        {
            InitializeComponent();

            spirit = new Image {Width = 150, Height = 150};
            Carrier.Children.Add(spirit);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(150);
            //dispatcherTimer.Start();

            bitmapFrame = BitmapFrame.Create(new Uri("pack://application:,,,/Images/Player/PlayerMagic.png"));
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //spirit.Source = new BitmapImage((new Uri(@"Images\Player\" + count + ".png", UriKind.Relative)));
            //count = count == 7 ? 0 : count + 1;

            //var image = new BitmapImage(new Uri("pack://application:,,,/Images/Player/PlayerMagic.png"));

            

            //spirit.Source = CutImage("pack://application:,,,/Images/Player/PlayerMagic.png", count * 150, 0, 150, 150);

            spirit.Source = CutImage(count * 150, 0, 150, 150);
            count = count == 9 ? 0 : count + 1;
        }

        private BitmapSource CutImage(int x, int y, int width, int height)
        {
            return new CroppedBitmap(bitmapFrame, new Int32Rect(x, y, width, height));
        }

        private void Carrier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (runing)
            {
                dispatcherTimer.Stop();
            }
            else
            {
                dispatcherTimer.Start();
            }
            runing = !runing;
        }
    }
}