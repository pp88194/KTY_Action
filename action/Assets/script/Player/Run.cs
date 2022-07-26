using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : Istate
{
    private Player player;
    public static Run Instance;
    public float speed = 3;
    Rigidbody2D rid;
    int cnt = 0;
    GameObject gam;
    // Start is called before the first frame update



    void Istate.OnEnter(Player player)
    {
        Instance = this;
        this.player = player;
        rid = player.Rigid;
    }

    void Istate.Update()
    {
        if (player.Hit)
        {
            //transform.position += dir * speed * Time.deltaTime;
            rid.velocity = player.Dir * speed; // rid 를 쓸거라서 transform.position을 쓰지 않고 속도에 값을 넣어줘서 실행한다 rid쓰는데  transform.position을 쓰면 인식을 못해 아래로 떨어진다 중력때문에
           
        }
        else
            rid.velocity =Vector2.zero; // rid 를 쓸거라서 transform.position을 쓰지 않고 속도에 값을 넣어줘서 실행한다 rid쓰는데  transform.position을 쓰면 인식을 못해 아래로 떨어진다 중력때문에

        if ((rid.velocity.x == 0 && rid.velocity.y == 0))
        {
            player.SetState(new Idle());
            rid.velocity = Vector2.zero; //이렇게 안하면 달리다가 공격할때  Attack에서 Idle로 바뀌는데 오류가 생겨서 계속 움직이기때문에  상태가 변환될때 움직을 멈추는 코드를 짜서 계속 움직이지 못하게 한다
        }
        if (Input.GetMouseButtonUp(0))
        {
            player.SetState(new Attack());
            rid.velocity = Vector2.zero; //이렇게 안하면 달리다가 공격할때  Attack에서 Idle로 바뀌는데 오류가 생겨서 계속 움직이기때문에  상태가 변환될때 움직을 멈추는 코드를 짜서 계속 움직이지 못하게 한다
        }
        
    }


   
    void Istate.OnExit()
    {//종료되면서 정리해야할것 구현}


    }
}
