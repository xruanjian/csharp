## 第一部分:基础语法类

### 一:  c#理解传值和传址

[正常的传值示例(下面函数1完整实例)](https://github.com/xruanjian/csharp/blob/master/%E4%BC%A0%E5%80%BC%E5%92%8C%E4%BC%A0%E5%9D%8001.cs)

###### 声明一个函数1:

```
static double Bigger(double x,double y){
    return x=(x>y)?x:y  ;
}
```
> 假设调用该函数
`a=Bigger(double a=58,double b=84648);`
给形参x,y分配一份内存空间，把实参a,b的值复制一份给形参x,y

![传值方式](https://github.com/xruanjian/csharp/blob/master/csharpJpg/%E5%80%BC%E4%BC%A0%E9%80%92.jpg "传值方式")


[传址方式示例(下面函数2的完整实例)](https://github.com/xruanjian/csharp/blob/master/%E4%BC%A0%E5%80%BC%E5%92%8C%E4%BC%A0%E5%9D%8002.cs)

###### 声明一个函数2

```
 将每个数组元素加倍
static void Doubling(int[] array){
    for(int i=0;i<array.Length;i++){
       array[i] = 2*array[i];
    }
}
```

假设调用该函数:数组进行的是传址操作，当形参(实参的地址)变化，实参也变化

> 最终打印结果数组元素都加倍

```
int[] a ={1,5,8,15,78};
    //调用函数加倍数组元素
    Doubling(a);
        
    foreach(int element in a){
       Console.Write("\\t"+element);
}
```
![传址方式](https://github.com/xruanjian/csharp/blob/master/csharpJpg/%E5%9C%B0%E5%9D%80%E4%BC%A0%E9%80%92.png "传址方式")

### 二:  函数的引用型参数
[传值变传址的引用型参数代码](https://github.com/xruanjian/csharp/blob/master/%E5%87%BD%E6%95%B03%20%20%E4%BC%A0%E5%80%BC%E5%92%8C%E4%BC%A0%E5%9D%8003%E5%BC%95%E7%94%A8%E5%9E%8B%E5%8F%82%E6%95%B0.cs)


了解上例中的传值和传址原理，对基本数据类型数据，可使用引用型参数(本质就是c语言的&取址后传递)

以两个数交换示例:
```
static void Swap1(int a,int b){
    int c;
    c=a;a=b;b=c;
}

static void Swap2(ref int a,ref int b){
    int c;
    c=a;a=b;b=c;
}
```
*swap1是传值无法交换两个数*    
*swap2是传址操作可以交换两个数*

下面测试下:    

*注意调用swap2时候，传递实参也得加ref，即取地址后传入，结合C语言理解，一目了然*
```
int m=588,n=896;
    Swap1(m,n);    
    Console.WriteLine("swap1函数交换后m={0}  n={1}",m,n);
    //调用时候也要ref即相当于&m和&n传址
    Swap2(ref m,ref n);
    Console.WriteLine("swap2函数采用ref引用型参数交换后m={0}  n={1}",m,n);

```
打印结果:    
588    896   
896    588

### 三:  函数的输出型参数

> 一个函数的可能产生多个有价值的计算结果，而使用 return 语句只能返回一个数据。
如何能将更多的数据返回到主调函数中呢？其实仔细想想你就会发现，上一节所讲的引用
型参数（ref）能改变实参的值，天然的能将计算结果反馈到主调函数中。除了引用型参数
外，还可以使用输出型参数（out）返回有用的计算结果。out 型参数和 ref 型参数的用法
几乎完全一样，二者之间只用一个区别：    
   ***ref 型参数传入函数前必须赋值;     
   out 型参数传入函数前不需赋值，即使赋了值也会被忽略。***    
所以 out 型参数只能用来从函数返回结果，而不能用来向函数传递数据。在函数结束
钱，必须为 out 型参数赋值。

[代码页](https://github.com/xruanjian/csharp/blob/master/%E5%87%BD%E6%95%B02%20%20Function%E4%B9%8B%E8%BE%93%E5%87%BA%E5%9E%8B%E5%8F%82%E6%95%B0.cs)

主要代码说明:
```
    //计算圆的周长面积
    //周长是输出型参数c需要在参数列表out声明
    static double CaculateCircle(double r,out double c){
     c =2*Math.PI*r;
     return Math.PI*r*r;
    }
```
测试:

```
    Console.WriteLine("输入半径:\n");
    double r = Convert.ToDouble(Console.ReadLine());
    double circumference;
    //circumference周长，胸围，圆周的意思
    double area=CaculateCircle(r,out circumference);
    
    Console.WriteLine("该圆面积是{0},周长是{1}",area,circumference);
    
```

*out circumference这里只有传回数据作用，而不可以传入*


### 四:  可选参数
[可选参数代码](https://github.com/xruanjian/csharp/blob/master/%E5%87%BD%E6%95%B04%20%20%E5%8F%AF%E9%80%89%E5%8F%82%E6%95%B0.cs)

主要说明代码:
###### 给形参赋初值，就可以变为可选参数，实例化可以不给赋值，而初始化为形参原始给定的值。
```
//计算圆柱体体积
static double VolumeOfColumn(double r,double h=1,double pi=3.14){
   retuen pi*r*r*h;
}
```

测试打印:
```
//半径是3的圆柱体体积。其中高默认是1，pi默认3.14。其实此时算的是底面积，即圆面积公式
    v1=VolumeOfColumn(3);
    //半径是3，高2，pi默认3.14的圆柱体体积
    v2=VolumeOfColumn(3,2);
    //半径是3，高2，pi是3.14159的圆柱体体积
    v3=VolumeOfColumn(3,2,3.14159);
    
```

    

## [第二部分: 面向对象编程OOP(Object-oriented Programming)](https://github.com/xruanjian/csharp/blob/master/object/Tutorial/OOP.md)

