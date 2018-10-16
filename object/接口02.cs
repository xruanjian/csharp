using System;

/*
如果一个类继承一个接口，就必须实现类的接口的所有成员。
但是如果不同接口内部有重名方法，怎么处理:
需要用到接口的显示实现。   接口名.方法名
注意显示实现的定义:
IAnimal life1=new Life()
*/

interface IAnimal{
     void Breath();
}

interface IPlant{
     void Breath();
}

//继承两个类
class Life:IAnimal,IPlant{
     void IAnimal.Breath(){
       Console.WriteLine("动物呼吸氧气");
     }
     
     void IPlant.Breath(){
       Console.WriteLine("植物呼吸二氧化碳");
     }
}

class program{
 static void Main(string[] args){
   IAnimal life1=new Life();
   //Life life2=new Life();  像这样定义没办法使用Breath方法，会出错，所以定义只能是IPlant life2=new Life()。
   IPlant life2=new Life();
   
   life1.Breath();
   life2.Breath();
   Console.Read();
 
 }
}