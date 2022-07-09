using Server.Net.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static List<Client> _clients;
        static TcpListener _listener;
        static void Main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"),8080);
            _clients = new List<Client>();
            _listener.Start();

            while (true)
            {
                var client = new Client(_listener.AcceptTcpClient());
                _clients.Add(client);
                BrodcastMessage();
            }
            
        }

        public static void BrodcastMessage()
        {
            foreach (var user in _clients)
            {
                foreach (var usr in _clients)
                {
                    var brodcast = new PacketBuilder();
                    brodcast.WriteOpCode(1);
                    brodcast.WriteObject(usr.User);
                    brodcast.WriteString(usr.UID.ToString());
                    user.ClientSocet.Client.Send(brodcast.GetPacketBytes());
                }
            }
        }
        
        public static void SendMessage(string uidfrom, string uidto, string message)
        {
            var brodcast = new PacketBuilder();
            var clientFound = _clients.Find(x => x.UID.ToString() == uidfrom);
            
            MessageModel messageModel = new() {
                UserName = clientFound.User.UserName,
                UserNameColor = clientFound.User.UserNameColor,
                ImageSource = clientFound.User.ImageSource,
                Message = message, 
                Time = DateTime.Now,
                FirstMessage = false,
            };
            
            brodcast.WriteOpCode(5);
            brodcast.WriteObject(messageModel);
            brodcast.WriteString(uidfrom);
            foreach (var user in _clients)
            {
                if (user.UID.ToString() == uidto)
                {
                    user.ClientSocet.Client.Send(brodcast.GetPacketBytes());
                    Console.WriteLine("Message sent to " + uidto);
                }
            }
        }
        public static void DisconectedMessage(string uid)
        {
            var disconectedUser = _clients.Where(x => x.UID.ToString() == uid).FirstOrDefault();
            _clients.Remove(disconectedUser);
            foreach (var user in _clients)
            {
                var brodcast = new PacketBuilder();
                brodcast.WriteOpCode(10);
                brodcast.WriteString(uid);
                user.ClientSocet.Client.Send(brodcast.GetPacketBytes());
            }
        }
        
    }
}