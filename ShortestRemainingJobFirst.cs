using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    class ShortestRemainingJobFirst : SchedulingAlgorithm
    {

        public ShortestRemainingJobFirst(List<Process> inputwaitingQueue) : base(inputwaitingQueue)
        {
        }

        private void RemoveFromReadyQueue(Process process)
        {
            List<Process> readyQueueList = readyQueue.ToArray().ToList();
            readyQueueList.Remove(process);
            readyQueue = new Queue<Process>(readyQueueList);
        }

        private Process GetProcessSmallestProcessingTime()
        {
            //The best process is the one with the lowest
            //burst time
            Process selectedProcess = readyQueue.Peek();
            double smallestBurstTime = selectedProcess.GetBurstTime();
            foreach (Process process in readyQueue)
            {
                if (process.GetBurstTime() < smallestBurstTime)
                {
                    selectedProcess = process;
                    smallestBurstTime = selectedProcess.GetBurstTime();
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

                //Find process with the smallest remaining time to complete
                Process selectedProcess = GetProcessSmallestProcessingTime();

                if (currentlyRunningProcess != null)
                {
                    int runningTime = clockTime - startTimeCurrentlyRunningProcess;
                    int currentlyRunningProcessBurstTime = currentlyRunningProcess.GetBurstTime();
                    int currentlyRunningProcessTimeLeft = currentlyRunningProcessBurstTime - runningTime;
                    int selectedProcessBurstTime = selectedProcess.GetBurstTime();

                    //If selectedProcess is the runningProcess
                    //i.e running process is the one with shortest cpu burst time
                    if (currentlyRunningProcess.Equals(selectedProcess))
                    {
                        clockTime++;
                        continue;
                    }

                    //If currently running process is still faster than selectedProcess
                    if (currentlyRunningProcessTimeLeft <= selectedProcessBurstTime)
                    {
                        clockTime++;
                        continue;
                    }
                    else if (currentlyRunningProcessTimeLeft > selectedProcessBurstTime)
                    {
                        //If currently running process is slower then run selectedProcess
                        //prepare to context switch currentlyRunningProcess by 
                        //setting its Burst Time to the remaining Time for Completion(aka Saving State)
                        currentlyRunningProcess.SetBurstTime(currentlyRunningProcessTimeLeft);
                        RemoveFromReadyQueue(currentlyRunningProcess);
                        readyQueue.Enqueue(currentlyRunningProcess);//Add preempted process back to readyQueue
                        Console.WriteLine(String.Format("PID: {0} is preempted, returned back to ready Queue.", currentlyRunningProcess.GetProcessID()));
                        schedule.Add(new ScheduleItem(currentlyRunningProcess.GetProcessID(), startTimeCurrentlyRunningProcess, clockTime, false));
                        currentlyRunningProcess = null;
                        startTimeCurrentlyRunningProcess = 0;
                    }
                }

                runProcess(selectedProcess);
            }

            return schedule;
        }
    }
}
