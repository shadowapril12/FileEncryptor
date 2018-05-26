using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание экземпляра класса 'Encryptor'
            Encryptor enc = new Encryptor();

            //Вызов метода шифрования
            enc.Encrypt();

            //Вызов метода дешифрования
            enc.UnEncrypt();

            Console.ReadLine();
        }
    }
}
