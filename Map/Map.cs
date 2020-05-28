using System;
using System.Collections.Generic;
using System.Text;
//完成人：徐明睿
namespace DaFuWeng
{
    public class Map
    {
        public int PlayerNum { set; get; }//玩家人数
        public int Turns { set; get; }//回合数
        public Player[] p = new Player[8];
        Event e = new Event();
        public Map(int num)
        {
            PlayerNum = num;
            for (int i = 0; i < num; i++)//i:玩家号
            {
                p[i] = new Player(i,Turns);
            }
        }

        //前进
        public void LocationUP(int n, int i)
        {
            p[i].Location += n;
            Console.WriteLine("目前位置为：" + GetLocation(i));
        }
        //后退
        public void LocationDown(int n, int i)
        {
            p[i].Location -= n;
            Console.WriteLine("目前位置为：" + GetLocation(i));
        }
        //移动
        public void Run(int i)
        {
            Random rd = new Random();
            int n = rd.Next(1, 6);
            Console.WriteLine("获得点数为：" + n);
            LocationUP(n, i);
        }
        //事件
        public void GetEvent(int i)
        {
            e.doEvent(this, i);
        }
        //报告位置
        public int GetLocation(int i)
        {
         //   Console.WriteLine("目前位置为：" + p[i].Location);
            return p[i].Location;
        }
        public void ShowProperty(int i)
        {
            Console.WriteLine("\n"+p[i].property());
        }
    }
}
//完成人：徐明睿