using System;
using NUnit.Framework;
using Rhino.Mocks;
using Canzsoft.Silverlight.Rpc;
using Canzsoft.Silverlight.Rpc.Messaging;
using Canzsoft.Silverlight.Rpc.Serialization;
using Canzsoft.Silverlight.Rpc.Web;

namespace Canzsoft.Silverlight.UnitTests.Rpc
{
    [TestFixture]
    public class ServiceProxyTest
    {
        private IXmlSerializer _serializer;
        private IWebPoster _poster;

        [Test]
        public void Invoke_SerializeRequestToXml()
        {
            var serviceProxy = CreateServiceProxy();

            var request = new Request();
            serviceProxy.Invoke<Response>(request);

            _serializer.AssertWasCalled(s => s.Serialize(request));
        }

        [Test]
        public void Invoke_DeserializeToResponse()
        {
            var serviceProxy = CreateServiceProxy();
            _poster.Stub(p => p.Post(String.Empty)).IgnoreArguments().Return("abc").Repeat.Any();

            serviceProxy.Invoke<Response>(new Request());

            _serializer.AssertWasCalled(s => s.Deserialize<Response>("abc"));
        }

        [Test]
        public void Invoke_ReturnDeserializedObject()
        {
            var serviceProxy = CreateServiceProxy();
            var expectedResponse = new Response();
            _serializer.Stub(s => s.Deserialize<Response>(String.Empty)).IgnoreArguments().Return(expectedResponse).Repeat.Any();

            var resultResponse = serviceProxy.Invoke<Response>(new Request());

            Assert.AreEqual(expectedResponse, resultResponse);
        }


        private  ServiceProxy CreateServiceProxy()
        {
            _serializer = MockRepository.GenerateStub<IXmlSerializer>();
            _serializer.Stub(s => s.Serialize<Request>(null)).IgnoreArguments().Return(String.Empty);
            _serializer.Stub(s => s.Deserialize<Response>(String.Empty)).IgnoreArguments().Return(null);

            _poster = MockRepository.GenerateStub<IWebPoster>();
            _poster.Stub(p => p.Post(String.Empty)).IgnoreArguments().Return(String.Empty);

            return new ServiceProxy(_poster);
        }
    }
}