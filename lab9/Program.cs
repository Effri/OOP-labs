using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW9
{
    public static class StringChanger
    {
        public static string RemoveMarks(string str)
        {
            char[] marks = { '-', ';', '+' };
            for (int i = 0; i < str.Length; i++)
            {
                if (marks.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }
        public static string RemoveSpaces(string str)
        {
            return str.Replace("  ", string.Empty);
        }
        public static string AddSymbols(string str, char ch, int pos)
        {
            return str.Insert(pos, Convert.ToString(ch));
        }
        public static string ToUpperCase(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    str = str.Replace(str[i], Char.ToUpper(str[i]));
                }
            }
            return str;
        }
        public static string Reverse(string str)
        {
            char[] symbols = str.ToCharArray();
            Array.Reverse(symbols);
            return new string(symbols);
        }
    }
    public class Boss
    {
        public int upgrade;
        public delegate void GetUpgrade(string message);
        public delegate void GetTurnOn(string message);
        public event GetUpgrade Upgrade;
        public event GetTurnOn TurnOn;
        public Boss(int upgrade)
        {
            this.upgrade = upgrade;
        }
        public void Upgrading(int level)
        {
            upgrade += level;
            if (Upgrade != null)
            {
                Upgrade("Object level-up to" + upgrade + " level.");
            }
        }
        public void TurningOn(int voltage)
        {
            if (TurnOn != null)
            {
                if (voltage < 220)
                {
                    TurnOn("Object experienced " + voltage + " volt and stayed alive!");
                }
                else
                {
                    TurnOn("Object did not survive the " + voltage + " volt!");
                }

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Boss man = new Boss(1); // первый уровень
            Boss machine = new Boss(10); // десятый уровень
            man.Upgrade += (string message) => Console.WriteLine(message); // прокачался
            man.TurnOn += (string message) => Console.WriteLine(message); // выключение
            man.Upgrading(10); // поднял уровень до десятого
            man.TurningOn(300); // значение вышло за диапазон
            machine.TurnOn += (string message) => Console.WriteLine(message);
            machine.TurningOn(127);
            machine.TurnOn -= (string message) => Console.WriteLine(message);
            machine.Upgrading(27);
            Console.WriteLine(machine.upgrade + "\n");
            Console.WriteLine("String handle\n-----------------------------\n");
            string str = "s; t ++ r - i n -+ g s!";
            Func<string, string> Handler = StringChanger.RemoveMarks;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Handler(str));
            Handler = StringChanger.RemoveSpaces;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Handler(str));
            Handler = StringChanger.ToUpperCase;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Handler(str));
            Func<string, char, int, string> Symbols = StringChanger.AddSymbols;
            Symbols = StringChanger.AddSymbols;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Symbols(str, 'Q', 4));
            Handler = StringChanger.Reverse;
            Console.WriteLine("Before: {0}\nAfter: {1}\n", str, str = Handler(str));
            Console.ReadKey();
        }
    }
}