using System;

namespace neural.Class
{
    class layer
    {
        public Perceptron perceptron;
        public int size;
        public int previousLayerSize;
        public double[,] values;
        public layer(int previousLayerSize, int numberOfNeurons, Perceptron.myDelegate activationFunction)
        {
            this.size = numberOfNeurons;
            this.previousLayerSize = previousLayerSize;
            values = new double[numberOfNeurons, numberOfNeurons];
            perceptron = new Perceptron(numberOfNeurons, previousLayerSize, activationFunction);
            perceptron.randomScalesGenerate();
        }
    }
}
