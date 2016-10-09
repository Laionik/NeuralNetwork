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
        double temp1;
        double temp2;
        int dayOfTheYear;
        layer[] layerList;
        public NeuralNetwork(int numberOfLayers, params int[] numberOfNeurons)
        {
            double temp1 = 12.213;
            double temp2 = 15.313;
            int dayOfTheYear = 123;
            trData = new TrainingData(temp1, temp2, dayOfTheYear);

            layerList = new layer[numberOfLayers];
            for(int i = 0; i < numberOfLayers; i++)
            {
                layerList[i] = new layer(numberOfNeurons[i]);
            }


        }

        //uwzględnianie wag
        //czy jest lato? n1 = t1*w1,1 + t2 * w1,2 + t3* w1,3 wektor * macierz transpozycja 
        //temperatura spada? 
        //czy ostatnio było ciepło
        //nieznane zjawisko
    }
}
