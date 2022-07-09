using Server.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Server
{
    internal class Client
    {
        public Client(TcpClient clientSocet)
        {
            ClientSocet = clientSocet;
            UID = Guid.NewGuid();
            _packetReader = new PacketReader(clientSocet.GetStream());

            User = _packetReader.ReadObject<MessageModel>();

            Console.WriteLine($"[{DateTime.Now}]: {User.UserName} Connected!");

            Task.Run(() => Prosses());
        }

        public MessageModel User;
        PacketReader _packetReader;
        public Guid UID { get; set; }
        public TcpClient ClientSocet { get; set; }


        void Prosses()
        {
            while (true)
            {
                try
                {
                    var opcode = _packetReader.ReadByte();
                    switch (opcode)
                    {
                        case 5:
                            var message =_packetReader.ReadObject<SendMessageToModel>();
                            Console.WriteLine($"[{DateTime.Now}]: Message resived! from {message.uidFrom}({User.UserName}) to {message.uidTo} with message: {message.message}");
                            Program.SendMessage(message.uidFrom, message.uidTo, message.message);
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"[{DateTime.Now}] Client [{UID}]: Disconnected!");
                    Program.DisconectedMessage(UID.ToString());
                    ClientSocet.Close();
                    break;
                }
            }
        }
    }


    class SendMessageToModel
    {
        public string message { get; set; }
        public string uidFrom { get; set; }
        public string uidTo { get; set; }
    }

    class MessageModel
    {
        public string UserName { get; set; }
        public string UserNameColor { get; set; }
        public string ImageSource { get; set; }

        public string UID { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public bool IsNativeOrigen { get; set; }
        public bool? FirstMessage { get; set; }
    }
}
