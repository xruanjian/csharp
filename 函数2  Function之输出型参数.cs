using System;

namespace 输出型参数{
class program{
    //计算圆的周长面积
    //周长是输出型参数c需要在参数列表out声明
    static double CaculateCircle(double r,out double c){
     c =2*Math.PI*r;
     return Math.PI*r*r;
    }

static void Main(string[] args){
    Console.WriteLine("输入半径:\n");
    double r = Convert.ToDouble(Console.ReadLine());
    double circumference;
    //circumference周长，胸围，圆周的意思
    double area=CaculateCircle(r,out circumference);
    
    Console.WriteLine("该圆面积是{0},周长是{1}",area,circumference);
    

}
}
}
