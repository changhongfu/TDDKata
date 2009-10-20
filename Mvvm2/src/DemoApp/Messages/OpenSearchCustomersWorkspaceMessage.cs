using Quark.Tools.Wpf.Events;

namespace DemoApp.Messages
{
    public class OpenSearchCustomersWorkspaceMessage : IMessage
    {
        public static OpenSearchCustomersWorkspaceMessage Instance = new OpenSearchCustomersWorkspaceMessage();
    }
}