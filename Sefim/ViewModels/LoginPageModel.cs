namespace Sefim.ViewModels
{
    public partial class LoginPageModel : ObservableObject
    {
        [ObservableProperty]
        private string? password;

        private readonly AppDbContext _context;

        private readonly INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService, AppDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
        }

        [RelayCommand]
        private async Task LoginBtn(string? buttonText)
        {
            try
            {
                if (!string.IsNullOrEmpty(buttonText))
                {
                    Password += buttonText;
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAlert("LoginBtn Hatası", ex);
            }
        }

        [RelayCommand]
        private async Task Login()
        {
            try
            {
                if (string.IsNullOrEmpty(Password))
                {
                    await Shell.Current.DisplayAlert("Uyarı", "Lütfen şifrenizi girin", "Tamam");
                    return;
                }

                bool userExists = await _context.User
                    .Where(u => (u.Deleted == false || u.Deleted == null) && u.Password == Password)
                    .AnyAsync();

                if (userExists)
                {
                    await _navigationService.GoToAsync(Navigation.Absolute().ShellContent<MenuPageModel>());
                }
                else
                {
                    await Shell.Current.DisplayAlert("Sistem", "Giriş Başarısız", "Tamam");
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAlert("Login Hatası", ex);
            }
        }

        [RelayCommand]
        private async Task BtnClear()
        {
            try
            {
                Password = string.Empty;
            }
            catch (Exception ex)
            {
                await ShowErrorAlert("Clear Hatası", ex);
            }
        }

        private async Task ShowErrorAlert(string title, Exception ex)
        {
            await Shell.Current.DisplayAlert(title, ex.Message, "Tamam");

            bool copyError = await Shell.Current.DisplayAlert(
                "Sistem",
                "Hatayı Kopyalamak İstermisiniz?",
                "Evet", "Hayır"
            );

            if (copyError)
            {
                await Clipboard.SetTextAsync(ex.Message);
            }
        }
    }
}