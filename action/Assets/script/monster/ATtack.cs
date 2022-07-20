using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATtack : ISTATe
{
    private Monster monster;
    Animator ani;
    void ISTATe.OnEnter(Monster monster)
    {
        ani = monster.Ani;
        this.monster = monster;
        monster.StartCoroutine(A());
    }
    void ISTATe.Update()
    {

    }



    void ISTATe.OnExit()
    {

    }

    IEnumerator A()
    {

        ani.SetBool("isAttack", true);
        //Run.Instance.speed = 0;
        yield return new WaitForSeconds(1f);
        ani.SetBool("isAttack", false);
        monster.SetState(new IDle());
    }



}
