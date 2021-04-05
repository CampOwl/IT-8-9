using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Siteeva_Praktika_8
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
    Chart chart;
    private double XMin = 0.01;
    private double XMax = 3.5;
    private double Step = 0.1;
    private double[] x;
    private double[] y;
    public double Func(double x)
    {
      return Math.Sqrt(3 + Math.Log(x) + 15 - x) / (1 + Math.Sin((2 + x*x)/(1 + x)));
    }
    private void CalcFunction()
    {
      int count = (int)Math.Ceiling((XMax - XMin) / Step) + 1;
      x = new double[count];
      y = new double[count];
      for (int i = 0; i<count; i++)
      {
        x[i] = XMin + Step * i;
        y[i] = Func(x[i]);
      }
    }
    private void CreateChart()
    {
      chart = new Chart();
      chart.Parent = this;
      chart.SetBounds(10, 10, ClientSize.Width - 20, ClientSize.Height - 20);
      ChartArea area = new ChartArea();
      area.Name = "myGraph";
      area.AxisX.Minimum = XMin;
      area.AxisX.Maximum = XMax;
      area.AxisX.MajorGrid.Interval = Step;
      chart.ChartAreas.Add(area);
      Series series1 = new Series();
      series1.ChartArea = "myGraph";
      series1.ChartType = SeriesChartType.Spline;
      series1.BorderWidth = 3;
      series1.LegendText = "наша функция";
      chart.Series.Add(series1);
      Legend legend = new Legend();
      chart.Legends.Add(legend);
    }


    private void Form1_Load(object sender, EventArgs e)
    {
      CreateChart();
      CalcFunction();
      chart.Series[0].Points.DataBindXY(x, y);
    }
  }
}
