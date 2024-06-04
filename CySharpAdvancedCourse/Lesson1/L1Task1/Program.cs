using System;
using System.Collections.Generic;

namespace L1Task1
{
    /*
    Задание 2
    Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
    количество дней в соответствующем месяце. Реализуйте возможность выбора месяцев, как по
    порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
    только один месяц.
     */
    internal class Program
    {
        public static void Main(string[] args)
        {

            var year = new Year();

            var months = year.GetMonthsByAmountOfDays(31);
            foreach (var m in months)
            {
                Console.WriteLine(m.Title);
            }
            
            var month = year.GetMonthByOrdinal(1);
            Console.WriteLine(month.Title);
        }
    }

    internal class Year
    {
        public readonly Month[] _months;
        
        public List<Month> GetMonthsByAmountOfDays(int amountOfDays)
        {
            List<Month> months = new List<Month>();
            
            for (var i = 0; i < _months.Length; i++)
            {
                var month = _months[i];
                if (month.AmountOfDays == amountOfDays)
                {
                    months.Add(month);
                }
            }
            return months;
        }
        
        public Month GetMonthByOrdinal(int ordinal)
        {
            Month month = null;
            
            if (ordinal >= 1 && ordinal <= 12)
            {
                month = _months[ordinal - 1];
            }
            return month;
        }

        public Year()
        {
            _months = new[]
            {
                new Month(1, 31, "Январь"),
                new Month(2, 28, "Февраль"),
                new Month(3, 31, "Март"),
                new Month(4, 30, "Апрель"),
                new Month(5, 31, "Май"),
                new Month(6, 30, "Июнь"),
                new Month(7, 31, "Июль"),
                new Month(8, 31, "Август"),
                new Month(9, 30, "Сентябрь"),
                new Month(10, 31, "Октябрь"),
                new Month(11, 30, "Ноябрь"),
                new Month(12, 31, "Декабрь")
            };
        }
    }

    internal class Month
    {
        public string Title { get; private set; }
        
        public int Ordinal { get; private set; }
        
        public int AmountOfDays { get; private set; }

        public Month(int ordinal, int amountOfDays, string title)
        {
            Ordinal = ordinal;
            AmountOfDays = amountOfDays;
            Title = title;
        }
    }
}