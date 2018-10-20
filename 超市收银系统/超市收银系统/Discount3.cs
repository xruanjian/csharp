using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    //1-----不打折   2-------打九折  3----------超过M元优惠n元
    class Discount3:DiscountFather
    {
        public double M { get; set; }
        public double N { get; set; }
        public Discount3(double m,double n) {
            this.M = m; this.N = n;
        }
        public override double GetTotalMoney(double realMoney)
        {
            if (realMoney >= this.M)
            {
                return realMoney - (int)((realMoney / this.M)) * N;
            }
            else {
                return realMoney;
            }
        }
    }
}
