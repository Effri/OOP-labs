using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    partial class SuperString
    {
        static SuperString()
        {
            IdSession = DateTime.Now.Ticks; //return number your's ticks
        }
        public SuperString()
        {
            Console.Write("Input string: ");
            str = new StringBuilder(Console.ReadLine()); //повышает производительность при соединении строк
            countObj++;
        }
        public SuperString(StringBuilder str)
        {
            this.str = str; //метод расширения, ссылается на текущий экземпляр класса, для квалификации элементов, скрытых одинаковыми именами
            countObj++; 
        }
        public char this [int symbol]
        {
            get { return str[symbol]; }
            set { str[symbol] = value; }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return str.ToString();
        }
        public void ReplaceChar(char changeble)
        {
            Console.WriteLine("Before: {0}\n", str);
            Console.Write("Input new char: ");
            char newChar = Convert.ToChar(Console.ReadLine());
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == changeble)
                {
                    str[i] = newChar;
                }
            }
            Console.WriteLine("\nAfter: {0}\n", str);
        }
        public bool inString(char char1)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == char1)
                {
                    return true;
                }
            }
            return false;
        }
        public static void Swap(ref SuperString str1, ref SuperString str2)
        {
            SuperString temp = str1;
            str1 = str2;
            str2 = temp;
        }
        public void GetFirstSymbol(out char char1)
        {
            char1 = str[0];
        }
        public int SuperStringLength()
        {
            return str.Length;
        }
        public void Print()
        {
            Console.WriteLine("\nString's size: {0}\nString: {1}\n", SuperStringLength(), str);
        }
        public static void ClassData()
        {
            Console.WriteLine("Information about class");
            Console.WriteLine("Count strings: {0}\nSession ID: {1}\n", countObj, IdSession);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SuperString str1 = new SuperString();
            SuperString str2 = new SuperString(new StringBuilder("Darkness"));
            SuperString str3 = new SuperString(new StringBuilder("Angelina"));
            str1.Print();
            str2.Print();
            SuperString.Swap(ref str1, ref str2); //исп парам типов, замена строки
            str1.GetFirstSymbol(out char char1); //замена по одному символу
            Console.WriteLine("\nFirst in: {0}\nSecond in: {1}\n", str1.inString('H'), str2.inString('D'));
            str1.ReplaceChar('D');
            SuperString[] SuperStrings = new SuperString[3];
            SuperStrings[0] = str1;
            SuperStrings[1] = str2;
            SuperStrings[2] = str3;
            Console.Write("Input length: ");
            int defLength = Convert.ToInt32(Console.ReadLine());
            StringBuilder defString = new StringBuilder("Darkness");
            for (int i = 0; i < SuperStrings.Length; i++)
            {
                if (SuperStrings[i].SuperStringLength() <= defLength)
                {
                    Console.WriteLine("\nDefine length\n");
                    SuperStrings[i].Print();
                }
                if (SuperStrings[i].SuperStringLength() == defLength)
                {
                    Console.WriteLine("\nSpecified word\n");
                    SuperStrings[i].Print();
                }
                //if (SuperStrings[i].ToString().Contains(defString.ToString()))
                //{
                //    Console.WriteLine("\nSpecified word\n");
                //    SuperStrings[i].Print();
                //}
            }
            SuperString.ClassData();
            var anonSuperString = new { superString = new StringBuilder("MegaString") };
            Console.WriteLine("Anon type: {0}", anonSuperString.superString);
            Console.ReadKey();
        }
    }
}