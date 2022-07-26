using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ATtack : ISTATe
{
   
    int random;
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
        random = Random.Range(1, 4);
        if (random == 1)
        {
            ani.SetBool("isAttack", true);
            //Run.Instance.speed = 0;
            yield return new WaitForSeconds(1f);
            ani.SetBool("isAttack", false);
            monster.SetState(new IDle());
        }
       else if(random == 2)
        {
            ani.SetBool("isAttack2", true);
            //Run.Instance.speed = 0;
            yield return new WaitForSeconds(1f);
            ani.SetBool("isAttack2", false);
            monster.SetState(new IDle());
        }
       else if(random == 3)
        {
            ani.SetBool("isAttack3", true);
            //Run.Instance.speed = 0;
            yield return new WaitForSeconds(1f);
            ani.SetBool("isAttack3", false);
            monster.SetState(new IDle());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Debug.Log("die");
        }
    }

}
