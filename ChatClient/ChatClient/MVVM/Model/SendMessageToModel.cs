using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.Model
{
    internal class SendMessageToModel
    {
        public string message { get; set; }
        public string uidFrom { get; set; }
        public string uidTo { get; set; }
    }
}
