using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.IO;
using Microsoft.Win32;
//using Microsoft.Win32;
/// <summary>
/// Библиотека взаимодействия с массивом
/// </summary>

namespace LibMas
{
    public class Class1
    {
        public static void MasZapoln(int i, out int[] mas)
        {
            mas = new int[i];
            Random rnd = new Random();
            for (int j = 0; j < i; j++)
            {
                mas[j] = rnd.Next(-100, 100);
            }
        }
        public static void MasOchist(ref int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 0;
            }
        }
        public static void MasSave(int[] mas)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(Convert.ToString(mas.Length));
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
        }
        public static void MasOpen(out int[] mas)
        {
            mas = new int[1];
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открыть таблицы";
            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int x = Convert.ToInt32(file.ReadLine());
                mas = new Int32[x];
                for (int i = 0; i < x; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
            }

        }
    }
}
