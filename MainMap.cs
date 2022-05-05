using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Карта_Кохонена
{
    public class MainMap
    {
        Double[] inputlayer;
        Double[] outputlayer;
        Double[][] weights;

        Func<Double, Double> activfunc;

        public MainMap(int inputlayer, int outputlayer, Func<Double, Double> activfunc)
        {
            Random random = new();
            this.inputlayer = new Double[inputlayer];
            this.outputlayer = new Double[outputlayer];
            this.activfunc = activfunc;
            this.weights = new Double[outputlayer][];
            for (int i = 0; i < outputlayer; i++)
            {
                weights[i] = new Double[inputlayer];
                for (int j = 0; j < inputlayer; j++)
                {
                    weights[i][j] = random.NextDouble();
                }
            }
        }

        public void SetMap(Double[] inputlayer)
        {
            try
            {
                this.inputlayer = inputlayer;

                for (int i = 0; i < weights.Length; i++)
                {
                    this.outputlayer[i] = 0;

                    for (int j = 0; j < weights.Length; j++)
                    {
                        this.outputlayer[i] += weights[i][j] * this.activfunc(this.inputlayer[j]);
                    }

                    this.outputlayer[i] = this.activfunc(this.outputlayer[i]);
                }
            }
            catch (Exception ex) when (inputlayer.Length != this.inputlayer.Length)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Double[] GetMap()
        {
            return outputlayer;
        }


    }
}
