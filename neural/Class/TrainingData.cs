using System.Collections.Generic;
using System.Windows;

namespace neural.Class
{
    class TrainingData
    {
        public double[] input;
        public double[] output;
        
        public TrainingData(double[] dataIn, double[] dataOut)
        {
            input = dataIn;
            output = dataOut;
        }
    }
}
