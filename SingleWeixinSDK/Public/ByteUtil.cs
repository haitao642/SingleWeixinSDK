using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public static class ByteUtil
    {
        public static byte[] subBytes(byte[] bytes, int offset, int size)
        {
            byte[] b = new byte[size];
            int a = 0;
            for (int i = 0; i < size; i++)
            {
                b[a++] = bytes[offset + i];
            }
            return b;
        }

        public static String bytes2Ip(byte[] bytes, int offset, int size)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append((int)(bytes[offset + i] & 0xFF) + ".");
            }
            String ip = sb.ToString();
            return ip.Substring(0, ip.Length - 1);
        }

        public static byte[] charToByte(char c)
        {
            byte[] b = new byte[2];
            b[0] = (byte)((c & 0xFF00) >> 8);
            b[1] = (byte)(c & 0xFF);
            return b;
        }

        public static char byteToChar(byte[] b)
        {
            char c = (char)(((b[0] & 0xFF) << 8) | (b[1] & 0xFF));
            return c;
        }

        public static String toHex(byte b)
        {
            return ("" + "0123456789ABCDEF"[0xf & b >> 4] + "0123456789ABCDEF"
                    [b & 0xf]);
        }

        public static String toString(byte[] bytes, int index, int size)
        {
            String ss = "";
            for (int i = 0; i < size; i++)
            {
                ss += Byte2S(bytes[index + i]);
            }
            return ss.Trim();
        }

        public static int toInt(String hex)
        {
            int ss = 0;
            if ((hex[0] - 'A') >= 0)
            {
                ss += (hex[0] - 'A' + 10) * 16;
            }
            else
            {
                ss += (hex[0] - '0') * 16;
            }
            if ((hex[1] - 'A') >= 0)
            {
                ss += hex[1] - 'A' + 10;
            }
            else
            {
                ss += hex[1] - '0';
            }
            return ss;
        }

        public static int[] byte2int(byte[] bytes, int index, int size)
        {
            int[] temp = new int[size * 2];
            int k = 0;
            for (int i = 0; i < size; i++)
            {
                temp[k++] = 0xF0 & bytes[index + i];
                temp[k++] = 0xF0 & (0x0F & bytes[index + i]) << 4;
            }
            return temp;
        }

        public static int[] str2int(String[] strings)
        {
            int[] temp = new int[strings.Length * 2];
            int k = 0;
            for (int i = 0; i < strings.Length; i++)
            {
                temp[k++] = hex2int(strings[i][0]);
                temp[k++] = hex2int(strings[i][1]);
            }
            return temp;
        }

        public static int hex2int(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return (c - '0') * 16;
            }
            if (c >= 'A' && c <= 'F')
            {
                return (c - 'A' + 10) * 16;
            }
            return 0;
        }

        public static int toInt(byte b)
        {
            return (int)b & 0xFF;
        }

        public static int hexByte2int(byte b)
        {
            return toInt(toHex(b));
        }

        public static String Byte2S(byte b)
        {
            return toHex(b);
        }

        public static byte[] hexStringToBytes(String hexString)
        {
            if (hexString == null || hexString.Equals(""))
            {
                return null;
            }
            hexString = hexString.ToUpper();
            int length = hexString.Length / 2;
            char[] hexChars = hexString.ToCharArray();
            byte[] d = new byte[length];
            for (int i = 0; i < length; i++)
            {
                int pos = i * 2;
                d[i] = (byte)((char2Byte(hexChars[pos]) << 4) | char2Byte(hexChars[pos + 1]));
            }
            return d;
        }

        private static byte char2Byte(char c)
        {
            return (byte)"0123456789ABCDEF".IndexOf(c);
        }

        /**
         * 
         * @param h 高8位
         * @param l 低8位
         * @return int
         */
        public static int bytes2int(byte h, byte l)
        {
            char c = (char)(((h & 0xFF) << 8) | (l & 0xFF));
            return (int)c & 0xffff;
        }


        public static int bytes2int(byte[] bytes, int index, int length)
        {
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum = sum * 256 + bytes[index + i];
            }
            return sum;
        }


        public static byte[] toBytes(int n, int len)
        {
            byte[] bytes = new byte[len];
            for (int i = 0; i < len; i++)
            {
                bytes[len - i - 1] = (byte)(n % 256);
                n = n / 256;
            }
            return bytes;
        }

        public static byte CheckSum(byte[] bytes, int index, int len)
        {
            byte sum = 0;
            for (int i = 0; i < len; i++)
            {
                sum += bytes[index + i];
            }
            sum = (byte)(~sum + 1);
            return sum;
        }


        /**
         * 校验
         * 
         * @param param
         * @return
         */
        public static byte jiaoyan(byte[] param)
        {
            byte temp = 0;
            for (int i = 0; i < param.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                if (i == 1)
                {
                    temp = (byte)(param[i - 1] ^ param[i]);
                }
                if (i > 1)
                {
                    temp = (byte)(temp ^ param[i]);
                }
            }

            byte t = (byte)(~temp);
            return t;

        }

        /// <summary>
        /// 字符串每2位调换
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string reverse(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length / 2; i++)
            {
                Array.Reverse(chars, i * 2, 2);
            }
            return new string(chars);
        }
        /// <summary>
        /// 对象转换为Json
        /// </summary>
        /// <param name="jsonObject">对象</param>
        /// <returns>Json字符串</returns>
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }
        /// <summary>
        /// Json转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonText)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonText));
            T obj = (T)s.ReadObject(ms);
            ms.Dispose();
            return obj;
        }
    }
}
