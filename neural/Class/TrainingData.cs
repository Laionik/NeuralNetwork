using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neural.Class
{
    class TrainingData
    {
        List<object> input; //T t1; T t2; T d;
        List<object> output;

        public TrainingData(params object[] dataIn)
        {
            input = dataIn.ToList();
        }
    }
}
