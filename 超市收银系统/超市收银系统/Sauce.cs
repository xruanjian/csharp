using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    //酱油类
    class Sauce:ProductFather
    {
        public Sauce(string id,double price,string name):base(id,price,name){}
    }
}
