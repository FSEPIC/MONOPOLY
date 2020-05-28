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
                    allEvent1(m);
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
        public void allEvent1(Map m)     //所有玩家后退两个格子
        {
            for (int i = 0; i < m.PlayerNum; i++)
            {
                if (m.p[i].Health > 0)
                {
                    m.p[i].Location = (m.p[i].Location - 2) % 36;
                }
            }
        }
    }
}
