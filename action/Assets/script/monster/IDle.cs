using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDle :ISTATe
{
    private Monster monster;
    void ISTATe.OnEnter(Monster monster)
    {
        this.monster = monster;
    }
    void ISTATe.Update()
    {
        


         if(monster.Target != null)
        {
            Debug.Log("RUn");
            monster.SetState(new RUn());
        }
        


        
    }



    void ISTATe.OnExit()
    {

    }
}
