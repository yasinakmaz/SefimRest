namespace Sefim.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage(MenuPageModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}