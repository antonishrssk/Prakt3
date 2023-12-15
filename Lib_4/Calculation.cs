using System;

namespace Lib_4
{
    public class Calculation
    {
        /// <summary>
        /// ���������� ������������ ��������� ������� ������� �������
        /// </summary>
        /// <param name="matr">�������</param>
        /// <returns>������ � �������������� ��������� ������� �������</returns>
        public static int[] ColumnProduct(int[,] matr)
        {
            int[] result = new int[matr.GetLength(1)];
            for (int j = 0; j < result.Length; j++) // ���������� ��� ������� �������
            {
                int product = 1; // ������������ ��������� ������� �������
                for (int i = 0; i < matr.GetLength(0); i++) // ���������� �������� ���� ��������� �������
                    product *= matr[i, j];
                result[j] = product;
            }

            return result;
        }
    }
}
