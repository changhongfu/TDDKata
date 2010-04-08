using System;

namespace DemoApp.Shared.Views
{
    public interface IModuleMenuItemView
    {
        event EventHandler Clicked;
    }
}