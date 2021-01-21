using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    abstract class SchedulingAlgorithm
    {
        protected int clockTime;
        private int totalProcessCount;
        protected int processedCount;
        protected int startTimeCurrentlyRunningProcess;
        protected Schedule schedule;
        protected Process currentlyRunningProcess;
        protected Queue<Process> waitingQueue;
        protected Queue<Process> readyQueue;

        public SchedulingAlgorithm(List<Process> inputProcesses)
        {
            waitingQueue = new Queue<Process>();
            readyQueue = new Queue<Process>();
            clockTime = 0;
            schedule = new Schedule();
            totalProcessCount = inputProcesses.Count;
            currentlyRunningProcess = null;
            startTimeCurrentlyRunningProcess = 0;

            //clone inputProcesses
            foreach (Process process in inputProcesses)
            {
                waitingQueue.Enqueue(process.Clone());
            }
        }

        public void FillReadyQueue()
        {
            //Dispatch processes that arrived at the current clockTime
            for (int i = 0; i < waitingQueue.Count; i++)
            {
                Process process = waitingQueue.Peek();
                int arrivalTime = process.GetArrivalTime();
                if (arrivalTime.Equals(clockTime) && !(process.IsBlocked(clockTime)))
                {
                    readyQueue.Enqueue(waitingQueue.Dequeue());
                    continue;
                }
                //reset ArrivalTime of blocked process on waitingQueue
                if (clockTime > arrivalTime) {
                    process.SetArrivalTime(clockTime + process.GetIOBlockTime() + 1);
                }

                Console.WriteLine(String.Format("PID {0} is still waiting..., ClockTime: {1}, BlockTillTime: {2}, Arrival Time: {3}", 
                    process.GetProcessID(), clockTime, process.GetBlockedTill(), process.GetArrivalTime()));
            }

            //Currently arrived not blocked processes

            //Queue<Process> temp = new Queue<Process>(waitingQueue);
            //foreach(Process process in temp)
            //{
            //    //Currently arrived not blocked processes
            //    if (process.GetArrivalTime().Equals(clockTime) && !(process.IsBlocked(clockTime)))
            //    {
            //        readyQueue.Enqueue(waitingQueue.Dequeue());
            //        continue;
            //    }
            //    Console.WriteLine(String.Format("PID {0} is still waiting..., ClockTime: {1}, BlockTillTime: {2}", process.GetProcessID(), clockTime, process.GetBlockedTill()));
            //    ////Processes that were blocked but are now ready
            //    //if (process.GetBlockedTill().Equals(clockTime))
            //    //{
            //    //    readyQueue.Enqueue(waitingQueue.Dequeue());
            //    //}

            //}
        }

        public int GetTotalProcessCount() {
            return totalProcessCount;
        }
        public void runProcess(Process process)
        {
            currentlyRunningProcess = process;
            startTimeCurrentlyRunningProcess = clockTime;
            currentlyRunningProcess.Start(clockTime);
            clockTime++;
        }

        public abstract Schedule GenerateProcessSchedule();
    }
}
