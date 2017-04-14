using ZedGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Assignment_1
{
    public partial class Form1 : Form
    {


        List<string> process_name = new List<string>();
        List<int> Burst_time = new List<int>();
        List<int> Arrival_time = new List<int>();
        List<int> Priority_Number = new List<int>();

        ArrayList remaining_time = new ArrayList();

        Dictionary<object, object> NamArriv = new Dictionary<object, object>();
        Dictionary<object, object> NamBurst = new Dictionary<object, object>();
        Dictionary<object, object> Nampriority = new Dictionary<object, object>();
        Dictionary<object, object> NamRemTime = new Dictionary<object, object>();


        int q_interval;

        

        double AvgWt;
        string num;
        double t1 = 0, temp = 0, t2;

        public Form1()
        {
            InitializeComponent();
            Prog_show();
            creatGraph(zedGraphControl1);
            }
        public void Prog_show() 
        {
            textBox5.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        
        private int lastCheck = -1;
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int toUncheck = lastCheck;
            if (toUncheck != -1)
                checkedListBox1.SetItemChecked(toUncheck, false);
            lastCheck = checkedListBox1.SelectedIndex;
            checkedListBox1.SetItemChecked(lastCheck, true);

            switch (checkedListBox1.Text)
            {     
                              
                case "FCFS" :
                    textBox5.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = false;
                    textBox4.Enabled = true;
                    textBox6.Enabled = false;
                    button2.Enabled = true;
                    break;
                case "SJF (Preemptive)":
                    textBox5.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = false;
                    textBox4.Enabled = true;
                    textBox6.Enabled = false;
                    button2.Enabled = true;
                    break;
                case "SJF (non-Preemptive)":
                    textBox5.Enabled = true;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = true;
                    textBox6.Enabled = false;
                    button2.Enabled = true;
                    break;
                case "Priority (Preemptive)":
                    textBox5.Enabled = true;
                    textBox2.Enabled = false;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox6.Enabled = false;
                    button2.Enabled = true;
                    break;
                case "Priority (non-Preemptive)":
                    textBox5.Enabled = true;
                    textBox2.Enabled = false;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox6.Enabled = false;
                    button2.Enabled = true;
                    break;
                case "Round Robin (RR)":
                    textBox5.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = false;
                    textBox4.Enabled = true;
                    textBox6.Enabled = true;
                    button2.Enabled = true;
                    break;
            }

        }
        int i=0, j=0, k=0, l=0, m=0, n=0;
       
        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            switch (checkedListBox1.Text)
            {
                case "FCFS":

                    do {
                        process_name.Add(textBox5.Text);
                        Burst_time.Add(int.Parse(textBox4.Text));
                        Arrival_time.Add(int.Parse(textBox2.Text));
                        NamArriv.Add(process_name[i], Arrival_time[i]);
                        NamBurst.Add(process_name[i], Burst_time[i]);
                        i++;
                    break;
                    } while (i < process_name.Count);
                    break;
                case "SJF (Preemptive)":
                    do {
                        process_name.Add(textBox5.Text);
                        Burst_time.Add(int.Parse(textBox4.Text));
                        Arrival_time.Add(int.Parse(textBox2.Text));
                        NamArriv.Add(process_name[j], Arrival_time[j]);
                        NamBurst.Add(process_name[j], Burst_time[j]);
                        j++;
                        break;
                    } while (j < process_name.Count);
                    break;
                case "SJF (non-Preemptive)":
                    do {
                        process_name.Add(textBox5.Text);
                        Burst_time.Add(int.Parse(textBox4.Text));
                        //Arrival_time.Add(int.Parse(textBox2.Text));
                        //NamArriv.Add(process_name[k], Arrival_time[k]);
                        NamBurst.Add(process_name[k], Burst_time[k]);
                        k++;
                        break;
                    } while (k < process_name.Count);
                    break;
                case "Priority (Preemptive)":
                    do {
                        process_name.Add(textBox5.Text);
                        Burst_time.Add(int.Parse(textBox4.Text));
                        Priority_Number.Add(int.Parse(textBox3.Text));
                        NamBurst.Add(process_name[l], Burst_time[l]);
                        Nampriority.Add(process_name[l], Priority_Number[l]);
                        l++;
                        break;
                    } while (l < process_name.Count);
                    break;
                case "Priority (non-Preemptive)":
                    do {
                        process_name.Add(textBox5.Text);
                        Burst_time.Add(int.Parse(textBox4.Text));
                        Priority_Number.Add(int.Parse(textBox3.Text));
                        NamBurst.Add(process_name[m], Burst_time[m]);
                        Nampriority.Add(process_name[m], Priority_Number[m]);
                        m++;
                        break;
                    } while (m < process_name.Count);
                    break;
                case "Round Robin (RR)":
                    do {
                        process_name.Add(textBox5.Text);
                        Burst_time.Add(int.Parse(textBox4.Text));
                        Arrival_time.Add(int.Parse(textBox2.Text));
                        q_interval = int.Parse(textBox6.Text);
                        NamBurst.Add(process_name[n], Burst_time[n]);
                        NamArriv.Add(process_name[n], Arrival_time[n]);
                        n++;
                        break;
                    } while (n < process_name.Count);
                    break;
            }
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            
            Arrival_time.Sort();
            Priority_Number.Sort();
            Burst_time.Sort();
            
            
            switch (checkedListBox1.Text)
            {

                case "FCFS":
                    fcfs();
                    break;
                case "SJF (Preemptive)":
                    
                    break;
                case "SJF (non-Preemptive)":
                    SJF_nP();
                    break;
                case "Priority (Preemptive)":
                    
                    break;
                case "Priority (non-Preemptive)":
                    Priority_nP();
                    break;
                case "Round Robin (RR)":
                    RR();
                    break;
            }
        }


        
        //FCFS Funcion
        public void fcfs() 
        {
            do
            {
                var sortedDict = from entry in NamArriv orderby entry.Value ascending select entry;

                t2 += t1;
                t1 = Convert.ToDouble(NamBurst[sortedDict.First().Key]);
                
                if (temp == (process_name.Count - 1))
                {
                    AvgWt = t2 / process_name.Count;
                }

                stackBar(zedGraphControl1, sortedDict.First().Key.ToString(), t1);

                NamArriv.Remove(sortedDict.First().Key);
                sortedDict = null;
                temp++;
            } while (temp < process_name.Count);

            label31.Text = AvgWt.ToString();
        }
        //SJF non-preemptive Function
        public void SJF_nP() 
        {

            do
            {
                var sortedDict = from entry in NamBurst orderby entry.Value ascending select entry;

                t2 += t1;
                t1 = Convert.ToDouble(NamBurst[sortedDict.First().Key]);

                if (temp == (process_name.Count - 1))
                {
                    AvgWt = t2 / process_name.Count;
                }

                stackBar(zedGraphControl1, sortedDict.First().Key.ToString(), t1);

                NamBurst.Remove(sortedDict.First().Key);
                sortedDict = null;
                temp++;
            } while (temp < process_name.Count);

            label31.Text = AvgWt.ToString();
        }
        //Round Robin Function
        public void RR()
        {
            do
            {
                var sortedDict = from entry in NamArriv orderby entry.Value ascending select entry;

                t2 += t1;
                t1 = Convert.ToDouble(NamBurst[sortedDict.First().Key]);

                if (temp == (process_name.Count - 1))
                {
                    AvgWt = t2 / process_name.Count;
                }

                stackBar(zedGraphControl1, sortedDict.First().Key.ToString(), t1);

                NamArriv.Remove(sortedDict.First().Key);
                sortedDict = null;
                temp++;
            } while (temp < process_name.Count);

            label31.Text = AvgWt.ToString(); 
        }
        //Priority non-preemptive function
        public void Priority_nP()
        {
            do
            {
                var sortedDict = from entry in Nampriority orderby entry.Value ascending select entry;

                t2 += t1;
                t1 = Convert.ToDouble(NamBurst[sortedDict.First().Key]);

                if (temp == (process_name.Count - 1))
                {
                    AvgWt = t2 / process_name.Count;
                }

                stackBar(zedGraphControl1, sortedDict.First().Key.ToString(), t1);

                Nampriority.Remove(sortedDict.First().Key);
                sortedDict = null;
                temp++;
            } while (temp < process_name.Count);

            label31.Text = AvgWt.ToString();
        }



        GraphPane myPane = new GraphPane();
        public void creatGraph(ZedGraphControl zgc)
        {
            // set your pane
            myPane = zgc.GraphPane;

            // set a title
            myPane.Title.Text = "Scheduling Output!";

            // set X and Y axis titles
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "";

            myPane.BarSettings.Type = BarType.Stack;
            myPane.BarSettings.ClusterScaleWidth = 1.5;
            myPane.BarSettings.Base = BarBase.Y;

            // draw
            zgc.AxisChange();
            zgc.Refresh();
        
        }

        private void stackBar(ZedGraphControl zg1, string labelName, double val)
        {
            Random rnd = new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            ZedGraph.PointPairList listStack = new ZedGraph.PointPairList();
            listStack.Add(val, 0);      //al value aly han7otaha, faks al Y-axis bkam 


            BarItem barC = zg1.GraphPane.AddBar(labelName, listStack,  randomColor);
            barC.Bar.Fill = new Fill( randomColor);
            zg1.AxisChange();
            zg1.Refresh();
        }

        /////////////////////////
        
		

		/*public void CreateGraph( ZedGraphControl zgc )
		{
			// set your pane
            myPane = zgc.GraphPane;

            // set a title
            myPane.Title.Text = "Scheduling Output!";

            // set X and Y axis titles
            myPane.XAxis.Title.Text = "X Axis";
            myPane.YAxis.Title.Text = "Y Axis";

            // ---- CURVE TWO ----
            listPointsTwo.Add(0, 0);
            listPointsTwo.Add(50, 0);
            
            // set lineitem to list of points
            myCurveTwo = myPane.AddCurve(null, listPointsTwo, Color.Blue, SymbolType.None);
            myCurveTwo.Line.Width = 5;
            // ---------------------

            // draw
            zgc.AxisChange();
		}*/

    }
}


//var myKey = types.FirstOrDefault(x => x.Value == "one").Key;
/*for (int b = 0; b < Process; b++)
            {
                prior.Push(Priority_Number[b]);
            }*/