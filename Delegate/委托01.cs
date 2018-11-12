using System;
using System.Text;
/*
委托就是方法调用方法，即给一个方法传递另外一个方法
条件:必须有相同的签名
步骤:
01: 声明委托，必须在namespace开头声明，不能声明到类里面
02: public delegate 来声明一个委托，必须具有相同签名
03，传递参数并执行
*/
namespace 了解委托{
//一定是在命名空间下面声明委托，而不是在类内部
   public delegate void Conv(string[] s);
  
public class Program{
static void Main(string[] args){
   string[] names={"angaLaBAby","XuEYichen","JAckie chan"};
   
   //使用委托调用转换大写
   Conv cv1=new Conv(ConvertUpper);
   cv1(names);
   
   //使用委托打印
   Conv cv2=ChainStr;
   cv2(names);
   
   Console.WriteLine("########下面是组合委托#######");
   //使用组合委托
   Conv cv3=ConvertLower;
   cv3=cv3+cv2;
   cv3(names);
   
   Console.WriteLine("########下面是给委托增加方法#######");
   //给委托实例01增加方法ChainStr
   cv1+=ChainStr;
   cv1(names);
   Console.ReadKey();
}

//全部变大写
private static void ConvertUpper(string[] s){
   for(int i=0; i<s.Length; i++){
   							s[i]=s[i].ToUpper();
   }  
}

//全部变小写
private static void ConvertLower(string[] s){
   for(int i=0; i<s.Length; i++){
   							s[i]=s[i].ToLower();
   }
}


private static void ChainStr(string[] s){
								string str=null;
									for(int i=0; i<s.Length; i++){
									   str+="#######";
									   str+=s[i];
									}
									Console.WriteLine(str);
}

}
}