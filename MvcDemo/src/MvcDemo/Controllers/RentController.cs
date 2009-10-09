using System.Linq;
using System.Web.Mvc;
using MvcDemo.Models;
using MvcDemo.Services;

namespace MvcDemo.Controllers
{
    public class RentController : Controller
    {
        private readonly IPropertyService _service;

        public RentController() : this(new InMemoryPropertyService())
        {
        }

        //Testing constructor for DI
        public RentController(IPropertyService service)
        {
            _service = service;
        }

        public ActionResult List()
        {
            ViewData.Model = _service.GetProperties();
            return View();
        }

        public ActionResult Create()
        {
            ViewData["Properties"] = _service.GetProperties().ToArray();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(RentalProperty propertyToCreate)
        {
            _service.CreateProperty(propertyToCreate);
            if (Request.IsAjaxRequest())
            {
                return PartialView("PropertyPartial", propertyToCreate);
            }
            return RedirectToAction("List");
        }
    }
}