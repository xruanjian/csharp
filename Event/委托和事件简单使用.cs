using System;

namespace 事件委托简单实例{
//定义事件委托
public delegate void RaiseEventHandler(string hand);
public delegate void FallEventHandler();

class A{

//声明事件
public event RaiseEventHandler RaiseEvent;
public event FallEventHandler FallEvent;


//举手
public void Raise(string hand){
//举手动作传递左手或者右手
Console.WriteLine("首领举起来了{0}手",hand);

//从这里可以看到，定义RaiseEvent委托的意义，将A的举手动作暴露出去，给外界的B和C一个属性(其实就是事件的地址，详见委托的概念)，然后B和C会在暴露出来的属性，注册事件(因为是委托，可以直接传入事件多播委托)。而A在举手时候直接判断他的这个暴露出去的委托属性，如果里面有注册的事件，就执行相应的事件。设计巧妙。B和C这里也可以看出来，他们要注册的事件必须和A的委托属性对象，签名保持一致
if(RaiseEvent != null){
   RaiseEvent(hand);
}
}

public void Fall(){
Console.WriteLine("首领直接摔杯子");
if(FallEvent != null){
    FallEvent();
}
}
}


//部下类B
class B{

void Attack(){
Console.WriteLine("部下B开始进攻，大喊:关云长来也!!");
}
void a_RaiseEvent(string hand){
    if(hand.Equals("左")){
    Attack();
    }
}

void a_FallEvent(){
   Attack();
}

//构造函数传入一个a对象，用来访问并注册a的属性
public B(A a){
   a.RaiseEvent += new RaiseEventHandler(a_RaiseEvent);
   a.FallEvent += new FallEventHandler(a_FallEvent);
}
}


class C{

void Attack(){
 Console.WriteLine("张翼德在此，谁敢一战!!");
}


void a_RaiseEvent(string hand){
    if(hand.Equals("右")){
    Attack();
    }
}

void a_FallEvent(){
    Attack();
}

public C(A a){
a.RaiseEvent += a_RaiseEvent;
a.FallEvent += a_FallEvent;
}
}

//测试类
class Program{
static void Main(){
   A a=new A();
   B b=new B(a);
   C c=new C(a);
   
   
   a.Raise("左");
   Console.WriteLine("#######分割线#######");
   a.Fall();
   Console.ReadKey();
}
}

}