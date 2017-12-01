using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using lab5;

namespace lb14 //процес преобразования объектов в поток байтов
{
    [Serializable]
    public class UI<T>
    {
        public List<T> container;
        public UI()
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
        public void PushRange(T[] arr)
        {
            container.AddRange(arr);
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
    public static class Serializator
    {
        public static Tests accept, exit;
        public static Tests[] buttons;
        public static UI<Tests> container;
        static Serializator()
        {
            accept = new Tests(3, "accept");
            exit = new Tests(1, "exit");
            buttons = new Tests[] { accept, exit };
            container = new UI<Tests>();
            container.PushRange(buttons);
        }
        public static void Binary()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fwriter = new FileStream("binary.dat", FileMode.OpenOrCreate);
            formatter.Serialize(fwriter, container);
            fwriter.Close();
            FileStream file = new FileStream("binary.dat", FileMode.OpenOrCreate);
            UI<Tests> desButtons = (UI<Tests>)formatter.Deserialize(file);
            desButtons.Output();
        }
        public static void JSON()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(UI<Tests>));
            FileStream fwriter = new FileStream("tests.json", FileMode.OpenOrCreate);
            jsonFormatter.WriteObject(fwriter, container);
            fwriter.Close();
            FileStream freader = new FileStream("tests.json", FileMode.OpenOrCreate);
            UI<Tests> desButtons = (UI<Tests>)jsonFormatter.ReadObject(freader);
            desButtons.Output();
        }
        public static void XML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(UI<Tests>));
            FileStream fwriter = new FileStream("tests.xml", FileMode.OpenOrCreate);
            formatter.Serialize(fwriter, container);
            fwriter.Close();
            FileStream freader = new FileStream("tests.xml", FileMode.OpenOrCreate);
            UI<Tests> desButtons = (UI<Tests>)formatter.Deserialize(freader);
            freader.Close();
        }
        public static void XPath()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("tests.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("//Tests/title");
            foreach (XmlNode n in childnodes)
            { Console.WriteLine(n.InnerText); }
        }
    }
    public static class XMLer
    {
        public static void CreateDoc()
        {
            XDocument xdoc = new XDocument();
            XElement accept = new XElement("tests");
            XAttribute title = new XAttribute("title", "accept");
            XElement count = new XElement("count", "3");
            accept.Add(title);
            accept.Add(count);
            XElement exit = new XElement("button");
            XAttribute title1 = new XAttribute("title", "exit");
            XElement count1 = new XElement("count", "1");
            exit.Add(title1);
            exit.Add(count1);
            XElement buttons = new XElement("tests-s");
            buttons.Add(accept);
            buttons.Add(exit);
            xdoc.Add(buttons);
            xdoc.Save("testsLINQ.xml");
        }
        public static void Print()
        {
            XDocument xdoc = XDocument.Load("testsLINQ.xml");
            foreach (XElement tests in xdoc.Element("tests-s").Elements("tests"))
            {
                XAttribute title = tests.Attribute("title");
                XElement count = tests.Element("count");
                if (title != null && count != null)
                {
                    Console.WriteLine("Test's title: {0}", title.Value);
                    Console.WriteLine("Count of: {0}", count.Value);
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Serializator.Binary();
            Serializator.JSON();
            Serializator.XML();
            Serializator.XPath();
            XMLer.CreateDoc();
            XMLer.Print();
            Console.ReadLine();
        }
    }
}
