using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    //fsm�� �� �������� ���¸� ����� ������ ���±۳��� ������ �ȵ��־  ���µ鳢�� ������ ����� ��찡 ���� �ٵ� ���¿� �̱����� �Ἥ �ٸ� ���·� �ҷ�����
    //���µ鳢�� ������ �Ǳ� ������ fsm�� ������ ������� �׷��� �Ҽ� ������ ��ӹް� �ִ� Monster ���� �Ϳ��� �޾ƿ��°� ����� �ȹ޾� ���°� ����.
    private ISTATe CurrentState;
    public static Monster Instance;
    Transform target = null;
    public Transform Target /*=> target;*/ //�б����� ������Ƽ ����� //���� �Ҵ� �Ҷ��� set �о�ö��� get
    {
        get => target;
        set => target = value;
    }
    Collider2D D;
    Animator ani;
    public Animator Ani => ani;
    RaycastHit2D hit;
    SpriteRenderer sprite;
    Rigidbody2D rid;
   public  Rigidbody2D Rid => rid;
    void Start()
    {
        Instance = this;
        SetState(new IDle());
        D = GetComponent<Collider2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.Update();
        CharacterState();
    }

    public void SetState(ISTATe nextState)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = nextState;
        CurrentState.OnEnter(this);
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") //player�����ϸ� target�� player��ġ�� �־��ְ�  monster�� �����̴� ����� true���ش�
        {
            target = col.gameObject.transform;
            ani.SetBool("isRun", true);
        }


    }

    private void OnTriggerExit2D(Collider2D col)
    {
            ani.SetBool("isRun", false);
        target = null;
    }


    void CharacterState()
    {
            sprite.flipX = Player.Instance.transform.position.x < transform.position.x;
    }

}
