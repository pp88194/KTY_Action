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
            rid.velocity = Player.Instance.Dir * speed; // rid �� ���Ŷ� transform.position�� ���� �ʰ� �ӵ��� ���� �־��༭ �����Ѵ� rid���µ�  transform.position�� ���� �ν��� ���� �Ʒ��� �������� �߷¶�����
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
    {//����Ǹ鼭 �����ؾ��Ұ� ����}


    }
}
