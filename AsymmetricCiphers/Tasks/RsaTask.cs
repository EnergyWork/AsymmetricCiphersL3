using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsymmetricCiphers.Ciphers;

namespace AsymmetricCiphers.Tasks
{
    class RsaTask
    {
        private static bool isPrime(int n)
        {
            if (n > 1) // если n > 1
            {
                for (int i = 2; i < n; i++) // в цикле перебираем числа от 2 до n - 1
                {
                    if (n % i == 0) // если n делится без остатка на i - возвращаем false (число не простое)
                    {
                        return false;
                    }
                }
                // если программа дошла до данного оператора, то возвращаем true (число простое) - проверка пройдена
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void myRSA()
        {
            int p, q; 
            do
            {
                Console.Clear();
                Console.Write("Введите простое число p: ");
                p = int.Parse(Console.ReadLine());
                Console.Write("Введите простое число q: ");
                q = int.Parse(Console.ReadLine());
                if (isPrime(p) && isPrime(q))
                    break;
                else
                    Console.WriteLine("Оба числа должы быть простые!");
            } while (true);
            Console.Write("Введите сообщение: ");
            string message = Console.ReadLine();

            
            RSAmy _RSA = new RSAmy(p, q);
            Console.WriteLine("\nRSA публичный ключ (n = {0}, key = {1})", _RSA.n, _RSA.publicKey);

            List<string> encryptedText = _RSA.Encrypt(message);
            Console.WriteLine("Зашифрованное сообщение: ");
            for (int i = 0; i < message.Length; i++)
                Console.Write("{0} ", encryptedText[i]);
            Console.WriteLine();

            StringBuilder decryptedText = new StringBuilder();
            decryptedText.Append(_RSA.Decrypt(encryptedText));
            Console.WriteLine("Расшифрованное сообщение: {0}", decryptedText);

            Console.ReadKey();
        }
    }
}
