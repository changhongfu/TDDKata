using System;
using System.Web.Mvc;
using NUnitAssert = NUnit.Framework.Assert;

namespace MvcDemo.Tests
{
    public static class AssertExtensions
    {
        public static void Assert(this Controller controller, HasError error)
        {
            NUnitAssert.AreEqual(error.ErrorMessage, controller.ModelState[error.Key].Errors[0].ErrorMessage);
        }

        public static void Assert(this ActionResult result, Direct direct)
        {
            NUnitAssert.AreEqual(typeof(ViewResult), result.GetType());
            NUnitAssert.AreEqual(direct.Name, ((ViewResult)result).ViewName);
        }

        public static void Assert(this ActionResult result, Redirect redirect)
        {
            NUnit.Framework.Assert.AreEqual(typeof(RedirectToRouteResult), result.GetType());
            if (!String.IsNullOrEmpty(redirect.ActionName))
            {
                NUnitAssert.AreEqual(redirect.ActionName, ((RedirectToRouteResult)result).RouteValues["Action"]);
            }
            if (!String.IsNullOrEmpty(redirect.ControllerName))
            {
                NUnitAssert.AreEqual(redirect.ControllerName, ((RedirectToRouteResult)result).RouteValues["Controller"]);
            }
        }
    }

    public class Redirect
    {
        public string ActionName { get; private set; }
        public string ControllerName { get; private set; }

        private Redirect()
        {
        }

        public static Redirect To
        {
            get { return new Redirect(); }
        }

        public Redirect Action(string actionName)
        {
            ActionName = actionName;
            return this;
        }

        public Redirect Controller(string controllerName)
        {
            ControllerName = controllerName;
            return this;
        }
    }

    public class Direct
    {
        public string Name { get; private set; }

        private Direct()
        {
        }

        public static Direct To
        {
            get { return new Direct(); }
        }

        public Direct DefaultView()
        {
            Name = String.Empty;
            return this;
        }

        public Direct View(string viewName)
        {
            Name = viewName;
            return this;
        }
    }

    public class HasError
    {
        public string Key { get; private set; }
        public string ErrorMessage { get; private set; }

        private HasError()
        {
        }

        public static HasError On(string fieldName)
        {
            var error = new HasError { Key = fieldName };
            return error;
        }

        public HasError WithMessage(string errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }
    }
}