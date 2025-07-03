namespace Sefim.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductGroup { get; set; }
        public string? ProductCode { get; set; }
        public string? Order { get; set; }
        public decimal? Price { get; set; }
        public decimal? VatRate { get; set; }
        public bool? FreeItem { get; set; }
        public string? InvoiceName { get; set; }
        public string? ProductType { get; set; }
        public string? Plu { get; set; }
        public bool? SkipOptionSelection { get; set; }
        public string? Favorites { get; set; }
        public bool? Aktarildi { get; set; }
        public bool? IsSynced { get; set; }
        public bool? IsUpdated { get; set; }
        public string? IstisnaKodu { get; set; }
        public string? OzelMatrahKodu { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Toplam { get; set; }
        [NotMapped]
        public ICommand? DeleteCommand { get; set; }
        public string? ColorCode { get; set; }

        private bool _isSelected;
        public bool choose
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(choose));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
