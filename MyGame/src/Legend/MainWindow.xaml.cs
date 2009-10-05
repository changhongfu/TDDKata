using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Legend
{
    public partial class MainWindow
    {
        private int count = 1;
        private readonly Image spirit;
        private readonly DispatcherTimer dispatcherTimer;

        private Storyboard storyboard;


        public MainWindow()
        {
            InitializeComponent();

            spirit = new Image { Width = 150, Height = 150 };
            Carrier.Children.Add(spirit);
            Canvas.SetLeft(spirit, 0);
            Canvas.SetTop(spirit, 0);
            dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(150) };
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
            //bitmapFrame = BitmapFrame.Create(new Uri("pack://application:,,,/Images/Player/PlayerMagic.png"));
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (storyboard != null && storyboard.GetCurrentTime() == TimeSpan.FromSeconds(1))
            {
                spirit.Source = new BitmapImage((new Uri(@"Images\Player\0.png", UriKind.Relative)));
                count = 0;
            }
            else
            {
                spirit.Source = new BitmapImage((new Uri(@"Images\Player\" + count + ".png", UriKind.Relative)));
                count = count == 7 ? 0 : count + 1;
            }
            
        }

        private void Carrier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(Carrier);
            MoveTo(position);
        }

        private void MoveTo(Point position)
        {
            storyboard = new Storyboard();

            DoubleAnimation doubleAnimation = new DoubleAnimation(Canvas.GetLeft(spirit), position.X, new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(doubleAnimation, spirit);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.LeftProperty));

            storyboard.Children.Add(doubleAnimation);

            doubleAnimation = new DoubleAnimation(Canvas.GetTop(spirit), position.Y, new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(doubleAnimation, spirit);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.TopProperty));

            storyboard.Children.Add(doubleAnimation);

            if (!Resources.Contains("rectAnimation"))
            {
                Resources.Add("rectAnimation", storyboard);
            }

            storyboard.Begin();
        }
    }
}