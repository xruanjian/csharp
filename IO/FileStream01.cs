using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 文件流
{
    class TestFileStream {
        static void Main(string[] args){
            /*
               file是对文件进行操作的类，比如建立、修改、删除等。filestream是文件流，就是把把文件读取到内存中进行使用
             * file:是一个文件的类,对文件进行操作的.
               filestream:文件流.对txt,xml等文件写入内容的时候需要使用的一个工具.
               打个形象的比喻.file是笔记本,需要filestream的这个笔才能写.
             * 
             * FileStream对象表示在磁盘或网络路径上指向文件的流。这个类提供了在文件中读写字节的方法，但经常使用StreamReader或 StreamWriter执行这些功能。
             * 这是因为FileStream类操作的是字节和字节数组，而Stream类操作的是字符数据。
             * 这是这两种类的一个重要区别:
             * 如果你是准备读取byte数据的话，用StreamReader读取然后用 System.Text.Encoding.Default.GetBytes转化的话，则可能出现数据丢失的情况(如下面注释操作)，如byte数据的个数不对等。
             * string textContent = fileStream.ReadToEnd();
             * byte[] bytes = System.Text.Encoding.Default.GetBytes(textContent);
             * 因此操作byte数据时要用FileStream。
             * 字符数据易于使用， 但是有些操作，比如随机文件访问(访问文件中间某点的数据)，就必须由FileStream对象执行.
             * 
             * 
             * 将创建流对象过程写在using中，系统会自动释放资源，不用我们自己写close和dispose
             * 
             */



            //用FileStream流来读取数据
        FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\数据.txt",FileMode.OpenOrCreate);
        //定义一个900k来拿数据
        byte[] buffer = new byte[1024*900];
        //返回本次读取到的有效的字节数
        int r = fs.Read(buffer, 0, buffer.Length);
        //将字节数组按照给定的编码解码成字符串
        string str1 = Encoding.UTF8.GetString(buffer);
        /*
         这个是读取的字符串:
         * 第一项撒旦法沙发沙发水电费萨芬撒多少发撒旦法萨芬撒地方了健康\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0....很多个\0无法打印。
         * 所以截取下
          */
        int m = str1.IndexOf('\0');
        str1 = str1.Substring(0, m);
        //关闭流
        fs.Close();
        //释放所占的资源
        fs.Dispose();
        Console.Write(str1);

        
      //使用StreamReader来读取数据

        Console.WriteLine("\n######################用StreamReader读取数据##############################");
        using (StreamReader sr = new StreamReader(@"C:\Users\Administrator\Desktop\数据.txt", Encoding.UTF8)) {
            while (!sr.EndOfStream) {
                Console.WriteLine(sr.ReadLine());
            }
        }




    /*
     
     * 用FileStream流写数据
     */
        Console.WriteLine("\n######################用FileStream流写数据##############################");

        using(FileStream fsWriter=new FileStream(@"C:\Users\Administrator\Desktop\数据.txt",FileMode.Open)){
            string str2 = "用流写入的数据";
            byte[] buffer2 = Encoding.UTF8.GetBytes(str2);
           
            fsWriter.Write(buffer2, 0, buffer2.Length);
            //这里就括起来，相当于释放资源
        }

        /*
         结果：
         * 用流写入的数据沙发沙发水电费萨芬撒多少发撒旦法萨芬撒地方了健康
         * 发现把前几个字符覆盖掉了
         */
            Console.WriteLine("写入成功");


            Console.WriteLine("\n######################用StreamWriter流写数据##############################");
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Administrator\Desktop\数据.txt",false)) {
                sw.Write("测试是否覆盖掉了");
            }
            //测试当StreamWriter的第二个boolean参数为false则覆盖，为true不覆盖
            Console.WriteLine("StreamWriter写入完成");


            Console.Read();
       

        }
    }
}
