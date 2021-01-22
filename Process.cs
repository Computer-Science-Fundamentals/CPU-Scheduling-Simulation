using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class Process
    {
        private string processID;
        private int burstTime;
        private int arrivalTime;
        private double ioBlockProbability;
        private int ioBlockTime;
        private readonly Random random = new Random();

        private int blockedTill;

        public Process(String processID, int burstTime, int arrivalTime, double ioBlockProbability, int ioBlockTime)
        {

            this.processID = processID;
            this.burstTime = burstTime;
            this.arrivalTime = arrivalTime;
            this.ioBlockProbability = ioBlockProbability;
            this.ioBlockTime = ioBlockTime;

            this.blockedTill = -1;

        }

        public void SetBurstTime(int burseTime)
        {
            this.burstTime = burseTime;
        }

        public void SetArrivalTime(int arrivalTime)
        {
            this.arrivalTime = arrivalTime;
        }

        public double GetIOBlockProbability()
        {
            return ioBlockProbability;
        }

        public string GetProcessID()
        {
            return processID;
        }

        public int GetBurstTime() { return burstTime; }

        public int GetArrivalTime()
        {
            return arrivalTime;
        }

        public int GetIOBlockTime()
        {
            return ioBlockTime;
        }

        public Process Clone() {
            return new Process(this.processID, this.burstTime, this.arrivalTime, this.ioBlockProbability, this.ioBlockTime);
        }

        public void Start(int ct)
        {
            double runIOProbability;

            lock (random)
            {//synchronize
                runIOProbability = random.NextDouble();
            }

            if (ioBlockProbability > runIOProbability)
                blockedTill = ct + ioBlockTime + 1; //+1 because of block after 1 ms
        }

        public bool IsBlocked(int ct)
        {
            return (blockedTill > ct);
        }

        public int GetBlockedTill()
        {
            return blockedTill;
        }

    }
}
