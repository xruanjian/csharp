using System;
using System.Text;
namespace 简单工厂{
//假设姓名有下面三种写法
//firstName,lastName
//firstName lastName
//lastName一般网络人名字都这么写用空格或者逗号分割，我们通过判断逗号或者空格位置就可以知道姓和名。

//基类
public class Namer{
protected string frName,lName;
public string GetFrname(){
 							return frName;
}

public string GetLname(){
								return lName;
}
}

//因为基类已经定义了frName和lName,以及GetFrname()和GetLname，所以派生类可以直接使用，不用再去封装字段

//派生类1
//在FirstFirst类中，即给定的字符串只有名字没有姓，假设最后一个空格前面的所有字符串都是firstname
public class FirstFirst:Namer{
				public FirstFirst(string name){
						int i=name.Trim().IndexOf(" ");
						if(i>0){
						 frName=name.Substring(0,i).Trim();
lName=name.Substring(i+1).Trim();
						}else{
						lName=name;
						frName="";
						}
				}
}


//派生类2
public class LastFirst:Namer{
public LastFirst(string name){
      int i=name.IndexOf(",");
      if(i>0){
      lName=name.Substring(0,i);
      frName=name.Substring(i+1).Trim();
      }else{
      lName=name;
      frName="";
      }
}


//构造简单工厂
public class NameFactory{
public NameFactory(){}

public static Namer GetName(string name){
						int i=name.IndexOf(",");
						if(i>0){
											return new LastFirst(name);
						}else{
											return new FirstFirst(name);
						}
}
}

class Program{
static void Main(){
							Namer nm=NameFactory.GetName("Metz,Micheal");
							
							Console.WriteLine("{0}-------{1}",nm.GetFrname(),nm.GetLname());
							Console.ReadKey();
}
}


}

}