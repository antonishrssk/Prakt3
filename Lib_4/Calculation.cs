using System;

namespace Lib_4
{
    public class Calculation
    {
        /// <summary>
        /// Вычисление произведений элементов каждого столбца матрицы
        /// </summary>
        /// <param name="matr">Матрица</param>
        /// <returns>Массив с произведениями элементов каждого столбца</returns>
        public static int[] ColumnProduct(int[,] matr)
        {
            int[] result = new int[matr.GetLength(1)];
            for (int j = 0; j < result.Length; j++) // Перебираем все столбцы матрицы
            {
                int product = 1; // Произведение элементов столбца матрицы
                for (int i = 0; i < matr.GetLength(0); i++) // Перебираем значения всех элементов столбца
                    product *= matr[i, j];
                result[j] = product;
            }

            return result;
        }
    }
}
