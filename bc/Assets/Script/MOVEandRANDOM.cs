using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;
using System;
//完成人：陈威
public class MOVEandRANDOM : MonoBehaviour
{
    public Text Ph1;
    public Text Pm1;
    public Text Pg1;
    public Text Pt1;
    public Text Ph2;
    public Text Pm2;
    public Text Pg2;
    public Text Pt2;
    public Text Ph3;
    public Text Pm3;
    public Text Pg3;
    public Text Pt3;
    public Text Ph4;
    public Text Pm4;
    public Text Pg4;
    public Text Pt4;
    public Text Pn;
    public Text Pm;
    public Text Ph;
    public Text Pg;
    public Text Pe;
    public GameObject finalpanle;
    public GameObject PEE;
    public GameObject cinemachine1;
    public GameObject cinemachine2;
    public GameObject cinemachine3;
    public GameObject cinemachine4;
    public Rigidbody2D P1;
    public Rigidbody2D P2;
    public Rigidbody2D P3;
    public Rigidbody2D P4;
    float speed = 7f;
    bool isp = false;
    public GameObject roll;
    public GameObject button;
    public Animator animator;
    public MapForGame map;
    Vector3 v3;
    int r;
    int[] whichway = new int[4]{1,1,1,1};
    const float DistanceForOne = 2.4f;
    public int MovePlayer;
    // Start is called before the first frame update
    void Start()
    {
        map = new MapForGame(4,60);
        MovePlayer=1;
        Pn.text =  map.p[0].Name;
        Pm.text = Convert.ToString(map.p[0].Money);
        Ph.text = Convert.ToString(map.p[0].Health);
        Pg.text = Convert.ToString(map.p[0].Grade);
    }
    // Update is called once per frame
    void Update()
    {
        end();
        CilekBT();
    }
    // void DetermineXY(int i){
    //     if(map.p[i].Location + r < 9){
    //         v2.Set(v2.x - ( r * Distance ),v2.y);
    //     }else{
    //         v2.Set(v2.x,v2.y + ( r * Distance ));
    //     }
    // }
    Vector3 Gettar(Rigidbody2D player,int po){
        int s = map.p[po].Location;
        Vector3 final = new Vector3(player.position.x,player.position.y,player.transform.localPosition.z);
        for(int i =0;i<r;i++){
            if(9>s){
                whichway[po] = 1;
            }
            if(s<18 && s>=9){
                whichway[po] = 2;
            }
            if(s<27 && s>=18){
                whichway[po] = 3;
            }
            if(s>=27){
                whichway[po] = 4;
            }
            switch(whichway[po]){
                case 1:
                    final.x -= DistanceForOne;
                    break;
                case 2:
                    final.y += DistanceForOne;
                    break;
                case 3:
                    final.x +=DistanceForOne;
                    break;
                case 4:
                    final.y -= DistanceForOne; 
                    break;
            }
            if(s == 35){
                s = 0;
            }
            s++;
        }
        return final;
    }
    public void pullbutton(){
        isp = true;
        r = IndividualEventForGame.rdom(1,6);
        //获取坐标
        switch(MovePlayer){
            case 1:
                v3 = Gettar(P1,0);
                break;
            case 2:
                v3 = Gettar(P2,1);
                break;
            case 3:
                v3 = Gettar(P3,2);
                break;
            case 4:
                v3 = Gettar(P4,3);
                break;
        }
    }

