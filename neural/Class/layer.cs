using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neural.Class
{
    class layer
    {
        public Perceptron perceptron;
        List<double> result;
        public int size;
        public int previousLayerSize;
        public layer(int previousLayerSize, int numberOfNeurons)
        {
            this.size = numberOfNeurons;
            this.previousLayerSize = previousLayerSize;
            perceptron = new Perceptron(numberOfNeurons, previousLayerSize, new Perceptron.myDelegate(Perceptron.sigmodFunction));
            perceptron.randomScalesGenerate(10);
        }
    }
}
