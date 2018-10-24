using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finger_Guessing
{
    class Judge
    {
        public enum Result { 玩家赢,电脑赢,平局}

        public static Result CompResult(int playNum,int ComputerNum){
            int k=playNum-ComputerNum;
            if (k == -1 || k == 2) {
                return Result.玩家赢;
            }else if(k==0){
                return Result.平局;
            }else{
                return Result.电脑赢;
            }
        }
    }
}
