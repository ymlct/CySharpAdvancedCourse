using System.Collections.Generic;

namespace L2Task2
{
    /*
    Задание 3
    Несколькими способами создайте коллекцию, в которой можно хранить только целочисленные и
    вещественные значения, по типу «счет предприятия – доступная сумма» соответственно. 
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Первый способ
            var dict = new Dictionary<int, double>();

            // Второй способ
            var sortedDict = new SortedDictionary<int, double>();
        }
    }
}