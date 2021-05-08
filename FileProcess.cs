using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace HomeWork_6
{
    static class FileProcess
    {
        /// <summary>
        /// Запись данных в файл
        /// </summary>
        /// <param name="myList"></param>
        /// <param name="num_group"></param>
        public static void Write(List<int> myList, int num_group)
        {
            bool newfile;
            if (num_group == 0)
            {
                newfile = false;
            }
            else
            {
                newfile = true;
            }
            string pathToOwnerFile = AppDomain.CurrentDomain.BaseDirectory;
            string writePath = pathToOwnerFile + "complete.txt";
            using (StreamWriter sw = new StreamWriter(writePath, newfile, System.Text.Encoding.Default))
            {
                sw.Write("\n");
                sw.Write($"Group {num_group + 1}: ");
            }
            Console.WriteLine($"Группа {num_group + 1}: записываю..."); //временно для проверки = удалить
            foreach (int List in myList)
            {
                using StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default);
                sw.Write(List + " ");
            }
        }

        /// <summary>
        /// Архивация файла в ZIP формат
        /// </summary>
        public static void Archive()
        {
            string pathToOwnerFile = AppDomain.CurrentDomain.BaseDirectory;
            string source = pathToOwnerFile + "complete.txt";
            string compressed = pathToOwnerFile + "complete.zip";
            using FileStream soucestream = new FileStream(source, FileMode.OpenOrCreate); //открытие потока для работы с файлом
            using FileStream filestream = File.Create(compressed); //поток для записи сжатого файла
            using GZipStream compressstream = new GZipStream(filestream, CompressionMode.Compress);
            soucestream.CopyTo(compressstream);
            Console.WriteLine("Сжатие завершено!");
        }
    }
}
