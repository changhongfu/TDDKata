using System;
using System.Web;
using Elmah;

namespace MvcDemo.ErrorHandling
{
    public class ElmahLogger : ILogger
    {
        public void Log(Exception ex)
        {
            var context = HttpContext.Current;
            ErrorLog.GetDefault(context).Log(new Error(ex, context));
        }
    }
}