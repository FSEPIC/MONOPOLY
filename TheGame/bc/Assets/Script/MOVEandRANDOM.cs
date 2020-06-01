using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEandRANDOM : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float speed = 10f;
    public bool isp = false;
    public GameObject roll;
    public GameObject button;
    public Animator animator;
    public Vector2 v2;
    // Start is called before the first frame update
    void Start()
    {
        v2 = rb.position;
        v2.Set(v2.x - 3.00f,v2.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Toresult();
    }

    public void pullbutton(){
        isp = true;
    }

    void Move(){
        if(isp){
            button.SetActive(false);
            roll.SetActive(true);
            
        }
    }
    void Toresult(){
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime >= 1.0f){
            animator.SetBool("isONE",true);
            rb.velocity = new Vector2(-1*speed,0);
            if(rb.position == v2){
                rb.velocity = new Vector2(0,0);
                isp = false;
                roll.SetActive(false);
                button.SetActive(true);
            }
        }
    }
}
