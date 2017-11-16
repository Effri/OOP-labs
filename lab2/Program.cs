using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LW2
{
    class Usellesator
    {
       
        static void Types()
        {

            // явное преобразование
            //1
            double x = 1234.7;
            int a;
            // Cast double to int.
            a = (int)x;
            //2
            double dblV = (double)8657443;
            //3
            sbyte sbV = (sbyte)-102;
            //4
            ushort ushV = (ushort)65034;
            //5
            short shrtV = (short)201;


            // неявное преобразование (сохраненяемое значение может уместиться в переменной без усечения или округления)
            //1
            int num = 2147483647;
            long bigNum = num;
            //2
            long longValue1 = 4294967296;
            float lV1 = longValue1;
            //3
            ushort ushortValue1 = 65034;
            int usV1 = ushortValue1;
            //4
            byte byteValue1 = 201;
            uint bV1 = byteValue1;
            //5
            sbyte sbyteValue1 = -102;
            short sbV1 = sbyteValue1;

            int i1 = 123;
            object o = (object)i1;  // boxing
            o = 123;
            i1 = (int)o;  // unboxing


            // i is compiled as an int
            // неявно типизированная переменная
            var i = 5;

            // nullable-перемен.
            int? x1 = null;
            int? x2 = null;
            if (x1 == x2)
                Console.WriteLine("Объекты равны (nullable-перемен.) \n");
            else
                Console.WriteLine("Объекты не равны (nullable-перемен.) \n");


            Console.WriteLine("Явное преобразование: {0}\n {1}\n {2}\n {3}\n {4}\n", a, dblV, sbV, ushV, shrtV);
            Console.WriteLine("Вывод неявно преобразования: {0}\n {1}\n {2}\n {3}\n {4}\n", bigNum, lV1, usV1, bV1, sbV1);
            Console.WriteLine("Вывод неявно тип. перем.: {0}\n", i);
            Console.WriteLine("Вывод запакованного/распакованного типа: {0}\n {1}", (object)i1, i1);

            Console.ReadLine();
        }
        static void Strings()
        {
            //1
            //строковые литералы - сравнение

            // Create upper-case characters from their Unicode code units.
            String stringUpper = "\x0041\x0042\x0043";

            // Create lower-case characters from their Unicode code units.
            String stringLower = "\x0061\x0062\x0063";

            // Display the strings.
            Console.WriteLine("Comparing '{0}' and '{1}':",
                              stringUpper, stringLower);

            // Compare the uppercased strings; the result is true.
            Console.WriteLine("The Strings are equal when capitalized? {0}",
                              String.Compare(stringUpper.ToUpper(), stringLower.ToUpper()) == 0
                                             ? "true" : "false");

            // The previous method call is equivalent to this Compare method, which ignores case.
            Console.WriteLine("The Strings are equal when case is ignored? {0}",
                              String.Compare(stringUpper, stringLower, true) == 0
                                             ? "true" : "false");

            //2
            String value = "This is a short string.";
            String value2 = "Of course";
            String value3 = "STO";

            //сцепление 
            string val = value + value2 + value3;
            Console.WriteLine("Объединение:  {0}\n", val);

            //копирование
            value2 = String.Copy(value);
            Console.WriteLine("Копирование = {0}\n {1}\n", value, value2);

            //выделение подстроки
            Console.WriteLine(value.Substring(5, 2));

            // разделения строки на слова
            Char delimiter = 's';
            String[] substrings = value.Split(delimiter);
            foreach (var substring in substrings)
                Console.WriteLine("Разделение {0}\n", substring);

            // вставка подстроки в заданную позицию
            Console.WriteLine("Вставка строки в заданную позицию через Insert");
            Console.WriteLine(value2);
            String modvalue2 = value2.Insert(6, "IS");
            Console.WriteLine(modvalue2);
            Console.WriteLine('\n');

            //удаление заданной подстроки
            Console.WriteLine("Удаление заданной подстроки через Remove");
            Console.WriteLine(modvalue2);
            Console.WriteLine(modvalue2.Remove(6, 6));
            Console.WriteLine('\n');

            //Работа с пустой и null строками
            Console.WriteLine("Работа с пустой и null строками");
            String nullstring = null;
            String emptyString = "";
            Console.WriteLine(value + nullstring);
            Console.WriteLine(value + emptyString);
            value = String.Copy(emptyString);
            // str2 = String.Copy(nullstring); Ошибка
            Console.WriteLine(value);
            Console.WriteLine('\n');

            // Работа со строкой с помощью String.Builder
            StringBuilder str6 = new StringBuilder("Builder's String");
            Console.WriteLine(str6);
            Console.WriteLine(str6.Remove(9, 7));
            Console.WriteLine(str6.Append(" new String"));
            Console.WriteLine(str6.Insert(0, "My "));
            Console.WriteLine();

            Console.ReadLine();
        }
        static void Arrays()
        {
            Console.WriteLine("Вывод матрицы\n");
            int[][] nums = new int[2][];
            nums[0] = new int[] { 5, 7, 8 };
            nums[1] = new int[] { 0, 5, 6 };
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[i].Length; j++)
                {
                    Console.Write($"{nums[i][j]} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Вывод массива строк\n");
            string[] strings = new string[] { "It's", "a", "good", "day", "to", "make", "labs" };
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(String.Join(" ", strings));
            Console.WriteLine();
            Console.WriteLine("Размер строки: {0}\n", strings.Length);

            int position = 5;
            string newstring = "die with";
            for (int i = 0; i < strings.Length; i++)
            {
                if (i == position)
                {
                    strings[i] = newstring;
                }
            }
            Console.WriteLine(String.Join(" ", strings));
            Console.WriteLine();

            Console.WriteLine("Вывод ступенчатого массива\n");
            int[][] stairs = new int[3][];
            stairs[0] = new int[2];
            stairs[1] = new int[3];
            stairs[2] = new int[4];
          /*  int g, k = 0;
            for (g = 0; g < stairs.Length; g++)
            {
                for (k = 0; k < stairs[g].Length; k++)
                {
                    stairs[g][k] = Convert.ToInt32(Console.ReadLine());
                }
            } */
            for (int n = 0; n < stairs.Length; n++)
            {
                for (int m = 0; m < stairs[n].Length; m++)
                {
                    Console.Write($"{stairs[n][m]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Неявно типизированные переменные с массивом и строкой");
            var notclearlyarray = new[] { 0, 1, 2 };
            var notclearlystring = "Неявно типизированная строка";
            foreach (var i in notclearlyarray)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("{0} ", notclearlystring);
            Console.WriteLine();
        }

            // int, char, string, ulong.  
            // Данный метод возвращает кортеж с 4-мя
            // разными значениями
        static Tuple<int, ulong, string, char> Corteg(int a, string name)
            {
                int sqr = a * a;
                ulong lng = 45678;
                string s = "Привет, " + name;
                char ch = (char)(name[0]);

                return Tuple.Create<int, ulong, string, char>(sqr, lng, s, ch);
            }

            static void Kortage()
            {

                var myTuple = Corteg(25, "Лина");
                Console.WriteLine("{0}\n25 в квадрате: {1}\nЦелое число без знака: "
                    + "{2}\nПервый символ в имени: {3}\n", myTuple.Item3, myTuple.Item1, myTuple.Item2, myTuple.Item4);

                // Создаем кортеж произвольной размерности
                var myTuple2 = Tuple.Create<int, char, string, decimal, float, byte, short, Tuple<int,
                    ulong, string, char>>(12, 'C', "Name", 12.3892m, 0.5f, 120, 4501, myTuple);
                Console.ReadLine();
            }


        static void Main(string[] args)
        {
            /// <PackageReference Include = "System.ValueTuple" Version="4.3.1" />
            (int, int, int, char) GetTuple(int[] array, string sentense)
            {
                int min = array[0];
                int max = array[0];
                int sum = 0;
                char letter = sentense[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > min)
                    {
                        max = array[i];
                    }
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                    sum += array[i];
                }
                var tuple = (max, min, sum, letter);
                return tuple;
            }
            Types();
            Strings();
            Arrays();
            Kortage();
            int[] numbers = new int[] { 7, 9, 27, 23, 67, 6 };
            var mainTuple = GetTuple(numbers, "Witcher");
            Console.WriteLine("\nПолучение кортежа значений\n");
            Console.WriteLine("Max: {0}", mainTuple.Item1);
            Console.WriteLine("Min: {0}", mainTuple.Item2);
            Console.WriteLine("Sum: {0}", mainTuple.Item3);
            Console.WriteLine("Letter: {0}", mainTuple.Item4);
            Console.ReadLine();
        }
    }
        public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>
        {
        }
}
