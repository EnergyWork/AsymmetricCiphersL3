using System;
using AsymmetricCiphers.Tasks;

namespace AsymmetricCiphers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(
                    "---------Меню---------\n" +
                    "1. Задача о рюкзаке\n" +
                    "2. RSA\n" +
                    "3. RSA .NET\n" + 
                    "----------------------\n" +
                    "0. Выход"
                );
                Console.Write("> ");
                string act = Console.ReadLine();
                switch (act)
                {
                    case "1": BackpackTask.backpackTask(); break;
                    case "2": RsaTask.myRSA(); break;
                    case "3": RsaDotNetTask.dotnetRSA(); break;
                    case "0": Environment.Exit(0); break;
                    default:  Console.WriteLine("Неизвестная команда!"); break;
                }
            }
        }
    }
}
