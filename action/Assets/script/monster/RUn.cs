using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUn : ISTATe
{
    //public static RUn Instance; 여따가 쓰고 IDle 에서 쓰면 RUn자체가 실행이 안돼서 Instance가 계속 Null이 니까 IDle if문이 실행이 안됨
   // Transform target = null; 
   //public Transform Target /*=> target;*/ //읽기전용 프로퍼티 축약형 //값을 할당 할때는 set 읽어올때는 get
   // {
   //     get => target;
   //     set => target = value;
   // }
    int  speed = 2;
    private Monster monster;
    Collider2D D;
    public RaycastHit2D Hit;
    void ISTATe.OnEnter(Monster monster)
    {
        //Instance = this;
        this.monster = monster;
        D = monster.GetComponent<Collider2D>();


    }
    void ISTATe.Update()
    {
      Hit = Physics2D.Raycast(monster.transform.position, Vector3.forward, 1, LayerMask.GetMask("map"));
        if (monster.Target != null &&  Hit)
        {
            Vector3 dir = monster.Target.position - monster.transform.position;
            monster.transform.Translate(dir.normalized * speed * Time.deltaTime);
        }

        if (Vector3.Distance(monster.Target.position, monster.transform.position) < 3)
        {
            monster.SetState(new ATtack());
        }
    }
    

    void ISTATe.OnExit()
    {

    }
}
