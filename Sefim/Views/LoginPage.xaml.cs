namespace Sefim.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}