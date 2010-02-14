using System;
using Canzsoft.Silverlight.Rpc.Web;
using NUnit.Framework;

namespace Canzsoft.Silverlight.UnitTests.Rpc
{
    [TestFixture]
    public class WebPosterTest
    {
        [Test]
        public void Post()
        {
            var poster = new WebPoster();

            var result = poster.Post(String.Empty);

            Assert.IsNotNullOrEmpty(result);
        }
    }
}