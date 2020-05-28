using System;

namespace Player
{
    class Player
    {
        public string Name { set; get; } //玩家姓名
        public int Id { set; get; }      //玩家编号
        public int Location { set; get; }//位置
        public int Pause { set; get; }   //暂停回合数
        public int Money { set; get; }   //金钱
        public int Turn { set; get; }   //剩余回合数
        public int Health { set; get; }  //健康值，最大值为100
        public int Grade { set; get; }   //成绩，最大值为750
    }
}
