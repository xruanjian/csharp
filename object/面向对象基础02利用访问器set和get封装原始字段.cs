using System;
//惯例，猫叫延时
namespace 类的学习02属性get和set访问器{

class Cat{
//字段成员
private string _name;
private int _age;
private int _miceCount = 0;

//方法成员
//私有方法1:打招呼
private void SayHello(){
    Console.WriteLine("Hillo,This is mouse:{0}",this._name);
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
   Console.WriteLine("我已经抓了{0}只老鼠了",_miceCount);
}


//属性成员
//........属性成员1Name
public string Name{
     get{
        return _name;
     }
     set{
        if(value.Length<0 | value.Length>7){
        _name="非法猫";
        }else{
        _name=value;
        }
     }
}

//.........属性成员2Age
public int Age{
    get{
      return _age;
    }
    set{
        if(value<0)
        _age=0;
        else
        _age=value;
    }
}

//...........属性成员3
public int MiceCount{get;set;}


}

class program{
//调用演示
static void Main(string[] args){
//声明类成员对象
    Cat xiaoW=new Cat();
    xiaoW.Name="旺财猫";
    xiaoW.Age=2;
    
    
    //xiaoW.SayHello(); 这种不可以直接调用类的私有方法
    //xiaoW.miceCount=9;    也不可以改变类的内部私有变量
    xiaoW.Meow();
    xiaoW.CheaseMice();
    xiaoW.CheaseMice();
}
}
}