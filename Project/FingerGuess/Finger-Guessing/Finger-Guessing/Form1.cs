using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finger_Guessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Player pl = new Player();
        Computer comPlayer = new Computer();
        private void button1_Click(object sender, EventArgs e)
        {
            string str = "石头";
            PlayGame(str);
        }


        private void PlayGame(string str)
        {
            pl.ShowFist(str);
            int c=comPlayer.ShowFist();
            label1.Text = "您出的是:  " + str;
            label2.Text = "电脑出的是: " + comPlayer.Fist;
            string rs = Judge.CompResult(pl.Num,c).ToString();
            label3.Text = rs;
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            pic1.ImageLocation = @"E:\图片\素材图\农民1.jpg";
            pic2.ImageLocation = @"E:\图片\素材图\地主0.jpg";
            pic3.ImageLocation = @"E:\图片\素材图\石头剪刀布.jpg";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "剪刀";
            PlayGame(str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "布";
            PlayGame(str);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label3.Text == "电脑赢")
            {
                Random rd = new Random();
                int index2 = rd.Next(0, 5);
                int index1 = rd.Next(1, 3);
                pic2.ImageLocation = @"E:\图片\素材图\地主" + index2 + ".jpg";
                pic1.ImageLocation = @"E:\图片\素材图\农民" + index1 + ".jpg";

            }
            else if(label3.Text=="玩家赢"){
                pic2.ImageLocation = @"E:\图片\素材图\地主5.jpg";
            }
        }

    }
}
