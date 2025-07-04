namespace Sefim
{
    public partial class AppShell : NaluShell
    {
        public AppShell(INavigationService navigationService) : base(navigationService, "main")
        {
            InitializeComponent();
        }
    }
}
