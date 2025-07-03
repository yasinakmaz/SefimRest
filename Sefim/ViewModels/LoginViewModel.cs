namespace Sefim.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? password;

        private AppDbContext _context;
        public LoginViewModel() 
        {
            _context = new AppDbContext();
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
                await Shell.Current.DisplayAlert("Sistem", $"Genel Hata : {ex.Message}", "Tamam");
                bool answer = await Shell.Current.DisplayAlert("Sistem", "Hatayı Kopyalamak İstermisiniz", "Evet", "Hayır");
                if (answer)
                {
                    await Clipboard.SetTextAsync(ex.Message);
                }
            }
        }

        [RelayCommand]
        private async Task Login()
        {
            try
            {
                bool answer = await _context.User.Where(dl => dl.Deleted == false || dl.Deleted == null && dl.Password == Password).AnyAsync();

                if (answer)
                {
                    Nalu.Navigation.Relative().Push<MenuPage>();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Sistem", "Giriş Başarısız", "Tamam");
                }
            }
            catch (SqlException ex)
            {
                await Shell.Current.DisplayAlert("Sistem", $"Sql Hatası : {ex.Message}", "Tamam");
                bool answer = await Shell.Current.DisplayAlert("Sistem", "Hatayı Kopyalamak İstermisiniz", "Evet", "Hayır");
                if (answer)
                {
                    await Clipboard.SetTextAsync(ex.Message);
                }
            }
            catch (DbUpdateException ex)
            {
                await Shell.Current.DisplayAlert("Sistem", $"Veritabanı Hata : {ex.Message}", "Tamam");
                bool answer = await Shell.Current.DisplayAlert("Sistem", "Hatayı Kopyalamak İstermisiniz", "Evet", "Hayır");
                if (answer)
                {
                    await Clipboard.SetTextAsync(ex.Message);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Sistem", $"Genel Hata : {ex.Message}", "Tamam");
                bool answer = await Shell.Current.DisplayAlert("Sistem", "Hatayı Kopyalamak İstermisiniz", "Evet", "Hayır");
                if (answer)
                {
                    await Clipboard.SetTextAsync(ex.Message);
                }
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
                await Shell.Current.DisplayAlert("Sistem", $"Genel Hata : {ex.Message}", "Tamam");
                bool answer = await Shell.Current.DisplayAlert("Sistem", "Hatayı Kopyalamak İstermisiniz", "Evet", "Hayır");
                if (answer)
                {
                    await Clipboard.SetTextAsync(ex.Message);
                }
            }
        }
    }
}
