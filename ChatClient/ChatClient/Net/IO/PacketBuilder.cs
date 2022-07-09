using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net.IO
{
    internal class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }
        public void WriteOpCode(byte opCode)
        {
            _ms.WriteByte(opCode);
        }
        public void WriteObject(object o)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(o);
            _ms.Write(BitConverter.GetBytes(json.Length));
            _ms.Write(Encoding.ASCII.GetBytes(json));
        }
        public void WriteString(string str)
        {
            _ms.Write(BitConverter.GetBytes(str.Length));
            _ms.Write(Encoding.ASCII.GetBytes(str));
        }
        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }

    }
}
