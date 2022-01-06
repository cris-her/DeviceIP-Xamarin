using App.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace App
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly IIPAddressManager _ipAddressManager;
        private string _ipAddress;
        public MainViewModel(IIPAddressManager ipAddressManager)
        {
            _ipAddressManager = ipAddressManager;
        }
        public string IpAddress
        {
            get => _ipAddress;
            set => Set(ref _ipAddress, value);
        }
        public void OnAppeared()
        {
            //IpAddress = _ipAddressManager.GetIPAddress();
            //IpAddress = "Hello world";
            getExternalIp();
        }

        public string getExternalIp()
        {
            try
            {
                //string externalIP;
                IpAddress = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
                IpAddress = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                             .Matches(IpAddress)[0].ToString();
                return IpAddress;
            }
            catch { return null; }
        }

    }
}
