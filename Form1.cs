using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CPU_SCHEDULING_SIMULATION
{
    public partial class Form1 : Form
    {
        private BindingSource processBindingSource;
        private BindingSource fcfsScheduleBindingSource;
        private BindingSource pnpScheduleBindingSource;
        private BindingSource srjfScheduleBindingSource;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            processBindingSource = new BindingSource();
            fcfsScheduleBindingSource = new BindingSource();
            pnpScheduleBindingSource = new BindingSource();
            srjfScheduleBindingSource = new BindingSource();
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
            dv.Sort = isParamTypeDatatable ? "ArrivalTime" : "StartTime";
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
            ICDFFunction uniformDistributionFunction = new UniformDistributionFunction();
            WaitTimeGenerator waitTimeGenerator = WaitTimeGenerator.GetInstance(uniformDistributionFunction);
            List<Process> inputProcesses = waitTimeGenerator.GenerateProcesses(noOfProcesses);

            //cpu scheduling simulation
            SchedulingAlgorithm fcfsPreemptive = new FirstComeFirstServe(inputProcesses);
            Schedule fcfsSchedule = fcfsPreemptive.GenerateProcessSchedule();

            SchedulingAlgorithm priorityNonPreemptive = new PriorityNonPreemptive(inputProcesses);
            Schedule pnpSchedule = priorityNonPreemptive.GenerateProcessSchedule();

            SchedulingAlgorithm shortestRemainingJobFirst = new ShortestRemainingJobFirst(inputProcesses);
            Schedule srjfSchedule = shortestRemainingJobFirst.GenerateProcessSchedule();

            List<object[]> listProcesses, listFCFSSchedule, listPNPSchedule, listSRJFSchedule;

            listProcesses = new List<Object[]>();
            listFCFSSchedule = new List<Object[]>();
            listPNPSchedule = new List<Object[]>();
            listSRJFSchedule = new List<Object[]>();
            List<string> strDataset = new List<string>();
            List<string> fcfsTurn = new List<string>();
            List<string> pnpTurn = new List<string>();
            List<string> srjfTurn = new List<string>();

            string labels = "";

            int totalFCFSTurnAroundTime = 0, totalPNPTurnAroundTime = 0, totalSRJFTurnAroundTime = 0;
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

                int fcfsTurnAroundTime = fcfsSchedule.GetTurnAroundTime(process);
                totalFCFSTurnAroundTime += fcfsTurnAroundTime;

                int endTime = fcfsSchedule.GetEndTime(process);

                fcfsTurn.Add(fcfsTurnAroundTime.ToString());
                listFCFSSchedule.Add(new object[] {
                    pid,
                    process.GetArrivalTime(),
                    endTime,
                    fcfsTurnAroundTime
                });

                int pnpTurnAroundTime = pnpSchedule.GetTurnAroundTime(process);
                totalPNPTurnAroundTime += pnpTurnAroundTime;

                endTime = pnpSchedule.GetEndTime(process);
                pnpTurn.Add(pnpTurnAroundTime.ToString());
                listPNPSchedule.Add(new object[] {
                    pid,
                    process.GetArrivalTime(),
                    endTime,
                    pnpSchedule.GetTurnAroundTime(process)
                });

                int srjfTurnAroundTime = srjfSchedule.GetTurnAroundTime(process);
                totalSRJFTurnAroundTime += srjfTurnAroundTime;

                endTime = srjfSchedule.GetEndTime(process);
                srjfTurn.Add(pnpTurnAroundTime.ToString());
                listSRJFSchedule.Add(new object[] {
                    pid,
                    process.GetArrivalTime(),
                    endTime,
                    srjfSchedule.GetTurnAroundTime(process)
                });
            }

            strDataset.Add(ConvertToJSON(new Dictionary<string, object>() {
                { "label", "First Come First Serve" },
                {"data", String.Join(",", fcfsTurn.ToArray()) }
            }));
            strDataset.Add(ConvertToJSON(new Dictionary<string, object>() {
                { "label", "Priority Non Preemptive" },
                {"data", String.Join(",", pnpTurn.ToArray()) }
            }));
            strDataset.Add(ConvertToJSON(new Dictionary<string, object>() {
                { "label", "Shortest Remaining Job First" },
                {"data", String.Join(",", srjfTurn.ToArray()) }
            }));
            labels = labels.Substring(0, labels.Length - 1);
            int avgFCFSSchedule, avgPNPSchedule, avgSRJFSchedule;

            avgFCFSSchedule = totalFCFSTurnAroundTime / noOfProcesses;
            avgPNPSchedule = totalPNPTurnAroundTime / noOfProcesses;
            avgSRJFSchedule = totalSRJFTurnAroundTime / noOfProcesses;

            lblFCFSAvgTurnAround.Text = avgFCFSSchedule.ToString();
            lblPNPAvgTurnAround.Text = avgPNPSchedule.ToString();
            lblSRJFAvgTurnAround.Text = avgSRJFSchedule.ToString();

            LoadDataGrid(grdProcesses, processBindingSource, ConvertListToDataTable(listProcesses));
            LoadDataGrid(grdFCFSSchedule, fcfsScheduleBindingSource, ConvertListToDataTable(listFCFSSchedule, false));
            LoadDataGrid(grdPNPSchedule, pnpScheduleBindingSource, ConvertListToDataTable(listPNPSchedule, false));
            LoadDataGrid(grdSRJFSchedule, srjfScheduleBindingSource, ConvertListToDataTable(listSRJFSchedule, false));

            GenerateGanttChart(strDataset.ToArray(), labels);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
