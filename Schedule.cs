using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPU_SCHEDULING_SIMULATION
{
    struct ScheduleItem
    {
        public String ItemID { get; }
        public int StartTime { get; }
        public int EndTime { get; }
        public bool IsFinished { get; }

        public ScheduleItem(String itemID, int startTime, int endTime, bool finished)
        {
            this.ItemID = itemID;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.IsFinished = finished;
        }
    }

    class Schedule
    {
        private List<ScheduleItem> schedule = new List<ScheduleItem>();
        public void Add(ScheduleItem item)
        {
            this.schedule.Add(item);
        }

        public List<ScheduleItem> GetSchedule()
        {
            return schedule;
        }

        public int GetTurnAroundTime(Process process)
        {
            int arrivalTime = process.GetArrivalTime();
            int finishTime = GetEndTime(process);

            return finishTime - arrivalTime;
        }

        public int GetEndTime(Process process)
        {
            string processID = process.GetProcessID();
            int finishTime = 0;

            foreach (ScheduleItem item in schedule)
            {
                if (item.IsFinished && item.ItemID == processID)
                {
                    finishTime = item.EndTime;
                    break;
                }

            }

            return finishTime;
        }

        public void PrintSchedule()
        {
            foreach(ScheduleItem item in this.schedule)
            {
                Console.WriteLine("ProcessID: " + item.ItemID);
                Console.WriteLine("  ProcessStartTime: " + item.StartTime);
                Console.WriteLine("  ProcessEndTime: " + item.EndTime);
                Console.WriteLine("  ProcessFinished: " + item.IsFinished);
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------");
        }
    }
}
