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
            int firstColumns = firstMatrix.GetLength(1);
            int firstRows = firstMatrix.GetLength(0);
            int secondColumns = secondMatrix.GetLength(1);
            int secondRows = secondMatrix.GetLength(0);
            if (firstColumns != secondRows)
                throw new Exception("Macierze do siebie nie pasują. Wymiary macierzy " + firstRows + "x" + firstColumns + "---" + secondRows + "x" + secondColumns);
            double[,] resultMatrix = new double[firstRows, secondColumns];
            for (int i = 0; i < firstRows; i++)
            {
                for (int j = 0; j < secondColumns; j++)
                {
                    for (int k = 0; k < secondRows; k++)
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
            double[,] resultMatrix = new double[firstMatrix.GetLength(0), firstMatrix.GetLength(1)];
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
            int matrixRow = matrix.GetLength(0);
            int matrixColumn = matrix.GetLength(1);
            double[,] newMatrix = new double[matrixColumn, matrixRow];
            for (int i = 0; i < matrixColumn; i++)
            {
                for (int j = 0; j < matrixRow; j++)
                {
                    newMatrix[i, j] = matrix[j, i];
                }
            }
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

        /// <summary>
        /// Wektor na macierz
        /// </summary>
        /// <param name="input">Wektor</param>
        /// <returns>Macierz</returns>
        public static double[,] ConvertToMatrix(double[] input)
        {
            double[,] matrix = new double[1, input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                matrix[0, i] = input[i];
            }
            return matrix;
        }
    }
}