    void CilekBT(){
        if(isp){
            button.SetActive(false);
            roll.SetActive(true);
            Toresult();
        }
    }
    void CMControl(){
        switch(MovePlayer){
            case 1:
                cinemachine1.SetActive(true);
                cinemachine2.SetActive(false);
                cinemachine3.SetActive(false);
                cinemachine4.SetActive(false);
                break;
            case 2:
                cinemachine2.SetActive(true);
                cinemachine1.SetActive(false);
                cinemachine3.SetActive(false);
                cinemachine4.SetActive(false);
                break;
            case 3:
                cinemachine3.SetActive(true);
                cinemachine2.SetActive(false);
                cinemachine1.SetActive(false);
                cinemachine4.SetActive(false);
                break;
            case 4:
                cinemachine4.SetActive(true);
                cinemachine2.SetActive(false);
                cinemachine3.SetActive(false);
                cinemachine1.SetActive(false);
                break;
        }
    }
    void EndMove(){
        String s = null;
        Debug.Log("执行几次？");
        map.LocationUP(r,MovePlayer-1);
        //刷新数据
        isp = false;
        CMControl();
        Debug.Log(MovePlayer);
        s = map.getEvent(MovePlayer-1);
        playerinfo();
        if(s != null){
            PEE.SetActive(true);
            StartCoroutine(changeev(s));
        }
        map.Turns--;
        if(MovePlayer == 4) {MovePlayer = 1;} else {MovePlayer++;}
    }
    void end(){
        if(map.Turns==0){
            finalpanle.SetActive(true);
            final(map);
        }
    }
    void playerinfo(){
        Pn.text = map.p[MovePlayer-1].Name;
        Pm.text = Convert.ToString(map.p[MovePlayer-1].Money);
        Ph.text = Convert.ToString(map.p[MovePlayer-1].Health);
        Pg.text = Convert.ToString(map.p[MovePlayer-1].Grade);
    }
    IEnumerator changeev(String s){
        playerinfo();
        Time.timeScale = 0.5f;
        Pe.text = s;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        PEE.SetActive(false);
    }
    IEnumerator left(Rigidbody2D player,Vector2 final,int step){
        Vector2 To =  new Vector2(player.position.x - DistanceForOne,player.position.y);
        player.velocity = new Vector2(-1*speed,0);
        // while(!(Vector2.Distance(player.position,final)<=1f)){
        // }
        // return;
        Debug.Log(v3);
        yield return new WaitForSeconds(1f);
        if(Vector2.Distance(player.position,To)<=0.1f){
            Debug.Log("已触发");
            player.velocity = new Vector2(0,0);
            if(step == r){
                yield return StartCoroutine(left(P1,final,++step));
            }
            yield return 0;
        }
    }
    // void left(Rigidbody2D player,Vector2 final){
    //     player.velocity = new Vector2(-1*speed,0);
    //     // while(!(Vector2.Distance(player.position,final)<=1f)){
    //     // }
    //     // return;
    //     Debug.Log(v2);
    //     if(Vector2.Distance(player.position,v2)<=0.1f){
    //         Debug.Log("已触发");
    //         player.velocity = new Vector2(0,0);
    //     }
    // }
    bool up(Rigidbody2D player,Vector2 final){
        player.velocity = new Vector2(0,speed);
        if(Vector2.Distance(player.position,final)<=0.1f){
            Debug.Log("已触发");
            player.velocity = new Vector2(0,0);
            return true;
        }
        return false;
    }
    IEnumerator Move(Rigidbody2D player,int po){
        while(player.transform.localPosition != v3){
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition,v3,speed*Time.deltaTime);
            yield return 0;
        }
        // if(plposition[po] < 9 ){
        //     Vector2 final = new Vector2(player.position.x - DistanceForOne,player.position.y);
        //     StartCoroutine(left(P1,final,1));
        //     yield return new WaitForSeconds(0.5f);
        // }
        // if(plposition[po] < 18){
        //     Vector2 final = new Vector2(player.position.x,player.position.y + DistanceForOne);
        //     up(player,final);
        //     yield return new WaitForSeconds(0.5f);
        // }
        
        // EndMove();
        // yield break;
    }
    void WhichMove(){
        switch(MovePlayer){
            case 1:
                Debug.Log("目前没问题");
                // Vector2 final = new Vector2(P1.position.x - DistanceForOne,P1.position.y);
                // StartCoroutine(left(P1,final));
                StartCoroutine(Move(P1,0));
                Debug.Log("会等吗");
                break;
            case 2:
                StartCoroutine(Move(P2,1));
                break;
            case 3:
                StartCoroutine(Move(P3,2));
                break;
            case 4:
                StartCoroutine(Move(P4,3));
                break;
        }
        EndMove();
    }
    void Toresult(){
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime >= 1.0f){
            // isp =false;
            animator.SetInteger("whichresult",r);
            StartCoroutine(DisplayR());
            WhichMove();
        }
    }

    IEnumerator DisplayR(){
        yield return new WaitForSeconds(1f);
        roll.SetActive(false);
        button.SetActive(true);
    }
    void final(MapForGame m){
        Ph1.text = "健康:" + Convert.ToString(m.p[0].Health);
        Pm1.text = "金钱:" + Convert.ToString(m.p[0].Money);
        Pg1.text = "成绩:" + Convert.ToString(m.p[0].Grade);
        Pt1.text = "总成绩：" + Convert.ToString((m.p[0].Health+m.p[0].Money+m.p[0].Grade)/3);
        Ph2.text = "健康:" + Convert.ToString(m.p[1].Health);
        Pm2.text = "金钱:" + Convert.ToString(m.p[1].Money);
        Pg2.text = "成绩:" + Convert.ToString(m.p[1].Grade);
        Pt2.text = "总成绩：" + Convert.ToString((m.p[1].Health+m.p[1].Money+m.p[1].Grade)/3);
        Ph3.text = "健康:" + Convert.ToString(m.p[2].Health);
        Pm3.text = "金钱:" + Convert.ToString(m.p[2].Money);
        Pg3.text = "成绩:" + Convert.ToString(m.p[2].Grade);
        Pt3.text = "总成绩：" + Convert.ToString((m.p[2].Health+m.p[2].Money+m.p[2].Grade)/3);
        Ph4.text = "健康:" + Convert.ToString(m.p[3].Health);
        Pm4.text = "金钱:" + Convert.ToString(m.p[3].Money);
        Pg4.text = "成绩:" + Convert.ToString(m.p[3].Grade);
        Pt4.text = "总成绩：" + Convert.ToString((m.p[3].Health+m.p[3].Money+m.p[3].Grade)/3);
    }
}
//完成人：陈威
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// //完成人：陈威
// public class MOVEandRANDOM : MonoBehaviour
// {
//     public Text Pn;
//     public Rigidbody2D P1;
//     public Rigidbody2D P2;
//     public Rigidbody2D P3;
//     public Rigidbody2D P4;
//     float speed = 6f;
//     bool isp = false;
//     public GameObject roll;
//     public GameObject button;
//     public Animator animator;
//     public MapForGame map;
//     Vector2 v2;
//     int r;
//     public int WhichPlayer;
//     // Start is called before the first frame update
//     void Start()
//     {
//         map = new MapForGame(4,60);
//         WhichPlayer=1;
//         Pn.text = map.p[0].name;
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         CilekBT();
//         Toresult();
//     }

