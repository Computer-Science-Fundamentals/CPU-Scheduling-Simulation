using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class EvenOddDynamicRoundRobin : SchedulingAlgorithm
    {
        private int quantum;
        private int lastQueueSize;

        public EvenOddDynamicRoundRobin(List<Process> inputwaitingQueue) : base(inputwaitingQueue)
        {
            quantum = 25;
            lastQueueSize = 0;
        }

        private void ReOrderReadyQueueUsingBurstTimeAsPriority()
        {
            //Reorder queue in order to grant the shortest job
            //the Highest priority
            var queueList = readyQueue.ToArray().ToList();
            int midIndex = (queueList.Count - 1) / 2;
            queueList.Sort(
                (p1, p2) => p1.GetBurstTime().CompareTo(p2.GetBurstTime())
                );

            quantum = queueList.ElementAt<Process>(midIndex).GetBurstTime();
            if (queueList.Count % 2 == 0)
            {
                int pBurstTime = queueList.ElementAt<Process>(midIndex + 1).GetBurstTime();
                quantum = (quantum + pBurstTime) / 2;
            }

            if (quantum < 25) quantum = 25;
            readyQueue = new Queue<Process>(queueList);
        }

        public override Schedule GenerateProcessSchedule()
        {
            /* ---------------------- Algorithm ----------------------*/
            while (processedCount < GetTotalProcessCount())
            {
                if (currentlyRunningProcess != null)
                {

                    //Check if the currently running process is done
                    int runningTime = clockTime - startTimeCurrentlyRunningProcess;
                    if (currentlyRunningProcess.GetBurstTime() == runningTime)
                    {
                        schedule.Add(new ScheduleItem(currentlyRunningProcess.GetProcessID(), startTimeCurrentlyRunningProcess, clockTime, true));
                        processedCount++; //process completion
                        //waitingQueue.remove(currentlyRunningProcess);
                        Console.WriteLine(String.Format("PID: {0} is done!", currentlyRunningProcess.GetProcessID()));
                        currentlyRunningProcess = null;
                        startTimeCurrentlyRunningProcess = 0;
                    }


                    //Check if the currently running Process is blocked
                    else if (currentlyRunningProcess.IsBlocked(clockTime))
                    {
                        schedule.Add(new ScheduleItem(currentlyRunningProcess.GetProcessID(), startTimeCurrentlyRunningProcess, clockTime, false));
                        currentlyRunningProcess.SetBurstTime(currentlyRunningProcess.GetBurstTime() - runningTime);
                        Console.WriteLine(String.Format("PID: {0} is blocked, returned back to waiting Queue.", currentlyRunningProcess.GetProcessID()));
                        waitingQueue.Enqueue(currentlyRunningProcess); //Add IO Process to waitQueue
                        currentlyRunningProcess = null;
                        startTimeCurrentlyRunningProcess = 0;
                    }

                    //Check if currently running Process is out of time (preemption)
                    else if (runningTime >= quantum)
                    {
                        int remainingTime = currentlyRunningProcess.GetBurstTime() - runningTime;
                        currentlyRunningProcess.SetBurstTime(remainingTime);
                        readyQueue.Enqueue(currentlyRunningProcess);//Add preempted process back to readyQueue
                        Console.WriteLine(String.Format("PID: {0} is preempted, returned back to ready Queue.", currentlyRunningProcess.GetProcessID()));
                        schedule.Add(new ScheduleItem(currentlyRunningProcess.GetProcessID(), startTimeCurrentlyRunningProcess, clockTime, false));
                        currentlyRunningProcess = null;
                        startTimeCurrentlyRunningProcess = 0;
                    }

                }

                //Load waiting processes into readyQueue
                FillReadyQueue();
                //sort queue according to their burstTime when
                //readyQueue Changes
                if ((readyQueue.Count > 0) && (readyQueue.Count != lastQueueSize))
                {
                    ReOrderReadyQueueUsingBurstTimeAsPriority();
                    lastQueueSize = readyQueue.Count;
                    Console.WriteLine("Reordering Queue!");
                }

                //If there are no processes currently ready increase clockTime
                if (readyQueue.Count == 0)
                {
                    clockTime++;
                    Console.WriteLine("No Job Available!");
                    Console.WriteLine(String.Format("No of Waiting Jobs: {0}", waitingQueue.Count));
                    continue;
                }
                //If a process is running already increase clockTime
                if (currentlyRunningProcess != null)
                {
                    clockTime++;
                    Console.WriteLine(String.Format("PID: {0} is processing!", currentlyRunningProcess.GetProcessID()));
                    continue;
                }

                runProcess(readyQueue.Dequeue());

            }

            return schedule;
        }
    }
}
