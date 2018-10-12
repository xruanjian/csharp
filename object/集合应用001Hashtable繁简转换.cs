using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 
 * 总结：HashTabel不可以有两个相同的键（键不能重复）
 * 将一个字符数组转换为字符串
 * char[] ch=new char[]{‘读’,‘d’,‘s’,‘d’,‘f’,‘a’};
 * string str=new string(ch);
 */
namespace 集合
{
    class program
    {
        static string strConvert(string jt, Hashtable dict)
        {
            //因为不知道输入多少个字，所以使用数组不合适，因为不定长
            ArrayList ftList = new ArrayList();
            for (int i = 0; i < jt.Length; i++)
            {
                //判断词典中是否包含有翻译的字符
                if (!dict.ContainsKey(jt[i])) {
                   // Console.WriteLine("对不起，词典中不含有字符{0}", jt[i]);
                    //不识别的繁体字用*表示,注意应添加字符''不能添加成“”,否则会报错，因为后面会进行强制类型转换
                   ftList.Add('*');
                }else
                {

                    // ftList[i] = dict[jt[i]];老提示错误提示System.ArgumentOutOfRangeException，崩溃了，原来不能直接这样写，因为ftList此时不能直接取下标
                    ftList.Add(dict[jt[i]]);
                }
            }
            int ftLen = ftList.Count;
            char[] ftChar = new char[ftLen];
            for (int j = 0; j < ftLen; j++)
            {
                ftChar[j] = (char)ftList[j];
            }
            string ft = new string(ftChar);
            return ft;
        }
        static void Main(String[] args)
        {

            string jt = "我在垃圾上单废了发见佛阿丢放假啊是放超级开心最姐奕看了辰快速的反击群殴嗯误入歧途假了啦尽快发了多少开飞机啊老师绿色的减肥啦神经康复来到房间啊来撒的风景";
            string ft = "我在垃圾上單廢了發見佛阿丟放假啊是放超級開心最姐奕看了辰快速的反擊群毆嗯誤入歧途假了啦盡快發了多少開飛機啊老師綠色的減肥啦神經康復來到房間啊來撒的風景";
            //建立词典
            Hashtable ht = new Hashtable();
            for (int i = 0; i < jt.Length; i++)
            {
                //如果有重复值，添加会出错，原因Hashtable不可以有重复键，排查好久不知道什么原因。所以排除下
                if (!ht.ContainsKey(jt[i]))
                {
                    ht.Add(jt[i], ft[i]);
                }
               
              }

            Console.WriteLine("请输入需要转换的字符串:");
            string jtString = Console.ReadLine();

            string ftString = strConvert(jtString, ht);
            Console.WriteLine("转换后的数据为（词典里没有的用*表示）：\n");
            Console.Write(ftString);
            Console.Read();

        }
    }
}
