using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatClient.Core;

namespace ChatClient.MVVM.Model
{
    class ContactModel
    {
        public ContactModel()
        {
            Messages = new ObservableCollection<MessageModel>();
        }

        public string UserName { get; set; }
        public string UID { get; set; }
        public string ImageSource { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }

        public string LastMessage => Messages.Last().Message;


    }
}
