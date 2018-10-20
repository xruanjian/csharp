using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    //1-----不打折   2-------打九折  3----------超过M元优惠n元
    class Discount2:DiscountFather
    {
        public double Rate { get; set; }
        //构造函数传入打折比例
        public Discount2(double rate) { this.Rate = rate; }
        public override double GetTotalMoney(double realMoney)
        {
            return realMoney * this.Rate;
        }
    }
}
