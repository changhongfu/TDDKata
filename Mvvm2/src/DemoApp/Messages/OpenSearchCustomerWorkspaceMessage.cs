using Quark.Tools.Wpf.Events;

namespace DemoApp.Messages
{
    public class OpenSearchCustomerWorkspaceMessage : IMessage
    {
        public static OpenSearchCustomerWorkspaceMessage Instance = new OpenSearchCustomerWorkspaceMessage();
    }
}