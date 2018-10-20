using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class ProductFather
    {
        public string Name { set; get; }
        public double Price { set; get; }
        public string ID { set; get; }
        public ProductFather(string id, double price, string name) {
            this.ID = id;
            this.Price = price;
            this.Name = name;
        }

    }
}
