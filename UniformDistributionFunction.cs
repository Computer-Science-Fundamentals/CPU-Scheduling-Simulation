using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class UniformDistributionFunction : ICDFFunction
    {
        /** 
         * This method generates the burst time of 
         * various cpu scheduling parameter such as 
         * burst time,
         * using cummulative distribution function
         * P(x < X | x > 0) = x - a/b-a
         * between range 1 - 20
        **/
        private const int min = 1;
        private const int max = 20;
        public double ComputeCDF(Random rnd)
        {
            //interval = (0,1)
            Double X, cdf;
            const int a = 0, b = 1;
            lock (rnd)
            {//synchronize
                X = rnd.NextDouble();
            };
            //Console.WriteLine("X: {0}", X);
            cdf = (X - a) / (b - a);
            return cdf;
        }

        public int GenerateBurstTime(Random rnd)
        {
            Double cdf = ComputeCDF(rnd);
            Console.WriteLine(cdf);
            //scale cdf between 1 - 20
            int wt = (int)(min + (cdf * (max - min)));
            Console.WriteLine(wt);
            return wt;
        }
    }
}
