using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practicum9_Task2_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //фильтр по типу файлов
            dlg.Filter = "Text files(*.txt)|*.txt";
            //директория папки, которая открывается по нажатию кнопки
            dlg.InitialDirectory = "D:\\c_develop\\projects\\Practicum9\\Practicum9_Task2\\bin\\Debug";

            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем имя выбранного файла
            string fileName = dlg.FileName;
            //получаем директорию выборанного файла
            string filePath = Path.GetFullPath(fileName);
            //переносим строки из файла в массив
            string[] arr = File.ReadAllLines(filePath);
            //вывод массива строк в текстбокс и поиск самой длинной строки
            int maxSizeStr = arr[0].Length;
            int indexStr = 0;

            richTextBox1.Clear();
            for (int i = 0; i < arr.Length; i++)
            {
                richTextBox1.Text += $"[{i + 1}] {arr[i]}\n";
                if (arr[i].Length > maxSizeStr)
                {
                    maxSizeStr = arr[i].Length;
                    indexStr = i;
                }
            }
            //вывод информации о самой длинной строке во второй текстбокс
            richTextBox2.Text = $"Номер самой длинной строки - {indexStr + 1}, размер - {maxSizeStr} символов";
        }
    }
}
