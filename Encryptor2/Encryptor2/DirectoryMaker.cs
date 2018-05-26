using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Encryptor2
{
    /// <summary>
    /// Класс отвечающий за создание дирректории
    /// </summary>
    class DirectoryMaker
    {
        //Каталог
        public string CatalogDir { get; private set; }

        //Название файла
        public string FileName { get; private set; }

        //Gлный путь
        public string FullDir { get; private set; }

        //Метод создающий каталог
        public void MakeDirectory()
        {
            //Директория каталога
            CatalogDir = @"";

            //Получение директории
            Console.WriteLine("Введите путь по которму вы хотите сохранить файл");
            
            //Запись в свойство
            CatalogDir += Console.ReadLine();

            //Создание экземпляра класса DirectoryInfo с указанной директорией в конструкторе
            DirectoryInfo d = new DirectoryInfo(CatalogDir);

            //Создание директории
            d.Create();
        }

        /// <summary>
        /// Метод создания файла в указанной директории
        /// </summary>
        public void FileMaker()
        {
            Console.WriteLine("Введите название файла");

            //Присваивание значения свойсту 'FileName'
            FileName = Console.ReadLine();

            //Полный путь
            string fileDir = $"{CatalogDir}\\{FileName}";

            FullDir = fileDir;

            //Создание файла
            File.Create(fileDir).Close();
        }
    }
}
