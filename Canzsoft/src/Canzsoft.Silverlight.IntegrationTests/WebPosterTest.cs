using System;
using Canzsoft.Silverlight.Rpc.Web;
using NUnit.Framework;

namespace Canzsoft.Silverlight.IntegrationTests
{
    [TestFixture]
    public class WebPosterTest
    {
        public void TestPost()
        {
            var poster = new WebPoster();


            var responseString = poster.Post(String.Empty);

            Assert.IsNotNullOrEmpty(responseString);
        }
    }
}