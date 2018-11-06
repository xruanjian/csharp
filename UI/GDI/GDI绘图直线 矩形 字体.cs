//示例图http://note.youdao.com/noteshare?id=9991417f56149337c68c3f9ec22f4386

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI绘图
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //01创建GDI对象
            Graphics g = this.CreateGraphics();
            //02创建画笔对象
            Pen pen = new Pen(Brushes.Brown);
            //03创建两个点
            Point p1 = new Point(80, 50);
            Point p2 = new Point(100, 190);
            
            //04用画笔绘图
            g.DrawLine(pen,p1,p2);
            g.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Yellow);
            //size用于指定矩形的宽度和高度
            Size size = new System.Drawing.Size(180, 180);

Rectangle rec = new Rectangle(new Point(90, 90), size);

g.DrawRectangle(pen,rec);

g.Dispose();

}


private void button3_Click(object sender, EventArgs e)

{

Graphics g = this.CreateGraphics();

g.DrawString("奕辰最棒", new Font("宋体", 20, FontStyle.Bold), Brushes.SpringGreen, new PointF(51, 82));

g.Dispose();

}


}

}


