using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//完成人:闫顺兴
public class PlayerForGame : MonoBehaviour
{
    public string Name { set; get; } //玩家姓名
    public int Id { set; get; }      //玩家编号
    public int Location { set; get; }//位置
    public int Pause{set;get;}//是否暂停
    public int Money { set; get; }   //金钱
    public int Health { set; get; }  //健康值，最大值为100
    public int Grade { set; get; }   //成绩，最大值为750
    public PlayerForGame(int i)
    {
        Id = i;
        Name = "玩家"+(i+1);
        Location = 0;
        Health = 100;
        Money = 500;
    }
    public string property() {
        return Name + "\n到达位置" + Location  + "\n成绩" + Grade + "\n健康值" + Health + "\n剩余金钱" + Money ;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//结束