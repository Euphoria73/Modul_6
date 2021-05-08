using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_6
{
    public static class OutPut
    {
        /// <summary>
        /// Метод вывода значений листа листов в консоль
        /// </summary>
        /// <param name="myList"></param>
        public static void OutputConsole(int groups)
        {
            Console.Write($"Total groups: {groups} ");
            Console.WriteLine();
            Console.WriteLine("Готово!");
        }
        /// <summary>
        /// Вывод времени работы операций
        /// </summary>
        /// <param name="ts">затраченное время на операции</param>
        public static void OutTimespan(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00} секунд и {1:00} миллисекунд", ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Время выполнения программы: " + elapsedTime);
        }
    }
}
