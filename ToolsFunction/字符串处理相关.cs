using System;

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
            string str3 = "adcFGcvggfxGHFFNOI";
            string str4 = "    测试所有的   字符串(((处理函数，这 23里放很多字 ....符串测,,,试效果，试试}}效果怎么样   ";

            Console.WriteLine("Length测试字符串长度为{0}\n", str1.Length);

            str2 = str2.ToUpper();
            Console.WriteLine("ToUpper字符串全部转换为大写字母，该函数处理后其实是返回一个字符串备份，必须赋值给原字符串，最后字符串为{0}\n", str2);

            //String.Equals期中Eqauls的参数有三个，第一和第二个是字符串，第三个是StringComparison的一个枚举类型，用来说明比较选项
            Console.WriteLine("equals不区分大小写。所以字符串2和字符串3两个字符串相等是:{0}\n", String.Equals(str2,