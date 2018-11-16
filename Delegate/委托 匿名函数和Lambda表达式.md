## 委托篇

#### 概念

> delegate:    
委托可以认为是这样的对象。它包含具有相同签名和返回值类型的有序方法列表。    
- 方法的列表统称为调用列表(invocation list)。
- 当委托被调用时候，它调用列表中的每一个方法。

*包含单个方法的委托和C++当中函数指针类似，但是与函数指针不同，委托是面向对象，并且类型安全(type-safe)的*

> **委托是寻址方式的.net版本。    
在c++中，函数指针只不过是一个指向内存地址的指针，他不是类型安全的。我们无法判断这个指针究竟指向什么，像参数和返回值等，就更加无法可知了。    
.net委托完全不同，委托是类型安全的类，它定义了返回类型和参数的类型。委托类不仅包含对方法的引用，也可以包含对多个方法的引用。**

*匿名方法和Lambda表达式都与委托直接相关，(一般不用匿名方法了)当参数是委托类型时候，就可以使用Lambda表达式实现委托引用的方法*
    
    
我们通常习惯于把一个参数传递给一个方法:    
 `` int i = int.Parse("5.85"); ``     
给一个方法传递另一个方法听起来有点奇怪，但是，实际经常遇到，甚至经常不知道第二个方法是什么，这个信息只能在运行时得到，所以需要把第二个方法作为参数传递给第一个方法。经常遇到的有:    
    
- **启动线程和任务**    

- **通用类库**    

*C和 c++中,只能提取函数的地址,并作为一个参数传递它。C没有类型安全性。可以把任
何函数传递给需要函数指针的方法。但是,这种直接方法不仅会导致一些关于类型安全性的问题,而且没有意识到:在进行面向对象编程时,几乎没有方法是孤立存在的,而是在调用方法前通常需要与类实例相关联。所以.NET FmmewOrk在 语法上不允许使用这种直接方法。如果要传递方法,就必须把方法的细节封装在一种新类型的对象中,即委托。**委托只是一种特殊类型的对象,其特殊之处在于,我们以前定义的所有对象都包含数据,而委托包含的只是一个或多个方法的地址。***

***
#### 1 :声明委托类型

 `` delegate void MyDel(int x); `` 

或者:

 `` delegate static string MyDel(string s); `` 

***

#### 2 :创建委托对象
*委托是引用类型，创建好委托类型后，就需要声明变量并创建委托实例对象*

```
MyDel  delVar1，delVar2;
delVar1=new MyDel(实例方法或者静态方法名);
// 或者使用快捷语法
delVar2=实例方法或者静态方法名;
```
***
#### 3 :委托赋值
*委托因为是引用类型，可以通过赋值来改变委托变量的引用*
***
#### 4 :组合委托
*委托可以使用额外的运算符，来组合方法，这个运算最终会产生一个新的委托*

```
MyDel delA= function1;
MyDel delB= function1;
//组合调用列表
MyDel delC= delA+delB;
```
***
#### 5 :为委托增加方法
*使用+=运算符时候，实际上发生的是创建了新的委托*

```
MyDel myDel=function1;
myDel    +=function2;
myDel    +=function3;

```

***
#### 6 : 为委托删除方法
*从委托调用列表最后开始搜索，并且删除第一个匹配到的同名方法，如果没有该列表，则该语句无效。*
```
myDel -=function3;
```

#### 7 :调用委托
```
delegate void Mydel(int m);
class Program{

MyDel myDel=function1;
myDel    +=function2;
myDel    +=function3;
…………
myDel(55);
…………
}
```
### [git委托示例代码](https://github.com/xruanjian/csharp/blob/master/Delegate/%E5%A7%94%E6%89%9801.cs)


### [模拟实际中委托使用实例](https://github.com/xruanjian/csharp/blob/master/Delegate/%E5%A7%94%E6%89%9802.cs)


##  泛型委托    

