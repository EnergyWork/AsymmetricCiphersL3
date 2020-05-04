using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers.Ciphers
{
    class RSAmy
    {
        public int publicKey;
        private int privateKey;
        public int n;
        public RSAmy(int p, int q)
        {
            Random rand = new Random();
            n = p * q;//считаем n
            int fi = (p - 1) * (q - 1);//считаем функцию Эйлера
            publicKey = rand.Next(1, fi);//генерируем публичный ключ
            while (NOD(publicKey, fi) != 1)
                publicKey = rand.Next(1, fi);
            privateKey = calculateD(publicKey, fi);//считаем приватный ключ
        }
        public List<string> Encrypt(string encryptString)
        {
            char[] characters = new char[26];
            for (int i = 97; i < 123; i++)
                characters[i - 97] = (char)i;
            List<string> result = new List<string>();
            BigInteger bi;
            for (int i = 0; i < encryptString.Length; i++)
            {
                int index = Array.IndexOf(characters, encryptString[i]);
                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, publicKey);
                BigInteger n_ = new BigInteger(n);
                bi %= n_;
                result.Add(bi.ToString());
            }
            return result;
        }
        public string Decrypt(List<string> decryptArr)
        {
            char[] characters = new char[26];
            for (int i = 97; i < 123; i++)
                characters[i - 97] = (char)i;
            string result = "";
            BigInteger bi;
            foreach (string item in decryptArr)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, privateKey);
                BigInteger n_ = new BigInteger(n);
                bi %= n_;
                int index = Convert.ToInt32(bi.ToString());
                result += characters[index].ToString();
            }
            return result;
        }


        static int NOD(int a, int b)
        {
            return b == 0 ? a : NOD(b, a % b);
        }
        static int calculateD(int l, int fi)
        {
            int k = 1;
            while (true)
            {
                k += fi;
                if (k % l == 0)
                {
                    return (k / l);
                }
            }
        }
    }
}
