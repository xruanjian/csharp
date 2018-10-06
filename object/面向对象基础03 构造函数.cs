using System;

namespace 构造函数{

class Cat{
private string _name;
public string Name{get{return _name;}set{this._name=value;}}
private int _age;
public int Age{get{return _age;}set{this._age=value;}}
private int _miceCount;
public int MiceCount{get{return _miceCount;}set{this._miceCount=value;}}



//类中添加构造函数
public Cat(string nameValue,int ageValue,int miceCountValue){
   //初始化变量
   this.Name=nameValue;
   this.Age=ageValue;
   this.MiceCount=0;
   
   //测试一下
   Console.WriteLine("我利用第一个构造函数,把老鼠名字初始化为{0}，年龄{1},抓了老鼠为{2}",this.Name,this.Age,this.MiceCount);
}

public Cat(string nameValue,int miceCountValue){
     this.Name=nameValue;
     this.MiceCount=miceCountValue;
     Console.WriteLine("构造函数可以有好几个，第二个构造函数只初始化两个变量,该名字{0},还有老鼠数{1}  年龄是被编译器初始化为{2}",this.Name,this.MiceCount,this.Age);
}
 
}
class program{
  static void Main(string[] args){
      Cat wangC1=new Cat("旺财猫1",2,3);
     
      
      Cat wangC2=new Cat("旺财猫2",8);
  }
}

}