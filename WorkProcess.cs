using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork_6
{
    public static class WorkProcess
    {
        /// <summary>
        /// Общение с пользователем - выбор режима работы и нужна ли архивация
        /// </summary>
        /// <param name="choise"></param>
        /// <returns></returns>
       public  static int SelectWork(string choise)
        {
            int select = 1;
            if (choise == "work mode") Console.WriteLine("Выберите режим работы: 1 - показать в консоли число групп; 2 - записать данные групп в файл");
            if (choise == "archive") Console.WriteLine("Заархивировать файл? Выберите: 1 - да; 2 - нет");
            try
            {
                select = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Вы ошиблись с вводом, компьютер выберет за Вас");
                Console.ReadKey();
            }
            return select;
        }
        /// <summary>
        /// Считывание числа N из файла
        /// </summary>
        /// <returns></returns>
       public static int Number()
        {
            string pathToOwnerFile = AppDomain.CurrentDomain.BaseDirectory;
            string Str = File.ReadAllText(pathToOwnerFile + "number.txt");

            int number;

            bool isNum = int.TryParse(Str, out number);

            if (!isNum || number > 1_000_000_000)
            {
                Console.WriteLine("Введёное значение должно быть числом, не превышающим 1000000000. Исправте файл и повторите попытку");
                number = 0;
            }
            return number;
        }

        /// <summary>
        /// Заполнение листа числами
        /// </summary>
        /// <param name="group"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private static List<int> Perebor(int group, int number)
        {
            List<int> myList = new List<int>();
            int firstnumgroup = Convert.ToInt32(Math.Pow(2, group)); //определяем начало диапазона чисел в группе
            int nextnumgroup = Convert.ToInt32(Math.Pow(2, group + 1)); //определяем конец диапазона чисел в группе                
            myList.Add(firstnumgroup);
            for (int j = firstnumgroup + 1; j < nextnumgroup; j++)
            {
                myList.Add(j);

                if (j == number)
                {
                    break;
                }
            }
            return myList;
        }

        /// <summary>
        /// Рекурсивный метод записи данных в файл
        /// </summary>
        /// <param name="num_group">one group at the moment</param>
        /// <param name="groups">total groups</param>
        /// <param name="number">user value</param>
       public static void Recursion(int num_group, int groups, int number)
        {
            List<int> myList = Perebor(num_group, number);
            FileProcess.Write(myList, num_group);
            if (num_group + 1 < groups)
            {
                Recursion(num_group + 1, groups, number);
            }
            else
            {
                return;
            }
        }
    }
}
