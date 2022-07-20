using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Istate
{
    private Player player;

    void Istate.OnEnter(Player Player)
    {
        
        this.player = Player;
    }

    void Istate.Update()
    {
        //2d면 이렇게 쓰고 3d에서만 Physics2D hit넣어서 함 왜냐하면 반환형 때문
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            player.SetState(new Run());
        }
        if(Input.GetMouseButtonDown(0))
        {
            player.SetState(new Attack());
        }
        //Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //if (dir != Vector3.zero)
        //    Player.SetState(new run());
    }


    void Istate.OnExit()
    {//종료되면서 정리해야할것 구현}

    }
}
