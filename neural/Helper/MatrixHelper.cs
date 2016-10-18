using System;

namespace neural.Helper
{
    static class MatrixHelper
    {

        /// <summary>
        /// Mnożenie macierzy
        /// </summary>
        /// <param name="firstMatrix">Macierz</param>
        /// <param name="secondMatrix">Macierz</param>
        /// <returns>Macierz</returns>
        public static double[,] MatrixMultiply(double[,] firstMatrix, double[,] secondMatrix)
        {
            double[,] resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < firstMatrix.GetLength(1); k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
            return resultMatrix;
        }

        /// <summary>
        /// Odejmowanie macierzy
        /// </summary>
        /// <param name="firstMatrix">Macierz</param>
        /// <param name="secondMatrix">Macierz</param>
        /// <returns>Macierz</returns>
        public static double[,] MatrixSubstraction(double[,] firstMatrix, double[,] secondMatrix)
        {
            double[,] resultMatrix = new double[firstMatrix.GetLength(0), firstMatrix.GetLength(0)];
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = firstMatrix[i, j] * secondMatrix[i, j];
                }
            }
            return resultMatrix;
        }

        /// <summary>
        /// Transpozcyja macierzy
        /// </summary>
        /// <param name="matrix">Macierz</param>
        /// <returns>Macierz</returns>
        public static double[,] MatrixTransposition(double[,] matrix)
        {
            //TODO Transpozycja macierzy
            return matrix;
        }


        /// <summary>
        /// Wyświetlanie macierzy
        /// </summary>
        /// <param name="matrix">Macierz</param>
        public static void MatrixDisplay(double[,] matrix)
        {
            for (int first = 0; first < matrix.GetLength(0); first++)
            {
                for (int second = 0; second < matrix.GetLength(1); second++)
                {
                    Console.Write("{0} ", matrix[first, second]);
                }
                Console.WriteLine();
            }
        }
    }
}
