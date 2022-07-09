using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.ViewModel
{
    internal class RegisterViewModel
    {
        public RegisterViewModel()
        {
        }

        public string UserName { get; set; }
        public string UserNameColor { get; set; }
        public string ImageSource { get; set; }
        public string Password { get; set; }
    }
}
