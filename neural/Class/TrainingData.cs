using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neural.Class
{
    class TrainingData
    {
        public double[] input; //T t1; T t2; T d;
        public List<double> output;

        public TrainingData(params double[] dataIn)
        {
            input = dataIn.ToArray();
            output = new List<double>();
        }
    }
}
