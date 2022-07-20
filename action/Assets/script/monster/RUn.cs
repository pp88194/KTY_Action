using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUn : ISTATe
{
    //public static RUn Instance; ������ ���� IDle ���� ���� RUn��ü�� ������ �ȵż� Instance�� ��� Null�� �ϱ� IDle if���� ������ �ȵ�
   // Transform target = null; 
   //public Transform Target /*=> target;*/ //�б����� ������Ƽ ����� //���� �Ҵ� �Ҷ��� set �о�ö��� get
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
