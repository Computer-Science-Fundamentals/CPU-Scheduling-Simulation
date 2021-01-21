using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPU_SCHEDULING_SIMULATION
{
    public partial class Form1 : Form
    {
        private BindingSource processBindingSource;
        private BindingSource ppScheduleBindingSource;
        private BindingSource hrrnScheduleBindingSource;
        private BindingSource eodrrScheduleBindingSource;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            processBindingSource = new BindingSource();
            ppScheduleBindingSource = new BindingSource();
            hrrnScheduleBindingSource = new BindingSource();
            eodrrScheduleBindingSource = new BindingSource();
        }

        private DataTable ConvertListToDataTable(List<object[]> list, bool isParamTypeDatatable = true)
        {
            DataTable dt = new DataTable();
            DataColumn[] dataColumns = new DataColumn[]
            {
                new DataColumn("ProcessID", typeof(string)),
                new DataColumn(isParamTypeDatatable ? "ArrivalTime" : "StartTime", typeof(int)),
                new DataColumn(isParamTypeDatatable ? "BurstTime" : "FinishTime", typeof(int)),
                new DataColumn(isParamTypeDatatable ? "IOBlockTime" : "TurnAroundTime", typeof(int))
            };

            dt.Columns.AddRange(dataColumns);

            foreach (var values in list)
            {
                dt.Rows.Add(values);
            }
            DataView dv = dt.DefaultView;
            dv.Sort = isParamTypeDatatable ? "ArrivalTime" : "FinishTime";
            return dv.ToTable();
        }
        private void LoadDataGrid(DataGridView gridView, BindingSource bindingSource, DataTable dt)
        {
            bindingSource.DataSource = dt;
            gridView.DataSource = bindingSource;
        }

        /*Naive*/
        private string ConvertToJSON(Dictionary<String, Object> obj)
        {
            var entries = obj.Select(d => string.Format("\"{0}\":{1}", d.Key,
                                    (d.Value.ToString().Contains(",")) ? String.Format("[{0}]", d.Value) : String.Format("\"{0}\"", d.Value))
                                     );
            return "{" + String.Join(",", entries.ToArray()) + "}";
        }

        private void GenerateGanttChart(string[] strDataset, string labels)
        {
            
            string url = "https://quickchart.io/chart?c=";
            string graphConfig = "{\"type\":\"bar\",\"data\":{\"labels\":[**Label**],";
            graphConfig += "\"datasets\":[**DataSet**]},\"options\":{\"title\":{\"display\":true,\"text\":\"Turn Around Time(ms)\",\"fontColor\":\"hotpink\",\"fontSize\":24},";
            graphConfig += "\"legend\":{\"position\":\"bottom\"},\"plugins\":{\"datalabels\":";
            graphConfig += "{\"display\":false,\"font\":{\"style\":\"bold\"}}}}}";

            graphConfig = graphConfig.Replace("**DataSet**", String.Join(",", strDataset)).Replace("**Label**", labels);
            url += graphConfig;
            System.Diagnostics.Process.Start(url);
            Console.WriteLine(url);
        }
        private void BtnGenerateProcess_Click(object sender, EventArgs e)
        {
            int noOfProcesses = Int32.Parse(txtNoOfProcess.Text);
            ICDFFunction exponentialDistributionFunction = new ExponentialDistributionFunction();
            WaitTimeGenerator waitTimeGenerator = WaitTimeGenerator.GetInstance(exponentialDistributionFunction);
            List<Process> inputProcesses = waitTimeGenerator.GenerateProcesses(noOfProcesses);

            //cpu scheduling simulation
            SchedulingAlgorithm priorityPreemptive = new PriorityPremptive(inputProcesses);
            Schedule ppSchedule = priorityPreemptive.GenerateProcessSchedule();

            SchedulingAlgorithm highestResponseRatioNext = new HighestResponseRatioNext(inputProcesses);
            Schedule hrrnSchedule = highestResponseRatioNext.GenerateProcessSchedule();

            SchedulingAlgorithm evenOddDynamicRoundRobin = new EvenOddDynamicRoundRobin(inputProcesses);
            Schedule eodrrSchedule = evenOddDynamicRoundRobin.GenerateProcessSchedule();

            List<object[]> listProcesses, listPPSchedule, listHRRNSchedule, listEODRRSchedule;

            listProcesses = new List<Object[]>();
            listPPSchedule = new List<Object[]>();
            listHRRNSchedule = new List<Object[]>();
            listEODRRSchedule = new List<Object[]>();
            List<string> strDataset = new List<string>();
            List<string> ppTurn = new List<string>();
            List<string> hrrnTurn = new List<string>();
            List<string> eodrrTurn = new List<string>();

            string labels = "";

            int totalPPTurnAroundTime = 0, totalHRRNTurnAroundTime = 0, totalEODRRTurnAroundTime = 0;
            foreach (Process process in inputProcesses)
            {
                string pid = process.GetProcessID();
                labels += String.Format("\"{0}\",", pid);
                listProcesses.Add(new object[] {
                    pid,
                    process.GetArrivalTime(),
                    process.GetBurstTime(),
                    process.GetIOBlockTime()
                });

                int ppTurnAroundTime = ppSchedule.GetTurnAroundTime(process);
                totalPPTurnAroundTime += ppTurnAroundTime;

                int endTime = ppSchedule.GetEndTime(process);

                ppTurn.Add(ppTurnAroundTime.ToString());
                listPPSchedule.Add(new object[] {
                    pid,
                    process.GetArrivalTime(),
                    endTime,
                    ppTurnAroundTime
                });

                int hrrnTurnAroundTime = hrrnSchedule.GetTurnAroundTime(process);
                totalHRRNTurnAroundTime += hrrnTurnAroundTime;

                endTime = hrrnSchedule.GetEndTime(process);
                hrrnTurn.Add(hrrnTurnAroundTime.ToString());
                listHRRNSchedule.Add(new object[] {
                    pid,
                    process.GetArrivalTime(),
                    endTime,
                    hrrnSchedule.GetTurnAroundTime(process)
                });

                int eodrrTurnAroundTime = eodrrSchedule.GetTurnAroundTime(process);
                totalEODRRTurnAroundTime += eodrrTurnAroundTime;

                endTime = eodrrSchedule.GetEndTime(process);
                eodrrTurn.Add(hrrnTurnAroundTime.ToString());
                listEODRRSchedule.Add(new object[] {
                    pid,
                    process.GetArrivalTime(),
                    endTime,
                    eodrrSchedule.GetTurnAroundTime(process)
                });
            }

            strDataset.Add(ConvertToJSON(new Dictionary<string, object>() {
                { "label", "Priority Preemptive" },
                {"data", String.Join(",", ppTurn.ToArray()) }
            }));
            strDataset.Add(ConvertToJSON(new Dictionary<string, object>() {
                { "label", "Highest Response Ratio Next" },
                {"data", String.Join(",", hrrnTurn.ToArray()) }
            }));
            strDataset.Add(ConvertToJSON(new Dictionary<string, object>() {
                { "label", "Even-Odd Dynamic Round Robin" },
                {"data", String.Join(",", eodrrTurn.ToArray()) }
            }));
            labels = labels.Substring(0, labels.Length - 1);
            int avgPPSchedule, avgHRRNSchedule, avgEODRRSchedule;

            avgPPSchedule = totalPPTurnAroundTime / noOfProcesses;
            avgHRRNSchedule = totalHRRNTurnAroundTime / noOfProcesses;
            avgEODRRSchedule = totalEODRRTurnAroundTime / noOfProcesses;

            lblPPAvgTurnAround.Text = avgPPSchedule.ToString();
            lblHRRNAvgTurnAround.Text = avgHRRNSchedule.ToString();
            lblEODRRAvgTurnAround.Text = avgEODRRSchedule.ToString();

            LoadDataGrid(grdProcesses, processBindingSource, ConvertListToDataTable(listProcesses));
            LoadDataGrid(grdPPSchedule, ppScheduleBindingSource, ConvertListToDataTable(listPPSchedule, false));
            LoadDataGrid(grdHRRNSchedule, hrrnScheduleBindingSource, ConvertListToDataTable(listHRRNSchedule, false));
            LoadDataGrid(grdEODRRSchedule, eodrrScheduleBindingSource, ConvertListToDataTable(listEODRRSchedule, false));

            GenerateGanttChart(strDataset.ToArray(), labels);
            //Console.WriteLine("Priority Preemptive CPU Scheduling Simulation Done.");

            //foreach (Process process in inputProcesses)
            //{
            //    Console.WriteLine(process.GetProcessID() + ";" + "PP;" + ppSchedule.GetTurnAroundTime(process));
            //    Console.WriteLine(process.GetProcessID() + ";" + "HRRN;" + hrrnSchedule.GetTurnAroundTime(process));
            //    Console.WriteLine(process.GetProcessID() + ";" + "EODRR;" + eodrrSchedule.GetTurnAroundTime(process));
            //}
        }
    }
}
