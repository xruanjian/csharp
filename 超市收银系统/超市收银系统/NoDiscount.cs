using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    /// <summary>
    /// 没有优惠的政策1
    /// </summary>
    class NoDiscount:DiscountFather
    {
        public override double GetTotalMoney(double realMoney)
        {
            return realMoney;
        }
    }
}
