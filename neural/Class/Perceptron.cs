using System;
using System.Collections.Generic;

namespace neural.Class
{
    //http://numerics.mathdotnet.com/
    class Perceptron
    {
        object[,] scalesMatrix;
        public Perceptron(int sizeX, int sizeY, int activFunctionMode)
        {
            scalesMatrix = new object[sizeX, sizeY];
            //var result = ActivationFunction(0, activFunctionMode);
        }

        public static double? ActivationFunction(double data, int mode, double beta = 1)
        {
            switch (mode)
            {
                case 1: //binary
                    return data < 0 ? 0 : 1;
                case 2: //sigmod binary
                    return 1 / (1 + Math.Pow(Math.E, beta * (-1) * data));

                default:
                    return null;
            }
        }

        //public List<object> Propagation()
        //{
            //zrob mnozenie macierzy
        //}

        //public List<object> MatrixMultiply(List<object> x1, List<object> x2)
        //{

        //}
    }
}
