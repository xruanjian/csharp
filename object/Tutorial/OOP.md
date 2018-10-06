### 背景
> C 语言把重点放在写函数上，较大的任务被分解成若干小任务，每个小任务均由函数实现，这种分而治之的编程思想称_**结构化编程**_。程序包含两类基本元素——***数据和函数***。结构化编程注重函数的实现过程，数据的存在只不过是为函数提供支持，所以这种编程方式是面向过程的。结构化编程思想曾经对软件业的发展起了巨大的作用。      
然而随着计算机硬件技术的飞速发展，人们对软件开发提出了越来越高的要求，软件
的代码空前膨胀，软件的复杂程度也空前提高。以微软的操作系统为例，1981 年发行的
DOS 1.0 只有 4000 行汇编代码，可以运行在 8KB 的内存中；而 2007 年的 Vista 系统的代
码达到了 5000 万行，安装光盘有 2.5GB。面对如此惊人的数据，其复杂程度可想而知。    
面向过程编程的基本要点是自顶向下的按照功能把软件分解为不同的模块，并用函数
实现这些模块。然而在进行模块分解时很难保持各模块的独立性，以函数为基本单位的设
计模式使得程序员在设计模块时很难排除其他模块的影响，要同时考虑众多模块。故随着
程序规模的不断扩大，需要记住的细节越来越多，当细节多到一定程度时，程序员就会感
到难以应付。***另外在面向过程编程中，数据和操作代码是分离的***，这与人们认识事物的方
式相违背，程序员往往难以理清数据和操作之间的联系。以 C 语言为例，当代码超过 1000
行时就有点吃力，编写的程序常常产生意想不到的错误。这就使得程序员难以控制软件开
发的周期和成本，甚至无法交付。人们把这种状况称为“软件危机”。


-------
> 面向
对象编程（Object-Oriented Programming，OOP）是一种强有力的软件开发方法，在这种方
法中，数据和对数据的操作被封装成“零件”，人们用这些零件组装程序。面向对象编程
的组织方式和人们认识现实世界的方式一致，符合人们的思维习惯，大大减轻程序员的思
维负担；同时它有助于控制软件的复杂性，提高软件的生产效率。所以面向对象方法得到
广泛应用，已成为目前最流行的软件开发方法。


