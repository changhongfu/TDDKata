namespace DemoApp
{
    public class ShellPresenter
    {
        public ShellPresenter(IShellView view)
        {
            View = view;
        }

        public IShellView View { get; private set; }

        public void ShowView()
        {
            View.ShowView();
        }
    }
}