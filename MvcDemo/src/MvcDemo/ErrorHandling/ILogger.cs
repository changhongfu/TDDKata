using System;

namespace MvcDemo.ErrorHandling
{
    public interface ILogger
    {
        void Log(Exception ex);
    }
}