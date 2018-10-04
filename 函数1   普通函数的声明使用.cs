using System;

namespace space2{   
 //加个命名空间这里纯属装逼

  class program{
  
  
  //在这里定义一个函数
  //关键字 static 说明该函数是一个静态函数，非静态函数需要实例化后才能使用，静态函数则可直接使用，将来学到类和对象时会详细研究
 static string CaculateWeekday(int y,int m,int d){
  //计算日期函数
     if (m == 1 || m == 2) { m += 12; y--; } 
     int week = (d + 2*m + 3*(m + 1)/5 + y + y/4 - y/100 + y/400 + 1)%7; 
     string weekstring = ""; 
     
 switch (week) 
 { 
 case 0: weekstring = "星期日"; break; 
 case 1: weekstring = "星期一"; break; 
 case 2: weekstring = "星期二"; break; 
 case 3: weekstring = "星期三"; break; 
 case 4: weekstring = "星期四"; break; 
 case 5: weekstring = "星期五"; break; 
 case 6: weekstring = "星期六"; break; 
 default: break; 
  } 
  return weekstring;
  }
  
  
 
 static void Main(string[] args){
     Console.WriteLine("1992年5月3日是:{0}",CaculateWeekday(1992,5,3));
  }
  
  
  
  
}
}