#### 为什么要使用泛型委托
*之前，我们学习总结了委托这个概念，也阐述了委托，匿名方法，lambda表达式三者之间的关系，那么今天再来继续学习委托更深层次的东西：泛型委托，什么是泛型，这个概念我也会在之后做出总结，这里不做很深层次的讨论，重点是讨论泛型和委托如何配合使用，其实泛型这个概念在这里也不会对我们对委托的理解有太大的影响，我们只要大概知道泛型就是一种动态的类型，它在使用时可以代表任意类型，下面我们再来回顾一下我们是如何定义普通委托的*    

>  #####  public delegate int 委托名(int a, int b); 

这是委托的定义，它的定义有这几个特点    
1. 可以用访问修饰符修饰。
2. delegate关键字。
3. 有返回值和参数。

*我们之前也说了，委托是一种类型，与之对应的方法必须和它具有相同的签名，即相同的参数个数，相同的参数类型和相同的返回值类型。我们回顾了普通委托之后再来看一下泛型委托的定义：*    

>  
#####  public delegate T 委托名<T>(T a, T b);

*与之前不同的是，我们把int类型变成了万能的T类型，这样写的好处是什么呢？
可以想象，我们之前写了这样一个方法来处理加减乘除不同的计算方法：*

```

    static void Calculate(Expression ex, int a, int b)
        {
            Console.WriteLine(ex(a, b) + "\n");
        }    

```

