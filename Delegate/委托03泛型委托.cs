using System;
using System.Collections.Generic;
namespace 泛型委托的实例{
//##########工具类######################
class BubbleSorter{
//为Func传入comparison方法，返回值给Func返回值。这里的comparison为下面运行中比较CompareSalary来比较，运行中才可以得到的方法，传入进来，正好契合委托的使用定义。
static public void Sort<T>(IList<T> sortArray,Func<T,T,bool> comparision){
	bool swapped = true;
	do{
			swapped = false;
			for(int i=0;i<sortArray.Count-1; i++){
				if(comparision(sortArray[i+1],sortArray[i])){
				T temp = sortArray[i];
				sortArray[i] = sortArray[i+1];
				sortArray[i+1] = temp;
				swapped = true;
				}
			}
	}while(swapped);
	}
}



//##########类2员工类###################

class Employee{
public Employee(string name,decimal salary){
     this.Name = name;
     this.Salary = salary;
}

public string Name{get;private set;}
public decimal Salary{get;private set;}

public override string ToString(){
  			return string.Format("{0},{1:c}",Name,Salary);
}

//为了匹配Func<T,T,bool>的签名，这里必须定义一个匹配的方法来委托传入进去，只不过委托已经被微软用Func<>包装起来了，不用再定义
public static bool CompareSalary(Employee e1,Employee e2){
					return  e1.Salary < e2.Salary;
}
}


//###############开始测试实现##########
class Program{
static void Main(){
		Employee[] employees ={
		    new Employee("小明",28822),
		    new Employee("刘德华",500000),
		    new Employee("YiChen",187000000)
		};
		
		BubbleSorter.Sort(employees,Employee.CompareSalary);
		
		foreach(Employee item in employees){
		Console.WriteLine(item);
		}
}
}
}