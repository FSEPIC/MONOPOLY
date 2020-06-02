using System;
using System.Collections.Generic;
using System.Text;
//完成人：闫顺兴
namespace DaFuWeng
{

    public class Player
    {
        public string Name { set; get; } //玩家姓名
        public int Id { set; get; }      //玩家编号
        public int Location { set; get; }//位置
        public int Turn{ set; get; }   //剩余回合数
        public int Pause { set; get; }   //暂停回合数
        public int Money { set; get; }   //金钱
        public int Health { set; get; }  //健康值，最大值为100
        public int Grade { set; get; }   //成绩，最大值为750
        public Player(int i)
        {
            Id = i;
            Name = "玩家"+(i+1);
            Location = 0;
            Health = 100;
            Money = 500;
            Pause = 0;
        }
        public string property() {
            return Name + "\n到达位置" + Location  + "\n成绩" + Grade + "\n健康值" + Health + "\n剩余金钱" + Money ;
        }
    }
}
//完成人：闫顺兴