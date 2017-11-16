using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создать Сессию, содержащую зачеты и экзамены.
//Найти
//все экзамены по заданному предмету, 
//подсчитать общее количество испытаний в сессии
//количество тестов с заданным числом вопросов.

namespace LW6
{
    enum State
    { EXP = 1, TEST };
    struct Owner
    {
        public static readonly string Name = "Lina";
        public static long Id;
    }
    public class ExamException : Exception
    {
        public ExamException(string message) : base(message)
        { }
    }
    public class AmountException : ExamException
    {
        public AmountException(string message) : base(message)
        { }
    }
    public class AmountNumber : ExamException
    {
        public AmountNumber(string message) : base(message)
        { }
    }
    public abstract class Experience
    {
        public abstract double FinalExam();
    }
    public interface IExam
    {
        void Show();
        void Input();
    }

    public class Exams : Experience, IExam
    {
        public double amount;
        private double _otvet;

        public Exams()
        {
            Input();
        }
        static Exams()
        {
            Owner.Id = DateTime.Now.Ticks;
        }
        public Exams(double amount)
        {
            this.amount = amount;
            if (amount < 0)
            {
                throw new AmountException("Amount cannot be less then zero.");
            }
        }

        public override double FinalExam()
        {
            return 8;
            //double otvet = _otvet;
            //Console.WriteLine("Вариант билета на экзамене: {0}", _otvet);
            //return _otvet;
        }

        public override string ToString()
        {
            Show();
            return base.ToString();
        }
        public void Input()
        {
            Console.Write("Введите вариант билета на выпускном экзамене: ");
            amount = Convert.ToInt32(Console.ReadLine());
        }

        public void Show()
        {
            Console.WriteLine("\nИспытание\nВариант билета на экзамене: {0} \n", amount);
        }

        //public override double Question()
        //{
        //    return 0;
        //}
    }

    public class Tests : Experience, IExam
    {
        private double _var;

        public Tests(string _v, string _v2, string _v3)
        {
            Input();
        }

        //public override double Question()
        //{
        //    double var = _var;
        //    Console.WriteLine("Вариант вопроса в тесте: {0}", _var);
        //    return _var;
        //}

        public override string ToString()
        {
            Show();
            return base.ToString();
        }
        public void Input()
        {
            Console.Write("Введите вариант вопроса в тесте: ");
            _var = Convert.ToInt32(Console.ReadLine());
        }

        public void Show()
        {
            Console.WriteLine("Испытание\nВариант вопроса теста: {0}\n", _var);
        }

        public override double FinalExam()
        {
            return 0;
        }
    }

    sealed public class Printer
    {
        public Printer() { }
        public string Print(IExam obj)
        {
            return obj.ToString();
        }

    }

    public class Session<T>
    {
        private List<T> container;
        public Session()
        {
            container = new List<T>();
        }
        public T this[int number]
        {
            get { return container[number]; }
            set { container[number] = value; }
        }
        public void Push(T element)
        {
            container.Add(element);
        }
        public void Pop()
        {
            container.RemoveAt(container.Count - 1);
        }
        public int Size
        {
            get { return container.Count; }
        }
        public void Output()
        {
            Console.WriteLine("\nContainer: ");
            for (int i = 0; i < container.Count; i++)
            {
                Console.Write(container[i]);
            }
            Console.WriteLine();
        }
    }
    public class SessionController
    {
        public double TotalSquare = 0;
        public int TotalElements = 0;
        private Session<Experience> UIF;
        private Session<Experience> UIT;
        public SessionController(Session<Experience> ui)
        {
            this.UIF = ui;
        }
        //public Session1Controller(Session<Experience> ui)
        //{
        //    this.UIT = ui;
        //}
        //public int GetCountUiElements()
        //{
        //    for (int i = 0; i < UIF.Size; i++)
        //    {
        //        TotalElements += UIF[i].count;
        //    }
        //    return TotalElements;
        //}
        public double GetTotalSquare()
        {
            for (int i = 0; i < UIF.Size; i++)
            {
                TotalSquare += UIF[i].FinalExam();
            }
            return TotalSquare;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Session<Experience> exp = new Session<Experience>();
            exp.Push(new Exams(4));

            Session<Experience> test = new Session<Experience>();
            test.Push(new Tests("варианты на экзамене", "третий", "четвертый"));

            // figures.Output();
            Console.Write("Choose the action: \n1. Figures\n2. Elements\n");
            int state = Convert.ToInt32(Console.ReadLine());
            SessionController controller;
            if (state == (int)State.EXP)
            {
                controller = new SessionController(exp);
                Console.WriteLine("Total square: {0}", controller.GetTotalSquare());
            }
            else if (state == (int)State.TEST)
            {
                //controller = new SessionController(test);
                //Console.WriteLine("Total elements: {0}", controller.GetCountUiElements());
                //controller.GetButtonList();
                Console.WriteLine("Error is coming {0}");
            }
            else
            {
                Console.WriteLine("Error.");
            }
            //Debug.Assert(isError); // проверяет, есть ли логическая ошибка при создании программы. Выбрасывает стек вызовов, если false
            //IExam exam = new Exams("варианты на экзамене", "первый", "второй");
            //IExam que = new Tests("варианты на экзамене", "первый", "второй");


            //Printer printer = new Printer();
            //Console.WriteLine("\nIS-operator: {0}, {1}", exam is Exams, que is Tests);
            //// обычное приведение, но с использование оператора as(выбрасывает не исключение, а null)
            //IExam exam1 = exam as Exams;
            //IExam que1 = que as Tests;
            //printer.Print(exam);
            //printer.Print(que);

            Console.ReadKey();
        }
    }
}
