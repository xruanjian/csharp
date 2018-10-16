using System;

/*
引用符Reference和对象Object的区别:
对象存储在堆中，引用符存储在栈中。
引用符的值是对象在堆中的地址，因此通过引用符可以轻松找到对象。
通常我们可以形象的说明:  某引用符指向某对象。
一般情况，引用符是同一类型，基类的引用符指向基类的对象，派生类的引用符指向派生类的对象。

基类引用符则可以指向派生类对象:
Animal p1=new Person();
Animal c1=new Cat();

从上面看出:
一个基类的引用符可以指向多个派生类对象，具有多个不同的形态。这种特性叫多态Polymorphism

利用多态，可以实现通用性编程。

要判断基类的引用符到底指向了哪种派生类对象，我们使用is运算符判断。
比如上面:
if(p1 is Person){}
如果一个父对象中只装有一个子类对象(基类引用类型指向特定派生类对象)，可以强制类型转换把父类转换为子类类型。
p1=(Person)p1;

此外还有一种as运算符。
as 运算符用执行两个引用类型之间的显式转换，它是一种安全的转换，使用前不需要
用 is 运算符测试类型。在类型不兼容的时候，转换的结果是 null，而不会抛出异常。因此
建议使用这种方法进行类型转换。



--1.抽象类是单一继承，接口是多重实现【子类只能有一个父类，而子类可以实现多个接口，继承
抽象类表示“从属”，实现接口表示“组合”关系】
--2.接口中全是抽象方法，抽象类中可以有抽象方法，也可有方法体的方法
--3.接口中无构造方法，不可继承，可实现；抽象类可有构造方法，不可被实例化
--4.抽象类的抽象方法不能使用private，final，static，方法不能用private，final修饰
接口的属性默认是用public，static，final修饰，接口中方法是默认用public，abstract修饰。但是不能写

*/

//接口只能有成员声明，不能有任何代码实现。
//接口成员都是共有的，不需要也不能添加public等方法。不能声明为虚方法或者静态方法。


//接口:银行账户
interface IBankCount{
   //方法:存款
   void PayIn(decimal amount);
   
   //方法:取款
   void WithDraw(decimal amount);
   
   //属性:账户余额
   decimal Balance{get;}
}


//实现接口的类
class Saver:IBankCount{
//私有变量
private decimal balance;

//对外提供只读属性
public decimal Balance{
   get{return balance;}
}

//存款
public void PayIn(decimal amount){
										balance += amount;
										Console.WriteLine("您的存款金额为{0},当前余额{1}",amount,this.Balance);
}

//取款
public void WithDraw(decimal amount){
     if(balance > amount){
										balance -= amount;
										Console.WriteLine("您本次的消费金额为{0},当前余额{1}",amount,this.Balance);
										}else{
										Console.WriteLine("余额不足，无法支付");
										}
}
}


class program{
static void Main(string[] args){
      IBankCount sv=new Saver();
      sv.PayIn(10000);
      sv.PayIn(9000000000);
      sv.WithDraw(50000);
      Console.Read();
}
}

/*打印结果如下:
您 的 存 款 金 额 为 10000,当 前 余 额 10000
您 的 存 款 金 额 为 9000000000,当 前 余 额 9000010000
您 的 取 款 金 额 为 50000,当 前 余 额 8999960000
*/