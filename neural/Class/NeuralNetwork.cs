using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neural.Class
{
    class NeuralNetwork
    {
        TrainingData trData;
        layer[] layerList;

        public NeuralNetwork(int numberOfLayers, params int[] numberOfNeurons)
        {
            layerList = new layer[numberOfLayers];
            for(int i = 0; i < numberOfLayers; i++)
            {
                layerList[i] = new layer(i == 0? 0 : numberOfNeurons[i-1], numberOfNeurons[i]);
            }
        }

        public void Populate(params double[] data)
        {
            trData = new TrainingData(data);
        }

        public void AppendLayer(int n)
        {
            int lastInputLayerSize = 0;
            var outputLayer = layerList.LastOrDefault().size;
            var tempLayerList = layerList;
            layerList = new layer[tempLayerList.Length + 1];
            for (int i = 0; i < tempLayerList.Length - 1; i++)
            {
                layerList[i] = tempLayerList[i];
                lastInputLayerSize = tempLayerList[i].size;
            }
            layerList[tempLayerList.Length - 1] = new layer(lastInputLayerSize, n); //new hidden input layer
            layerList[tempLayerList.Length] = new layer(n, outputLayer); //last layer
        }

        public double Propagate(TrainingData td)
        {
            double[,] inputData = new double[td.input.Length, 1];
            for(int i = 0; i < td.input.Length; i++)
            {
                inputData[i,0] = td.input[i];
            }
            List<double> listOfResults = new List<double>();
            double result = 0;

            //nie wiem co tu przekazać...
            for(int i = 1; i < layerList.Length; i++)
            {
                var matrixTest = MatrixMultiply(inputData, layerList[i].perceptron.scalesMatrix);
                listOfResults.Add(layerList[i].perceptron.activationFunction());
                result = layerList[i].perceptron.activationFunction();
            }
            return result;
        }

        public double[,] MatrixMultiply(double[,] firstMatrix, double[,] secondMatrix)
        {
            double[,] resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < secondMatrix.GetLength(1); k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
            return resultMatrix;
        }
    }
}
