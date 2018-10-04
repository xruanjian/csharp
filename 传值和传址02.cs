using System;
//数组进行的是传址操作，当形参(实参的地址)变化，实参也变化
namespace 传值和传址02{
class program{
//将每个数组元素加倍
static void Doubling(int[] array){
    for(int i=0;i<array.Length;i++){
       array[i] = 2*array[i];
    }
}

static void Main(string[] args){
    int[] a ={1,5,8,15,78};
    //调用函数加倍数组元素
    Doubling(a);
        
    foreach(int element in a){
       Console.Write("\t"+element);
    }
}
}
}