using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using Contract;

namespace SilverlightClient.Core
{
    [DebuggerStepThrough()]
    public class LoadEmployeesCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly object[] results;

        public LoadEmployeesCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public EmployeeInfo[] Result
        {
            get
            {
                RaiseExceptionIfNecessary();
                return ((EmployeeInfo[]) (results[0]));
            }
        }
    }
}