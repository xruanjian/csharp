using System;
using System.IO;
using System.Diagnostics;
using System.Text;

class FileTest{
static void Main(string[] args){
 /*
            Path 类
            */

            //获取当前执行的所在的路径
            string pathStr = Process.GetCurrentProcess().MainModule.FileName;

            Console.WriteLine(pathStr);
            //获取文件名
            Console.WriteLine(Path.GetFileName(pathStr));

            //获取文件名不带扩展名
            Console.WriteLine(Path.GetFileNameWithoutExtension(pathStr));

            //过去文件类型
            Console.WriteLine(Path.GetExtension(pathStr));

            //获取所在的文件夹名
            Console.WriteLine(Path.GetDirectoryName(pathStr));

            //获取全路径
            Console.WriteLine(Path.GetFullPath(pathStr));

            //将两个字符串合并为一个路径
            Console.WriteLine(Path.Combine(@"c:\Administrator", @"\1.txt"));

            /*
            File类
            ####################################################################分割线#############################################################################
            */
            File.Create(@"苍老师.txt");

            Console.WriteLine("Success");
    
            //程序正确，但是运行会抛异常：文件“苍老师.txt”正由另一进程使用，因此该进程无法访问此文件。
            //后面在解决。
            File.Copy(@"苍老师.txt", "苍井空.txt");
            
            File.Move(@"苍井空.txt", @"..\苍井空.txt");
            
            File.Delete(@"苍老师.txt");

            /*
            以上是Create,Delete,Move和Copy
            下面开始Read和Write
            Encoding类可以指定写入或者读取的格式。有
            UTF-8     GB2312   GBK  Unicode   ANSI
            */

            /*
            ##################################################################写数据#################################################################################
            */
            string str = "苍老师大片，苍老师是处女";
            //需要将字符串转换为字节数组
            byte[] buffer1 = Encoding.Default.GetBytes(str);

            File.WriteAllBytes(@"..\写入测试.txt", buffer1);
            Console.WriteLine("写入成功");

            /*
            #################################################################读取测试#################################################################################
            */

            byte[] buffer = File.ReadAllBytes(@"..\写入测试.txt");

            string s = Encoding.Default.GetString(buffer);

            Console.WriteLine(s);
   Console.Read();

}

}
