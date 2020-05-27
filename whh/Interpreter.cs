using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace whh
{
    
    class Player
    {   
        
        int MAXCELL = 36;
        public string Name { get; set; }
        public int Id { get; set; }
        public int Grade { get; set; }
        public int Money { get; set; }
        public int Health { get; set; }
        public int Location { get; set; }
        public int Pause { get; set; }
    }
    class Game {
        static void Interpreter(int Index1, Player Player1, int Parameter1, int Index2, Player Player2, int Parameter2, int Index3, Player Player3, int Parameter3)
        {
            switch (Index1)
            {
                case 0:
                    Pause_N_Round(Player1, Parameter1);
                    break;
                case 1:
                    MoneyAddOrDecrease(Player1, Parameter1);
                    break;
                case 2:
                    HealthAddOrDecrease(Player1, Parameter1);
                    break;
                case 3:
                    GradeAddOrDecrease(Player1, Parameter1);
                    break;
                case 4:
                    Teleport(Player1, Parameter1);
                    break;
                default:
                    break;
            }
            switch (Index2)
            {
                case 0:
                    Pause_N_Round(Player2, Parameter2);
                    break;
                case 1:
                    MoneyAddOrDecrease(Player2, Parameter2);
                    break;
                case 2:
                    HealthAddOrDecrease(Player2, Parameter2);
                    break;
                case 3:
                    GradeAddOrDecrease(Player2, Parameter2);
                    break;
                case 4:
                    Teleport(Player2, Parameter2);
                    break;
                default:
                    break;
            }
            switch (Index3)
            {
                case 0:
                    Pause_N_Round(Player3, Parameter3);
                    break;
                case 1:
                    MoneyAddOrDecrease(Player3, Parameter3);
                    break;
                case 2:
                    HealthAddOrDecrease(Player3, Parameter3);
                    break;
                case 3:
                    GradeAddOrDecrease(Player3, Parameter3);
                    break;
                case 4:
                    Teleport(Player3, Parameter3);
                    break;
                default:
                    break;
            }
        }
        static void Pause_N_Round(Player player, int parameter) {
            player.Pause += parameter;
            return;
        }
        static void MoneyAddOrDecrease(Player player, int parameter)
        {
            player.Money += parameter;
            return;
        }
        static void HealthAddOrDecrease(Player player, int parameter)
        {
            player.Health += parameter;
            return;
        }
        static void GradeAddOrDecrease(Player player, int parameter)
        {
            player.Grade += parameter;
            return;
        }
        static void Teleport(Player player, int parameter)
        {
            player.Location += parameter;
            return;
        }
        Player[] gamePlayer = new Player[4];
        //喝下昏睡红茶，暂停1回合
        //currentPlayer 当前玩家，以后可以改
        //Interpreter(0, currentPlayer, 1, -1, currentPlayer, 0, -1, currentPlayer, 0)
        //路上捡到钱，金钱加300
        //Interpreter(2, currentPlayer, 300, -1, currentPlayer, 0, -1, currentPlayer, 0)
        //换上感冒，健康-5，金钱-100
        //Interpreter(2, currentPlayer, -100, 3, currentPlayer, -5, -1, currentPlayer, 0)
        //被同学拖去健身，健康+10，金钱-500
        //Interpreter(2, currentPlayer, -500, 3, currentPlayer, 10, -1, currentPlayer, 0)
        //沉迷网游，无法自拔，成绩减25
        //Interpreter(3, currentPlayer, -25, -1, currentPlayer, 0, -1, currentPlayer, 0)
        //路上遇到老司机带，前进3格
        //Interpreter(4, currentPlayer, 3, -1, currentPlayer, 0, -1, currentPlayer, 0)
    }
}
