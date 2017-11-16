using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Испытание, Тест, Экзамен, Выпускной экзамен, Вопрос;

namespace lab5
{
    public abstract class Experience
    {
        public abstract double FinalExam();
        public abstract double Question();
    }
    public interface IExam
    {
        void Show();
        void Input();
    }

    public class Exams : Experience, IExam
    {
        public string otvet;
        public string otvet1;
        private double _otvet;
        private double _otvet1;

        public Exams(string v, string v1, string v2)
        {
            Input();
        }
        public Exams(string otvet)
        {
            this.otvet = otvet;
        }

        public override double FinalExam()
        {
            double otvet = _otvet;
           Console.WriteLine("Вариант билета на экзамене: {0}", _otvet1);
            return _otvet;
        }

        public override string ToString()
        {
            Show();
            return base.ToString();
        }
        public void Input()
        {
            Console.Write("Введите вариант билета на выпускном экзамене: ");
            _otvet1 = Convert.ToInt32(Console.ReadLine());
        }

        public void Show()
        {
            Console.WriteLine("\nИспытание\nВариант билета на экзамене: {0} \n", _otvet1);
        }

        public override double Question()
        {
            return 0;
        }
    }

    public class Tests : Experience, IExam
    {
        public string var;
        public string var1;
        private double _var;
        private double _var1;

        public Tests(string _v, string _v2, string _v3)
        {
            Input();
        }
        public Tests(string var)
        {
            this.var = var;
        }

        public override double Question()
        {
            double var = _var;
            Console.WriteLine("Вариант вопроса в тесте: {0}", _var1);
            return _var;
        }

        public override string ToString()
        {
            Show();
            return base.ToString();
        }
        public void Input()
        {
            Console.Write("Введите вариант вопроса в тесте: ");
            _var1 = Convert.ToInt32(Console.ReadLine());
        }

        public void Show()
        {
            Console.WriteLine("Испытание\nВариант вопроса теста: {0}\n", _var1);
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
    class Program
    {
        static void Main(string[] args)
        {
            IExam exam = new Exams("варианты на экзамене", "первый", "второй");
            IExam que = new Tests("варианты на экзамене", "первый", "второй");
  
            Printer printer = new Printer();
            Console.WriteLine("\nIS-operator: {0}, {1}", exam is Exams, que is Tests);
            // обычное приведение, но с использование оператора as(выбрасывает не исключение, а null)
            IExam exam1 = exam as Exams;
            IExam que1 = que as Tests;
            printer.Print(exam);
            printer.Print(que);

            Console.ReadKey();
        }
    }
}
