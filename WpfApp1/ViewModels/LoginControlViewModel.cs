using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    [ObservableObject]
    public partial class LoginControlViewModel
    {
        [ObservableProperty]
        private ObservableCollection<String> _emails;

        public LoginControlViewModel()
        {
            Emails = new ObservableCollection<String>()
            {
                "test1",
                "test2"
            };
        }
    }
}
