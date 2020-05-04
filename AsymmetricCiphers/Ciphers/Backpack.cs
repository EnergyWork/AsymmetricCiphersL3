using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers.Ciphers
{
    class Backpack
    {
        public static List<int> increase(List<int> mass, int fMass)
        {
            List<int> backpack = new List<int>();
            mass.Reverse();
            foreach (int mas in mass)
            {
                if (mas < fMass)
                {
                    backpack.Add(mas);
                    fMass -= mas;
                }
            }
            backpack.Reverse();
            return backpack;
        }
        public static bool isMutuallyPrimeNumbers(int num1, int num2)
        {
            return num1 == num2 ? num1 == 1 : num1 > num2 ? isMutuallyPrimeNumbers(num1 - num2, num2) : isMutuallyPrimeNumbers(num2 - num1, num1);
        }
        public static List<int> key(List<int> mass, int mod, int multiplier)
        {
            List<int> opKey = new List<int>();
            foreach (int mas in mass)
                opKey.Add((mas * multiplier) % mod);
            return opKey;
        }
        public static string ReverseArray(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static string StringToBinaryString(string message)
        {
            string result = string.Empty, buf;
            byte[] ar = Encoding.Default.GetBytes(message);
            foreach (byte b in ar)
            {
                buf = Convert.ToString(b, 2);
                if (buf.Length != 8)
                {
                    buf = ReverseArray(buf);
                    while (buf.Length != 8)
                        buf += '0';
                    buf = ReverseArray(buf);
                }
                result += buf;
            }
            return result;
        }
        public static int calculateD(int l, int fi)
        {
            int k = 1, d;
            while (true)
            {
                k += fi;
                if (k % l == 0)
                {
                    d = (k / l);
                    return d;
                }
            }
        }
        public static string back(List<int> key, int block)
        {
            string bl = string.Empty;
            key.Reverse();
            foreach (int i in key)
            {
                if (i > block)
                {
                    bl += '0';
                }
                else
                {
                    block -= i;
                    bl += '1';
                }
            }
            bl = ReverseArray(bl);
            key.Reverse();
            return bl;
        }
        public static string BinaryStringToString(string message)
        {
            string bufs;
            int c = 8, 
                i = 0;
            byte buf;
            byte[] b;
            List<byte> bb = new List<byte>();
            while (i != message.Length)
            {
                bufs = message.Substring(i, c);
                while (bufs[0] == '0')
                {
                    bufs = bufs.Remove(0, 1);
                }
                buf = Convert.ToByte(bufs, 2);
                bb.Add(buf);
                i += c;
            }
            b = bb.ToArray();
            return Encoding.Default.GetString(b);
        }
    }
}
