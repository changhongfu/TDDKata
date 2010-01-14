using System;
using System.ComponentModel;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using Contract;

namespace SilverlightClient.Core
{
    public class EmployeeServiceClient : ClientBase<IEmployeeService>, IEmployeeService
    {
        private BeginOperationDelegate onBeginCloseDelegate;
        private BeginOperationDelegate onBeginLoadEmployeesDelegate;

        private BeginOperationDelegate onBeginOpenDelegate;
        private SendOrPostCallback onCloseCompletedDelegate;
        private EndOperationDelegate onEndCloseDelegate;
        private EndOperationDelegate onEndLoadEmployeesDelegate;

        private EndOperationDelegate onEndOpenDelegate;
        private SendOrPostCallback onLoadEmployeesCompletedDelegate;

        private SendOrPostCallback onOpenCompletedDelegate;

        public EmployeeServiceClient()
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public EmployeeServiceClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public CookieContainer CookieContainer
        {
            get
            {
                var httpCookieContainerManager = InnerChannel.GetProperty<IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null))
                {
                    return httpCookieContainerManager.CookieContainer;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                var httpCookieContainerManager = InnerChannel.GetProperty<IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null))
                {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else
                {
                    throw new InvalidOperationException(
                        "Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                        "ookieContainerBindingElement.");
                }
            }
        }

        #region IEmployeeService Members

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult IEmployeeService.BeginLoadEmployees(AsyncCallback callback, object asyncState)
        {
            return Channel.BeginLoadEmployees(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        EmployeeInfo[] IEmployeeService.EndLoadEmployees(IAsyncResult result)
        {
            return Channel.EndLoadEmployees(result);
        }

        #endregion

        public event EventHandler<LoadEmployeesCompletedEventArgs> LoadEmployeesCompleted;

        public event EventHandler<AsyncCompletedEventArgs> OpenCompleted;

        public event EventHandler<AsyncCompletedEventArgs> CloseCompleted;

        private IAsyncResult OnBeginLoadEmployees(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((IEmployeeService) (this)).BeginLoadEmployees(callback, asyncState);
        }

        private object[] OnEndLoadEmployees(IAsyncResult result)
        {
            EmployeeInfo[] retVal = ((IEmployeeService) (this)).EndLoadEmployees(result);
            return new object[]
                       {
                           retVal
                       };
        }

        private void OnLoadEmployeesCompleted(object state)
        {
            if ((LoadEmployeesCompleted != null))
            {
                var e = ((InvokeAsyncCompletedEventArgs) (state));
                LoadEmployeesCompleted(this,
                                       new LoadEmployeesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }

        public void LoadEmployeesAsync()
        {
            LoadEmployeesAsync(null);
        }

        public void LoadEmployeesAsync(object userState)
        {
            if ((onBeginLoadEmployeesDelegate == null))
            {
                onBeginLoadEmployeesDelegate = new BeginOperationDelegate(OnBeginLoadEmployees);
            }
            if ((onEndLoadEmployeesDelegate == null))
            {
                onEndLoadEmployeesDelegate = new EndOperationDelegate(OnEndLoadEmployees);
            }
            if ((onLoadEmployeesCompletedDelegate == null))
            {
                onLoadEmployeesCompletedDelegate = new SendOrPostCallback(OnLoadEmployeesCompleted);
            }
            InvokeAsync(onBeginLoadEmployeesDelegate, null, onEndLoadEmployeesDelegate,
                             onLoadEmployeesCompletedDelegate, userState);
        }

        private IAsyncResult OnBeginOpen(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((ICommunicationObject) (this)).BeginOpen(callback, asyncState);
        }

        private object[] OnEndOpen(IAsyncResult result)
        {
            ((ICommunicationObject) (this)).EndOpen(result);
            return null;
        }

        private void OnOpenCompleted(object state)
        {
            if ((OpenCompleted != null))
            {
                var e = ((InvokeAsyncCompletedEventArgs) (state));
                OpenCompleted(this, new AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }

        public void OpenAsync()
        {
            OpenAsync(null);
        }

        public void OpenAsync(object userState)
        {
            if ((onBeginOpenDelegate == null))
            {
                onBeginOpenDelegate = new BeginOperationDelegate(OnBeginOpen);
            }
            if ((onEndOpenDelegate == null))
            {
                onEndOpenDelegate = new EndOperationDelegate(OnEndOpen);
            }
            if ((onOpenCompletedDelegate == null))
            {
                onOpenCompletedDelegate = new SendOrPostCallback(OnOpenCompleted);
            }
            InvokeAsync(onBeginOpenDelegate, null, onEndOpenDelegate, onOpenCompletedDelegate, userState);
        }

        private IAsyncResult OnBeginClose(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((ICommunicationObject) (this)).BeginClose(callback, asyncState);
        }

        private object[] OnEndClose(IAsyncResult result)
        {
            ((ICommunicationObject) (this)).EndClose(result);
            return null;
        }

        private void OnCloseCompleted(object state)
        {
            if ((CloseCompleted != null))
            {
                var e = ((InvokeAsyncCompletedEventArgs) (state));
                CloseCompleted(this, new AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }

        public void CloseAsync()
        {
            CloseAsync(null);
        }

        public void CloseAsync(object userState)
        {
            if ((onBeginCloseDelegate == null))
            {
                onBeginCloseDelegate = new BeginOperationDelegate(OnBeginClose);
            }
            if ((onEndCloseDelegate == null))
            {
                onEndCloseDelegate = new EndOperationDelegate(OnEndClose);
            }
            if ((onCloseCompletedDelegate == null))
            {
                onCloseCompletedDelegate = new SendOrPostCallback(OnCloseCompleted);
            }
            InvokeAsync(onBeginCloseDelegate, null, onEndCloseDelegate, onCloseCompletedDelegate, userState);
        }

        protected override IEmployeeService CreateChannel()
        {
            return new EmployeeServiceClientChannel(this);
        }

        #region Nested type: EmployeeServiceClientChannel

        private class EmployeeServiceClientChannel : ChannelBase<IEmployeeService>, IEmployeeService
        {
            public EmployeeServiceClientChannel(ClientBase<IEmployeeService> client) :
                base(client)
            {
            }

            #region IEmployeeService Members

            public IAsyncResult BeginLoadEmployees(AsyncCallback callback, object asyncState)
            {
                var _args = new object[0];
                IAsyncResult _result = BeginInvoke("LoadEmployees", _args, callback, asyncState);
                return _result;
            }

            public EmployeeInfo[] EndLoadEmployees(IAsyncResult result)
            {
                var _args = new object[0];
                var _result = ((EmployeeInfo[]) (EndInvoke("LoadEmployees", _args, result)));
                return _result;
            }

            #endregion
        }

        #endregion
    }
}