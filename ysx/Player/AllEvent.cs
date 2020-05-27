using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
    class AllEvent
    {
        public void allEvent1(Player []players)     //所有玩家后退两个格子
        {
            for (int i=0;i<6;i++)
            {
                if (players[i].Health>0)
                {
                    players[i].Location = (players[i].Location - 2)%36;
                }
            }
        }
        public void allEvent2(Player []players)     //所有玩家健康值降低10点
        {
            for (int i=0;i<6;i++)
            {
                if (players[i].Health>0)
                {
                    if (players[i].Health>10)
                    {
                        players[i].Health = players[i].Health - 10;
                    }
                    else
                    {
                        players[i].Health = 0;      //当玩家健康值不高于10点时，最终结果为0
                    }
                }
            }
        }
        public void allEvent3(Player[]players)    //根据成绩排名对玩家进行奖励与惩罚
        {
            for (int i=0;i<6;i++)
            {
                if (players[i].Health > 0)
                {
                    if (players[i].Grade >= 680)       //玩家成绩不低于680时，前进5格，并且奖励金钱100
                    {
                        players[i].Location += 5;
                        players[i].Money += 100;
                    }
                    else if (players[i].Grade >= 600)     //玩家成绩不低于600时，前进2格，奖励金钱50
                    {
                        players[i].Location += 3;
                        players[i].Money += 50;
                    }
                    else if (players[i].Grade >= 524)     //玩家成绩不低于524时，前进1格
                    {
                        players[i].Location += 1;
                    }
                    else                               //玩家成绩低于524时，后退1格
                    {
                        players[i].Location -= 2;
                    }
                }
            }
        }
        public void allEvent4(Player[]players)     //考试之后，所有玩家的成绩增加50
        {
            for (int i = 0; i < 6; i++)
            {
                if (players[i].Health > 0)
                {
                    players[i].Grade += 50;
                    if (players[i].Grade > 750)    //如果考试之后玩家成绩超过750分，则修改为750分
                    {
                        players[i].Grade = 750;
                    }
                }
            }
        }
        public void allEvent5(Player[]players)       //体检之后，玩家健康值提升20点
        {
            for (int i = 0; i < 6; i++)
            {
                if (players[i].Health>0)
                {
                    players[i].Health += 20;
                    if (players[i].Health > 100)     //如果体检之后玩家健康值超过100点，则修改为100点
                    {
                        players[i].Health = 100;
                    }
                }
            }
        }
    }
}
