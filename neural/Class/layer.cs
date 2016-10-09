using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neural.Class
{
    class layer
    {
        Perceptron perceptron;
        List<object> result;
        public layer(int numberOfNeurons)
        {
            perceptron = new Perceptron(0,0, 1); //0 i 0 do zmiany
        }
    }
}
