using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    /// <summary>
    /// 计算优惠的父类
    /// </summary>
    abstract class DiscountFather
    {
        public abstract double GetTotalMoney(double realMoney);
    }
}
