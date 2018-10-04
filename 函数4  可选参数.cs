using System;
//在声明函数时候某些参数给初始值，可以不给这些参数赋值，将使用默认的值，这些参数是可选参数
namespace 可选参数{
//计算圆柱体体积
static double VolumeOfColumn(double r,double h=1,double pi=3.14){
   retuen pi*r*r*h;
}

class program{
static void Main(string[] args){
    //半径是3的圆柱体体积。其中高默认是1，pi默认3.14。其实此时算的是底面积，即圆面积公式
    v1=VolumeOfColumn(3);
    //半径是3，高2，pi默认3.14的圆柱体体积
    v2=VolumeOfColumn(3,2);
    //半径是3，高2，pi是3.14159的圆柱体体积
    v3=VolumeOfColumn(3,2,3.14159);
    
}
}
}