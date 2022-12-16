using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Practicum9_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName, filePath;
            //ввод имени файла
            while (true)
            {
                try
                {
                    Console.WriteLine("При запуске с github необходимо заранее создать текстовый файл в папке, \n" +
                        "где находится исполняемый файл (.../bin/Debug/)");
                    Console.WriteLine("___________________________________________________________________________________");
                    Console.Write("Введите имя файла и его расширение через точку: ");
                    fileName = Console.ReadLine();
                    Regex regex = new Regex(@"[A-Za-z].txt");
                    MatchCollection matches = regex.Matches(fileName);
                    if (matches.Count == 0) throw new Exception("Вы ввели неправильно. Введите согласно указаниям");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //нахождение пути до файла
            filePath = Path.GetFullPath(fileName);
            //запись строк из файла в массив
            string[] arr = File.ReadAllLines(filePath);
            //поиск самой длинной строки
            int maxSizeStr = arr[0].Length;
            int indexStr = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length > maxSizeStr)
                {
                    maxSizeStr = arr[i].Length;
                    indexStr = i;
                }
            }
            //вывод в консоль
            Console.WriteLine($"Самая длинная строка - {arr[indexStr]}\n" +
                $"Ее номер - {indexStr + 1}, размер - {maxSizeStr}");



        }
    }
}

