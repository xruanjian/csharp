using System;

namespace 静态和非静态{

static class Tools{
   static string _usage="吃喝嫖赌";
   //不可以使用  this._usage=value因为不可以实例化，所以静态类前面加this会报错
   //设置属性别忘记public 后面加static错了怎么都找不出
   public static string Usage{get{return _usage;}set{_usage=value;}}
   
   
   public static void InformUsage(){
     Console.WriteLine(Usage);
   }
}

class program{
   static void Main(string[] args){
      Tools.InformUsage();
      //通过类名访问静态类字段
      Tools.Usage="改变恶习";
      Tools.InformUsage();
   }

}


}