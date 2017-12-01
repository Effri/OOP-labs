using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab13
{
    public class LASLog
    {
        private const string path = @"las_log.txt";
        public StreamReader freader;
        public StreamWriter fwriter;
        public LASLog()
        { }
        public void Read()
        {
            freader = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            while ((line = freader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            freader.Close();
        }
        public void Write(object obj)
        {
            fwriter = new StreamWriter(path, true, System.Text.Encoding.Default);
            fwriter.WriteLine("Session's time: {0}, {1}", DateTime.Now, obj + "\nEnd session.\n\n");
            fwriter.Close();

        }
        public void Find(string str)
        {
            int countSessions = 0;
            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains(str))
                {
                    Console.WriteLine(line);
                }
                if (line.Contains("Session"))
                {
                    countSessions++;
                }
            }
            Console.WriteLine("Session's count: {0}", countSessions);
        }
    }
    public static class LASDiskInfo
    {
        static DriveInfo[] drives;
        static LASDiskInfo()
        {
            drives = DriveInfo.GetDrives(); //сведения на диске
        }
        public static string GetFreeSpace(string title)
        {
            string freeSpace = "";
            foreach (DriveInfo drive in drives)
            {
                if (title == drive.Name)
                {
                    freeSpace = ("Drive's free space: " + drive.TotalFreeSpace); //объем свободного места на диске в байтах
                }
            }
            return freeSpace;
        }
        public static string GetFileSystem(string title)
        {
            string fileSystem = "";
            foreach (DriveInfo drive in drives)
            {
                if (title == drive.Name)
                {
                    fileSystem = ("Drive's type: " + drive.DriveType); //тип диска
                }
            }
            return fileSystem;
        }
        public static string GetAllInfo() //инфа о диске
        {
            string info = "";
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    info += ("Drive's title: " + drive.Name + ", " +
                             "Drive's space: " + drive.TotalSize + ", " +
                             "Drive's free space: " + drive.TotalFreeSpace + ", " +
                             "Drive's label: " + drive.VolumeLabel + ", ");
                }
            }
            return info;
        }
    }
    public class LASFileInfo
    {
        public FileInfo file;
        public LASFileInfo(string path)
        {
            file = new FileInfo(path);
        }
        public string GetFullPath()
        {
            return file.DirectoryName;
        }
        public string GetFileInfo()
        {
            return ("File's name: " + file.Name + ", " +
                    "File's extension: " + file.Extension + ", " +
                    "File's length: " + file.Length);
        }
        public string GetCreationTime()
        {
            return ("File's creation date: " + file.CreationTime);
        }
    }
    public static class LASDirInfo
    {
        public static int countDirs = 0;
        public static string GetCountSubDirectories(string directory)
        {
            string[] dirs = Directory.GetDirectories(directory);
            int count = 0;
            foreach (string dir in dirs)
            {
                count++;
            }
            return ("Sub directory's count: " + count);
        }
        public static string GetCreationTime(string directory)
        {
            return Convert.ToString(Directory.GetCreationTime(directory));
        }
        public static string GetCountFiles(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            int count = 0;
            foreach (string file in files)
            {
                count++;
            }
            return ("File's count in this directory: " + count);
        }
        public static string GetCountParentDirectories(string directory) //есть ли каталог(директория)
        {
            if (Directory.Exists(directory))
            {
                countDirs++;
                return GetCountParentDirectories(Convert.ToString(Directory.GetParent(directory))); ;
            }
            else
            {
                return ("Count of parent's directories: " + countDirs);
            }
        }
    }
    public static class LASFileManager
    {
        public static void Task(string drive, string user_dir, string user_ex)
        {
            string list = (LASDirInfo.GetCountSubDirectories(drive) + "\n" + LASDirInfo.GetCountFiles(drive));
            string dir = Convert.ToString(Directory.CreateDirectory(@"E:\Учёба\3 сем\ООП\Лабы\lb13\LASInspect"));
            StreamWriter fwriter = new StreamWriter(dir + "\\las_dirinfo.txt", true, System.Text.Encoding.Default);
            fwriter.Write(list);
            fwriter.Close();
            FileInfo file = new FileInfo(dir + "\\las_dirinfo.txt");
            if (file.Exists)
            {
                file.CopyTo(dir + "\\las_dirinfonew.txt", true); //удаление первоначального файла
                file.Delete();
            }
            string newDir = Convert.ToString(Directory.CreateDirectory(@"E:\Учёба\3 сем\ООП\Лабы\lb13\work_file"));
            string[] dirs = Directory.GetFiles(user_dir);
            for (int i = 0; i < dirs.Length; i++)
            {

                if (dirs[i].Contains(user_ex))
                {
                    string path = dirs[i];
                    FileInfo fileInf = new FileInfo(path);
                    if (fileInf.Exists)
                    {
                        dirs[i] = dirs[i].Remove(0, 11);
                        fileInf.MoveTo(@"E:\Учёба\3 сем\ООП\Лабы\lb13\work_file\" + dirs[i]);
                    }
                }
            }
            string oldPath = @"E:\Учёба\3 сем\ООП\Лабы\lb13\work_file";
            dir += "\\lasfiles";
            Directory.Move(oldPath, dir);

            string zip = @"E:\Учёба\result.zip";
            string extract = @"E:\Учёба\extract";
            ZipFile.CreateFromDirectory(dir, zip);
            ZipFile.ExtractToDirectory(zip, extract);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LASLog logger = new LASLog();
            LASFileInfo file = new LASFileInfo(@"E:\Учёба\3 сем\ООП\Лабы\lb13\las_log.txt");
            // LASFileManager.Task(@"C:\", @"E:\Учёба\3 сем\ООП\Лабы\lb13\txt", ".txt"); // запускать очень осторожно, не забыв про создание файлов в txt, удаление zip
            logger.Write(LASDirInfo.GetCountParentDirectories(@"E:\Учёба\3 сем\ООП\Лабы\lb13"));
            logger.Write(LASDirInfo.GetCountSubDirectories(@"E:\Учёба\3 сем\ООП\Лабы\lb13"));
            logger.Write(LASDirInfo.GetCountFiles(@"E:\Учёба\3 сем\ООП\Лабы\lb13"));
            logger.Write(LASDirInfo.GetCreationTime(@"E:\Учёба\3 сем\ООП\Лабы\lb13"));
            logger.Write(LASDiskInfo.GetFreeSpace("C:\\"));
            logger.Write(LASDiskInfo.GetFileSystem("E:\\"));
            logger.Write(LASDiskInfo.GetAllInfo());
            logger.Write(file.GetFullPath());
            logger.Write(file.GetFileInfo());
            logger.Write(file.GetCreationTime());
            logger.Find("18");
            Console.ReadLine();
        }
    }
}
