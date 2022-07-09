using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ChatClient.Core;
using ChatClient.MVVM.Model;
using ChatClient.Net;

namespace ChatClient.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /*Net*/

        
        Server _server { get; set; }


        /* Commands */

        public RelayCommand SendCommand { get; set; }
        public RelayCommand ConnectToServer { get; set; }
        
        
        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value; OnPropertyChanged(); }
        }
        
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        public MessageModel ClientUser;

        public string UserName { get; set; }

        public MainViewModel()
        {
            
            ClientUser = new MessageModel()
            {
                UserName = "",
                UserNameColor = "#a83232",
                ImageSource = "https://i.imgur.com/AD3MbBi.jpeg",
            };

            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();
            _server = new Server();

            _server.connectedEvent += UserConnected;
            _server.messageRecivedEvent += MessageRecived;
            _server.userDisconnectEvent += UserDisconnected;

            ConnectToServer = new RelayCommand(o =>
            {
                ClientUser.UserName = UserName;
                _server.ConnectToServer(ClientUser);
            }, o => !string.IsNullOrEmpty(UserName));

            SendCommand = new RelayCommand(o =>
            {
                _server.SendMessageToServer(new SendMessageToModel()
                {
                    message = Message,
                    uidFrom = ClientUser.UID,
                    uidTo = SelectedContact.UID,
                });

                SelectedContact.Messages.Add(new MessageModel()
                {
                    UserName = ClientUser.UserName,
                    UserNameColor = "#a83232",
                    ImageSource = "https://i.imgur.com/AD3MbBi.jpeg",
                    Time = DateTime.Now,
                    Message = Message,
                    FirstMessage = true,
                });

                Message = string.Empty;

            }, o => !string.IsNullOrEmpty(Message));


        }

        private void MessageRecived()
        {
            var message = _server.PacketReader.ReadObject<MessageModel>();
            message.FirstMessage = true;
            message.Time = DateTime.Now;
            var messageTo = _server.PacketReader.ReadString();

            Application.Current.Dispatcher.Invoke(() =>{
                foreach (var contact in Contacts)
                {
                    if (contact.UID == messageTo)
                    {
                        contact.Messages.Add(message);
                    }
                }
            });
            
        }
        private void UserDisconnected() 
        {
            var uid = _server.PacketReader.ReadString();
            var contact = Contacts.Where(x => x.UID == uid).FirstOrDefault();
            Application.Current.Dispatcher.Invoke(() => Contacts.Remove(contact));
        }

        public void UserConnected()
        {
            var usr = _server.PacketReader.ReadObject<MessageModel>();
            usr.UID = _server.PacketReader.ReadString();

            if (usr.UserName == ClientUser.UserName)
            {
                ClientUser.UID = usr.UID;
                return;
            }
            if (!Contacts.Any(x => x.UID == usr.UID))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Contacts.Add(new ContactModel()
                    {
                        UserName = usr.UserName,
                        UID = usr.UID,
                        ImageSource = usr.ImageSource,
                        Messages = new ObservableCollection<MessageModel>()
                    }) ;
                });
            }
        }
    }
}
