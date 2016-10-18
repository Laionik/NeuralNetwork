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
            Task1();
            Task2();
            Console.ReadKey();
        }

        /// <summary>
        /// Standardowa propagacja sieci neuronowej
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("Propagation");
            NeuralNetwork nn = new NeuralNetwork(3, 3, activationFunction);
            nn.AppendLayer(5);
            nn.AppendLayer(5);
            var result = nn.Propagate(3, 4, 5);
            Console.WriteLine("Result:");
            MatrixHelper.MatrixDisplay(result);
        }

        /// <summary>
        /// Propagacja sieci neuronowej z wykorzystaniem wstecznej propagacji
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("Back propagation");
            NeuralNetwork nn = new NeuralNetwork(3, 3, activationFunction);
            nn.AppendLayer(5);
            nn.AppendLayer(5);
            for (int i = 0; i < 1000; i++)
            {
                nn.PropagateBack(new double[] { 3, 4, 5 },new double[] { 0.1, 0.2, 0.3 }, activationFunction);
            }
            
            var result = nn.Propagate(3, 4, 5);
            Console.WriteLine("Result:");
            MatrixHelper.MatrixDisplay(result);
        }
    }
}
