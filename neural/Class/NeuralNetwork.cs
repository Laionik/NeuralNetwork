using neural.Helper;
using System;
using System.Linq;

namespace neural.Class
{
    class NeuralNetwork
    {
        public TrainingData trData;
        public layer[] layerList;
        private int inputSize;
        private int outputSize;
        private Perceptron.myDelegate activationFunction;

        public NeuralNetwork(int inputSize, int outputSize, Perceptron.myDelegate activationFunction)
        {
            this.inputSize = inputSize;
            this.outputSize = outputSize;
            this.activationFunction = activationFunction;
            LayerCreateInputOutput(inputSize, outputSize);
        }

        // TODO
        /// <summary>
        /// Rozszerzenie TrainingData
        /// </summary>
        /// <param name="data">Wartości startowe</param>
        public void Populate(double[] data)
        {
            // TODO
            //trData = new TrainingData(data, new double[] { });
        }

        /// <summary>
        /// Tworzenie warstwy wejściowej i wyjściowej
        /// </summary>
        /// <param name="inputSize">Liczba neuronów warstwy wejściowej</param>
        /// <param name="outputSize">Liczba neuronów warstwy wyjściowej</param>
        private void LayerCreateInputOutput(int inputSize, int outputSize)
        {
            layerList = new layer[2];
            layerList[0] = new layer(0, inputSize, activationFunction);
            layerList[1] = new layer(inputSize, outputSize, activationFunction);
        }

        /// <summary>
        /// Dodawanie nowej warstwy
        /// </summary>
        /// <param name="n">liczba elementów nowej warstwy</param>
        public void AppendLayer(int n)
        {
            int lastInputLayerSize = 0;
            var tempLayerList = layerList;
            layerList = new layer[tempLayerList.Length + 1];
            for (int index = 0; index < tempLayerList.Length - 1; index++)
            {
                layerList[index] = tempLayerList[index];
                lastInputLayerSize = tempLayerList[index].size;
            }
            layerList[tempLayerList.Length - 1] = new layer(lastInputLayerSize, n, activationFunction);
            layerList[tempLayerList.Length] = new layer(n, outputSize, activationFunction);
        }

        /// <summary>
        /// Metoda propagacji - sporządza predykcję wektora wejściowego
        /// </summary>
        /// <param name="td"></param>
        /// <returns></returns>
        public double[,] Propagate(params double[] data)
        {
            trData = new TrainingData(data, new double[] { });
            double[,] inputData = MatrixHelper.ConvertToMatrix(trData.input);

            for (int index = 1; index < layerList.Length; index++)
            {
                inputData = MatrixHelper.MatrixMultiply(inputData, layerList[index].perceptron.scalesMatrix);
                if (index != layerList.Length)
                    inputData = ExecuteActivationFunction(inputData, layerList[index].perceptron.activationFunction);
                layerList[index].values = inputData;
            }
            return inputData;
        }

        /// <summary>
        /// Użycie funkcji aktywacji na każdym elemencie macierzy
        /// </summary>
        /// <param name="input">macierz</param>
        /// <returns></returns>
        private double[,] ExecuteActivationFunction(double[,] input, Perceptron.myDelegate activationFunction, bool deriv = false)
        {
            for (int first = 0; first < input.GetLength(0); first++)
            {
                for (int second = 0; second < input.GetLength(1); second++)
                {
                    input[first, second] = activationFunction(input[first, second], deriv);
                }
            }
            return input;
        }

        /// <summary>
        /// Obliczanie błędu
        /// </summary>
        /// <param name="trData">Dane treningowe</param>
        /// <returns>Macierz</returns>
        private double[,] ErrorCalculate(TrainingData trData)
        {
            double[,] y = MatrixHelper.ConvertToMatrix(trData.output);
            var ysim = Propagate(trData.input);
            return MatrixHelper.MatrixSubstraction(y, ysim);
        }

        /// <summary>
        /// Propagacja wsteczna
        /// </summary>
        /// <param name="input">Dane wejściowe</param>
        /// <param name="output">Dane wyjściowe</param>
        public void PropagateBack(double[] input, double[] output, Perceptron.myDelegate activationFunction)
        {
            var error = ErrorCalculate(new TrainingData(input, output));
            int numberOfLayers = layerList.Length - 1;
            for (int index = 0; index < numberOfLayers; index++)
            {
                var valuesActivationFunction = ExecuteActivationFunction(layerList[numberOfLayers - index].values, activationFunction, true);
                var delta = MatrixHelper.MatrixMultiply(error, valuesActivationFunction);

                var scalesMatrixTransposition = MatrixHelper.MatrixTransposition(layerList[numberOfLayers - index].perceptron.scalesMatrix);
                error = MatrixHelper.MatrixMultiply(delta, scalesMatrixTransposition);

                var matrixMultiplied = MatrixHelper.MatrixMultiply(layerList[numberOfLayers - index - 1].values, delta);
                var matrixTransposed = MatrixHelper.MatrixTransposition(matrixMultiplied);
                layerList[numberOfLayers - index].perceptron.scalesMatrix = MatrixHelper.MatrixSubstraction(layerList[numberOfLayers - index].perceptron.scalesMatrix, matrixTransposed);
            }
        }
    }
}