*仔细的你会发现我们封装的这个方法有很大的局限性，假如我们某天要计算Double，float小数类型或者其他类型的加减乘除时，我们是不是又不得不重载多个不同参数类型的Calculate方法*    
**使用泛型和Lambda表达式的委托:**
```
//定义泛型委托类型
public delegate T Expression<T>(T a, T b);
    class Program
    {
        static void Main(string[] args)
        {
//实例化，可以多态的定义泛型具体类型，根据里式转换原则。这里时使用lambda表达式
            Expression<int> add = (a, b) => a + b;
            Calculate(add, 10, 25);
            Console.ReadKey();
        }
//定义一个泛型方法
        static void Calculate<T>(Expression<T> ex, T a, T b)
        {
            Console.WriteLine(ex(a, b) + "\n");
        }     
    }
```
*我们只需在声明委托Expression<>时,为委托定义int类型就可以了，假如有一天，我要定义double类型，同理只需把Expression<int>换成Expression<double>即可，这样写是不是既节省了代码，又让Calculate方法的灵活性变高了。不管是lambda表达式还是泛型，微软可谓把DRY(Don't-repeat-yourself)原则发挥的淋漓尽致，其实微软早已为我们定义好了一套泛型委托供我们使用，以免我们在自己使用时还繁琐重复的去定义它，他们分别是**Action，Func和Predicate***

> (1). Action    
Action是无返回值的泛型委托。    
Action 表示无参，无返回值的委托    
Action<int,string> 表示有传入参数int,string无返回值的委托    
Action<int,string,bool> 表示有传入参数int,string,bool无返回值的委托    
Action<int,int,int,int> 表示有传入4个int型参数，无返回值的委托    
**Action至少0个参数，至多16个参数，无返回值。**    
(2). Func    
Func是有返回值的泛型委托    
Func<int> 表示无参，返回值为int的委托    
Func<object,string,int> 表示传入参数为object, string 返回值为int的委托    
Func<object,string,int> 表示传入参数为object, string 返回值为int的委托    
Func<T1,T2,,T3,int> 表示传入参数为T1,T2,,T3(泛型)返回值为int的委托    
*Func至少0个参数，至多16个参数，根据返回值泛型返回。必须有返回值，不可void*    
(3). Predicate    
predicate 是返回bool型的泛型委托    
predicate<int> 表示传入参数为int 返回bool的委托    
**Predicate有且只有一个参数，返回值固定为bool**    

    
*一般的需求下，我们就使用微软定义的委托就足够了，这样减少了我们对委托的重复定义，可能有部分初学者见到Func<>,Action<>这样的代码肯定会很懵比，这只是你对新东西陌生罢了，多结合实例敲几遍，自然就会用了，它们其实就是微软封装定义好了的委托，没有什么特别的。我们上面的代码也可以这样写：*

```
class Program
    {
        static void Main(string[] args)
        {
            Func<int,int,int> add = (a, b) => a + b;
            Calculate(add, 10, 25);
            Console.ReadKey();
        }
        static void Calculate<T, Y, U>(Func<T, Y, U> ex, T a, Y b)
        {
            Console.WriteLine(ex(a, b) + "\n");
        }
    }
```
**这样写用Func就省去了定义委托这一步。**    

*同样，其实在我们的webform，winform框架中，微软也给我们规范了一个委托的定义：*

##### delegate void EvenHandler(object sender, EventArgs e);

*都知道上面的object类是所有类型的基类，那EventArgs类呢？它其实就是所有包含事件数据类的基类，那什么是事件呢？，之后的学习总结中，我们来解谜C#另一个扑朔迷离的东西：事件*

#### [非常实用的泛型委托，一定要掌握理解](https://github.com/xruanjian/csharp/blob/master/Delegate/%E5%A7%94%E6%89%9803%E6%B3%9B%E5%9E%8B%E5%A7%94%E6%89%98.cs)



## 匿名方法
#### 概念
##### 匿名方法(anonymous method)是在初始化委托时内联(inline)声明的方法。

*上面学习了使用静态方法或者实例方法初始化委托。对于这种情况，方法本身可以被代码的其他地方显示调用。当然，也就必须是某个类或者结构的成员。    
然而，如果方法只被调用一次----用来初始化委托怎么样呢?这种情况，除了创建委托语法的语需要，没有必要创建独立的具名方法。这时候就使用匿名方法。    
匿名方法可以允许我们避免使用独立的具名方法*

> 使用匿名函数的场合:    

> - 声明委托变量时候作为初始化表达式    
- 组合委托时候，在赋值语句右边    
- 为委托增加事件，在赋值语句右边

#### 匿名方法样式

###### 普通函数
```
class Program{
public static int Add20(int x){
			return x+=20;
}

delegate int OtherDel(int param);

static void Main(){
OtherDel myDel=Add20;

Console.WriteLine("{0}",myDel(5));

}

}

```
###### 匿名函数语法

```
class Program{

delegate int OtherDel(int param);

static void Main(){
OtherDel myDel=delegate(int x){
							return x+20;
							};

Console.WriteLine("{0}",myDel(5));

}

}
```

> 两段代码运行结果都是:    
25

定义匿名方法语法如下:

###### delegate关键字 (参数列表) {语句块};

###### delegate (*Parameters*) {*ImplementationCode*};


## Lambda表达式

*c#3.0推出Lambda表达式，他简化了匿名方法的语法，用来替代匿名方法*
> 和匿名方法区别:    
- 删除了delegate关键字，因为编译器已经知道我们把方法赋值给了委托。    
- 在参数列表和匿名方法主体之间，放置了lambda运算符=>，该运算符读做"goes to".

匿名方法:    
 ``MyDel del = delegate(int x){return x+1};``    
lambda表达式:    
 `` MyDel del1 = (int x) => {return x+1}; `` 

通过以上的简化，看不出多大简便性，但可以进一步简化，因为编译器已经可以根据委托声明判断出x的类型，所以可以进一步简化如下:    

```
//简化02
MyDel del2 =      (x) => {return x+1};
//简化03
MyDel del3 =      x=> {return x+1};
//简化04
MyDel del4 =      x=>  x+1 ;
```

简化语法的限制:

- Lambda表达式参数列表中参数必须在数量，类型和位置上与委托相匹配。    
- 表达式中的参数不一定要包含类型(隐式类型)，但是如果委托有ref或者out参数(显示类型)，则必须包括参数类型。    
- 如果只有一个参数，并且是隐式类型的，则周围圆括号可以去掉，否则就是必须的。    
- 如果没有参数，必须使用一组空的圆括号。
