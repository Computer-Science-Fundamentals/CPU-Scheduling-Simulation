using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class ExponentialDistributionFunction : ICDFFunction
    {
        /** 
         * This method generates the burst time of 
         * various cpu scheduling parameter such as 
         * burst time,
         * using cummulative distribution function
         * P(x < X | x > 0) = 1 - e^-LX
         * where L = Lamdba, using Lambda of 1
         * between range 51 - 100
        **/
        private const int min = 51;
        private const int max = 100;
        public double ComputeCDF(Random rnd)
        {
            int lambda = 1;
            Double X, cdf;
            lock (rnd)
            {//synchronize
                X = rnd.NextDouble();
            };
            //Console.WriteLine("X: {0}", X);
            cdf = 1 - Math.Exp(-lambda * X);
            return cdf;
        }

        public int GenerateBurstTime(Random rnd)
        {
            Double cdf = ComputeCDF(rnd);
            Console.WriteLine(min);
            Console.WriteLine(max);
            //scale cdf between 51 - 100
            int wt = (int)(min + (cdf * (max - min)));
            return wt;
        }
    }
}
