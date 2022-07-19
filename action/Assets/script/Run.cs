using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : Istate
{
    private Player player;
    public static Run Instance;
    public float speed = 3;
    Rigidbody2D rid;
    // Start is called before the first frame update



    void Istate.OnEnter(Player player)
    {
        Instance = this;
        this.player = player;
        rid = player.Rigid;
    }

    void Istate.Update()
    {
        Debug.Log("Run Update");
        if (Player.Instance.Hit)
        {
            //transform.position += dir * speed * Time.deltaTime;
            rid.velocity = Player.Instance.Dir * speed; // rid 를 쓸거라서 transform.position을 쓰지 않고 속도에 값을 넣어줘서 실행한다 rid쓰는데  transform.position을 쓰면 인식을 못해 아래로 떨어진다 중력때문에
        }

        if ((rid.velocity.x == 0 && rid.velocity.y == 0))
        {
            player.SetState(new Idle());
            rid.velocity = Vector2.zero;
        }
        if (Input.GetMouseButtonUp(0))
        {
            player.SetState(new Attack());
            rid.velocity = Vector2.zero;
        }
    }


    void Istate.OnExit()
    {//종료되면서 정리해야할것 구현}


    }
}
