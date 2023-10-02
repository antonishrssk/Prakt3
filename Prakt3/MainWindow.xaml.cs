using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_4;
using LibMas;

namespace Prakt3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[,] matr; // Описываем матрицу как глобальный элемент

        private void dataGridMatr_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex; // Определяем номер столбца
            int indexRow = e.Row.GetIndex(); // Определяем номер строки
            bool f = Int32.TryParse(((TextBox)e.EditingElement).Text, out matr[indexColumn, indexRow]); // Заносим полученное значение в массив
            if (!f) MessageBox.Show("Введите правильные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            bool f1 = Int32.TryParse(tbRowCount.Text, out int rowCount), // Получаем количество рядов в матрице
                f2 = Int32.TryParse(tbColumnCount.Text, out int columnCount); // Получаем количество колонок в матрице

            if (f1 && f2 && rowCount >= 0 && columnCount >= 0)
            {
                matr = new int[rowCount, columnCount]; // Создаем матрицу
                dataGridMatr.ItemsSource = VisualArray.ToDataTable(matr).DefaultView; // Выводим матрицу на форму
            }
            else MessageBox.Show("Введите правильные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            bool f1 = Int32.TryParse(tbRowCount.Text, out int rowCount), // Получаем количество рядов в матрице
                f2 = Int32.TryParse(tbColumnCount.Text, out int columnCount); // Получаем количество колонок в матрице

            if (f1 && f2 && rowCount >= 0 && columnCount >= 0)
            {
                matr = Arrays.Fill(rowCount, columnCount);
                dataGridMatr.ItemsSource = VisualArray.ToDataTable(matr).DefaultView; // Выводим матрицу на форму
            }
            else MessageBox.Show("Введите правильные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null)
            {
                tbRez.Clear();

                int[] result = Calculation.ColumnProduct(matr);
                for (int i = 0; i < result.Length; i++)
                    tbRez.Text += $"C{i + 1}={result[i]}  ";
            }
            else MessageBox.Show("Создайте таблицу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            matr = null;
            dataGridMatr.ItemsSource = null;
            tbRez.Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null) Arrays.Save(matr);
            else MessageBox.Show("Создайте таблицу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Arrays.Load(out matr, out bool isLoaded);

            if (isLoaded) dataGridMatr.ItemsSource = VisualArray.ToDataTable(matr).DefaultView; // Выводим матрицу на форму
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Антонишин Кирилл Сергеевич\n" +
                "Практическая работа №3\n" +
                "Дана матрица размера M × N. Для каждого столбца матрицы найти произведение его элементов.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
