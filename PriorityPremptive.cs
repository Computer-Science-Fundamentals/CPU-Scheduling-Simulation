using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class PriorityPremptive : SchedulingAlgorithm
    {
        private int timeSlice;

        public PriorityPremptive(List<Process> inputwaitingQueue) : base(inputwaitingQueue)
        {
            timeSlice = 75;
        }

        private void RemoveFromReadyQueue(Process process)
        {
            List<Process> readyQueueList = readyQueue.ToArray().ToList();
            readyQueueList.Remove(process);
            readyQueue = new Queue<Process>(readyQueueList);
        }

        private Process GetProcessHighestPriority()
        {
            //The Highest Priority in this case is the process with
            //the lowest IOBlockTime
            Process selectedProcess = readyQueue.Peek();
            double highestPriority = selectedProcess.GetIOBlockTime();
            foreach (Process process in readyQueue)
            {
                if (process.GetIOBlockTime() < highestPriority)
                {
                    selectedProcess = process;
                    highestPriority = selectedProcess.GetIOBlockTime();
                }
            }
            return selectedProcess;
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
                        RemoveFromReadyQueue(currentlyRunningProcess);
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
                        RemoveFromReadyQueue(currentlyRunningProcess);
                        currentlyRunningProcess = null;
                        startTimeCurrentlyRunningProcess = 0;
                    }

                    //Check if currently running Process is out of time (preemption)
                    else if (runningTime >= timeSlice)
                    {
                        int remainingTime = currentlyRunningProcess.GetBurstTime() - runningTime;
                        currentlyRunningProcess.SetBurstTime(remainingTime);
                        RemoveFromReadyQueue(currentlyRunningProcess);
                        readyQueue.Enqueue(currentlyRunningProcess);//Add preempted process back to readyQueue
                        Console.WriteLine(String.Format("PID: {0} is preempted, returned back to ready Queue.", currentlyRunningProcess.GetProcessID()));
                        schedule.Add(new ScheduleItem(currentlyRunningProcess.GetProcessID(), startTimeCurrentlyRunningProcess, clockTime, false));
                        currentlyRunningProcess = null;
                        startTimeCurrentlyRunningProcess = 0;
                    }

                }

                //Load waiting processes into readyQueue
                FillReadyQueue();

                //If there are no processes currently ready increase clockTime
                if (readyQueue.Count == 0)
                {
                    clockTime++;
                    Console.WriteLine("No Job Available!");
                    Console.WriteLine(String.Format("No of Waiting Jobs: {0}",waitingQueue.Count));
                    continue;
                }
                //If a process is running already increase clockTime
                if (currentlyRunningProcess != null)
                {
                    clockTime++;
                    Console.WriteLine(String.Format("PID: {0} is processing!", currentlyRunningProcess.GetProcessID()));
                    continue;
                }

                //Find process with the highest priority
                Process selectedProcess = GetProcessHighestPriority();

                runProcess(selectedProcess);

            }

            return schedule;
        }
    }
}
