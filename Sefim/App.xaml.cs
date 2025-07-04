namespace Sefim
{
    public partial class App : Application
    {
        public App(INavigationService navigationService)
        {
            InitializeComponent();
            MainPage = new AppShell(navigationService);
        }

        /*protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }*/
    }
}