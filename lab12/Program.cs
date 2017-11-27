using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
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
}

    namespace lab12
{
    public class Reflector
    {
        public Type type;
        public Reflector(string type)
        {
            this.type = Type.GetType(type, false, true);
        }
        public void AboutClass()
        {
            using (FileStream fstream = new FileStream("class.txt", FileMode.OpenOrCreate))
            {
                foreach (MemberInfo info in type.GetMembers())
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(info.DeclaringType + " - " + info.MemberType + " - " + info.Name + "\n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
        public void PublicMethods()
        {
            using (FileStream fstream = new FileStream("methods.txt", FileMode.OpenOrCreate))
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    if (method.IsPublic)
                    {
                        byte[] array = System.Text.Encoding.Default.GetBytes(method.Name + "\n");
                        fstream.Write(array, 0, array.Length);
                    }
                }
            }
        }
        public void SpecifiedMethods(string arg)
        {
            using (FileStream fstream = new FileStream("specified_methods.txt", FileMode.OpenOrCreate))
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    //инфа о параметре метода
                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (arg.Contains(parameters[i].ParameterType.Name))
                        {
                            byte[] array1 = System.Text.Encoding.Default.GetBytes(method.ReturnType.Name + " - " + method.Name + " (");
                            fstream.Write(array1, 0, array1.Length);
                            byte[] array2 = System.Text.Encoding.Default.GetBytes(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                            fstream.Write(array2, 0, array2.Length);
                            byte[] array3 = System.Text.Encoding.Default.GetBytes(", ");
                            if (i + 1 < parameters.Length)
                            {
                                fstream.Write(array3, 0, array3.Length);
                            }
                            fstream.Write(System.Text.Encoding.Default.GetBytes(")\n"), 0, System.Text.Encoding.Default.GetBytes(")\n").Length);
                        }
                    }
                }
            }
        }
        public void Fields()
        {
            using (FileStream fstream = new FileStream("fields.txt", FileMode.OpenOrCreate))
            {
                foreach (FieldInfo field in type.GetFields()) //возвр все поля данного типа
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(field.FieldType + " - " + field.Name + "\n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
        public void Properties()
        {
            using (FileStream fstream = new FileStream("properties.txt", FileMode.OpenOrCreate))
            {
                foreach (PropertyInfo prorertie in type.GetProperties()) //получ все св-ва (массив)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(prorertie.PropertyType + " - " + prorertie.Name + "\n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
        public void Interfaces()
        {
            using (FileStream fstream = new FileStream("interfaces.txt", FileMode.OpenOrCreate))
            {
                foreach (Type interfaces in type.GetInterfaces()) //реализ интерфейсы
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(interfaces.Name + "\n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
        //reflector.RunTimeMethod("lab12.Exams", "FinalExam");
        //public void RunTimeMethod(string type, string method)
        //{
        //    Assembly asm = Assembly.LoadFrom(@"E:\Учёба\3 сем\ООП\Лабы\lab12\lab12\bin\Debug\lab12.dll");
        //    Type newType = asm.GetType(type);
        //    List<int> nums = new List<int> { 1488, 0, 27, 54, 42 };
        //    object programm = Activator.CreateInstance(newType, new object[] { nums });
        //    MethodInfo newMethod = newType.GetMethod(method);
        //    object result = newMethod.Invoke(programm, new object[] { });
        //    Console.WriteLine("Method of another instanse: {0}\nMethod's value: {1}", method, result);
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Всё сохранилось в отдельные файлы в корневой папке");
            Reflector reflector = new Reflector("lab5.Exams");
            reflector.AboutClass();
            reflector.PublicMethods();
            reflector.Fields();
            reflector.Properties();
            reflector.Interfaces();
            reflector.SpecifiedMethods("Object");
            Console.ReadLine();
        }
    }
}
