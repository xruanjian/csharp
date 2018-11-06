//http://note.youdao.com/noteshare?id=2f4c1e348b11851ba2c0b2c2794eb896

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 验证码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r=new Random();
            string str = null;
            //生成随机数字符串
            for (int i = 0; i < 5; i++) {
                int num = r.Next(0, 5);
                str += num;
            }
            //MessageBox.Show(str);
            //创建位图，并且为位图创建个GDI绘图对象
            Bitmap bmp = new Bitmap(300,40);
            Graphics g = Graphics.FromImage(bmp);

            //绘制验证码
            for (int i = 0; i < 5; i++) {
                Point p = new Point(i* 40, 0);

string[] fonts = { "微软雅黑", "宋体", "黑体", "隶书", "仿宋" };

Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Black, Color.Yellow };

g.DrawString(str[i].ToString(), new Font(fonts[r.Next(0, 5)], 15, FontStyle.Bold), new SolidBrush(colors[r.Next(0, 5)]),p);

}


//绘制干扰线

for (int i = 0; i < 20; i++) {

Point p1 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));

Point p2 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));

g.DrawLine(new Pen(Brushes.Green),p1,p2);

}


//绘制干扰点

for (int i = 0; i < 500; i++) {

Point p = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));

bmp.SetPixel(p.X, p.Y, Color.Black);

}

//将生成位图bmp放到图片框中

pictureBox1.Image = bmp;

}

}

}


