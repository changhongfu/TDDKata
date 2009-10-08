using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class SayController : Controller
    {
        public ActionResult Hello()
        {
            ViewData["Message"] = "Hello world!";
            return View();
        }
    }
}