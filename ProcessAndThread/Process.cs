using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进程和线程
{
    class Program
    {
        static void Main(string[] args)
        {

            //打开指定应用
            Process.Start("calc");
            //可以带参数
            Process.Start("iexplore", "http://www.baidu.com");
            //遍历所有运行中的进程，打印出来

            Process[] pros = Process.GetProcesses();
            foreach (var item in pros) {
                //杀掉指定进程
                //item.Kill();
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}
