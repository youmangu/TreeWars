using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace GameServer.Servers
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
        public void ReadMessage(int newDataAmount, Action<RequestCode, ActionCode, string> processCodeCallBack)
        {
            startIndex += newDataAmount;
            while (true)
            {
                if (startIndex <= 4) return;
                int count = BitConverter.ToInt32(data, 0);
                if ((startIndex - 4) >= count)
                {
                    RequestCode requestCode = (RequestCode)BitConverter.ToInt32(data, 4);
                    ActionCode  actionCode = (ActionCode)BitConverter.ToInt32(data, 8);
                    string s = Encoding.UTF8.GetString(data, 12, count - 8);
                    processCodeCallBack(requestCode, actionCode, s);
                    Array.Copy(data, count + 4, data, 0, startIndex - 4 - count);
                    startIndex -= (count + 4);
                }
                else
                {
                    return;
                }
            }
        }

        public static byte[] PackData(RequestCode requestCode, string data)
        {
            byte[] requestCodeBytes = BitConverter.GetBytes((int)requestCode);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            int dataCount = requestCodeBytes.Length + dataBytes.Length;
            byte[] dataCountBytes = BitConverter.GetBytes(dataCount);
            dataCountBytes.Concat(requestCodeBytes).Concat(dataCountBytes);
            return dataCountBytes;
        }
    }
}
