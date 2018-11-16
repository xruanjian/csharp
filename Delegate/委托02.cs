using System;

namespace 委托2{
//一般情况下此工具类作为委托的方法
class MathOperations{

public static double MultiplyByThree(double x){
		 return 3*x;
}

public static double Square(double x){
			return x*x;
}

}

delegate double DoubleOp(double x);
class program{
//定义一个工具方法,将委托作为参数传入
static void ProcessAndDisplayNumber(DoubleOp action,double value){
//注意此表达式
		double result = action(value);
		
		Console.WriteLine("Value is {0} ,result of operation is {1}",value,result);
}


static void Main(){
			DoubleOp[] operations = {MathOperations.MultiplyByThree,MathOperations.Square};
			
			for(int i=0;i<operations.Length; i++){
			Console.WriteLine("using the operation {0}",operations[i]);
		 //调用中间方法，将委托实现
		 ProcessAndDisplayNumber(operations[i],5.23);
		 Console.WriteLine("");		
	}
	
		Console.ReadKey();
}
}
}