//     public void pullbutton(){
//         isp = true;
//         r = EventForGame.rdom(1,6);
//         switch(WhichPlayer){
//             case 1:
//                 v2 = P1.position;
//                 break;
//             case 2:
//                 v2 = P2.position;
//                 break;
//             case 3:
//                 v2 = P3.position;
//                 break;
//             case 4:
//                 v2 = P4.position;
//                 break;
//         }
//         v2.Set(v2.x - ( r * 1.476f ),v2.y);
//     }

//     void CilekBT(){
//         if(isp){
//             button.SetActive(false);
//             roll.SetActive(true);
//         }
//     }
//     // void Moveleft(Rigidbody2D player){
//     //     player.velocity = new Vector2(-1*speed,0);
//     //     if(Vector2.Distance(player.position,v2)<=0.1f){
//     //         player.velocity = new Vector2(0,0);
//     //         isp = false;
//     //         roll.SetActive(false);
//     //         button.SetActive(true);
//     //         Pn.text = map.p[WhichPlayer].name;
//     //         map.LocationUP(r,WhichPlayer-1);
//     //         // if(WhichPlayer != 4){
//     //         //     WhichPlayer++;
//     //         // }else{
//     //         //     WhichPlayer = 1;
//     //         // }
//     //     }
//     // }
//     void Move(){
//         switch(WhichPlayer){
//             case 1:
//                 P1.velocity = new Vector2(-1*speed,0);
//                 if(Vector2.Distance(P1.position,v2)<=0.1f){
//                     P1.velocity = new Vector2(0,0);
//                     isp = false;
//                     roll.SetActive(false);
//                     button.SetActive(true);
//                     Pn.text = map.p[WhichPlayer].name;
//                     map.LocationUP(r,WhichPlayer-1);
//                     WhichPlayer++;
//                 }
//                 break;
//             case 2:
//                 P2.velocity = new Vector2(-1*speed,0);
//                 if(Vector2.Distance(P2.position,v2)<=0.1f){
//                     P2.velocity = new Vector2(0,0);
//                     isp = false;
//                     roll.SetActive(false);
//                     button.SetActive(true);
//                     Pn.text = map.p[WhichPlayer].name;
//                     map.LocationUP(r,WhichPlayer-1);
//                     WhichPlayer++;
//                 }
//                 break;
//             case 3:
//                 P3.velocity = new Vector2(-1*speed,0);
//                 if(Vector2.Distance(P3.position,v2)<=0.1f){
//                     P3.velocity = new Vector2(0,0);
//                     isp = false;
//                     roll.SetActive(false);
//                     button.SetActive(true);
//                     Pn.text = map.p[WhichPlayer].name;
//                     map.LocationUP(r,WhichPlayer-1);
//                     WhichPlayer++;
//                 }
//                 break;
//             case 4:
//                 P4.velocity = new Vector2(-1*speed,0);
//                 if(Vector2.Distance(P4.position,v2)<=0.1f){
//                     P4.velocity = new Vector2(0,0);
//                     isp = false;
//                     roll.SetActive(false);
//                     button.SetActive(true);
//                     Pn.text = map.p[WhichPlayer].name;
//                     map.LocationUP(r,WhichPlayer-1);
//                     WhichPlayer++;
//                 }
//                 break;
//         }
        
//     }
//     void Toresult(){
//         AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
//         if(info.normalizedTime >= 1.0f){
//             animator.SetInteger("whichresult",r);
//             Move();
//         }
//     }
// }
// //完成人：陈威