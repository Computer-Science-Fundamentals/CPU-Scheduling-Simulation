using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class WaitTimeGenerator
    {
        private static readonly Random rnd = new Random();
        /** 
         * This method generates the burst time of 
         * various cpu scheduling parameter such as 
         * burst time,
         * using cummulative distribution function
         * P(x < X | x > 0) = 1 - e^-LX
         * where L = Lamdba, using Lambda of 1
         * between range 51 - 100
        **/
        private static Double ComputeCDF() {
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

        private static int GenerateBurstTime(int min = 51, int max = 100) {
            Double cdf = ComputeCDF();
            //scale cdf between 51 - 100
            int wt = (int) (min + (cdf * (max - min)));
            return wt;
        }

        private static Dictionary<string, Object> GenerateIOBlockParameter(int min = 0, int max = 100) {
            Double ioBlockProbability = ComputeCDF();
            int ioBlockTime = (int)(min + (ioBlockProbability * (max - min)));
            return new Dictionary<string, object>()
            {
                { "IOBlockProbability", ioBlockProbability },
                { "IOBlockTime", ioBlockTime }
            };
        }

        private static int GenerateArrivalTime(int lastArrivalTime = 0) {
            int waitTime = 0, min = 0, max = 5;
            lock (rnd)
            {//synchronize
                waitTime = rnd.Next(min, max);
            }
            return lastArrivalTime + waitTime;
        }

        public static List<Process> GenerateProcesses(int noOfProcesses)
        {
            int lastArrivalTime = 0;
            List<Process> inputProcesses = new List<Process>();
            for (int i = 1; i <= noOfProcesses; i++)
            {
                lastArrivalTime = (i > 1) ? GenerateArrivalTime(lastArrivalTime) : lastArrivalTime;

                string pid = String.Format("P{0}", i);
                Dictionary<string, object> IOBlockParam = GenerateIOBlockParameter();
                int BurstTime = GenerateBurstTime();
                int ArrivalTime = lastArrivalTime;

                Process process = new Process(pid, BurstTime, ArrivalTime, (Double)IOBlockParam["IOBlockProbability"], (int)IOBlockParam["IOBlockTime"]);
                inputProcesses.Add(process);

                Console.WriteLine(
                    String.Format("{0} => Arrival Time: {1}, Burst Time: {2}, IOBlockProbability: {3}, IOBlockTime: {4}",
                                    process.GetProcessID(),
                                    process.GetArrivalTime(),
                                    process.GetBurstTime(),
                                    process.GetIOBlockProbability(),
                                    process.GetIOBlockTime()
                                 )
                );
            }
            return inputProcesses;
        }

    }
}
