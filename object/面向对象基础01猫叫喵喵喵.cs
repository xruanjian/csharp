using System;
//惯例，猫叫演示
namespace 类的学习{

class Cat{
//字段成员
public string name;
public int age;
private int miceCount = 0;

//方法成员
//私有方法1:打招呼
private void SayHello(){
    Console.WriteLine("Hillo,This is mouse:{0}",this.name);
}

//方法2: 打招呼后，喵喵叫
public void Meow(){
   //成员方法调用成员方法
   SayHello();
   Console.WriteLine("喵喵…喵喵!");
}

//方法3: 抓老鼠,并提示抓了多少只
public void CheaseMice(){
   miceCount++;
   SayHello();
   Console.WriteLine("我已经抓了{0}只老鼠了",miceCount);
}



//调用演示
static void Main(string[] args){
//声明类成员对象
    Cat xiaoW=new Cat();
    xiaoW.name="旺财猫";
    xiaoW.age=2;
    
    xiaoW.SayHello();
    xiaoW.Meow();
    xiaoW.CheaseMice();
    xiaoW.CheaseMice();
}
}
}