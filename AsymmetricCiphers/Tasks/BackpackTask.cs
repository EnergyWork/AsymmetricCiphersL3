using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsymmetricCiphers.Ciphers;

namespace AsymmetricCiphers.Tasks
{
    class BackpackTask
    {
        static public void backpackTask()
        {
            List<int> 
                lBackpack,
                key, 
                encryptMsg = new List<int>(), 
                decryptMsg = new List<int>(),
                mass = new List<int>();
            List<string> 
                listBMsg = new List<string>();
            string 
                msg, 
                sBinMsg, 
                sDecryptBinMsg = "", 
                sDecryptMsg;
            int
                inputNum,
                fullArr,
                module,
                multiplier,
                sum = 0,
                countZero = 0,
                counter = 0;

            Console.Clear();
            Console.WriteLine("Введите последовательность масс(> 0) по одной за раз( -1 - закончить ввод )");
            while (true)
            {
                Console.Write(">");
                inputNum = int.Parse(Console.ReadLine());
                if (inputNum == 0)
                {
                    Console.WriteLine("Ошибка!");
                }
                else
                {
                    if (inputNum < -1)
                    {
                        Console.WriteLine("Ошибка!");
                    }
                    else
                    {
                        if (inputNum == -1)
                        {
                            Console.WriteLine("Ввод завершен. . .\n");
                            break;
                        }
                        else
                        {
                            mass.Add(inputNum);
                        }
                    }
                }
            }

            Console.Write("Введите полный вес рюкзака: ");
            fullArr = int.Parse(Console.ReadLine());
            lBackpack = Backpack.increase(mass, fullArr);

            Console.WriteLine("\nРюкзак: ");
            foreach (int i in lBackpack)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("\nВведите взаимнопростые модуль и множитель: ");
                Console.Write("Введите модуль больше {0}: ", sum);
                module = int.Parse(Console.ReadLine());
                Console.Write("Введите можитель: ");
                multiplier = int.Parse(Console.ReadLine());
                if ((module > sum) && Backpack.isMutuallyPrimeNumbers(module, multiplier))
                    break;
            }

            key = Backpack.key(lBackpack, module, multiplier);
            Console.WriteLine("\nОткрытый ключ:");
            foreach (int i in key)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.WriteLine("\nВведите сообщение:");
            msg = Console.ReadLine();
            sBinMsg = Backpack.StringToBinaryString(msg);

            while ((sBinMsg.Length % key.Count()) != 0)
            {
                sBinMsg += "0";
                countZero++;
            }
            do
            {
                listBMsg.Add(sBinMsg.Substring(counter, key.Count));
                counter += key.Count();
            } while (sBinMsg.Length != counter);

            foreach (string v in listBMsg)
            {
                int s = 0;
                for (int i = 0; i < v.Length; i++)
                    if (v[i] == '1')
                        s += key[i];
                encryptMsg.Add(s);
            }

            Console.WriteLine("\nЗашифрованное сообщение:");
            int multiplier_rew = Backpack.calculateD(multiplier, module);
            foreach (int i in encryptMsg)
            {
                Console.Write(i + " ");
                decryptMsg.Add((i * multiplier_rew) % module);
            }
            Console.WriteLine();

            Console.WriteLine("\nРасшифрованное сообщение:");
            foreach (int block in decryptMsg)
            {
                Console.Write(block + " ");
                sDecryptBinMsg += Backpack.back(lBackpack, block);
            }
            Console.WriteLine();

            sDecryptBinMsg = sDecryptBinMsg.Substring(0, sDecryptBinMsg.Length - countZero);
            sDecryptMsg = Backpack.BinaryStringToString(sDecryptBinMsg);
            Console.WriteLine("Cообщение: {0}", sDecryptMsg);
            Console.ReadKey();
        }
    }
}
