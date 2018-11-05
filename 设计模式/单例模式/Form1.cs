/*
所谓单例模式指的是打开按钮创建对象时候，会通过判断后，如果实例已经存在，返回唯一的实例，不存在即创建唯一实例。
比如:QQ点击图标，如果已经登录一个账号在系统，会重新打开一个全新的登录窗口出来，这就不是单例模式

再比如:点击360图标，只要系统已经打开了一个360程序，就不会重复打开新的360实例，而是直接打开运行中的360实例，这就是单例模式。

*/

using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;


namespace 单例模式

{

public partial class Form1 : Form

{

public Form1()

{

InitializeComponent();

}


private void button1_Click(object sender, EventArgs e)

{

// Form2 frm2 = new Form2(); 如果这样点击的话，会一直出现新的不同的窗体2

Form2 frm2 = Form2.GetSingle();

frm2.Show();

}

}

}



