using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventForGame : MonoBehaviour
{
    //事件格子
    //完成人：徐明睿
        public void doEvent(MapForGame m, int i)
        {
            int n = m.GetLocation(i);//n是格子号
            switch (n)
            {
                case 4:
                    SelfEvent(m, i);
                    break;
                case 8:
                    SelfEvent(m, i);
                    break;
                case 13:
                    AllEvent(m);
                    break;
                case 20:
                    SelfEvent(m, i);
                    break;
                case 25:
                    SelfEvent(m, i);
                    break;
                case 29:
                    SelfEvent(m, i);
                    break;
                case 34:
                    SelfEvent(m, i);
                    break;
                case 36:
                    SelfEvent(m, i);
                    break;
                default:
                    //
                    break;
            }
        }
        //个人事件卡池
        public void SelfEvent(MapForGame m, int i)
        {
            System.Random random = new System.Random();
            int n = random.Next(1, 6);
            switch (n)
            {
                case 1:
                    Event1(m, i);
                    break;
                case 2:
                    Event2(m, i);
                    break;
                case 3:
                    Event3(m, i);
                    break;
                case 4:
                    Event4(m, i);
                    break;
                case 5:
                    Event5(m, i);
                    break;
                case 6:
                    Event6(m, i);
                    break;
                default:
                    break;
            }
        }
        //公共事件卡池
        public void AllEvent(MapForGame m)
        {
            System.Random random = new System.Random();
            int n = random.Next(1, 5);
            switch (n)
            {
                case 1:
                    allEvent2(m);
                    break;
                case 2:
                    allEvent1(m);
                    break;
                case 3:
                    allEvent3(m);
                    break;
                case 4:
                    allEvent4(m);
                    break;
                case 5:
                    allEvent5(m);
                    break;
                default:
                    break;
            }
        }
//完成人：徐明睿
//完成人：王浩欢
        //个人事件
        static void Event1(MapForGame m, int i)
        {
            //Console.WriteLine("获得事件：路上遇到老司机带，逮虾户，加3步");
            m.LocationUP(3, i);
        }
        static void Event2(MapForGame m, int i)
        {
            //Console.WriteLine("获得事件：喝下昏睡红茶，暂停1回合");
            m.p[i].Turn += -1;
        }
        static void Event3(MapForGame m, int i)
        {
            //Console.WriteLine("获得事件：路上捡到钱，金钱加300");
            m.p[i].Money += 300;
        }
        static void Event4(MapForGame m, int i)
        {
            //Console.WriteLine("获得事件：换上感冒，健康-5，金钱-100");
            m.p[i].Health += -5;
            m.p[i].Money += -100;
        }
        static void Event5(MapForGame m, int i)
        {
           // Console.WriteLine("获得事件：被同学拖去健身，健康+10，金钱-500");
            m.p[i].Health += 10;
            m.p[i].Money += -500;
        }
        static void Event6(MapForGame m, int i)
        {
            //Console.WriteLine("获得事件：沉迷网游，无法自拔，健康-5，成绩-25");
            m.p[i].Health += -5;
            m.p[i].Grade += -25;
        }
//完成人：王浩欢
//完成人：闫顺兴
        //公共事件
        public void allEvent1(MapForGame m)     //所有玩家后退两个格子
        {
            //Console.WriteLine("获得事件：选课系统崩溃，集体选课失败，服务器退档");
            for (int i = 0; i < m.PlayerNum; i++)
            {
                if (m.p[i].Health > 0)
                {
                    m.p[i].Location = (m.p[i].Location - 2) % 36;
                }
            }
        }
        public void allEvent2(MapForGame m)     //所有玩家健康值降低10点
        {
            //Console.WriteLine("获得事件：食堂吃出奥力给，集体拉肚子");
            for (int i = 0; i < m.PlayerNum; i++)
            {
                if (m.p[i].Health > 0)
                {
                    if (m.p[i].Health > 10)
                    {
                        m.p[i].Health = m.p[i].Health - 10;
                    }
                    else
                    {
                        m.p[i].Health = 0;      //当玩家健康值不高于10点时，最终结果为0
                    }
                }
            }
        }
        public void allEvent3(MapForGame m)    //根据成绩排名对玩家进行奖励与惩罚
        {
            //Console.WriteLine("获得事件：学院对学生的成绩进行奖励");
            for (int i = 0; i < m.PlayerNum; i++)
            {
                if (m.p[i].Health > 0)
                {
                    if (m.p[i].Grade >= 680)       //玩家成绩不低于680时，前进5格，并且奖励金钱100
                    {
                        m.p[i].Location += 5;
                        m.p[i].Money += 100;
                    }
                    else if (m.p[i].Grade >= 600)     //玩家成绩不低于600时，前进2格，奖励金钱50
                    {
                        m.p[i].Location += 3;
                        m.p[i].Money += 50;
                    }
                    else if (m.p[i].Grade >= 524)     //玩家成绩不低于524时，前进1格
                    {
                        m.p[i].Location += 1;
                    }
                    else                               //玩家成绩低于524时，后退1格
                    {
                        m.p[i].Location -= 2;
                    }
                }
            }
        }
        public void allEvent4(MapForGame m)     //考试之后，所有玩家的成绩增加50
        {
            //Console.WriteLine("获得事件：期末大考");
            for (int i = 0; i < m.PlayerNum; i++)
            {
                if (m.p[i].Health > 0)
                {
                    m.p[i].Grade += 50;
                    if (m.p[i].Grade > 750)    //如果考试之后玩家成绩超过750分，则修改为750分
                    {
                        m.p[i].Grade = 750;
                    }
                }
            }
        }
        public void allEvent5(MapForGame m)       //体检之后，玩家健康值提升20点
        {
            //Console.WriteLine("获得事件：漂亮的护士小姐姐来体检");
            for (int i = 0; i < m.PlayerNum; i++)
            {
                if (m.p[i].Health > 0)
                {
                    m.p[i].Health += 20;
                    if (m.p[i].Health > 100)     //如果体检之后玩家健康值超过100点，则修改为100点
                    {
                        m.p[i].Health = 100;
                    }
                }
            }
        }
//完成人：闫顺兴
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
