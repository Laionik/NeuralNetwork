using neural.Class;
using neural.Helper;
using System;

namespace neural
{
    class Program
    {
        static Perceptron.myDelegate activationFunction;
        static void Main(string[] args)
        {
            activationFunction = new Perceptron.myDelegate(Perceptron.sigmodFunction);
            double[] trainingData = new double[] { 3, 4, 5 };
            Task1(trainingData);
            Task2(trainingData);
            Console.ReadKey();
        }

        /// <summary>
        /// Standardowa propagacja sieci neuronowej
        /// </summary>
        static void Task1(double[] trainingData)
        {
            Console.WriteLine("Propagation");
            NeuralNetwork nn = new NeuralNetwork(trainingData.Length, 1, activationFunction);
            nn.AppendLayer(5);
            var result = nn.Propagate(trainingData);
            Console.WriteLine("Result:");
            MatrixHelper.MatrixDisplay(result);
        }

        /// <summary>
        /// Propagacja sieci neuronowej z wykorzystaniem wstecznej propagacji
        /// </summary>
        static void Task2(double[] trainingData)
        {
            try
            {
                Console.WriteLine("Back propagation");
                NeuralNetwork nn = new NeuralNetwork(trainingData.Length, 3, activationFunction);
                nn.AppendLayer(5);
                for (int i = 0; i < 10000; i++)
                {
                   nn.PropagateBack(trainingData, new double[] { 0.1, 0.2, 0.3 }, activationFunction);
                }
                var result = nn.Propagate(trainingData);
                Console.WriteLine("Result:");
                MatrixHelper.MatrixDisplay(result);
            }
           catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }
}
