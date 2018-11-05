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
![传址方式](https://github.com/xruanjian/csharp/blob/master/csharpJpg/%E5%9C%B0%E5%9D%80%E4%