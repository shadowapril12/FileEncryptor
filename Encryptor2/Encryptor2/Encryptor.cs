using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Encryptor2
{
    class Encryptor
    {
        //Свойство хранящее путь к файлу
        public string Path { get; private set; }

        //Свойство хранящее массив зашифрованных байтов
        private byte[] EncryptedFileArr { get; set; }

        //Свойство хранящее ключ шифрования
        public byte Key { get; private set; }

        //Исходный массив байтов
        public byte[] OriginByteFileArr { get; private set; }

        /// <summary>
        /// Метод получения ключа
        /// </summary>
        public void GetKey()
        {
            Console.WriteLine("Введите ключ");

            try
            {
                Key = Convert.ToByte(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Неверный формат ключа. {ex.Message}");
                GetKey();
            }
        }

        /// <summary>
        /// Метод шифрования файла
        /// </summary>
        public void Encrypt()
        {
            //Создание экземпляра класса 'FileWorker'
            FileWorker f = new FileWorker();

            //Запись в файл
            f.WriteInFile();

            //Присваивание значения свойству 'Path'
            Path = f.Path;

            //Получение исходно массива байтов
            OriginByteFileArr = File.ReadAllBytes(Path);

            //Создание пустого массива байтов идентичного по размерности исходному
            EncryptedFileArr = new byte[OriginByteFileArr.Length];

            //Получения ключа шифрования
            GetKey();

            //Шифрование файла
            for(int i = 0; i < OriginByteFileArr.Length; i++)
            {
                EncryptedFileArr[i] = (byte)((OriginByteFileArr[i] + Key)%(byte.MaxValue + 1));
            }

            //Запись зашифрованного массива в файл
            File.WriteAllBytes(Path, EncryptedFileArr);

            Console.WriteLine("Файл успешно зашифрован");
        }
        
        /// <summary>
        /// Метод дешифровки файла
        /// </summary>
        public void UnEncrypt()
        {

            for(int i = 0; i < EncryptedFileArr.Length; i++)
            {
                OriginByteFileArr[i] = (EncryptedFileArr[i] >= 0) ? (byte)((EncryptedFileArr[i] - Key) % byte.MaxValue + 1) : (byte)(((byte.MaxValue + 1) - (EncryptedFileArr[i] + Key)) % (byte.MaxValue + 1));
            }

            //Запись дешифрованного массива в файл
            File.WriteAllBytes(Path, OriginByteFileArr);

            Console.WriteLine("Файл успешно расшифрован");
        }
        
    }
}
