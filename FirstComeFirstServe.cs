using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class FirstComeFirstServe : SchedulingAlgorithm
    {
        public FirstComeFirstServe(List<Process> inputwaitingQueue) : base(inputwaitingQueue)
        {

        }

        private void RemoveFromReadyQueue(Process process)
        {
            List<Process> readyQueueList = readyQueue.ToArray().ToList();
            readyQueueList.Remove(process);
            readyQueue = new Queue<Process>(readyQueueList);
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
                    //If the process has to block on I/O, it enters the waiting state
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


                }

                //Load waiting processes into readyQueue
                FillReadyQueue();

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


                //process next process on Queue
                //the scheduler picks the process from the head of the queue
                Process selectedProcess = readyQueue.Peek();

                runProcess(selectedProcess);

            }

            return schedule;
        }
    }
}
