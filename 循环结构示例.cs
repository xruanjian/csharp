//循环语句测试
double x0,y0;     //原始坐标点
double x1,y1;     //z(n-1)的实部和虚部
double x2,y2;     //zn的实部和虚部
double NN;        //模的平方

int n;            //记录迭代次数

//双层for打印点
for(y0=1.2;y0>-1.2; y0-=0.05){

  for(x0=-0.6; x0 <= 1.77; x0+=0.03){
     //
     n = 0;
     x1 = x0;
     y1 = y0;
     NN= x1*x1 + y1*y1;
     //当模的平方小于4且迭代次数小于40进行迭代
     while((NN<4) && (n<40)){
     //由z1的实部虚部计算z2的 
     x2 = x1*x1 -y1*y1 -x0;
     y2 = 2*x1*y1-y0;
     //计算z2的平方
     NN = x2*x2 +y2*y2;
     //记录迭代次数
     n++;
     //为下次迭代做准备
     x1 = x2;
     y1 = y2;
     
     }
     //用输出字符代替颜色
     switch(n%4){
      case 0: Console.Write(".");break;
      case 1: Console.Write("0");break;
      case 2: Console.Write("0");break;
      case 3: Console.Write("@");break;
     }
  
  }
       Console.Write("\n");
}


