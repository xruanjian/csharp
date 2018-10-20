using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//GUID会生成全世界都不会重复的字串
namespace _17GUID
{
    class Program
    {
        static void Main(string[] args)
        {
            string id1=(Guid.NewGuid()).ToString();
        }
    }
}
