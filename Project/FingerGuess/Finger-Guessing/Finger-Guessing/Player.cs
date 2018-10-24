using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finger_Guessing
{
    class Player
    {
        public int Num { get; set; }
        public int ShowFist(string fist) {
            switch (fist) {
                case "石头": this.Num = 0; break;
                case "剪刀": this.Num = 1; break;
                case "布":this.Num=2;break;
            }
            return Num;
        }
    }
}
