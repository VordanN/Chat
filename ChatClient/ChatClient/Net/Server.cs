using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ChatClient.MVVM.Model;
using ChatClient.Net.IO;

namespace ChatClient.Net
{
    internal class Server
    {
        TcpClient _client;
        public PacketReader PacketReader;

        public event Action connectedEvent;
        public event Action messageRecivedEvent;
        public event Action userDisconnectEvent;
        
        public Server()
        {
            _client = new TcpClient();
        }
        public void ConnectToServer(MessageModel message)
        {
            if (!_client.Connected)
            {
                _client.Connect("127.0.0.1", 8080);
                PacketReader = new PacketReader(_client.GetStream());
                var connectPacket = new PacketBuilder();
                connectPacket.WriteOpCode(0);
                connectPacket.WriteObject(message);
                _client.Client.Send(connectPacket.GetPacketBytes());

                ReadPackets();
            }
            
        }

        public void SendMessageToServer(SendMessageToModel message)
        {
            if (_client.Connected)
            {
                var packet = new PacketBuilder();
                packet.WriteOpCode(5);
                packet.WriteObject(message);
                _client.Client.Send(packet.GetPacketBytes());
            }
        }

        private void ReadPackets()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var opcode = PacketReader.ReadByte();
                    switch (opcode)
                    {
                        case 1:
                            connectedEvent?.Invoke();
                            break;
                        case 5:
                            messageRecivedEvent?.Invoke();
                            break;
                        case 10:
                            userDisconnectEvent?.Invoke();
                            break;
                        default:
                            break;
                    }
                }
            });
        }
    }
}
