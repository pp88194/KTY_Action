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
        //2d�� �̷��� ���� 3d������ Physics2D hit�־ �� �ֳ��ϸ� ��ȯ�� ����
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
    {//����Ǹ鼭 �����ؾ��Ұ� ����}

    }
}
