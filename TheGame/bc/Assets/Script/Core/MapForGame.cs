using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;

//完成人：徐明睿
public class MapForGame : MonoBehaviour
{
    public int PlayerNum { set; get; }//玩家人数
        public int Turns { set; get; }//回合数
        public PlayerForGame[] p = new PlayerForGame[8];
        EventForGame e = new EventForGame();
        public MapForGame(int num,int t)
        {
            /*PlayerNum = num;
            Turns = t;
            for (int i = 0; i < num; i++)//i:玩家号
            {
                p[i] = new PlayerForGame(i);
                p[i].Turn = Turns;
            }*/
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
            System.Random rd = new System.Random();
            int n = rd.Next(1, 6);
            if (p[i].Turn == 0)
            {
                n = 0;
                Console.WriteLine("回合已用完");
            }
            else
            {
                Console.WriteLine("获得点数为：" + n);
                p[i].Turn--;
            }
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
            return p[i].Location;
        }
        public void ShowProperty(int i)
        {
            Console.WriteLine("\n"+p[i].property());
        }
}
//结束