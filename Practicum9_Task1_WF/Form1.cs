using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practicum9_Task1_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] str_arr = textBox1.Text.Split(' ');
            int[] arr = new int[str_arr.Length];
            //заполнение массива интовых значений
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = int.Parse(str_arr[i]);
                }
            }
            catch
            {
                MessageBox.Show("Ожидается ввод целых чисел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание файла
            FileStream f = File.Create("t.dat");
            StreamWriter f_str = new StreamWriter("t_str.txt");
            BinaryWriter fOut = new BinaryWriter(f);

            richTextBox1.Clear();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] != 0)
                {
                    fOut.Write(arr[i]);
                    f_str.Write($"{arr[i]} ");
                }
            }
            fOut.Close();
            f.Close();
            f_str.Close();
            //Объекты f и fIn связаны с одним и тем же файлом 
            f = new FileStream("t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long m = f.Length;

            for (long i = 0; i < m; i += 4)
            {
                f.Seek(i, SeekOrigin.Begin);
                var n = fIn.ReadInt32();
                richTextBox1.Text += $"{n} ";
            }
            fIn.Close();
            f.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string file = "t.dat";
            string filePath = Path.GetFullPath(file);
            Process.Start(filePath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string file = "t_str.txt";
            string filePath = Path.GetFullPath(file);
            Process.Start(filePath);
        }
    }
}
