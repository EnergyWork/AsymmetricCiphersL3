using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AsymmetricCiphers.Ciphers;

namespace AsymmetricCiphers.Tasks
{
    class RsaDotNetTask
    {
        public static void dotnetRSA()
        {
            try
            {
                Console.Clear();
                Console.Write("Введите сообщение: \n");
                string message = Console.ReadLine();
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] dataToEncrypt = ByteConverter.GetBytes(message), 
                       encryptedData, 
                       decryptedData;
                string pathPrivateKey = "privateKey.xml", 
                       pathPublicKey = "publicKey.xml",
                       privateKey = string.Empty,
                       publicKey = string.Empty;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSAParameters RSAParametersPublic = RSA.ExportParameters(false);
                    RSAParameters RSAParametersPrivate = RSA.ExportParameters(true);
                    if (File.Exists(pathPrivateKey) && File.Exists(pathPublicKey))
                    {
                        using (FileStream fs = File.OpenRead(pathPrivateKey))
                        {
                            byte[] array = new byte[fs.Length];
                            fs.Read(array, 0, array.Length);
                            privateKey = Encoding.Default.GetString(array);
                        }
                        using (FileStream fs = File.OpenRead(pathPublicKey))
                        {
                            byte[] array = new byte[fs.Length];
                            fs.Read(array, 0, array.Length);
                            publicKey = Encoding.Default.GetString(array);
                        }
                        RSA.FromXmlString(publicKey);
                        RSAParametersPublic = RSA.ExportParameters(false);
                        RSA.FromXmlString(privateKey);
                        RSAParametersPrivate = RSA.ExportParameters(true);
                    }
                    else
                    {
                        privateKey = RSA.ToXmlString(true);
                        publicKey = RSA.ToXmlString(false);
                        using (FileStream fs = new FileStream(pathPrivateKey, FileMode.Create, FileAccess.Write))
                        {
                            byte[] array = Encoding.Default.GetBytes(privateKey);
                            fs.Write(array, 0, array.Length);
                        }
                        using (FileStream fs = new FileStream(pathPublicKey, FileMode.Create, FileAccess.Write))
                        {
                            byte[] array = Encoding.Default.GetBytes(publicKey);
                            fs.Write(array, 0, array.Length);
                        }
                        RSAParametersPublic = RSA.ExportParameters(false);
                        RSAParametersPrivate = RSA.ExportParameters(true);
                    }

                    encryptedData = RSAdotnet.RSAEncrypt(dataToEncrypt, RSAParametersPublic, false);
                    Console.WriteLine("Зашифрованное сообщение:");
                    for (int i = 0; i < encryptedData.Length; i++)
                        Console.Write("{0} ", encryptedData[i]);

                    decryptedData = RSAdotnet.RSADecrypt(encryptedData, RSAParametersPrivate, false);
                    Console.WriteLine();
                    Console.WriteLine("Расшифрованное сообщение: {0}", ByteConverter.GetString(decryptedData));
                    Console.ReadKey();
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Ошибка шифрвоания!");
                Console.ReadKey();
            }
        }
    }
}
