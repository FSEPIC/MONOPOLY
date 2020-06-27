using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;

//完成人：徐明睿
//完成人：闫顺兴
//完成人：王浩欢
//完成人：张文喆
public class MapForGame : MonoBehaviour
{
    
    IndividualEventForGame clinic = new IndividualEventForGame(0, 0, 0, 15, 0, "进入校医室检查身体，健康+15", -1);//固定事件进入校医室，直接单独一个标识符，不进入随机池子
    IndividualEventForGame teachingBuilding = new IndividualEventForGame(0, 0, 0, 0, 20, "在教学楼自习，成绩提升20", -1);
    IndividualEventForGame startPoint = new IndividualEventForGame(0, 0, 500, 0, 0, "回到起点，获得补助500元", -1);
    IndividualEventForGame tutorialSchool = new IndividualEventForGame(0, 0, -100, 0, 30, "到补习社学习，金钱-100，成绩提升30", -1);
    public int PlayerNum { set; get; }//玩家人数
    public int Turns { set; get; }//回合数
    public int NowT {set; get;}

    public int EventNum { get; set; }//事件数
    public int AllEventNum { get; set; }//事件数

    public PlayerForGame[] p = new PlayerForGame[8];
    IndividualEventForGame[] e = new IndividualEventForGame[25];
    AllEventForGame[] ae = new AllEventForGame[25];
    public MapForGame(int num,int t)
    {
        PlayerNum = num;
        Turns = t;
        NowT = 0;
        for (int i = 0; i < num; i++)//i:玩家号
        {
            p[i] = new PlayerForGame(i);
        }
        //前进步数，暂停回合数，金钱，健康，成绩，描述，传送
        //e[0] = new IndividualEventForGame(3, 0, 0, 0, 0, "路上遇到老司机带，逮虾户，前进3步", -1);
        //e[1] = new IndividualEventForGame(0, 1, 0, 0, 0, "喝下昏睡红茶，暂停一回合", -1);
        e[0] = new IndividualEventForGame(0, 0, 300, 0, 0, "路上捡到钱，金钱+300", -1);
        e[1] = new IndividualEventForGame(0, 0, -100, -5, 0, "患上感冒，健康-5，花掉100元", -1);
        e[2] = new IndividualEventForGame(0, 0, -500, 0, 0, "被同学拖去健身，花掉500块，但是健康+10", -1);
        e[3] = new IndividualEventForGame(0, 0, 0, -5, -25, "沉迷网游，无法自拔，健康-5，成绩-25", -1);
        //e[6] = new IndividualEventForGame(0, 2, 0, 0, 0, "摔伤了脚，前往校医室停留2回合", 10);
        //e[7] = new IndividualEventForGame(0, 1, 0, 0, 0, "逃课被抓，被抓到教学楼停留1回合", 18);
        e[4] = new IndividualEventForGame(0, 0, -50, 5, 0, "吃了一顿营养餐，金钱-50，健康+5", -1);
        //e[9] = new IndividualEventForGame(1, 1, 0, 0, 0, "踩到香蕉皮，往前一步，但是因为摔倒了停留一回合", -1);
        //e[10] = new IndividualEventForGame(0, 0, p[i].Grade/2, 0, 0, "家长看到你学习刻苦，决定根据你的成绩给相应的零花钱", -1);
        e[5] = new IndividualEventForGame(0, 0, 200, 10, 0, "去练习唱跳rap篮球，健康+10，并因为演出获得200元", -1);

        EventNum = 6;
        //金钱，健康，成绩，描述

        ae[0]= new AllEventForGame(-50, 0, 10, "购买学习资料");
        ae[1] = new AllEventForGame(0, 20, 0, "体检");
        ae[2] = new AllEventForGame(0, -10, 0, "食堂食物出问题，全体食物中毒");
        ae[3] = new AllEventForGame(0, 0, 35, "全体学生参加辅导班");
        ae[4] = new AllEventForGame(-100, 0, 0, "班级聚会");
        
        AllEventNum = 5;
    }
    public void addEvent(int l, int p, int m, int h, int g, string s,int t)
    {
        e[EventNum] = new IndividualEventForGame(l, p, m, h, g, s,t);
        EventNum++;
    }
    public void addAllEvent(int m, int h, int g, string s)
    {
        ae[AllEventNum] = new AllEventForGame( m, h, g, s);
        AllEventNum++;
    }
    public string getEvent(int i)
    {
        int x = p[i].Location;
        if (x == 2 || x == 4 || x == 8 || x == 16 || x == 24)
        {
            int n = IndividualEventForGame.rdom(0,EventNum-1);//把事件判断迁移到这里
            this.e[n].doEvent(this.p[i]);
            Debug.Log("单人事件"+i);
            return $"单人事件(玩家{i+1}):" + this.e[n].eventStr;
        }
        else if (x == 3 || x == 6 || x == 9 || x == 12 || x == 20)
        {
            int n = IndividualEventForGame.rdom(0,AllEventNum-1);
            this.ae[n].doEvent(this.p[i], this);
            Debug.Log("群体事件"+n);
            return "群体事件:" + this.ae[n].eventStr;
        }
        return null;
        //if (x == 10) {this.clinic.doEvent(this.p[i]);}
        //if (x == 18) {this.teachingBuilding.doEvent(this.p[i]);}
        //if (x == 27) {this.tutorialSchool.doEvent(this.p[i]);}
        //if (x == 0) {this.startPoint.doEvent(this.p[i]);}
    }
    //前进
    public void LocationUP(int n, int i)
    {
        if(n + p[i].Location >= 36){
            p[i].Location = n+p[i].Location-36;//避免越界--陈威
            return;
        }
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
         LocationUP(n, i);
     }
        //事件
    /*public void GetEvent(int i)//ID
    {
        e.doEvent(this, i);
    }*/
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