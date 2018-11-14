## 委托篇

#### 概念

> delegate:    
委托可以认为是这样的对象。它包含具有相同签名和返回值类型的有序方法列表。    
- 方法的列表统称为调用列表(invocation list)。
- 当委托被调用时候，它调用列表中的每一个方法。

*包含单个方法的委托和C++当中函数指针类似，但是与函数指针不同，委托是面向对象，并且类型安全(type-safe)的*

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
