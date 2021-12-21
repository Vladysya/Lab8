using System;
using System.IO;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string pd = "D:\\OOP_lab08";
            Create(pd);
            Copy(pd + "\\Texts", pd + "\\Havryshko");
            Copy(pd + "\\Sources", pd + "\\Havryshko");
            Copy(pd + "\\Reports", pd + "\\Havryshko");
            Console.WriteLine("Каталоги успiшно скопiйованi");
            Move(pd + "\\Havryshko", pd + "\\KN1-B20" + "\\Havryshko");

            string dirName = pd + "\\Texts";
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            string text = $"Назва каталогу: {dirInfo.Name}\n" +
                          $"Повна назва каталогу: {dirInfo.FullName}\n" +
                          $"Час створення каталогу: {dirInfo.CreationTime}\n" +
                          $"Кореневий каталог: {dirInfo.Root}";
            Console.WriteLine("Текстовий файл створено, та помiщено iнформацiю: \n" + text);
            using (FileStream fstream = new FileStream(pd + "\\Texts\\dirinfo.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }

            void Create(string path)
            {
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "\\KN1-B20" + "\\Havryshko");
                Directory.CreateDirectory(path + "\\Havryshko");
                Directory.CreateDirectory(path + "\\Sources");
                Directory.CreateDirectory(path + "\\Reports");
                Directory.CreateDirectory(path + "\\Texts");
            }
            void Copy(string path1, string path2)
            {
                DirectoryInfo dirinf1 = new DirectoryInfo(path1);
                DirectoryInfo dirinf2 = new DirectoryInfo(path2);
                string name = dirinf1.Name;
                Directory.CreateDirectory(path2 + $@"\{name}");
            }
            void Move(string path1, string path2)
            {
                DirectoryInfo dirinf = new DirectoryInfo(path2);
                if (dirinf.Exists)
                {
                    dirinf.Delete(true);
                }
                new DirectoryInfo(path1).MoveTo(path2);
                Console.WriteLine("Каталог перемiщено");
            }
        }
    }
}
