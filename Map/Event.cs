using System;
using System.Collections.Generic;
using System.Text;

namespace DaFuWeng
{
    public class Event
    {
        public void doEvent(Map m, int i)
        {
            int n = m.GetLocation(i);
            switch (n)
            {
                case 4:
                    EventOne(m, i);
                    break;
                case 8:
                    //
                    break;
                case 13:
                    //
                    break;
                case 20:
                    //
                    break;
                default:
                    //
                    break;
            }
        }
        public void EventOne(Map m, int i)
        {
            Console.WriteLine("获得事件：加一格");
            m.LocationUP(1, i);

        }
        public void allEvent1(Player[] players)     //所有玩家后退两个格子
        {
            for (int i = 0; i < 6; i++)
            {
                if (players[i].Health > 0)
                {
                    players[i].Location = (players[i].Location - 2) % 36;
                }
            }
        }
    }
}
