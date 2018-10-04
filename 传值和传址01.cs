using System;

//理解值传递和地址传递
//当调用Bigger(a,b)时候，进行的是
//给形参x,y分配一份内存空间，把实参a,b的值复制一份给形参x,y
namespace 传值传址{
class program{

static double Bigger(double x,double y){
    return x=(x>y)?x:y  ;
}

static void Main(string[] args){
      double a=589,b=8799464;
      Console.WriteLine("两个数中大数为:{0}",Bigger(a,b));

}
}
}
