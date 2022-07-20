using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Istate
{
    Animator ani;
    private Player player;
    void Istate.OnEnter(Player player)
    {
        this.player = player;
        ani = player.Ani;
        player.StartCoroutine(A());
    }
    void Istate.Update()
    {

    }
    void Istate.OnExit()
    {//����Ǹ鼭 �����ؾ��Ұ� ����}


    }


    IEnumerator A()
    {
        
        ani.SetBool("isattack", true);
        //Run.Instance.speed = 0;
        yield return new WaitForSeconds(0.5f);
        ani.SetBool("isattack", false);
        player.SetState(new Idle());
    }
}
