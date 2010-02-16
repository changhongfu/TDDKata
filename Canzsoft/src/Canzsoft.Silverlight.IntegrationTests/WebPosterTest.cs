using System.Threading;
using Canzsoft.Silverlight.Rpc.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canzsoft.Silverlight.IntegrationTests
{
    [TestClass]
    public class WebPosterTest
    {
        [TestMethod]
        public void TestPost()
        {
            ThreadPool.QueueUserWorkItem(RunPostAnsyc);
        }

        private static void RunPostAnsyc(object state)
        {
            var poster = new WebPoster();
            var responseString = poster.Post(string.Empty);
            Assert.IsNotNull(responseString);
        }
    }
}