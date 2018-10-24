//参考：http://note.youdao.com/noteshare?id=97c671723e654f8fbc6d2772d319812d&sub=28CEE3A5B5BB4C1FAF40ECB08F6E9126

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicePlayerAndPicsChange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //定义一个泛型列表，存放listbox选中的歌曲的全路径
        List<string> musicDir = new List<string>();
        //定义一个泛型列表，存放背景图片全路径
        string[] pics;
        
        /// <summary>
        /// 点击播放当前选中的ListBox1.SelectedIndex歌曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //打开对话框
            OpenFileDialog openDir = new OpenFileDialog();
            openDir.Title = "请选择想听的歌曲列表（多选）";
            openDir.Multiselect = true;
            openDir.InitialDirectory = @"e:\";
            openDir.Filter = "wav歌曲|*.wav";
            openDir.ShowDialog();

            string[] path = openDir.FileNames;
            for (int i = 0; i < path.Length; i++) {
                musicDir.Add(path[i]);
                path[i] = Path.GetFileName(path[i]);
                listBox1.Items.Add(path[i]);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = musicDir[listBox1.SelectedIndex];
            sp.Play();
            LabelWrite();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            //加入if判断防止list下标超出列表歌曲数
            if (listBox1.SelectedIndex == 0)
            {
                listBox1.SelectedIndex = listBox1.Items.Count-1;
            }
            else
            {
                listBox1.SelectedIndex --;
            }
            sp.SoundLocation = musicDir[listBox1.SelectedIndex];   
            sp.Play();
            LabelWrite();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            //加入if判断防止list下标超出列表歌曲数
            if (listBox1.SelectedIndex == listBox1.Items.Count-1)
            {
                listBox1.SelectedIndex = 0;
            }
            else {
                listBox1.SelectedIndex++;
            }
            sp.SoundLocation = musicDir[listBox1.SelectedIndex];
            sp.Play();
            LabelWrite();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PictureBox pic1 = new PictureBox();
            PictureBox pic2 = new PictureBox();
            OpenFileDialog openD2 = new OpenFileDialog();
            openD2.InitialDirectory=@"E:\";
            openD2.Filter = "图片|*.jpg";
            openD2.Title = "请选择需要设置背景的文件夹内任意一个图片";
            openD2.ShowDialog();

            string full_path = openD2.FileName;
            string path = Path.GetDirectoryName(full_path);
            //获取目录下所有jpg
            pics = Directory.GetFiles(path,"*.jpg");
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rm=new Random();
            int index1 = rm.Next(0, pics.Length);
            int index2 = rm.Next(0, pics.Length);
            pic1.ImageLocation = pics[index1];
            pic2.ImageLocation = pics[index2];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                 
        }

        private void LabelWrite()
        {
            
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = "当前播放歌曲为：" + listBox1.SelectedItem.ToString();
            label1.Text = label1.Text.Substring(2) + label1.Text.Substring(0, 2);
        }
    }
}
