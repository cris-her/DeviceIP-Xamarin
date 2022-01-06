using App.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly IIPAddressManager _ipAddressManager;
        private String _ipAddress;
        public MainViewModel(IIPAddressManager ipAddressManager)
        {
            _ipAddressManager = ipAddressManager;
        }
        public String IpAddress
        {
            get => _ipAddress;
            set => Set(ref _ipAddress, value);
        }
        public void OnAppeared()
        {
            IpAddress = _ipAddressManager.GetIPAddress();
            //IpAddress = "Hello world";
        }

    }
}
