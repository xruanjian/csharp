using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finger_Guessing
{
    class Computer
    { 
        public string Fist{get;set;}
        public int ShowFist()
        { 
            Random rm = new Random();
            int fistNum= rm.Next(0, 3);
            switch (fistNum) { 
                case 0:this.Fist="石头";break;
                case 1:this.Fist="剪刀";break;
                case 2:this.Fist="布";break;
            }
            return fistNum;
        }
    }
}
