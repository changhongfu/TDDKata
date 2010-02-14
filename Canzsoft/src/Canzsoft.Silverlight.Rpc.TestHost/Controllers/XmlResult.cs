using System.Web.Mvc;

namespace Canzsoft.Silverlight.Rpc.TestHost.Controllers
{
    public class XmlResult : ActionResult
    {
        private readonly object _objectToSerialize;

        public XmlResult(object objectToSerialize)
        {
            _objectToSerialize = objectToSerialize;
        }

        public object ObjectToSerialize
        {
            get { return _objectToSerialize; }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (_objectToSerialize != null)
            {
                context.HttpContext.Response.Clear();
                var xs = new System.Xml.Serialization.XmlSerializer(_objectToSerialize.GetType());
                context.HttpContext.Response.ContentType = "text/xml";
                xs.Serialize(context.HttpContext.Response.Output, _objectToSerialize);
            }
        }
    }
}