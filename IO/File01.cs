class Program
    {
        static void Main(string[] args)
        {
           
            /*
             * 学习File类的读写方法
             * Create       Move    Copy    Delete 
             * ReadAllBytes    ReadAllLines    ReadAllText     
             * WriteAllBytes   WriteAllLines   WriteAllText 
             * AppendAllLines     AppendAllText     AppendText
             * 
             ############################################################分割线######################################################################################
             * 假设桌面新建一个文本文件“C:\Users\Administrator\Desktop\数据.txt",记事本默认编码是ANSI
             * 存储三行内容如下：
               小明：	12
               小强： 	18
               奕辰：	2
            */

            string[] content = File.ReadAllLines(@"C:\Users\Administrator\Desktop\数据.txt", Encoding.UTF8);
            for (int i = 0; i < content.Length; i++) { Console.WriteLine(content[i]); }

            Console.WriteLine("##################分割线#############################");
            //测试出来两次打印结果相同
            string str1 = File.ReadAllText(@"C:\Users\Administrator\Desktop\数据.txt", Encoding.UTF8);
            Console.WriteLine(str1);
            //这个写的话应该写个有意义的byte数组，以下数组无意义，写完一个奇怪字符  

            File.WriteAllBytes(@"C:\Users\Administrator\Desktop\数据.txt", new byte[]{12,41,10});

            string[] str2={"第一项","第二项"};

            File.WriteAllLines(@"C:\Users\Administrator\Desktop\数据.txt", str2);

            string str3 = "这个是准备覆盖的Alltext数据字符串";
            File.WriteAllText(@"C:\Users\Administrator\Desktop\数据.txt", str3);

            //以上方法数据都会覆盖原来的文本内容
            //下面方法都不会
            File.AppendAllLines(@"C:\Users\Administrator\Desktop\数据.txt", str2);
            File.AppendAllText(@"C:\Users\Administrator\Desktop\数据.txt", str3);
            //
            //创建一个文件流
            StreamWriter sw=File.AppendText(@"C:\Users\Administrator\Desktop\数据.txt");
            //windows下\r\n换行
            sw.Write("\r\n这是StreamWriter追加的数据");
            sw.Close();

            Console.Read();
        }
    }
