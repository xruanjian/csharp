http://note.youdao.com/noteshare?id=2f6010a8f5ee4ecbcb7d924eafedb70a&sub=5DF85CC1C791460CBC8D4D7854354004
From事件：
Load事件用于初始化一些窗体事件。


习题1：

窗体1为主窗体：
点击按钮1，弹出消息框，并显示窗体2，隐藏自己
点击Form2的按钮1，则显示Form3，隐藏自己
点击Form3的按钮1，关闭程序，点击按钮2，显示所有窗体。
Form1的代码
private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("点击按钮会触发button1_Click事件");
            Form2 fm2 = new Form2();
            fm2.Show();
            //StaticForm._fm1.Hide();
            this.Hide();
        }

//Form1初始化时候传入一个静态类，这样Form2和Form3才可以访问他，不然，一个类没法访问另一个类。所以，一个类要访问另一个类，通过静态类的全局作用，使得可以共享成员。
        private void Form1_Load(object sender, EventArgs e)
        {
            StaticForm._fm1 = this;
        }


Form2的代码

 private void Form2_Load(object sender, EventArgs e)
        {
            StaticForm._fm2 = this;
        }
       
 private void button1_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.Show();
            this.Hide();
        }

Form3的代码
 private void button1_Click(object sender, EventArgs e)
        {
            StaticForm._fm1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StaticForm._fm1.Show();
            StaticForm._fm2.Show();
        }

静态类的代码
 static class StaticForm
    {
        public static Form1 _fm1;
        public static Form2 _fm2;
    }

习题2：跑马灯效果
textBox1的文字在label1中跑马灯


按钮1代码：
 private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入走马灯文字");
            }
            else {
                label1.Text = textBox1.Text;
                timer1.Enabled = true;
                
            }
        }

时间控件timer1代码：
 private void timer1_Tick(object sender, EventArgs e)
        {
            Timer timer1 = (Timer)sender;
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }

       

按钮2代码：
 private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
