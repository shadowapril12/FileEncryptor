using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Encryptor2
{
    class FileWorker
    {
        //Путь до файла
        public string Path { get; private set; }

        //Записываеый в файл текст
        public string Message { get; private set; }

        /// <summary>
        /// Метод записи в файл
        /// </summary>
        public void WriteInFile()
        {
            //Создание экземпляра класса DirecoryMaker
            DirectoryMaker d = new DirectoryMaker();

            //Создание директории
            d.MakeDirectory();

            //Создание файла в указанной директории
            d.FileMaker();

            //Присваивание свойсту Path полного пути до файла
            Path = d.FullDir;

            Console.WriteLine("Введите текст, который хотите записать в выбранный файл");

            //Присваивание значения свойсту 'Message'
            Message = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
            {   
                //Запись в файл
                sw.WriteLine(Message);
            }
        }
    }
}
