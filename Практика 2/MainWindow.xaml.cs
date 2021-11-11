using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_3;
using LibMas;
using Масивы;

namespace Практика_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] mas;
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила студентка группы ИСП-31 Баева Ирина. Пр2" +
               "  Ввести n целых чисел. Найти разницу чисел. Результат вывести на экран");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void V_Click(object sender, RoutedEventArgs e)
        {
            rez.Clear();

            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Вы не создали массив, укажите количество колонок, диапазон чисел и нажмите кнопку Заполнить", "Ошибка");
            }
            else
            {
                int otvet = Class2.baeva(mas);
                rez.Text = Convert.ToString(otvet);
            }
        }
        //Заполнение массива
        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {

            //Проверка поля на корректность введенных данных
            if (Int32.TryParse(kol.Text, out int count) && count > 0)
            {
                Class1.MasZapoln(count, out mas);

                //Выводим массив на форму
                masData.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;

                //очищаем результат
                rez.Clear();
            }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }
        //Очищение массива
        private void ОчиститьМассив_Click(object sender, RoutedEventArgs e)
        {
            Class1.MasOchist(ref mas);

            //Очищаем результат массива
            rez.Clear();

            //Выводим массив на форму
            masData.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }
        //Сохранение массива
        private void Savemas_Click(object sender, RoutedEventArgs e)
        {
            Class1.MasSave(mas);
        }

        //Открытие массива
        private void Openmas_Click(object sender, RoutedEventArgs e)
        {

            Class1.MasOpen(out mas);
            for (int i = 0; i < mas.Length; i++)
            {
                //Выводим массив на форму
                masData.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }
    }
}
