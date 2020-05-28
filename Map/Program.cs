using System;
//完成人：徐明睿
namespace DaFuWeng
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = 2;                    //回合数
            Console.WriteLine("请输入参与人数（最多8人）");
            int num = Convert.ToInt32(Console.ReadLine());
            Map map = new Map(num,turns);
            Console.WriteLine("\n游戏开始");

            for (int n = 1; n <= turns; n++)
            {
                Console.WriteLine("\n第" + n + "轮");
                for (int i = 0; i < num; i++)//i+1是玩家号
                {
                    Console.WriteLine("玩家" + (i + 1));
                    map.Run(i);
                    map.GetEvent(i);
                }
            }

            Console.WriteLine("\n游戏结束\n\n结算");
            for (int i = 0; i < num; i++)//i+1是玩家号
            {
                map.ShowProperty(i);
            }
        }
    }
}
//完成人：徐明睿
