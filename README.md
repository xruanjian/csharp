
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

![传值方式](/csharpJpg/值传递.png "传值方式")




