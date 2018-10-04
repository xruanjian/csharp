using System;
//ref就相当于c的取址操作符&
namespace 传值和传址03引用型参数{
class program{
static void Swap1(int a,int b){
    int c;
    c=a;a=b;b=c;
}

static void Swap2(ref int a,ref int b){
    int c;
    c=a;a=b;b=c;
}


static void Main(string[] args){
    int m=588,n=896;
    Swap1(m,n);
    Console.WriteLine("swap1函数交换后m={0}  n={1}",m,n);
    //调用时候也要ref即相当于&m和&n传址
    Swap2(ref m,ref n);
    Console.WriteLine("swap2函数采用ref引用型参数交换后m={0}  n={1}",m,n);
}
}
}
