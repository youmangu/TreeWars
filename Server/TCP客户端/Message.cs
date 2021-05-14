using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP客户端
{
    class Message
    {
        public static byte[] GetBytes(string s)
        {
            byte[] content = Encoding.UTF8.GetBytes(s);
            int count = content.Length;
            byte[] length = BitConverter.GetBytes(count);
            byte[] newByte = length.Concat(content).ToArray();
            return content;
        }

    }
}
