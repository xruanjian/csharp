using System;
using System.Threading.Tasks;

/*
partial内部类:同一个命名空间下，如果多人合作项目，共同开发一个类的话，可以讲这个类设计为内部类，格式:
public class partial Class A{
}
假设a和b程序员两者同时开发同名类，他们的字段属性方法都可以共享使用，但是两者定义的成员不可以重复

sealed密封类:
不可以被继承，但是可以继承别人的类
public sealed class Test:A{}
*/

//两个内部类在同一个命名空间下，共享所有成员(不论公有还是私有)
public partial class A{
    public string Name{get;set;}
}

public partial class A{
    protected void SayName(){
    Console.WriteLine("您的名字为{0}",this.Name);
    }  
}


public sealed class Mfl:A{
   public void SayHello(){
   Console.WriteLine("我是密封类，我继承了内部类A);
   this.SayName();
   }
}

class program{
static void Main(string[] args){
     Mfl m=new Mfl();
     m.Name="密封类";
     m.SayHello();
     
     A a=new A();
     a.Name="内部类";
     a.SayName();
     
     Console.Read();
}
}