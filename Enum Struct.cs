using System;
using System.IO;

namespace testspace{ 
//定义namespace作用，当工程量庞大的时候，防止重名，类似jsp的闭包比如，另外一个命名空间也有days的话也不会出错，会和testspace.days区分开
struct favorate{
    public string food;
    public string sport;
}

//可以看出来结构体和c语言结构体区别，{}后面没分号
struct student{
    public string name;
    public int    age;
    public favorate fav;
    //和c语言不一样的，不用使用
    //struct favorate fav这种形式声明结构体变量,直接favorite fav
}


class program {
//主函数外面定义枚举类型
enum days {Sunday,Monday,Tuesday,Wednesday,Thursday=10,Friday,Saturday};

static void Main(string[] args){
    Console.WriteLine(Convert.ToDouble(days.Tuesday));     //打印为2


Console.WriteLine(Convert.ToDouble(days.Saturday));    //打印为12


Console.Write("\n");
student stu1;
stu1.name="xiaoming";
stu1.age =12;
stu1.fav.food="noddles";
stu1.fav.sport="football";
Console.WriteLine("生成的学生名字:{0}  年龄:{1} \n 他最爱的食物:{2}   最爱的运动:{3}",stu1.name,stu1.age,stu1.fav.food,stu1.fav.sport);



	}
	}
	}