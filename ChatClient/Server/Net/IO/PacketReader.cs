using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Net.IO
{
    internal class PacketReader : BinaryReader
    {
        private NetworkStream _ns;
        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }
        public string ReadMessage()
        {
            byte[] msgbuffer;
            var lenght = ReadInt32();
            msgbuffer = new byte[lenght];
            _ns.Read(msgbuffer, 0, lenght);

            return Encoding.ASCII.GetString(msgbuffer);
        }

        public T ReadObject<T>()
        {
            byte[] msgbuffer;
            var lenght = ReadInt32();
            msgbuffer = new byte[lenght];
            _ns.Read(msgbuffer, 0, lenght);

            var json = Encoding.ASCII.GetString(msgbuffer);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
