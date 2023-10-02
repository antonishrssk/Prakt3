using Microsoft.Win32;
using System;
using System.IO;

namespace LibMas
{
    public class Arrays
    {
        /// <summary>
        /// ���������� ������� � ����
        /// </summary>
        /// <param name="matr">�������</param>
        public static void Save(int[,] matr)
        {
            // ������ � ���������� ������� SaveFileDialog
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "��� ����� (*.*) | *.* |��������� ����� (*.txt) | *.txt";
            save.FilterIndex = 2;
            save.Title = "���������� �������";

            if (save.ShowDialog() == true) // ��������� ���������� ���� � ��� ������ �������� � ������
            {
                StreamWriter file = new StreamWriter(save.FileName); // ������� ����� ��� ������ � ������ � ��������� ��� ��� �����

                file.WriteLine($"{matr.GetLength(0)}\n{matr.GetLength(1)}"); // ���������� ������ ������� � ����
                for (int i = 0; i < matr.GetLength(0); i++)
                    for (int j = 0; j < matr.GetLength(1); j++)
                        file.WriteLine(matr[i, j]); // ���������� �������� ������� � ����

                file.Close();
            }
        }

        /// <summary>
        /// ������ ������� �� �����
        /// </summary>
        /// <param name="matr">�������</param>
        /// <param name="isLoaded">��������� �� �������</param>
        public static void Load(out int[,] matr, out bool isLoaded)
        {
            // ������ � ����������� ������� OpenFileDialog
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "��� ����� (*.*) | *.* |��������� ����� (*.txt) | *.txt";
            open.FilterIndex = 2;
            open.Title = "�������� �������";

            if (open.ShowDialog() == true) // ��������� ���������� ���� � ��� ������ �������� � ������
            {
                StreamReader file = new StreamReader(open.FileName); // ������� ����� ��� ������ � ������ � ��������� ��� ��� �����

                int rowCount = Convert.ToInt32(file.ReadLine()),
                    columnCount = Convert.ToInt32(file.ReadLine());

                matr = new int[rowCount, columnCount]; // ������ �������
                for (int i = 0; i < matr.GetLength(0); i++)
                    for (int j = 0; j < matr.GetLength(1); j++)
                        matr[i, j] = Convert.ToInt32(file.ReadLine()); // ��������� ������� �� �����

                file.Close();

                isLoaded = true;
            }
            else
            {
                matr = null;
                isLoaded = false;
            }
        }

        /// <summary>
        /// ���������� ������� ���������� �������
        /// </summary>
        /// <param name="rowCount">���������� �����</param>
        /// <param name="columnCount">���������� ��������</param>
        /// <returns>����������� �������</returns>
        public static int[,] Fill(int rowCount, int columnCount)
        {
            int[,] matr = new int[rowCount, columnCount];
            Random rnd = new Random();

            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    matr[i, j] = rnd.Next(10);

            return matr;
        }
    }
}
