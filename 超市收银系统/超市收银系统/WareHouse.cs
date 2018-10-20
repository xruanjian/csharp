using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//仓库有三大作用：
//存储货物      提取货物        进货
namespace 超市收银系统
{
    //仓库父类
    class WareHouse
    {
        //思路层层进化
        //思路1   List<SamSung> list = new List<SamSung>();
        //思路2   List<ProductFather> list = new List<ProductFather>();
        //第二种思路虽然可以多态商品品种,但是下标数字不好对应查找
        //下面这种将第二种的list当作货架，来添加，这样查找起来方便，对商品进行了分门别类。
        List<List<ProductFather>> list = new List<List<ProductFather>>();

        public WareHouse() {
            list.Add(new List<ProductFather>());        //list[0]存储Acer电脑
            list.Add(new List<ProductFather>());        //list[1]存储SamSung
            list.Add(new List<ProductFather>());        //list[2]存储banana
            list.Add(new List<ProductFather>());        //list[3]存储Sauce
        }

        /// <summary>
        /// 进货方法
        /// </summary>
        /// <param name="strType">进货类型</param>
        /// <param name="count">进货数</param>
        public void ReciveProducts(string strType, int count) {
            for (int i = 0; i < count; i++) {

                switch (strType) { 
                    case "Acer":
                        list[0].Add(new Acer(Guid.NewGuid().ToString(), 10000, "宏基电脑"));
                        break;
                    case "SamSung":
                        list[1].Add(new SamSung(Guid.NewGuid().ToString(),20000,"三星手机"));
                        break;
                    case "banana":
                        list[2].Add(new Banana(Guid.NewGuid().ToString(),5,"香蕉"));
                        break; 
                    case "Sauce":
                        list[3].Add(new Sauce(Guid.NewGuid().ToString(),3,"酱油"));
                        break;

                }
            }
        }


        /// <summary>
        /// 取货
        /// </summary>
        /// <param name="strType">取货类型</param>
        /// <param name="count">取货数</param>
        /// <returns></returns>
        public ProductFather[] GetProducts(string strType, int count) {
            //因为取货数量知道为count，所以定义为一个数组取数据
            ProductFather[] pros = new ProductFather[count];

            for (int i = 0; i < count; i++) {
                switch (strType) { 
                    case "Acer":
                        pros[i] = list[0][0];
                        list[0].RemoveAt(0);
                        break;
                    case "SamSung":
                        pros[i] = list[1][0];
                        list[1].RemoveAt(0);
                        break;
                    case "banana":
                        pros[i] = list[2][0];
                        list[2].RemoveAt(0);
                        break;
                    case "Sauce":
                        pros[i] = list[3][0];
                        list[3].RemoveAt(0);
                        break;
                }            
            }
            return pros;  
        }



        /// <summary>
        /// 显示仓库库存的函数
        /// </summary>
        public void ShowProducts() {
            foreach (var item in list) {
                Console.WriteLine("我们超市有：" + item[0].Name + "," + "\t"  + "有" + item[1].Name + "," + "\t"  + "有" + item[2].Name + "," + "\t" + "有" + item[3].Name + "," + "\t" );
            }    
        }
    }
}
