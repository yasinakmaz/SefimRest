namespace Sefim.ViewModels
{
    public partial class MenuPageModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        public MenuPageModel(INavigationService navigationService) 
        {
            _navigationService = navigationService;
        }
        [RelayCommand]
        private async Task GoBack()
        {
            try
            {
                Navigation.Relative().Push<LoginPageModel>();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Navigation Hatası", ex.Message, "Tamam");
            }
        }
    }
}