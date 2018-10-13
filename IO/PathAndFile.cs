using System;
using System.IO;
using System.Diagnostics;

class FileTest{
static void Main(string[] args){
/*
Path 类
*/

//获取当前执行的所在的路径
    string pathStr=Process.GetCurrentProcess().MainModule.FileName;
    
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
   Console.WriteLine(Path.Combine(@"c:\\Administrator","\1.txt"));

/*
File类
##################分割线#########
*/
   File.Create(@"苍老师.txt");

   

   Console.WriteLine("Success");

   

   File.Copy(@"苍老师.txt","苍井空.txt");

   File.Move(@"苍井空.txt","../苍井空.txt");

   File.Delete(@"苍老师.txt");

   

   Console.Read();

}

}
