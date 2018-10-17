using System;

/*
假设用户需要购买电脑，电脑公司应该如何生产

   用户												电脑公司
   																
   																
  																	根据各个品牌抽象出来一个父类
 
   用														Dell
   户														Lenovo
   需														Acer
   求													 IBM
*/


public abstract class NoteBook{
							public abstract void  SayHello();
}

class Dell:NoteBook{
      public override void SayHello(){
      Console.WriteLine("戴尔笔记本的声音");
      }
}

class Acer:NoteBook{
     public override void SayHello(){
     Console.WriteLine("宏碁笔记本的声音");
     }
}


class Lenovo:NoteBook{
     public override void SayHello(){
     Console.WriteLine("联想笔记本的声音");
     }
}

class IBM:NoteBook{
     public override void SayHello(){
     Console.WriteLine("IBM笔记本的声音");
     }
}



class program{

//工厂模式，取数据并生成想要的实例模型。
public static NoteBook GetNoteBook(string brand){
       NoteBook nb=null;
       switch(brand){
         case "Lenovo":
         nb=new Lenovo();  break;
         case "Acer":
         nb=new Acer();    break;
         case "IBM":
         nb=new IBM();							break;
         case "Dell":
         nb=new Dell();						break;     
       }
       
       return nb;
}





static void Main(string[] args){
     
     Console.WriteLine("请输入需要购买的品牌名字");
     string brand =Console.ReadLine();
     NoteBook nb=GetNoteBook(brand);
     nb.SayHello();
     Console.Read();
     
}
}