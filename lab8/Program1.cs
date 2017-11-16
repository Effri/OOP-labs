using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace LW8
{
    interface IMultitude<T>
    {
        void Push(T number);
        void Pop();
        void Print();
    }
    public class Button
    {
        public int count;
        public string title;
        public Button(string title)
        {
            this.title = title;
        }
        public void Print()
        {
            Console.WriteLine("\nButtons\nCount: {0}\nTitle: {1}\n", count, title);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    class Owner
    {
        public static readonly long Id;
        public string Name;
        public string Organization;
        static Owner()
        {
            Id = DateTime.Now.Ticks;
        }
        public Owner()
        {
            Name = "Lina";
            Organization = "BelSTU";
        }
        public void GetData()
        {
            Console.WriteLine("ID: {0}\nName: {1}\nOrganization: {2}\n", Id, Name, Organization);
        }
    }
     class Multitude<T> : IMultitude<T>
    {
        class Date
        {
            public string createDate;
            public Date()
            {
                createDate = DateTime.Now.ToShortDateString();
            }
        }

        private List<T> list;
        public string mltCreatingDate;
        private string strings;
        private int size;
        int[] i = new int[9];
        public Multitude(string str)
        {
            Date time = new Date();
            Owner data = new Owner(); ;
            data.GetData();
            strings = str;
            size = strings.Length;
            mltCreatingDate = time.createDate;

        }
        public Multitude(List<T> numbers)
        {
            Date time = new Date();
            mltCreatingDate = time.createDate;
            list = numbers;
            size = list.Count;
        }
        private List<T> _list;
        Multitude() //множество
        {
            _list = new List<T>();
            list = new List<T>();
        }
        public const string Name = "Lina";
        public const string Organization = "BelSTU";
        public static readonly long Id = DateTime.Now.Ticks;
        private List<int> numbers;

        public void Print()
        {
            foreach (T number in list)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Multitude was created: {0}", mltCreatingDate);
        }

        public Multitude(params T[] args) //добавление эл в конец списка
        : this()
        {
            _list.AddRange(args);
        }
        public Multitude(IEnumerable<T> mas) //пересечение 2-х послед. с помощью заданного IEqualityComparer<T> для сравнения значений.
            : this()
        {
            _list.AddRange(mas);
        }

        public void Push(T elem)
        {
            _list.Add(elem);
        }
        public void Pop()
        {
            _list.RemoveAt(_list.Count - 1);
        }
        public void Add(T elem) //добавление эл в конец списка
        {
            _list.Add(elem);
        }
        public void Delete(T elem) //удаление
        {
            _list.Remove(elem);
        }
        public Multitude<T> Intersect(Multitude<T> Source) //пересечение
        {
            return new Multitude<T>(_list.Intersect(Source._list));
        }
        public Multitude<T> Union(Multitude<T> Source) //объединение
        {
            return new Multitude<T>(_list.Union(Source._list));
        }
        public Multitude<T> Except(Multitude<T> Source) //исключение
        {
            return new Multitude<T>(_list.Except(Source._list));
        }
        public override string ToString()
        {
            return string.Join(",", _list);
        }
        public int mulSize
        {
            get { return this.size; }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            string readPath = @"E:\Учёба\3 сем\ООП\Лабы\LW8\input.txt";
            string writePath = @"E:\Учёба\3 сем\ООП\Лабы\LW8\output.txt";

            //Multitude<int> _mt1 = new Multitude<int>(1, 2, 3, 4, 5);
            //Console.WriteLine("Множество 1: {0}", _mt1);

            //Multitude<int> _mt2 = new Multitude<int>(4, 5, 6, 7, 8);
            //Console.WriteLine("Множество 2: {0}", _mt2);

            //_mt1.Print();
            //Console.WriteLine("Пересечение множеств: {0}", _mt1.Intersect(_mt2));
            //_mt2.Add(9);
            //Console.WriteLine("Множество 2 после добавления элемента: {0}", _mt2);
            //Console.WriteLine("Объединение множеств: {0}", _mt1.Union(_mt2));
            //_mt1.Delete(1);
            //Console.WriteLine("Множество 1 после удаления элемента: {0}", _mt1);
            //Console.WriteLine("Разность множеств: {0}", _mt1.Except(_mt2));
           

            List<double> nums1 = new List<double> { 23.5, 65.4, 32.1, 9.0012 };
            List<int> nums2 = new List<int> { 27, 64, 128, 256 };
            IMultitude<double> mul1 = new Multitude<double>(nums1);
            IMultitude<int> mul2 = new Multitude<int>(nums2);
            Multitude<Button> mul3 = new Multitude<Button>();
            Multitude<int> mul4 = new Multitude<int>(nums2);
            try
            {
                mul1.Print();
                mul2.Print();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
                Console.WriteLine("Method: " + exception.TargetSite);
                Console.WriteLine("Source: " + exception.Source);
            }
            finally
            {
                Console.WriteLine("\nAll errors was processed");
            }
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
              
                for (int i = 0; i < mul4.mulSize; i++)
                {
                    sw.Write(mul4.mulSize + " ");
                }
            }
            List<int> nums3 = new List<int>();
            using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    nums3.Add(Convert.ToInt32(sr.ReadLine()));
                }
            }
            Multitude<int> mul5 = new Multitude<int>(nums3);
            mul5.Print();
            Console.ReadKey();
        }
    }
}