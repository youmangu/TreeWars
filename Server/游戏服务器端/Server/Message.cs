using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Server
{
    class Message
    {
        private byte[] data = new byte[1024];
        private int startIndex = 0; // 从数组的哪个位置开始

        //public void AddCount(int count)
        //{
        //    startIndex += count;
        //}

        public byte[] Data { get { return data; } }
        public int StartIndex { get { return startIndex; } }
        public int RemainSize
        {
            get
            {
                return data.Length - startIndex;
            }
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        public void ReadMessage(int newDataAmount)
        {
            startIndex += newDataAmount;
            while (true)
            {
                if (startIndex <= 4) return;
                int count = BitConverter.ToInt32(data, 0);
                if ((startIndex - 4) >= count)
                {
                    string s = Encoding.UTF8.GetString(data, 4, count);
                    Console.WriteLine("解析的数据： " + s);
                    Array.Copy(data, count + 4, data, 0, startIndex - 4);
                    startIndex -= (count + 4);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
