using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class SuperMarket
    {
        //创建一个仓库
        WareHouse wh = new WareHouse();

        /// <summary>
        /// 构造函数使得创建超市对象时候内部已经进货，让他拥有一定存货
        /// </summary>
        public SuperMarket() {
            wh.ReciveProducts("Acer", 200);
            wh.ReciveProducts("SamSung", 500);
            wh.ReciveProducts("Banana", 1000);
            wh.ReciveProducts("Sauce", 1000);

        }

        public double GetMoney(ProductFather[] pros) {
            double realMoney = 0;
                for(int i=0;i<pros.Length;i++){
                    realMoney+=pros[i].Price;
                }
            return realMoney;
        }
        /// <summary>
        /// 采用简单工厂来计算折扣率
        /// </summary>
        /// <param name="input">控制台输入的打折方式</param>
        /// <returns>返回应付现金</returns>
        public DiscountFather GetDis(string input) { 
            DiscountFather dis=null;
            switch (input)
            {
                case "1":
                    return dis = new NoDiscount(); break;
                case "2":
                    return dis = new Discount2(0.9); break;
                case "3":
                    return dis = new Discount3(500,100); break;
            }
            return dis;           
        }
        public void AskBuying() {
            Console.WriteLine("您好，请问您需要什么商品");
            Console.WriteLine("我们有Acer，SamSung，Sauce，banana");
            string strType = Console.ReadLine();
            Console.WriteLine("请问您需要多少");
            int count = Convert.ToInt32(Console.ReadLine());
            //去仓库取货
            ProductFather[] pros = wh.GetProducts(strType, count);
            //计算价格
            double realMoney = GetMoney(pros);
            Console.WriteLine("请选择打折方式：1-----不打折   2-------打九折  3----------超过M元优惠n元");
            string input = Console.ReadLine();
            
            //通过简单工厂模式，根据用户输入获得一个打折对象
            DiscountFather discount = GetDis(input);
            double realMoney1 = discount.GetTotalMoney(realMoney);
            
            //打印小票
            Console.WriteLine("以下是您的购物信息");
            foreach (ProductFather item in pros) {
                Console.WriteLine("商品名称：" + item.Name + "      商品价格:" + item.Price + "RMB       商品编号:" + item.ID);
            }
            Console.WriteLine("您总共购买了{0}元的商品，打折后应该支付{1}", realMoney, realMoney1);
            

        
        }
    }
}
