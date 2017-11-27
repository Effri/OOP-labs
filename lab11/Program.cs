using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    //язык запросов к источнику данных
    public class SuperString
    {
        public List<string> listing;
        public SuperString(List<string> str)
        {
            this.listing = str;
            MakeString();
        }
        public void Push(ref string number)
        {
            listing.Insert(0, number);
        }
        public void Pop()
        {
            listing.RemoveAt(0);
        }
        public int GetTop(List<char> str)
        {
            return str[0];
        }
        public int Length
        {
            get { return listing.Count; }
        }
        void MakeString()
        {
            listing.Reverse();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] year = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n = 3;
            var length = from month in year where month.Length == n select month;
            var alphabeth = from month in year orderby month select month;
            var sumWinMounth = from month in year
                               where month == year[0] ||
                                     month == year[1] ||
                                     month == year[11] ||
                                     month == year[5] ||
                                     month == year[6] ||
                                     month == year[7]
                               select month;
            var umonths = from month in year where month.Contains('u') && month.Length >= 4 select month;
            Console.WriteLine("Select by string length");
            foreach (string months in length)
            { Console.WriteLine(months); }
            Console.WriteLine("\nSort by alphabeth");
            foreach (string months in alphabeth)
            { Console.WriteLine(months); }
            Console.WriteLine("\nSelect by char 'u' and string length");
            foreach (string months in umonths)
            { Console.WriteLine(months); }
            Console.WriteLine("\nSelect only summer's and winter's months");
            foreach (string months in sumWinMounth)
            { Console.WriteLine(months); }

            //функциональные средства для минимизации обязательного для
            //написания объема кода
            List<string> listing = new List<string>{ "Какое прекрасное утро?",
                "Эта строка...",
                "А это точно было в ответах?",
                "А вот эта строка точно подойдет?",
            "Надо сдать лабораторные и быть спокойным, что всё хорошо!"};

            // Использование синтаксиса выражения запроса
            var str_length = from strs in listing where strs.Length == 13 || strs.Length == 34 select strs;
            Console.WriteLine("\nSelect by string length");
            foreach (string strs in str_length)
            { Console.WriteLine(strs); }

            var strMax = from strs in listing where strs.Length > 45 select strs;
            Console.WriteLine("\nSelect by max string length");
            foreach (string strs in strMax)
            { Console.WriteLine(strs); }

            var vstr_length = from strs in listing where strs.Contains('?') || strs.Contains('.') select strs;
            Console.WriteLine("\nSelect by symbol '?' and '.' string");
            foreach (string strs in vstr_length)
            { Console.WriteLine(strs); }

            var wordStr = from strs in listing where strs.EndsWith("хорошо!") select strs;
            Console.WriteLine("\nSelect by word 'хорошо!' string");
            foreach (string strs in wordStr)
            { Console.WriteLine(strs); }

            var mas_str = from strs in listing where strs.Contains("Эта") ||
                          strs.Contains("А это") ||
                          strs.Contains("А вот эта")  select strs;
            Console.WriteLine("\nSort by first word 'Эта!' string");
            foreach (string strs in mas_str)
            { Console.WriteLine(strs); }

            Console.ReadLine();

        }
    }
}
