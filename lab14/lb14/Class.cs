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

    [Serializable]
    public class Experiences
    {
        public int count;
        public string title;
    }

    [Serializable]
    public class Tests : Experiences, IExam
    {
        public string var;
        public string var1;
        private double _var;
        private double _var1;

        public Tests()
        {
            Input();
        }
        public Tests(int count, string title)
        {
            this.count = count;
            this.title = title;
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
    }
}