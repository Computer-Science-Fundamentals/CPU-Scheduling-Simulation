using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class WaitTimeGenerator
    {
        /*This Class is a Singleton for Generating Simulation Time
         * Thread Safety is ensured by using double check locking
         */
        private readonly Random rnd = new Random();
        private ICDFFunction cDFFunction;
        private static WaitTimeGenerator instance;
        private static object padlock = new object();
        private WaitTimeGenerator(ICDFFunction cDFFunction)
        {
            this.cDFFunction = cDFFunction;
        }

        public static WaitTimeGenerator GetInstance(ICDFFunction cDFFunction)
        {
            if (instance == null) {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new WaitTimeGenerator(cDFFunction);
                    }
                }
            }

            return instance;
        }

        private Dictionary<string, Object> GenerateIOBlockParameter(int min = 0, int max = 100) {
            Double ioBlockProbability = cDFFunction.ComputeCDF(rnd);
            int ioBlockTime = (int)(min + (ioBlockProbability * (max - min)));
            return new Dictionary<string, object>()
            {
                { "IOBlockProbability", ioBlockProbability },
                { "IOBlockTime", ioBlockTime }
            };
        }

        private int GenerateArrivalTime(int lastArrivalTime = 0) {
            int waitTime = 0, min = 0, max = 5;
            lock (rnd)
            {//synchronize
                waitTime = rnd.Next(min, max);
            }
            return lastArrivalTime + waitTime;
        }

        public List<Process> GenerateProcesses(int noOfProcesses)
        {
            int lastArrivalTime = 0;
            List<Process> inputProcesses = new List<Process>();
            for (int i = 1; i <= noOfProcesses; i++)
            {
                lastArrivalTime = (i > 1) ? GenerateArrivalTime(lastArrivalTime) : lastArrivalTime;

                string pid = String.Format("P{0}", i);
                Dictionary<string, object> IOBlockParam = GenerateIOBlockParameter();
                int BurstTime = cDFFunction.GenerateBurstTime(rnd);
                Console.WriteLine(BurstTime);
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
