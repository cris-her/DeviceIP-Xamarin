using App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //string ipaddress = DependencyService.Get<IIPAddressManager>().GetIPAddress();
            BindingContext = new MainViewModel(DependencyService.Get<IIPAddressManager>());
        }

        protected override void OnAppearing()
        {
            (BindingContext as MainViewModel).OnAppeared();
            base.OnAppearing();
        }
    }
}
