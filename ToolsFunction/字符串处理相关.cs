using System;
using System.Text;

namespace 字符串相关函数
{
    /*相关函数:
    .Length     ToUpper()    ToLower()
    Equals()    Split()      Substring()
    IndexOf()   LastIndexOf()   StartsWith()  EndsWith()  Replace()
    Contains()   Trim()   TrimEnd()  TrimStart()   String.IsNullOrEmpty()
    String.Join()
    */
    class TestString
    {
        static void Main(string[] args)
        {
            string str1 = "    测试所有的字符串处理函数，试试效果怎么样   ";
            string str2 = "adcFGcvggfxGHFFNOI";
            string str3 = "adcFGCvggfxGHFFNOI";
            string str4 = "    测试所有的   字符串(((处理函数，这 23里放很多字 ....符串测,,,试效果，试试}}效果怎么样   ";
            string str6="";
            Console.WriteLine("###########测试Length属性#############");

            Console.WriteLine("Length测试字符串长度为{0}\n", str1.Length);


            Console.WriteLine("##########测试ToUpper 方法############");
            str2 = str2.ToUpper();
            Console.WriteLine("ToUpper字符串全部转换为大写字母，该函数处理后其实是返回一个字符串备份，必须赋值给原字符串，最后字符串为{0}\n", str2);



            //String.Equals期中Eqauls的参数有三个，第一和第二个是字符串，第三个是StringComparison的一个枚举类型，用来说明比较选项
            Console.WriteLine("###########测试Equals方法##########");
            Console.WriteLine("equals不区分大小写。所以字符串2和字符串3两个字符串相等是:{0}\n", str2.Equals(str3,StringComparison.OrdinalIgnoreCase));
            
            Console.WriteLine("##########测试Split方法###########");
            //split分割字符串
            string[] str5=str4.Split(new char[]{'.',' ','(','}',',','，'},StringSplitOptions.RemoveEmptyEntries);
            for(int i=0;i<str5.Length;i++){
            Console.WriteLine(str5[i]);
            }
  
  
 //split和join放一起
 Console.WriteLine("#################Join函数############");
 string str7=String.Join("#",str5);
 Console.WriteLine("str5字符串数组用#链接起来{0}",str7);
            
 //测试Trim处理函数
            Console.WriteLine("#########测试Trim函数##############");
            Console.WriteLine("str1经过Trim消除空格后为:{0}",str1.Trim());
            
//测试IsNullOrEmpty
            Console.WriteLine("##########IsNullOrEmpty判断字符串是否为空###############");
            Console.WriteLine("测试字符串是否为空:1{0},2{1},6{2}",String.IsNullOrEmpty(str1),String.IsNullOrEmpty(str2),String.IsNullOrEmpty(str6));
           
           
          Console.WriteLine("############Contains方法判断是否包含字符串###########");
          Console.WriteLine("字符串1中包含试试效果，结果为{0}",str1.Contains("试试效果"));
            
           
           //测试replace
           Console.WriteLine("#############replace函数测试###########");
           str1=str1.Replace("试试效果","**");
           Console.WriteLine(str1);
           
           
           Console.WriteLine("#############测试indexOf##############");
           Console.WriteLine("字符串FGc在字符串2中位置为{0}",str2.IndexOf("FGc"));         
           
            }
            }
            }