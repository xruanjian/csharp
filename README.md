
### c#理解传值和传址

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

### 函数的引用型参数

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
*<font color=#AAFFBB>swap1是传值无法交换两个数</font>*    
*swap2是传址操作可以交换两个数*


### 函数的输出型参数

> 一个函数的可能产生多个有价值的计算结果，而使用 return 语句只能返回一个数据。
如何能将更多的数据返回到主调函数中呢？其实仔细想想你就会发现，上一节所讲的引用
型参数（ref）能改变实参的值，天然的能将计算结果反馈到主调函数中。除了引用型参数
外，还可以使用输出型参数（out）返回有用的计算结果。out 型参数和 ref 型参数的用法
几乎完全一样，二者之间只用一个区别：    
   ***ref 型参数传入函数前必须赋值;     
   out 型参数传入函数前不需赋值，即使赋了值也会被忽略。***    
所以 out 型参数只能用来从函数返回结果，而不能用来向函数传递数据。在函数结束
钱，必须为 out 型参数赋值。




