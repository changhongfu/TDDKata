using System.Threading;
using System.Windows;
using Canzsoft.Silverlight.Rpc.Web;

namespace Canzsoft.Silverlight.TestApp
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SendRequestButtonClick(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(RunPostAsync);
        }

        private void RunPostAsync(object state)
        {
            var poster = new WebPoster();
            var responseString = poster.Post("<?xml version=\"1.0\" encoding=\"utf-8\"?>{0}<MyClass>{0}{1}<Id>1</Id>{0}</MyClass>");

            Dispatcher.BeginInvoke(() => resultTextBlock.Text = responseString);
        }
    }
}
