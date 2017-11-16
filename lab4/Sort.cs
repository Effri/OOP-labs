using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW4
{
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
    public class Multitude<T>
{
        class Date
        {
            public string createDate;
            public Date()
            {
                createDate = DateTime.Now.ToShortDateString();
            }
        }

        private List<int> list;
        public string mltCreatingDate;
             public Multitude(List<int> numbers)
        {
            Date time = new Date();
            Owner data = new Owner();;
            data.GetData();
            list = numbers;
            mltCreatingDate = time.createDate;
    
        }
        private List<T> _list;
    Multitude() //множество
    {
         _list = new List<T>();
            list = new List<int>();
    }
        public const string Name = "Lina";
        public const string Organization = "BelSTU";
        public static readonly long Id = DateTime.Now.Ticks;
        public void Print()
        {

            foreach (int number in list)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
            Console.WriteLine("ID: {0}\nName: {1}\nOrganization: {2}\n", Id, Name, Organization);
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
    }
 
    class Program
{

    static void Main(string[] args)
    {

        Multitude<int> _mt1 = new Multitude<int>(1, 2, 3, 4, 5);
        Console.WriteLine("Множество 1: {0}", _mt1);
          
        Multitude<int> _mt2 = new Multitude<int>(4, 5, 6, 7, 8);
        Console.WriteLine("Множество 2: {0}", _mt2);
           
        _mt1.Print();
            Console.WriteLine("Пересечение множеств: {0}", _mt1.Intersect(_mt2));
        _mt2.Add(9);
        Console.WriteLine("Множество 2 после добавления элемента: {0}", _mt2);
        Console.WriteLine("Объединение множеств: {0}", _mt1.Union(_mt2));
        _mt1.Delete(1);
        Console.WriteLine("Множество 1 после удаления элемента: {0}", _mt1);
        Console.WriteLine("Разность множеств: {0}", _mt1.Except(_mt2));
        Console.ReadKey();
    }
}
}