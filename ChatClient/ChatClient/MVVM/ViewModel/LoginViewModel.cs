using ChatClient.Core;
using ChatClient.MVVM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatClient.MVVM.ViewModel
{
    internal class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public RelayCommand Login { get; set; }
        public LoginViewModel()
        {
            Login = new RelayCommand(o =>{
                MessageBox.Show(UserName + " " + Password);
            });
        }
    }
}
