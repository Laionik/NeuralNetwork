using System;
using System.Collections.Generic;

namespace neural.Class
{

    class Perceptron
    {
        public double[,] scalesMatrix;
        public delegate double myDelegate(double data);
        public myDelegate activationFunction;
        public object functionResult;
        public Perceptron(int sizeX, int sizeY, myDelegate activationFunction)
        {
            scalesMatrix = new double[sizeX, sizeY];
            this.activationFunction += activationFunction;
            //functionResult = this.activationFunction.DynamicInvoke(0);
        }

        public static double binaryFunction(double data)
        {
            return data < 0 ? 0 : 1;
        }

        public static double sigmodFunction(double data)
        {
            return 1 / (1 + Math.Pow(Math.E, 1 * (-1) * data));
        }


        public void randomScalesGenerate(int maxScale)
        {
            Random rnd = new Random();
            for (int first = 0; first < scalesMatrix.GetLength(0); first++)
                for (int second = 0; second < scalesMatrix.GetLength(1); second++)
                    scalesMatrix[first, second] = rnd.Next(maxScale);
        }

        //public static double? ActivationFunction(double data, int mode, double beta = 1)
        //{
        //    switch (mode)
        //    {
        //        case 1: //binary
        //            return data < 0 ? 0 : 1;
        //        case 2: //sigmod binary
        //            return 1 / (1 + Math.Pow(Math.E, beta * (-1) * data));

        //        default:
        //            return null;
        //    }
        //}


        //public List<object> Propagation()
        //{
        //zrob mnozenie macierzy
        //}

        //public List<object> MatrixMultiply(List<object> x1, List<object> x2)
        //{

        //}
    }
}
