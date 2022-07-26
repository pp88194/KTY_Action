using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : ISTATe
{
   
    private Monster monster;

    void ISTATe.OnEnter(Monster monster)
    {

        this.monster = monster;
    }
        
    void ISTATe.Update()
    {
        
    }



    void ISTATe.OnExit()
    {

    }
}
