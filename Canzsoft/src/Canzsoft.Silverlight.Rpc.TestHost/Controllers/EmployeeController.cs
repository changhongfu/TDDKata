using System.Web.Mvc;
using Canzsoft.Silverlight.Rpc.TestHost.Models;

namespace Canzsoft.Silverlight.Rpc.TestHost.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult List()
        {
            var employees = new[]
            {
                new Employee {Id = 1, FirstName = "Joe", LastName = "Smith"},
                new Employee {Id = 2, FirstName = "Jane", LastName = "Smith"},
                new Employee {Id = 3, FirstName = "John", LastName = "Smith"},
            };

            return new XmlResult(employees);
        }
    }
}