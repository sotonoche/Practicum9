using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practicum9
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            string[] str_arr;
            //ввод последовательности
            while (true)
            {
                try
                {
                    Console.Write("Введите числа последовательности через пробел: ");
                    str = Console.ReadLine();
                    if (str.Length == 0) throw new Exception("Пустая строка. Введите последовательность!");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //заполнение массива
            str_arr = str.Split(' ');
            int[] arr = new int[str_arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    arr[i] = int.Parse(str_arr[i]);
                    if (char.IsLetter(str[i])) throw new Exception("Входная строка имела неверный формат");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //создание файла
            FileStream f = File.Create("t.dat");
            StreamWriter f_str = new StreamWriter("t_str.txt");
            BinaryWriter fOut = new BinaryWriter(f);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] != 0)
                {
                    fOut.Write(arr[i]);
                    f_str.WriteLine($"{arr[i]} ");
                }
            }
            fOut.Close();
            f_str.Close();
            f.Close();
            //Объекты f и fIn связаны с одним и тем же файлом 
            f = new FileStream("t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long m = f.Length;

            Console.Write("Значения, записанные в файл: ");
            for (long i = 0; i < m; i += 4)
            {
                f.Seek(i, SeekOrigin.Begin);
                var n = fIn.ReadInt32();
                Console.Write($"{n} ");
            }
            Console.WriteLine();
            fIn.Close();
            f.Close();
        }
    }
}
