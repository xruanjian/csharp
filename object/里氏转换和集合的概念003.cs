using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//各个集合比较详细的一个教程 https://www.cnblogs.com/suizhikuo/archive/2012/01/31/2332699.html


namespace 里氏转换和集合的概念003
{
    class program
    {
        /*ArrayList和Hashtable的区别：
         
         * ArrayList和Hashtable都可以存放任意类型数据
         * 区别：ArrayList存放的是单个数据集合。Hashtable存放的是键值对的集合
         * ArrayList可以for进行遍历，Hashtable只可以用foreach遍历。
         * ArrayList访问成员使用list[下标号]访问
         * Hashtable访问成员使用ht[要访问值对应的key]
         * Hashtable的常用函数：
         *     Contains（值）   Add     Remove       GetType     Count   Equals    ContainsKey     ContainsValue
         *     Clear            Clone
         */

        /*
         注意打印结果为：
            *****Key为：新元素*****值为：这也是添加数据的一种方式******
            *****Key为：2*****值为：第二个值******
            *****Key为：键值3*****值为：值3******
            *****Key为：第一个Key*****值为：第一个值******
        并没有按照我们Add添加的顺序打印，这是因为hashtable内部的排序机制所导致。
         */
        static void printHashtable(Hashtable ht) {
            //利用键值进行遍历
            foreach (var item in ht.Keys)
            {
                Console.WriteLine("*****Key为：{0}*****值为：{1}******", item, ht[item]);
            }
        
        }

        static void Main(String[] args){
            Hashtable ht = new Hashtable();
            ht.Add("第一个Key", "第一个值");
            ht.Add(2, "第二个值");
            ht.Add("键值3", "值3");
            ht["新元素"]="这也是添加数据的一种方式";
            
            printHashtable(ht);

            Console.WriteLine("=====================================\n");

            if (ht.ContainsKey("第一个Key")) { Console.WriteLine("有这个键值key\n"); }
            Console.WriteLine("=====================================\n");
            //克隆是浅表克隆，反正是克隆了，不懂什么意思，测试，两组数据互不关联
            Hashtable hh=(Hashtable)ht.Clone();
            //移除键值为2的数据
            ht.Remove(2);
            printHashtable(ht);
            
            Console.Read();
            
        }
    }
}