### 面向对象基本概念
#####  静态和非静态的区别
[静态类和成员实例代码](https://github.com/xruanjian/csharp/blob/master/object/%E9%9D%99%E6%80%81%E5%92%8C%E9%9D%9E%E9%9D%99%E6%80%81%E7%9A%84%E5%8C%BA%E5%88%AB.cs)

静态类最多的地方的是程序配置部分，或者作为通用工具类。因为他的共享特性，在多个窗体中都需要调用，更主要的就是他在程序启动的时候就被初始化了

###### 1. 非静态类既可以有实例成员，又可以有静态成员调用实例成员的时候，采用 类名.静态成员名
###### 2. 静态成员必须用类名去调用。而实例成员允许用对象名来调用。静态类的本质，是一个抽象的密封类，所以不能被继承，也不能被实例化，不能包含实例构造函数。如果一个类下面的所有成员，都需要被共享，那么可以把这个类定义为静态类。因为静态类初始就加载到内存，程序结束才会释放，所以尽量少用

> 静态函数中，只能访问静态变量，不允许访问实例成员

> 实例函数中，既可以使用静态成员，有可以使用实例成员。

> 静态类只允许有静态成员，不允许有实例成员

> 静态类可以有构造函数，但是只被调用一次。






###### 面向对象最主要特点:封装  继承  多态

[面向对象惯例猫叫喵喵喵代码](https://github.com/xruanjian/csharp/blob/master/object/%E9%9D%A2%E5%90%91%E5%AF%B9%E8%B1%A1%E5%9F%BA%E7%A1%8001%E7%8C%AB%E5%8F%AB%E5%96%B5%E5%96%B5%E5%96%B5.cs)

#### 一:  类的声明格式(看起来和其他语言差不多)
*我们把具有相同属性和方法的进行进一步封装，抽象出来类的概念*


```
  class 类名{
       //类的成员变量和成员方法
      …
      …
    }
```

1. 成员变量(csharp成员变量又叫字段)和方法
2. 公有和私有
######  类有两大特性:封装    接口
       参考示例中public和private

######       类通过公有成员实现接口，用public修饰符定义
######       类通过私有成员实现封装，用private修饰符定义

> 说得浅一点： 私有成员（包括数据和成员函数）只能被该类的成员函数和友元函数访问。
公有成员（包括数据和成员函数）可以被任何函数访问。
说得深一点： 私有成员和保护成员定义实现，公有成员定义接口。 

```
class Cat{
//字段成员。csharp把成员变量叫字段
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
}
```

  
*对象实例化过程中    
Cat()  xiaoW=new Cat();    
实例化过程中，会被Cat类的同名构造函数Cat()初始化。    
name被初始化为null(空),miceCount和age被初始化为0*    
###### 如果同时定义多个Cat实例，则他们共享方法的代码，但是不共享数据成员，每个对象会在内存中开辟自己的内存空间来存储自己的数据成员。数据相互独立，创造几个对象，就创建几分数据



调用演示:

```

static void Main(string[] args){
    //声明类成员对象(字段)
    Cat xiaoW=new Cat();
    xiaoW.name="旺财猫";
    xiaoW.age=2;
      
    //xiaoW.SayHello(); 这种不可以直接调用类的私有方法
   //xiaoW.miceCount=9;    也不可以改变类的内部私有变量

    xiaoW.Meow();
    xiaoW.CheaseMice();
    xiaoW.CheaseMice();
}

```

C#3.0 中加入新特性——对象构造器，使得对象的初始化工作变得格外简单，我们可
以采用类似于数组初始化的方式来初始化类的对象。比如：

    Cat wangC1 = new Cat{name="WangCai",age=8};


#### 二:  类的属性

[修改上例的类定义代码](https://github.com/xruanjian/csharp/blob/master/object/%E9%9D%A2%E5%90%91%E5%AF%B9%E8%B1%A1%E5%9F%BA%E7%A1%8002%E5%88%A9%E7%94%A8%E8%AE%BF%E9%97%AE%E5%99%A8set%E5%92%8Cget%E5%B0%81%E8%A3%85%E5%8E%9F%E5%A7%8B%E5%AD%97%E6%AE%B5.cs)



属性的定义
```
public int Age 
{ 
 get 
 { 
 return _age; 
 } 
 set 
 { 
//去年过滤条件
  _age=value;
 }
}
```

参考修改后的代码:
> 将字段全部变为私有字段(变量)，然后利用属性封装

```
class Cat{
//字段成员全部修改为私有，并且修改成_这种约定俗成的样式
private string _name;
private int _age;
private int _miceCount = 0;
```



>声明对应的属性方法:
###### 注意成员属性3是自动属性，即只进行取值和赋值，如果不声明，编译器也会自动创建一个

```

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

//.......属性成员3:自动属性方法，只进行读取和设置，没有其他过滤条件
public int MiceCount{get;set;}


```

这样添加了筛选条件，测试

```
//调用演示
static void Main(string[] args){
//声明类成员对象
    Cat xiaoW=new Cat();
    xiaoW.Name="旺财猫名字特别长";
    xiaoW.Age=2;
   
    xiaoW.Meow();
    xiaoW.CheaseMice();
    xiaoW.CheaseMice();
}
```

>因为Name字段超过过滤的7个字符，所以他的名字是"非法字符"

打印结果:

*
Hillo,This is mouse:非法猫    
喵喵…喵喵!    
Hillo,This is mouse:非法猫     
我已经抓了1只老鼠了    
Hillo,This is mouse:非法猫    
我已经抓了2只老鼠了
*

#### 三:构造函数
[构造函数示例](https://github.com/xruanjian/csharp/blob/master/object/%E9%9D%A2%E5%90%91%E5%AF%B9%E8%B1%A1%E5%9F%BA%E7%A1%8003%20%E6%9E%84%E9%80%A0%E5%87%BD%E6%95%B0.cs)


> 构造函数作用:帮助我们初始化变量。

*构造函数是一种特殊的方法
构造函数没有返回值，连void也不能写    
构造函数必须和类同名    
构造函数在类new的过程中，就开始初始化了*

定义一个类测试:
```
class Cat{
//类字段默认都是private不用写也可以
private string _name;
public string Name{get{return _name;}set{this._name=value;}}

int _age;
public int Age{get{return _age;}set{this._age=value;}}

int _miceCount;
public int MiceCount{get{return _miceCount;}set{this._miceCount=value;}}
```
紧跟以上代码在类中定义构造函数:

```
//类中添加构造函数1
public Cat(string nameValue,int ageValue,int miceCountValue){
   //初始化变量
   this.Name=nameValue;
   this.Age=ageValue;
   this.MiceCount=0;
   Console.WriteLine("我利用第一个构造函数,把老鼠名字初始化为{0}，年龄{1},抓了老鼠为{2}",this.Name,this.Age,this.MiceCount);
}


//添加构造函数2
public Cat(string nameValue,int miceCountValue){
     this.Name=nameValue;
     this.MiceCount=miceCountValue;
     Console.WriteLine("构造函数可以有好几个，第二个构造函数只初始化两个变量,该名字{0},还有老鼠数{1}  年龄是被编译器初始化为{2}",this.Name,this.MiceCount,this.Age);
}

```
定义两个实例测试下
```
static void Main(string[] args){
      //注意new的过程中，构造函数初始化代码就会运行
      Cat wangC1=new Cat("旺财猫1",2,3);
      Cat wangC2=new Cat("旺财猫2",8);
}
```
结果:

*我利用第一个构造函数,把老鼠名字初始化为旺财猫1，年龄2,抓了老鼠为0    
构造函数可以有好几个，第二个构造函数只初始化两个变量,该名字旺财猫2,还有老鼠数8  年龄是被编译器初始化为0*
