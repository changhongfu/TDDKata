using System;
using System.Web.Mvc;
using MvcDemo.ErrorHandling;

namespace MvcDemo.Controllers
{
    [HandleErrorWithElmah]
    public class SayController : Controller
    {
        private readonly ILogger _logger;

        public SayController() : this(new ElmahLogger())
        {
        }

        public SayController(ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult Hello()
        {
            try
            {
                throw new Exception("Error happen when trying to say hello, But I will catch it...");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }
            
            ViewData["Message"] = "Hello world!";
            return View();
        }
    }
}