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
    public partial class Form2 : Form
    {
//定义一个静态对象，用于返回到窗体1点击事件的返回值。，只有定义这个静态对象，才可以判断它是否唯一。要不然没法判断具体的实例，但是因为判断GetSingle是静态方法，只能使用静态变量，所以定义为静态变量
        public static Form2 FrmSingle;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 单例模式判断
        /// </summary>
        /// <returns>如果</returns>
        public static Form2 GetSingle() {
            if (FrmSingle == null) {
                FrmSingle = new Form2();
            }
            return FrmSingle;
        }
    }
}
