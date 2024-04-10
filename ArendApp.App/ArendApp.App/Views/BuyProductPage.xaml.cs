using ArendApp.App.Models;
using ArendApp.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArendApp.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyProductPage : ContentPage
    {
        public ICommand BuyCommand { get; }
        public string CalculatedPrice { get => _calculatedPrice; 
            set 
            {
                _calculatedPrice = value;
                OnPropertyChanged(nameof(CalculatedPrice));
            } 
        }
        private string _calculatedPrice = "";

        
        public int LabelGridColumn
        {
            get => _labelGridColumn;
            set
            {
                _labelGridColumn = value - 1;
                OnPropertyChanged(nameof(LabelGridColumn));
            }
        }
        private int _labelGridColumn  = 0;


        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        private Product _product;

        public IApiService _apiService => DependencyService.Get<IApiService>();
        public IDataStorage DataStorage => DependencyService.Get<IDataStorage>();
        public BuyProductPage(Product product)
        {
            Product = product;
            InitializeComponent();
            BuyCommand = new Command(async () =>
            {
                DateTime endperiod = DateTime.Now;
                await _apiService.BuyProduct(_product.Id, endperiod);
                await DisplayAlert("Куплено!", "Вы успешно купили товар", "Ок");
                App.Current.MainPage = new AppShell();
            });
            CalculatedPrice = $"Итого: {_product.OncePrice}";
            this.BindingContext = this;
        }
    }
}