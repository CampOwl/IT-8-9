using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siteeva_praktika_9
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
    int flag = 1;
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      System.Threading.Thread.Sleep(2000);
      int x_point2 = 545;
      int x_point4 = 305;
      int coorx = 0;
      int ik = 0;
      while (flag>0)
      {
        Graphics g = e.Graphics;
        g.Clear(Color.AliceBlue);
        float xr = 300.0F;
        float y = 200.0F;
        float width = 260.0F;
        float height = 150.0F;
        float startAngle = 0.0F;
        float sweepAngle = 180.0F;
        SolidBrush redBrush = new SolidBrush(Color.SaddleBrown);
        g.FillPie(redBrush, xr, y, width, height, startAngle, sweepAngle);
        Pen brownPen = new Pen(Color.SaddleBrown, 5);
        g.DrawLine(brownPen, 410, 300, 410, 150);
        //парус
        SolidBrush blueBrush = new SolidBrush(Color.Red);
        Point point1 = new Point(415, 100);
        Point point2 = new Point(415, 260);
        Point point3 = new Point(x_point2, 260);
        Point[] curvePoints = { point1, point2, point3 };
        g.FillPolygon(blueBrush, curvePoints);
        Point point4 = new Point(x_point4, 260);
        Point point5 = new Point(405, 260);
        Point point6 = new Point(405, 150);
        Point[] curvePoints1 = { point4, point5, point6 };
        g.FillPolygon(blueBrush, curvePoints1);
        if (flag == 1)
        {
          x_point2 += 20;
          x_point4 += 20;
          flag = 2;
        }
        else
        {
          x_point2 -= 20;
          x_point4 -= 20;
          flag = 1;
        }
        coorx = -ik % 80;
        ik+=10;
        Pen bluePen = new Pen(Color.Blue, 3);
        int wid = 80;
        int hei = 50;
        int coory = 350;
        float start = 180.0F;
        float sweep = 100.0F;
        for (int i = 0; i < 11; i++)
        {
          if (i % 2 == 0)
          {
            start = 0.0F;
            sweep = 180.0F;
          }
          else
          {
            start = 180.0F;
            sweep = 180.0F;
          }
          Rectangle rect = new Rectangle(coorx, coory, wid, hei);
          coorx += 80;
          e.Graphics.DrawArc(bluePen, rect, start, sweep);
        }
        System.Threading.Thread.Sleep(500);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      flag = 0;
    }
  }
}
