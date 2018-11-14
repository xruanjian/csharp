using System;
namespace 事件{
class Dog 
{ 
//1.声明关于事件的委托；
public delegate void AlarmEventHandler(object sender, EventArgs e); 
 //2.声明事件；
 public event AlarmEventHandler Alarm; 
 //3.编写引发事件的函数
 public void OnAlarm() 
 { 
 if (this.Alarm != null) 
 this.Alarm(this, new EventArgs()); //发出警报
 } 
} 
//事件接收者
class Host 
{ 
 //４.编写事件处理程序
 void HostHandleAlarm(object sender, EventArgs e) 
 { 
 Console.WriteLine("主 人: 抓住了小偷！"); 
 } 
 //５.注册事件处理程序
 public Host(Dog dog) 
 { 
 dog.Alarm += new Dog.AlarmEventHandler(HostHandleAlarm); 
 } 
} 
//６.现在来触发事件
class Program 
{ 
 static void Main(string[] args) 
 { 
 Dog dog = new Dog(); 
 Host host = new Host(dog); 
 DateTime now = new DateTime(2011,12,31,23,59,55); 
 DateTime midnight = new DateTime(2012, 1, 1, 0, 0, 0); 
 Console.WriteLine("时间一秒一秒地流逝，等待午夜的到来... "); 
 while (true) 
 { 
 Console.WriteLine("当前时间: " + now); 
 //午夜零点小偷到达,看门狗引发 Alarm 事件
if(now == midnight) 
 { 
 Console.WriteLine("\n 月黑风高的午夜, 小偷悄悄地摸进了主人的屋内..."); 
 //引发事件
Console.WriteLine(" 狗报警: 有小偷进来了,汪汪~~~~~~~"); dog.OnAlarm(); break; } System.Threading.Thread.Sleep(1000); //程序暂停一秒
now = now.AddSeconds(1); //时间增加1秒
 } 
 } 
 }
 }